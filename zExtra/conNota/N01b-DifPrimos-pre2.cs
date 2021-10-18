/*
Ejercicio con nota N01. (Tema 2).

Crea un programa que pida al usuario dos números enteros y muestre la 
diferencia entre el menor número primo y el mayor número primo que hay entre 
esos dos números, ambos incluidos.

Aproximación 2: Números primos en un rango
*/

using System;

class N01Pre2
{
    static void Main()
    {
        int divisores;
        int cantidadDePrimos = 0;

        Console.Write("Teclea el número inicial: ");
        int inicio = Convert.ToInt32(Console.ReadLine());
        Console.Write("Teclea el número final: ");
        int fin = Convert.ToInt32(Console.ReadLine());
        
        for (int numero = inicio; numero <= fin; numero++)
        {
            divisores = 0;
            for (int divisorActual=1; divisorActual <= numero; divisorActual++)
                if (numero % divisorActual == 0)
                    divisores++;

            if (divisores == 2)
            {
                Console.Write("{0} ", numero);
                cantidadDePrimos++;
            }
        }
        Console.WriteLine("Primos encontrados: {0}", cantidadDePrimos);
    }
}
