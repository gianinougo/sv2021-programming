// Virginia (...)
// Conversor de pies a milímetros


/*
Debe usar "Write" en vez de "{0}". 
Debe utilizar "using System;". 
Debe  contener dos comentarios de una línea al principio: 
 - Uno con tu nombre
 - Otro con el cometido del programa 
*/

using System;

class Ejercicio6
{
    static void Main()
    {
        int pies;
        int milimetros;
        int milimetrosPorPie = 305;

        Console.Write("Introduce el número de pies: ");
        pies = Convert.ToInt32(Console.ReadLine());

        Console.Write(pies);
        Console.Write(" pies son ");
        milimetros = milimetrosPorPie * pies;
        Console.Write(milimetros);
        Console.WriteLine(" milímetros.");
    }
 }
