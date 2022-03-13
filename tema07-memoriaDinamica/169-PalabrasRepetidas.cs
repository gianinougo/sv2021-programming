//Author: Franco (..) + Javier (...)

/*
/* Variante del ejercicio 167 que no muestre las frases repetidas sino las 
 * palabras repetidas (ayudándote de ".Split()" para obtener las palabras 
 * y de ".Replace" para eliminar los símbolos de puntuación más habituales. 
 * Para que la salida no sea exageradamente grande, muestra sólo las palabras 
 * que se repiten más de 500 veces. Al igual que antes, crea una versión con 
 * SortedList y otra con una tabla Hash (o un Dictionary).
*/

using System;
using System.IO;
using System.Collections.Generic;

class Ej169
{
    static void Main()
    {
        Console.Write("Introduce el nombre del fichero: ");
        string ficheroALeer = Console.ReadLine();
        string[] lineas = File.ReadAllLines(ficheroALeer);
        string signosPuntuacion = ",.;:-_´¨+*`^{}[]'¡¿?=!\"&%$#@|\\() ";
        char[] separadores = signosPuntuacion.ToCharArray();

        Console.WriteLine("Version con SortedList:");
        SortedList<string, int> diccionario = new SortedList<string, int>();
        DateTime comienzo = DateTime.Now;
        foreach (string line in lineas) 
        {
            string[] palabras = line.Split(separadores);
            foreach(string p in palabras)
            {
                if (diccionario.ContainsKey(p))
                    diccionario[p] += 1;
                else
                    diccionario.Add(p, 1);
            }
        }
        Console.WriteLine("Tiempo transcurrido: " + (DateTime.Now - comienzo));
        for (int i = 0; i < diccionario.Count; i++)
            if ((diccionario.Keys[i] != "") 
                && (diccionario.Values[i] > 500))
            {
                Console.WriteLine("{0} = {1}",
                    diccionario.Keys[i], diccionario.Values[i]);
            }

        Console.WriteLine();
        Console.WriteLine("Version con tabla Hash:");
        Dictionary<string, int> hashtable = new Dictionary<string, int>();
        comienzo = DateTime.Now;
        foreach (string line in lineas)
        {
            string[] palabras = line.Split(separadores);
            foreach(string p in palabras)
            {
                if (hashtable.ContainsKey(p))
                    hashtable[p] += 1;
                else 
                    hashtable.Add(p, 1);
            }
        }
        Console.WriteLine("Tiempo transcurrido: " + (DateTime.Now - comienzo));
        foreach (KeyValuePair<string, int> dic in hashtable)
            if ((dic.Key != "") && (dic.Value > 500))
                {
                    Console.WriteLine("{0} = {1}", 
                        dic.Key, dic.Value);
                }
    }
}
