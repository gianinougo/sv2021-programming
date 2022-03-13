/*  Para comparar velocidades de ejecución, crea una versión 
alternativa del ejercicio 170, que no guarde las palabras en un 
conjunto sino en una List<string>. */


// Tiempos aproximados con procesador i7-8565u:
// List<string> : 06.477 seg
// HashSet<string> : 00.117 seg

using System;
using System.IO;
using System.Collections.Generic;

class VelocidadListaStrings
{
    static void Main()
    {
        Console.Write("Introduce el nombre del fichero: ");
        string ficheroALeer = Console.ReadLine();
        string[] lineas = File.ReadAllLines(ficheroALeer);
        string signosPuntuacion = ",.;:-_´¨+*`^{}[]'¡¿?=!\"&%$#@|\\() ";
        char[] separadores = signosPuntuacion.ToCharArray();

        Console.WriteLine("Version con Lista de strings:");
        List<string> diccionario = new List<string>();
        DateTime comienzo = DateTime.Now;
        foreach (string line in lineas) 
        {
            string[] palabras = line.Split(separadores);
            foreach(string p in palabras)
            {
                if (! diccionario.Contains(p))
                    diccionario.Add(p);
            }
        }
        Console.WriteLine("Tiempo transcurrido: " + (DateTime.Now - comienzo));
        Console.WriteLine("Palabras encontradas: " + diccionario.Count);
    }
}
