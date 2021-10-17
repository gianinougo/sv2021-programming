//Víctor (...)

// Ejercicio 25 T2. Muestra los números pares del 30 al 10, ambos inclusive, 
// descendiendo, separados por un espacio, sin avanzar de línea, usando "for".

using System;

class numPar30a10
{
    static void Main()
    {    
        for(int i = 30; i >= 10; i = i-2)
        {
            Console.Write("{0} ", i);
        }
        Console.WriteLine(); 
    }
}

