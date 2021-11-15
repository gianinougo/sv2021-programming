/*63. Crea un programa que pregunte al usuario cuántos datos (enteros largos) 
 * va a introducir, reserve espacio para todos ellos, se los pida al usuario y 
 * finamente muestre los números que estén duplicados. Por ejemplo, si los números 
 * son 12 23 36 23 45, la respuesta sería "Duplicados: 23". Si no hubiera ningún
 * duplicado, la respuesta deberá ser "Duplicados: Ninguno".
*/

// Rocio (...)

using System;

class Duplicado63
{
    static void Main()
    {
        Console.WriteLine("Cuanto datos enteros largos quiere introducir?");
        int cantidad = Convert.ToInt32(Console.ReadLine());
        long[] array = new long[cantidad];
        
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Inserte un numero:");
            long dato = Convert.ToInt64(Console.ReadLine());
            array[i] = dato;
        }        
        
        Console.Write("Duplicados: ");
        bool algunoEncontrado = false;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i+1; j < array.Length; j++)
            {
                if (array[i] == array[j])
                {
                    algunoEncontrado = true;
                    Console.Write(array[i] + " ");
                }
            }       
        }
        if (! algunoEncontrado)
        {
            Console.Write("Ninguno");
        }
    }
}

