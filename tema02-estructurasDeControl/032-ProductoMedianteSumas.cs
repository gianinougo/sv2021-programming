/*
    Crea un programa que pida al usuario 
    dos números enteros y muestre su producto, 
    empleando sumas repetitivas. Recuerda que 
    3 * 4 = 3 + 3 + 3 + 3 (es decir, 4 sumandos) = 12.
*/

// Franco (...)

using System;

class ProductoDosNumeros 
{
    static void Main () 
    {
        int num1, num2, resultado;

        Console.Write("Introduce un número entero: ");
        num1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Introduce otro número entero: ");
        num2 = Convert.ToInt32(Console.ReadLine());

        resultado = 0;

        for (int i = 1; i <= num1; i++) 
        {
            resultado = resultado + num2;
        }

        Console.Write("Su producto es: {0}", resultado);
    }
}
