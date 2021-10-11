/*20. Escribe un programa en C# que pida al usuario un número entero y muestre 
su tabla de multiplicar, usando "while".*/

// Carlos Manuel (...)
// 04/10/2021.

using System;

class Ejercicio_20
{
    static void Main()
    {
        int numero;
        int i = 0;

        Console.Write("Escribe un numero entero: ");
        numero = Convert.ToInt32(Console.ReadLine());

        while (i <= 10)
        {
            Console.WriteLine("{0} x {1} = {2}", numero, i, numero*i);
            i = i + 1;
        }
    }
}
