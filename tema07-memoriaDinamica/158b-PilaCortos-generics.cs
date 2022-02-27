﻿// JOSE (...)

/* 158. Haz una variante del ejercicio anterior, en la que los datos no se 
 * introduzcan en una cola, sino en una pila, de modo que se obtendrán en orden 
 * inverso al que se introdujeron. Nuevamente, puedes usar una pila con tipo o 
 * sin tipo.
 */

// Versión 2: "generics"

using System;
using System.Collections.Generic;

class Ejercicio158b
{
    static void Main()
    {
        byte cantidad;
        int suma = 0;
        bool salir;
        string opcion;
        short numero;
        Stack<short> numeros = new Stack<short>();

        do
        {
            Console.WriteLine("Introduce un número (Intro para terminar):");
            opcion = Console.ReadLine();

            salir = opcion == "";

            if (!salir)
            {
                numero = Convert.ToInt16(opcion);
                numeros.Push(numero);
            }

            cantidad = (byte)numeros.Count;
        } while (!salir);

        Console.Write("Los datos introducidos son: ");
        while(numeros.Count > 0)
        {
            short item = numeros.Pop();
            suma += item;
            Console.Write(item + " ");
        }
        
        Console.WriteLine();
        Console.WriteLine("La suma de todos los números es: " + suma);
        
        float media = suma / cantidad;
        Console.WriteLine("La media es: " + media.ToString("N2"));
    }
}

