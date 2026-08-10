using System;

public class Program
{
    private static void Main(string[] args)
    {
        Company company = new Company();

        Company.Department hr = company.CreateDepartment("HR", 75000m);
        Company.Department it = company.CreateDepartment("IT", 120000m);

        Console.Write("Company budget (read from inside Department): ");
        hr.ShowBudget();

        Console.WriteLine("--- All department budgets ---");
        company.ShowAllDepartmentBudgets();
    }
}