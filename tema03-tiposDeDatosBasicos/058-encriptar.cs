/*
 * VIRGINIA (...)
 *
 * 58. Crea un programa en C# que pida al usuario una cadena y la muestre
 * encriptada de dos maneras diferentes: primero sumando 1 a cada carácter,
 * luego con la operación XOR 1.
 */

using System;

class Ejercicio58
{
    static void Main()
    {
        Console.Write("Cadena?: ");
        string cadena = Console.ReadLine();
        string cadenaEncriptada1 = "", cadenaEncriptada2 = "";

        // Sumamos 1 a cada letra
        foreach(char letra in cadena)
        {
            cadenaEncriptada1 += (char) (letra + 1);
        }
        Console.WriteLine(cadenaEncriptada1);
        // Y desencriptamos
        foreach(char letra in cadenaEncriptada1)
        {
            Console.Write( (char) (letra - 1) );
        }
        Console.WriteLine();

        // Encriptamos con la suma exclusiva:
        foreach (char letra in cadena)
        {
            cadenaEncriptada2 += (char) (letra ^ 1);
        }
        Console.WriteLine(cadenaEncriptada2);
        // Y desencriptamos nuevamente
        foreach(char letra in cadenaEncriptada2)
        {
            Console.Write( (char) (letra ^ 1) );
        }
        Console.WriteLine();
    }
}
