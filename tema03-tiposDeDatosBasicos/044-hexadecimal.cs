//44. Programa que muestre todos los números entre ellos,en hexadecimal.
//Rocio (...)

using System;

class Hexadecimal44
{
    static void Main()
    {
        Console.Write("Introduce un numero: ");
        byte primero = Convert.ToByte(Console.ReadLine());
        Console.Write("Introduce otro numero: ");
        byte segundo = Convert.ToByte(Console.ReadLine());

        if (segundo <= primero)
        {
            byte menor = segundo;
            segundo = primero;
            primero = menor;
        }

        for (int i = primero; i <= segundo; i++)
        {
            Console.Write(Convert.ToString(i, 16));
            Console.Write(" ");
        }
    }
}
