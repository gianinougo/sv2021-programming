// Reto 1.02
// Muestra en líneas diferentes cada número > 0 y < 1000 en base 1
// Javier (...)


using System;

class NumerosBase1
{
    static void Main()
    {
        int num;
        
        do
        {
            num=Convert.ToInt32(Console.ReadLine());
            
            if (num > 0)
            {
                for (int i = 0; i < num; i++)
                    Console.Write("1");
                Console.WriteLine();
            }
        }
        while (num!=0);
    }
}
            
