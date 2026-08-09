
class Program
{
    static void Main(string[] args)
    { // done 1
      //double? input = null;
      //Console.WriteLine("Student Grade Checker  ");
      //Console.WriteLine("-------------------------------------");

        //while (true) 
        //{
        //    Console.Write("Enter your grade (Max:4 , Min: 0) : ");
        //    try
        //    {
        //        if (!double.TryParse(Console.ReadLine(), out double value))
        //        {
        //            Console.WriteLine("write wrong input value");
        //            continue;
        //        }
        //        input = value;
        //        if (input > 4 || input < 0)
        //        {
        //            Console.WriteLine("Out of range , try again");

        //        }
        //        else
        //        {
        //            break;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("write wrong input value");
        //    }
        //}





        //if (input >= 3.65 && input <= 4)   
        //{
        //    Console.WriteLine("your grade is Excellent");
        //}
        //else if (input >= 3.00 && input <3.65)
        //{
        //    Console.WriteLine("your grade is veryGood");
        //}
        //else if (input >= 2.50 && input < 3.00)
        //{
        //    Console.WriteLine("your grade is good");
        //}
        //else if (input >= 2.00 && input < 2.50 )
        //{
        //    Console.WriteLine("your grade is Fair");
        //}
        //else if (input < 2)
        //{
        //    Console.WriteLine("your grade is fail");
        //}
        // 2

        int[] value_int = [10];
        value_int = [1, 2, 4, 5, 6, 7, 90, 6, 554, -33];
        int? max = value_int[0];
        for (int i = 0; i < value_int.Length; i++)
        {
            if (value_int[i] > max) { max = value_int[i]; }

        }
        Console.WriteLine(max);


    }


}