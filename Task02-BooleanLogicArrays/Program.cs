
class Program
{
    static void Main(string[] args)
    { // done 1
        double? input = null;
        Console.WriteLine("Student Grade Checker  ");
        Console.WriteLine("-------------------------------------");

        while (true)
        {
            Console.Write("Enter your grade (Max:4 , Min: 0) : ");
            try
            {
                if (!double.TryParse(Console.ReadLine(), out double value))
                {
                    Console.WriteLine("write wrong input value");
                    continue;
                }
                input = value;
                if (input > 4 || input < 0)
                {
                    Console.WriteLine("Out of range , try again");

                }
                else
                {
                    break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("write wrong input value");
            }
        }





        if (input >= 3.65 && input <= 4)
        {
            Console.WriteLine("your grade is Excellent");
        }
        else if (input >= 3.00 && input < 3.65)
        {
            Console.WriteLine("your grade is veryGood");
        }
        else if (input >= 2.50 && input < 3.00)
        {
            Console.WriteLine("your grade is good");
        }
        else if (input >= 2.00 && input < 2.50)
        {
            Console.WriteLine("your grade is Fair");
        }
        else if (input < 2)
        {
            Console.WriteLine("your grade is fail");
        }
        // 2
        Console.WriteLine("\n \n \nfind the max, find the min, calculate the average, reverse the array, and sort it ");
        Console.WriteLine("---------------------------------------------------------");

        int[] value_int = [10];
        value_int = [2, 1, 4, 5, 6, 7, 90, 6, 54, 33];
        int[] value_int_reverse = new int[value_int.Length];
        int max = value_int[0];
        int min = value_int[0];
        int avg = 0;

        Console.Write("[");
        foreach (int num in value_int)
        {
            Console.Write(num + ",");
        }
        Console.Write("]");

        // Pass 1: max, min, avg, reverse — all based on the ORIGINAL order
        for (int i = 0; i < value_int.Length; i++)
        {
            if (value_int[i] > max) { max = value_int[i]; }
            if (value_int[i] < min) { min = value_int[i]; }
            avg += value_int[i];
            value_int_reverse[i] = value_int[value_int.Length - 1 - i];
        }

        Console.WriteLine();
        Console.WriteLine($"\nthis is the maxValue of array: {max}");
        Console.WriteLine($"\nthis is the minValue of array: {min}");
        Console.WriteLine($"\nthis is the average Value of array: {avg / value_int.Length}");
        Console.Write("\n[");
        foreach (int num in value_int_reverse)
        {
            Console.Write(num + ",");
        }
        Console.WriteLine("]");

        // Pass 2: sort — separate job, done last
        for (int i = 0; i < value_int.Length - 1; i++)
        {
            for (int j = 0; j < value_int.Length - 1 - i; j++)
            {
                if (value_int[j] > value_int[j + 1])
                {
                    int temp = value_int[j];
                    value_int[j] = value_int[j + 1];
                    value_int[j + 1] = temp;
                }
            }
        }

        Console.Write("\nsorted: [");
        foreach (int num in value_int)
        {
            Console.Write(num + ",");
        }
        Console.WriteLine("]");

    }


}