// Ejercicio 5:
// Calcula el resultado de (48 + 14 / 5 + 15 * 6 ) % 9 
//      y comprueba el resultado a mano
// Javier (...)

using System;

class Operacion
{
    static void Main()
    {
        int x;

        x = (48 + 14 / 5 + 15 * 6) % 9;

        Console.WriteLine("Resultado según C# : {0}", x);
        Console.WriteLine("Resultado a mano :");
        Console.WriteLine("  (48 + 2 + 90) % 9");
        Console.WriteLine("  140 % 9");
        Console.WriteLine("  5");
    }
}
