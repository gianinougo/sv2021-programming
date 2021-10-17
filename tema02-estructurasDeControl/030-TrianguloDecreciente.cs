/*
 *  Alejandro (...)
 *  
 *  30. Muestra un triángulo decreciente alineado a la izquierda, con el tamaño
 *  indicado por el usuario, usando "for":
        Tamaño? 5
        *****
        ****
        ***
        **
        *
 */

using System;
class Ejercicio_30
{
    static void Main()
    {
        int filas, columnas, tamanyo, asteriscos;

        Console.Write("Tamaño? ");
        tamanyo = Convert.ToInt32(Console.ReadLine());

        asteriscos = tamanyo;

        for (filas = 0; filas < tamanyo; filas++)
        {
            for (columnas = 0; columnas < asteriscos; columnas++)
            {
                Console.Write("*");
            }
            Console.WriteLine();

            asteriscos--;
         }
    }
}
