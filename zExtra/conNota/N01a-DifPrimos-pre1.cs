/*
Ejercicio con nota N01. (Tema 2).

Crea un programa que pida al usuario dos números enteros y muestre la 
diferencia entre el menor número primo y el mayor número primo que hay entre 
esos dos números, ambos incluidos.

Aproximación 1: Ver si un número es primo
*/

using System;

class N01Pre1
{
    static void Main()
    {
        int divisores=0;

        Console.Write("Teclea un número entero: ");
        int numero = Convert.ToInt32(Console.ReadLine());

        for (int divisorActual=1; divisorActual <= numero; divisorActual++)
            if (numero % divisorActual == 0)
                divisores++;

        if (divisores == 2)
            Console.WriteLine("Es primo.");
        else
            Console.WriteLine("No es primo.");
    }
}
