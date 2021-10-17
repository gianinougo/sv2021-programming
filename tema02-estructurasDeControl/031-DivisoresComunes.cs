/*31 Escribe un programa que le pida al usuario dos números y muestre sus divisores 
comunes (excepto el 1), o el texto "Ninguno"*/
//Rocio (...)
using System;

class Divisores31
{
    static void Main()
    {
        Console.Write("Introduce un número: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Introduce otro número: ");
        int b = Convert.ToInt32(Console.ReadLine());
        
        int valorMaximo = 0;
        int divisoresEncontrados=0;
       
        if (a <= b)
        {
            valorMaximo = b;
        }
        else
        {
            valorMaximo = a;
        }
        Console.Write("Sus divisores comunes son: ");
        
        for (int i = 2; i <= valorMaximo; i++)
        {
            if ((a % i == 0) && (b % i == 0))
            {
                Console.Write("{0} ", i);
                divisoresEncontrados++;
            }
        }
        
        if (divisoresEncontrados == 0)
        {
            Console.WriteLine("Ninguno");
        }
    }
}

