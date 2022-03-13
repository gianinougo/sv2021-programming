/* Crea un programa que calcule cuántas palabras diferentes hay en los 
ficheros words.txt y words2.txt, que tienes compartidos en GitHub. Haz 
dos versiones: la primera usará un ArrayList o una lista con tipo, la 
segunda empleará un diccionario. */

// Tiempos aproximados con procesador i7-8565u:
// List<string> : 07 min 20 seg
// HashSet<string> : 00 min 00 seg 02 centésimas

using System;
using System.Collections.Generic;
using System.IO;

class ContarPalabrasDistintas
{
    static void Main()
    {
        Console.WriteLine("Rellenando listas...");
        List<string> lista1 = new List<string>(File.ReadAllLines("words.txt"));
        List<string> lista2 = new List<string>(File.ReadAllLines("words2.txt"));
        
        Console.WriteLine("Comenzando a medir tiempos, lista...");
        int cantidad = 0;
        DateTime comienzo = DateTime.Now;
        for (int i = 0; i < lista1.Count; i++)
        {
            if (!(lista2.Contains(lista1[i])))
            {
                cantidad++;
            }
        }
        Console.WriteLine(cantidad + "palabras distintas");
        Console.WriteLine("Tiempo transcurrido: " + (DateTime.Now - comienzo));


        Console.WriteLine("Rellenando conjuntos...");
        HashSet<string> conjunto1 = new HashSet<string>(File.ReadAllLines("words.txt"));
        HashSet<string> conjunto2 = new HashSet<string>(File.ReadAllLines("words2.txt"));

        Console.WriteLine("Comenzando a medir tiempos, conjuuto...");
        cantidad = 0;
        comienzo = DateTime.Now;
        foreach (string dato in conjunto1)
        {
            if (! conjunto2.Contains(dato))
            {
                cantidad++;
            }
        }
        Console.WriteLine(cantidad + "palabras distintas");
        Console.WriteLine("Tiempo transcurrido: " + (DateTime.Now - comienzo));
    }
}
