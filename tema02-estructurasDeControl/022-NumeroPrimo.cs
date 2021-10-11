/*
 * VIRGINIA (...)
 * 22. Crea un programa que le pida al usuario un número y 
 * responda si es primo. Debes hacerlo contando cuántos 
 * divisores tiene. Será primo si y solo si tiene exactamente 
 * dos divisores.
 */

using System;

class Ejercicio22
{
    static void Main()
    {
        int numero, divisorActual=1, divisores=0;

        Console.Write("Teclea un número entero: ");
        numero = Convert.ToInt32(Console.ReadLine());

        while (divisorActual <= numero)
        {
            if (numero % divisorActual == 0)
            {                 
                divisores++;
            }
            divisorActual++;
        }

        if (divisores == 2)
        {
            Console.WriteLine("Es primo.");
        }
        else
        {
            Console.WriteLine("No es primo.");
        }

    }
}
