/*
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
 * 
 * Versión 2: con "new string"
 * 
 */

using System;

class Ejercicio29b
{
    static void Main()
    {
        int alto, ancho, fila;
        Console.Write("Alto? ");
        alto = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Ancho? ");
        ancho = Convert.ToInt32(Console.ReadLine());
        
        string lineaAsteriscos = new string('*', ancho);

        for (fila=1; fila<=alto; fila++)
        {
            Console.WriteLine(lineaAsteriscos);
        }
    }
}

