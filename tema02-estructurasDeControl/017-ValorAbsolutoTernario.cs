// Tema 2, ejercicio 17
// Paula (...)
/* Escribe un programa que calcule (y muestre) el valor absoluto de un número 
   x: si el número es positivo (o cero), su valor absoluto es exactamente el 
   número x; en caso contrario, su valor absoluto es -x. Hazlo de dos maneras 
   diferentes en el mismo programa: usando "if" y usando el "operador 
   condicional" u "operador ternario" (?). */


using System;

class Ejercicio_17
{
    static void Main()
    {
        int x, abs;

        // Versión con "if"
        Console.Write("Introduce un número: ");
        x = Convert.ToInt32(Console.ReadLine());

        if (x >= 0)
        {
            abs = x;
        }
        else
            abs = -x;
            
        Console.WriteLine("El valor absoluto es {0}", abs);
        
        // Versión con "operador ternario"
        abs = x >= 0 ? x : -x;
        Console.WriteLine("El valor absoluto es {0}", abs);
        
        // Versión con "operador ternario", compactada
        Console.WriteLine("El valor absoluto es {0}", x >= 0 ? x : -x);
    }
}
