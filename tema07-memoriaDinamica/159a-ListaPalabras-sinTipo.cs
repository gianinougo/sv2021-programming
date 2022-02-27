//Author: Franco (...)
/*
 * 159.Crea un programa que pida al usuario una frase tras otra, 
 * hasta que introduzca una frase vacía. 
 * Todas esas frases se deberán guardar en una lista de strings. 
 * Cuando introduzca la frase vacía que
 * marca el final de los datos, deberás preguntarle si 
 * desea ver los datos en su orden original, 
 * en orden inverso o bien ordenados alfabéticamente. 
 * Los datos se le mostrarán una única vez 
 * en el formato escogido, y terminará la ejecución del programa.
 */

// Versión 1: ArrayList

using System;
using System.Collections;

class ListaFrases
{
    static void Main()
    {
        ArrayList lista = new ArrayList();
        string textoEntrada;

        do
        {
            Console.WriteLine("Introduzca una frase:");
            textoEntrada = Console.ReadLine();

            if (textoEntrada != "")
                lista.Add(textoEntrada);

        } while (textoEntrada != "");

        Console.WriteLine("¿Desea ver los datos en su orden original, "
            + "en orden inverso o ordenado alfabéticamente? [o|i|a] ");
        string opcion = Console.ReadLine().ToLower();

        switch (opcion)
        {
            case "i":
                Console.WriteLine("Orden inverso:");
                for (int i = lista.Count-1; i >= 0; i--)
                {
                    Console.WriteLine(lista[i]);
                }
                break;
                
            case "a":
                Console.WriteLine("Ordenado alfabéticamente:");
                lista.Sort();
                foreach (string frase in lista)
                    Console.WriteLine(frase);
                break;
                
            case "o":
            default:
                Console.WriteLine("Orden original:");
                foreach (string frase in lista)
                    Console.WriteLine(frase);
                break;
        }
    }
}
