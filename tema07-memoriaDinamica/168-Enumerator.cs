//Author: Franco (..)

/*
168. Crea una variante del ejercicio 167, 
que utilice "enumeradores" para mostrar los resultados.
*/

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

class Ej168
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
        IDictionaryEnumerator miEnumerador1 =
            (IDictionaryEnumerator)diccionario.GetEnumerator();

        while (miEnumerador1.MoveNext())
        {
            if (((string) miEnumerador1.Key != "") 
                && ((int) miEnumerador1.Value > 1))
            {
                Console.WriteLine("{0} = {1}",
                    miEnumerador1.Key, miEnumerador1.Value);
            }
        }

        Console.WriteLine();
        Console.WriteLine("Version con Dictionary:");
        Dictionary<string, int> hashtable = new Dictionary<string, int>();
        foreach (string line in lineas)
        {
            if (hashtable.ContainsKey(line))
                hashtable[line] += 1;
            else 
                hashtable.Add(line, 1);
        }
        IDictionaryEnumerator miEnumerador2 =
            (IDictionaryEnumerator)hashtable.GetEnumerator();

        while (miEnumerador2.MoveNext())
        {
            if (((string) miEnumerador2.Key != "") 
                && ((int) miEnumerador2.Value > 1))
            {
                Console.WriteLine("{0} = {1}",
                    miEnumerador2.Key, miEnumerador2.Value);
            }
        }
    }
}
