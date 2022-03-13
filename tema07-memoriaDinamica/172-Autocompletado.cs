// Ejercicio recomendado 172 

/*
 * A partir del fichero "words.txt" (que está comprimido en un archivo 
 * "words.zip" en GitHub), crea un programa que sugiera palabras que 
 * comiencen por las letras que vaya tecleando el usuario, como el 
 * autocompletado de las búsquedas en Google. Puedes ayudarte de un 
 * "SortedSet".
 */

using System;
using System.Collections.Generic;
using System.IO;

class SugerirPalabras
{
    static void Main()
    {
        char letra;
        string palabra = "";
        ConsoleKeyInfo tecla;
        
        string[] lineas = File.ReadAllLines("words.txt");
        SortedSet<string> listaPalabras = new SortedSet<string>(lineas);
        
        Console.Clear();
        Console.WriteLine("Introduzca letras de la palabra a buscar:");
            
        tecla = Console.ReadKey(true);
        do
        {
            
            if (tecla.Key != ConsoleKey.Backspace)
            {
                // Si no es tecla de borrado, la añadimos
                letra = tecla.KeyChar;
                palabra += letra;
            }
            else if (palabra.Length > 0)
            {
                // Si es de borrado, y hay letras, quitamos la última
                palabra = palabra.Substring(0, palabra.Length - 1);
            }
            Console.WriteLine("Buscando: " + palabra);
            MostrarCoincidencias(listaPalabras, palabra);
            
            tecla = Console.ReadKey(true);
            Console.Clear();
        }
        while (tecla.Key != ConsoleKey.Escape);
    }

    static void MostrarCoincidencias(
        SortedSet<string> palabras, string texto)
    {
        if (texto == "")
            return;
            
        int palabrasAMostrar = 10;
        int mostradas = 0;

        foreach (string p in palabras)
        {
            if (p.StartsWith(texto) && mostradas < palabrasAMostrar)
            {
                Console.WriteLine(p);
                mostradas++;
            }
        }

        if (mostradas == palabrasAMostrar)
            Console.WriteLine("...");
    }
}
