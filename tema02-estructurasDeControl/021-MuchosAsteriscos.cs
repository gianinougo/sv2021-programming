/*
 * 
 *  Autor: Antonio (...)
 * 
 *  Prepara un programa en C# que muestre en pantalla tantos
 *  asteriscos como indique el usuario, en una misma linea, usando
 *  "while", y finalmente avance de línea. Por ejemplo, si el usuario
 *  introduce 5, la respuesta sería: *****
 * 
 */

using System;

class Asterisco
{
    static void Main()
    {
        int numero;
        int asterisco = 1;
        
        Console.Write("Introduce un número: ");
        numero = Convert.ToInt32(Console.ReadLine());
        
        while(asterisco <= numero)
        {
            Console.Write("*");
            asterisco++;
        }
        Console.WriteLine();
    }
}
