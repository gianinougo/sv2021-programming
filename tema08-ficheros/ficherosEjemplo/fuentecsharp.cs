using System;
public class DivideTwoNumbers
{
    public static void Main()
    {
        int number1, number2;
        
        Console.Write("Enter the first number:");
        number1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the second number:");
        number2 = Convert.ToInt32(Console.ReadLine());
        
        if (number2 != 0)
        {
            Console.WriteLine("The result for {0} / {1} is {2}", number1, 
                                number2, number1/number2);
        }
        else
            Console.WriteLine("Cannot be divided");
        for (int i=1; i<4; i++)
            Console.WriteLine("Bye!"); 
    }
}
