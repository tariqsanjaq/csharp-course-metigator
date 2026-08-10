using System;

class Program
{
    static void Main(string[] args)
    {
        Employee employee = new Employee();
        Employee employee2 = new Employee(employee);
        Employee employee3 = new Employee(12,"tariq","tariq@gmail.com",2000);

        Console.WriteLine($"e1: {employee},\ne1: {employee2},\ne1: {employee3}");
    }
}