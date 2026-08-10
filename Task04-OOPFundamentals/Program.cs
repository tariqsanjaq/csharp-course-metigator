using System;

class Program
{
    static void Main(string[] args)
    {
        //1
        Employee employee = new Employee();
        Employee employee2 = new Employee(employee);
        Employee employee3 = new Employee(12,"tariq", "tariq@BestDev.com", 2000);

        Console.WriteLine($"e1: {employee},\ne1: {employee2},\ne1: {employee3}");


        //2
        Employee e = new Employee(1, "Tariq", "tariq@BestDev.com", 3000);
        e.AddSkill("C#");
        e.AddSkill("SQL");
        Console.WriteLine(e[0]); // should print "C#"
        e[0] = "Python";
        Console.WriteLine(e[0]); // should print "Python"
    }
}