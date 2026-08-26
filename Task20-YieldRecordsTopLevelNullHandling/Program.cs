using Task20_YieldRecordsTopLevelNullHandling;

var lines = Pipeline.Read("data.csv");
var filtered = Pipeline.Filter(lines);
var employees = Pipeline.Transform(filtered);

DateTime asOf = new DateTime(2026, 8, 26);
var summaries = Pipeline.Select(employees, asOf);

List<EmployeeSummary> summaryList = summaries.ToList();

Console.WriteLine("=== Employee Summaries ===");
for (int i = 0; i < summaryList.Count; i++)
{
    var s = summaryList[i];
    Console.WriteLine(
        $"[{i}] {s.EmployeeId,-6} {s.Department,-12} " +
        $"Salary: {s.Salary,10:C}  Bonus: {(s.Bonus.HasValue ? s.Bonus.Value.ToString("C") : "none"),8}  " +
        $"TotalComp: {s.TotalCompensation,10:C}  YearsOfService: {s.YearsOfService}"
    );
}

// Value equality: records compare by value, not reference.
// summaryList[1] is the first E1002 row's summary; summaryList[^1] is the
// duplicate E1002 row's summary — two separately-parsed instances, but
// every field matches, so == is true.
Console.WriteLine();
Console.WriteLine("=== Value Equality ===");
Console.WriteLine($"[1]  {summaryList[1]}");
Console.WriteLine($"[^1] {summaryList[^1]}");
Console.WriteLine($"summaryList[1] == summaryList[^1] : {summaryList[1] == summaryList[^1]}");

// with: a raise produces a new EmployeeSummary. TotalCompensation is a
// derived property, not a stored field, so it recomputes automatically
// from the new Salary — nothing here recalculates it by hand.
Console.WriteLine();
Console.WriteLine("=== 'with' Expression: Raise ===");
Console.WriteLine($"Before: {summaryList[0]}");
EmployeeSummary raised = summaryList[0] with { Salary = summaryList[0].Salary + 5000 };
Console.WriteLine($"After:  {raised}");