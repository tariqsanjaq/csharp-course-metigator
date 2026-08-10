using System;
using System.Collections.Generic;

public class Company
{
    private decimal _confidentialBudget = 500000m;          // Department can read this
    private readonly List<Department> _departments = new List<Department>();

    // Company builds its own departments so 'this' can be passed in
    public Department CreateDepartment(string name, decimal budget)
    {
        Department d = new Department(this, name, budget);
        _departments.Add(d);
        return d;
    }

    public void ShowAllDepartmentBudgets()
    {
        foreach (Department d in _departments)
        {
            // Must use the property — d._internalBudget would be CS0122
            Console.WriteLine($"{d.Name}: {d.InternalBudget}");
        }
    }

    public class Department
    {
        // No implicit outer instance in C# — must be passed explicitly
        private readonly Company _company;
        private readonly string _name;
        private readonly decimal _internalBudget;

        public string Name => _name;
        public decimal InternalBudget => _internalBudget;   // Company can't see the field

        public Department(Company company, string name, decimal budget)
        {
            _company = company;
            _name = name;
            _internalBudget = budget;
        }

        public void ShowBudget()
        {
            Console.WriteLine(_company._confidentialBudget);  // reads Company's private field
        }
    }
}