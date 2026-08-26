using System;
using System.Collections.Generic;
using System.Text;

namespace Task20_YieldRecordsTopLevelNullHandling
{
    public class Pipeline
    {
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
                string department = parts[1];
                if (string.IsNullOrWhiteSpace(department))
                {
                    department = "Unassigned";
                }
                string salary = parts[2];
                if (!decimal.TryParse(salary,out decimal salaryDec))
                {
                    continue;
                }
                string hireData = parts[3];
                if (!DateTime.TryParse(hireData , out var hiredata))
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
        public static IEnumerable<EmployeeSummary> Select(IEnumerable<Employee> employees, DateTime asOf)
        {
            foreach (Employee employee in employees)
            {
                yield return EmployeeSummary.From(employee, asOf);
            }
        }
    }
}
