//Author: Franco (...)
/*
177. Crea una clase "ListaOrdenadaDeStrings", 
que permita guardar (usando un método "Anyadir") cadenas, 
que quedarán ordenadas alfabéticamente, 
así como obtenerlas a partir de su posición (con un método "Obtener(int n)") 
y saber cuántos datos hay (con una propiedad "Tamanyo"). 

Internamente debe emplear una List<string>. 

Incluye un Main que permita probarla.
*/

using System.Collections.Generic;
using System;

class ListaOrdenadaDeStrings
{

    protected List<string> lista = new List<string>();

    public int Tamanyo { get { return lista.Count; } }

    public void Anyadir(string texto)
    {
        lista.Add(texto);
        lista.Sort();
    }

    public string Obtener(int n)
    {
        return lista[n];
    }
}

class PruebaListaOrdenadaDeStrings
{
    static void Main()
    {
        ListaOrdenadaDeStrings listaOrdenada = new ListaOrdenadaDeStrings();

        //Cantidad de datos
        Console.WriteLine("Tamaño: {0}", listaOrdenada.Tamanyo);

        //Añadimos datos
        listaOrdenada.Anyadir("Prueba");
        listaOrdenada.Anyadir("c");
        listaOrdenada.Anyadir("b");
        listaOrdenada.Anyadir("a");

        //Mostramos datos
        for (int i = 0; i < listaOrdenada.Tamanyo; i++)
            Console.WriteLine(listaOrdenada.Obtener(i));

        //Cantidad de datos
        Console.WriteLine("Tamaño: {0}", listaOrdenada.Tamanyo);
    }
}
