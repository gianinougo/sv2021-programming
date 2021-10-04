// JOSE (...)
/* 9. Crea un programa en C# que pida al usuario un número entero y responda si 
 * es un número positivo, negativo o cero, usando "if" y "else".
 */
 
using System;

class Ejer_02_09
{
    static void Main()
    {
        int numero;
        
        Console.Write("Introduce un número: ");
        numero = Convert.ToInt32(Console.ReadLine());
        
        if (numero < 0)
        {
            Console.WriteLine("Es negativo.");
        }
        else if (numero > 0)
        {
            Console.WriteLine("Es positivo.");
        }
        else
        {
            Console.WriteLine("Es cero;");
        }
    }
}
