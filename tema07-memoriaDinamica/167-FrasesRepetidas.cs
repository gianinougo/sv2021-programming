//Author: Franco (..)

/*
167. Con la ayuda de File.ReadAllLines, y de un SortedList, 
crea un programa que pida al usuario el nombre de un fichero de texto 
y luego diga qué frases (no vacías) aparecen repetidas, 
y cuántas veces las ha encontrado. 

Haz una segunda versión usando una tabla Hash (o un Dictionary). 
Recorre los datos usando "foreach". 

Tienes ejemplos de ficheros de datos compartidos en GitHub.
*/

using System;
using System.IO;
using System.Collections.Generic;

class ej167
{
    static void Main()
    {
        Console.Write("Introduce el nombre del fichero: ");
        string ficheroALeer = Console.ReadLine();
        string[] lineas = File.ReadAllLines(ficheroALeer);

        Console.WriteLine("Version con SortedList:");
        SortedList<string, int> diccionario = new SortedList<string, int>();
        foreach (string line in lineas) 
        {
            if (diccionario.ContainsKey(line))
                diccionario[line] += 1;
            else
                diccionario.Add(line, 1);
        }
        for (int i = 0; i < diccionario.Count; i++)
            if ((diccionario.Keys[i] != "") 
                && (diccionario.Values[i] > 1))
            {
                Console.WriteLine("{0} = {1}",
                    diccionario.Keys[i], diccionario.Values[i]);
            }

        Console.WriteLine();
        Console.WriteLine("Version con tabla Hash:");
        Dictionary<string, int> hashtable = new Dictionary<string, int>();
        foreach (string line in lineas)
        {
            if (hashtable.ContainsKey(line))
                hashtable[line] += 1;
            else 
                hashtable.Add(line, 1);
        }
        foreach (KeyValuePair<string, int> dic in hashtable)
            if ((dic.Key != "") && (dic.Value > 1))
                {
                    Console.WriteLine("{0} = {1}", 
                        dic.Key, dic.Value);
                }
    }
}
