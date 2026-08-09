using System;

class Program
{
    public static void Main(string[] args)
    {
        int v1 = default(int);
        double v2 = default(double);
        float v3 = default(float);
        decimal v4 = default(decimal);
        char v5 = default(char);
        string v6 = default(string);
        bool v7 = default(bool);
        byte v8 = default(byte);
        long v9 = default(long);




        Console.WriteLine($"default value of int : {v1}   and min value: {int.MinValue} , maxvalue: {int.MaxValue}");
        Console.WriteLine($"default value of double :{v2} and min value: {double.MinValue}, maxvalue: {double.MaxValue}");
        Console.WriteLine($"default value of float :{v3}  and min value: {float.MinValue}, maxvalue: {float.MaxValue}");
        Console.WriteLine($"default value of decimal :{v4}  and min value: {decimal.MinValue}, maxvalue: {decimal.MaxValue}");
        Console.WriteLine($"default value of char :{v5}  and min value {char.MinValue} maxvalue: {char.MaxValue}");
        Console.WriteLine($"default value of string :{v6}");
        Console.WriteLine($"default value of bool :{v7}");
        Console.WriteLine($"default value of byte:{v8}  and min value: {byte.MinValue} maxvalue: {byte.MaxValue}");
        Console.WriteLine($"default value of long:{v9}  and min value: {long.MinValue} maxvalue: {long.MaxValue}");




    }
}