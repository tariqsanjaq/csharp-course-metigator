using System;
using System.Collections.Generic;
using System.Text;

namespace Task20_YieldRecordsTopLevelNullHandling
{
    /// <summary>
    /// A four-stage lazy pipeline that reads, filters, transforms, and
    /// projects employee records from a CSV file, one stage per method.
    /// </summary>
    public class Pipeline
    {
        /// <summary>
        /// Lazily reads a text file line by line without loading it entirely into memory.
        /// </summary>
        /// <param name="filepath">Path to the file to read.</param>
        /// <returns>Each line of the file, yielded one at a time as enumeration proceeds.</returns>
        public static IEnumerable<string> Read(string filepath)
        {
            using (StreamReader sr = new StreamReader(filepath))
            {
                while (!sr.EndOfStream)
                {
                    yield return sr.ReadLine()!;
                }
            }
        }

        /// <summary>
        /// Drops lines that cannot possibly become an <see cref="Employee"/>
        /// without parsing any field value: blank lines, the header line,
        /// and lines with fewer than 5 comma-separated columns. Whether an
        /// individual field's value parses (a bad number, a bad date) is
        /// not checked here — that is Transform's job, since answering it
        /// requires parsing the field.
        /// </summary>
        /// <param name="lines">Raw lines, typically from <see cref="Read"/>.</param>
        /// <returns>Only the lines that are structurally eligible to become an <see cref="Employee"/>.</returns>
        public static IEnumerable<string> Filter(IEnumerable<string> lines)
        {
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split(',');
                if (parts[0] == "EmployeeId") continue;
                if (parts.Length < 5) continue;

                yield return line;
            }
        }

        /// <summary>
        /// Parses each filtered line into an <see cref="Employee"/>. A line
        /// is dropped, not defaulted, if EmployeeId is blank or Salary or
        /// HireDate fails to parse. Department is coalesced to "Unassigned"
        /// when blank. Bonus is optional: a value that fails to parse is
        /// treated as absent (null), not as a fatal error for the row.
        /// </summary>
        /// <param name="lines">Structurally valid lines, typically from <see cref="Filter"/>.</param>
        /// <returns>One <see cref="Employee"/> per line that parses successfully; failing lines are omitted, not yielded as anything.</returns>
        public static IEnumerable<Employee> Transform(IEnumerable<string> lines)
        {
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                string employeeId = parts[0];
                if (string.IsNullOrWhiteSpace(employeeId))
                {
                    continue; // فشل — نتجاهل السطر كامل
                }
                string department = parts[1].Trim();
                if (string.IsNullOrWhiteSpace(department))
                {
                    department = "Unassigned";
                }
                string salary = parts[2];
                if (!decimal.TryParse(salary, out decimal salaryDec))
                {
                    continue;
                }
                string hireData = parts[3];
                if (!DateTime.TryParse(hireData, out var hiredata))
                {
                    continue;
                }
                string bonusRaw = parts[4];
                decimal? bonus;
                if (!decimal.TryParse(bonusRaw, out decimal parsedBonus))
                {
                    bonus = null;
                }
                else
                {
                    bonus = parsedBonus;
                }
                yield return new Employee(employeeId, department, salaryDec, hiredata, bonus);
            }
        }

        /// <summary>
        /// Projects each <see cref="Employee"/> into an <see cref="EmployeeSummary"/>
        /// as of a single, caller-supplied reference date, so every summary
        /// in the same run is comparable against the same point in time.
        /// </summary>
        /// <param name="employees">Employees, typically from <see cref="Transform"/>.</param>
        /// <param name="asOf">The reference date used to compute each summary's YearsOfService.</param>
        /// <returns>One <see cref="EmployeeSummary"/> per input <see cref="Employee"/>, in the same order.</returns>
        public static IEnumerable<EmployeeSummary> Select(IEnumerable<Employee> employees, DateTime asOf)
        {
            foreach (Employee employee in employees)
            {
                yield return EmployeeSummary.From(employee, asOf);
            }
        }
    }
}