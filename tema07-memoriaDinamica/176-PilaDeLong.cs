//Victor (...), retoques por Nacho
/*176. Crea una clase "PilaDeLong", que permita guardar (usando un método "Apilar") enteros largos, obtenerlos (con un método "Desapilar") y
saber cuántos datos hay (con una propiedad "Tamanyo"). Internamente debe emplear una List<long>. Incluye un Main que permita probarla. */
using System;
using System.Collections.Generic;

class PruebaPilaDeLong
{
    static void Main(string []args)
    {
        PilaDeLong Pila = new PilaDeLong();
        Pila.Apilar(1);
        Pila.Apilar(2);
        Pila.Apilar(3);
        Pila.Apilar(4);
        Pila.Apilar(5);
        Pila.Apilar(6);
        Pila.Apilar(7);
        Pila.Apilar(8);
        Pila.Apilar(9);

        while (Pila.Tamanyo > 0)
        {
            long dato = Pila.Desapilar();
            Console.WriteLine(dato);
        }
              
     }
}

class PilaDeLong
{
    private List<long> lista;
    
    public PilaDeLong()
    {
        lista = new List<long>();
    }
    
    public int Tamanyo { get { return lista.Count; } }

    public void Apilar(long num)
    {
        lista.Add(num);
    }
    
    public long Desapilar()
    {
        long dato = lista[ lista.Count-1 ];
        lista.RemoveAt( lista.Count-1 );
        return dato;
    }
}
