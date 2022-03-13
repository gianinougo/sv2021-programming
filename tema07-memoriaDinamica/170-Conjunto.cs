/* Crea una variante del ejercicio 169 (palabras existentes), que 
cuente las palabras que hay en el texto (sin preocuparse por cuántas 
veces aparecen), usando un conjunto. */

using System;
using System.IO;
using System.Collections.Generic;

class EjemploConjuntos
{
    static void Main()
    {
        Console.Write("Introduce el nombre del fichero: ");
        string ficheroALeer = Console.ReadLine();
        string[] lineas = File.ReadAllLines(ficheroALeer);
        string signosPuntuacion = ",.;:-_´¨+*`^{}[]'¡¿?=!\"&%$#@|\\() ";
        char[] separadores = signosPuntuacion.ToCharArray();

        Console.WriteLine("Version con Conjunto:");
        HashSet<string> diccionario = new HashSet<string>();
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
