/* Juan manuel (...) 1º DAM Sem. */

/* 
Ejercicio 157.Pide al usuario números enteros cortos (short), tantos como
desee, hasta que pulse Intro en vez de un número. Deberás ir almacenando
todos ellos en una cola. Finalmente, deberás mostrar todos los datos que
ha introducido, así como su suma y su media (que deberás calcular en el
momento de mostrar los datos, no en el de introducirlos). Puedes emplear
una cola con tipo base -Generics- o sin tipo, como prefieras (se compartirán
ambas soluciones, para que puedas comparar).

 *****  GENERICS  *****

*/


using System;
using System.Collections.Generic;


class Ejercicio157b
{
    static void Main()
    {
        Queue<short> miCola = new Queue<short>();
        string cadenaNumero;
        Console.WriteLine("Deme todos los numeros que desee separados");
        Console.WriteLine("por Enter, para finalizar pulse intro : ");
        do
        {
            cadenaNumero = Console.ReadLine();
            if (cadenaNumero != "")
            {
                miCola.Enqueue(Convert.ToInt16(cadenaNumero));
            }
        } while (cadenaNumero != "");

        int elementosCola = miCola.Count;
        int suma = 0;

        for (int i = 0; i < elementosCola; i++)
        {
            short dato = miCola.Dequeue();
            suma += dato;
            if (miCola.Count >= 1)
            {
                Console.Write("{0}, ", dato);
            }
            else
            {
                Console.WriteLine("{0}", dato);
            }

        }
        Console.WriteLine("La suma de los elementos de la cola" +
            " es : {0}", suma);
        Console.WriteLine("La media de los elementos de la cola" +
            " es : {0}", suma / elementosCola);

    }
}
