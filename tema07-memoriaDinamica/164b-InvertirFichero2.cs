/* Juan Manuel (...) 1º DAM Sem.*/

/*
Ejercicio 164.Crea un programa que muestre el contenido de un fichero de texto,
invertido (de la última línea a la primera), de la siguiente forma:

Para leer todo el contenido de un fichero a un array de strings puedes hacer
"string[] lineas = File.ReadAllLines("nombreDeFichero.ext");"
(necesitarás añadir también "using System.IO;")
Puedes crear una pila a partir del contenido de un array si indicas dicho
array como parámetro del constructor:
"Stack<string> pila = new Stack<string>(lineas);"
Ya sólo queda que recorras la pila, mostrando la información que contiene.
*/

// Versión 2: con "foreach"

using System;
using System.Collections.Generic;
using System.IO;


class Ejercicio164b
{
    static void Main()
    {
        Console.Write("Dime el nombre del fichero: ");
        string rutaFichero = Console.ReadLine();

        string[] lineas = File.ReadAllLines(rutaFichero);
        Stack<string> pila = new Stack<string>(lineas);

        foreach(string linea in pila)
            Console.WriteLine(linea);
    }
}

