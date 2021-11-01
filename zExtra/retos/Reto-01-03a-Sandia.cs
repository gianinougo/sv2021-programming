/*
 * VIRGINIA (...)
 * 
 * La sandía (Codeforces 4A)
 * (¿Se puede partir una sandía de modo que ambos trozos sean enteros
 * y pares?)
 * 
 */

using System;

class Reto1_03
{
    static void Main()
    {
        byte peso = Convert.ToByte(Console.ReadLine());

        if (peso % 2 == 0 && peso!=2)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}
