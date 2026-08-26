using Task20_YieldRecordsTopLevelNullHandling;

var lines = Pipeline.Read("data.csv");
var filtered = Pipeline.Filter(lines);
var employees = Pipeline.Transform(filtered);
var summaries = Pipeline.Select(employees, DateTime.Today);

Console.WriteLine("Before loop");

foreach (var s in summaries)
{
    Console.WriteLine(s);
}