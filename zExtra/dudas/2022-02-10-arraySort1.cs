// Primer ejemplo de "Array.Sort", con datos "ordenables" (string)

using System;

class ArraySort1
{
    static void Main()
    {
        // Ordenar todos los datos con "Array.Sort"
        string[] datos1 = {"uno", "dos", "tres", "cuatro"};
        Array.Sort(datos1);
        foreach (string dato in datos1) 
            Console.Write(dato+" ");
        Console.WriteLine();

        // Ordenar los 3 primeros datos con "Array.Sort"
        string[] datos2 = {"uno", "dos", "tres", "cuatro"};
        Array.Sort(datos2, 0, 3);
        foreach (string dato in datos2)
            Console.Write(dato + " ");
        Console.WriteLine();
    }
}
