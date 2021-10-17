/*
 * VIRGINIA (...)
 * 
 * 29. Haz un programa que pida al usuario un alto y un ancho 
 * y que muestre un rectángulo formado por asteriscos, con ese 
 * alto y ancho, como en este ejemplo:
 * Alto? 5
 * Ancho? 3
 * ***
 * ***
 * ***
 * ***
 * ***
 */

using System;

class Ejercicio29
{
    static void Main()
    {
        int alto, ancho, fila, columna;
        Console.Write("Alto? ");
        alto = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Ancho? ");
        ancho = Convert.ToInt32(Console.ReadLine());

        for (fila=1; fila<=alto; fila++)
        {
            for (columna=1; columna<=ancho; columna++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}

