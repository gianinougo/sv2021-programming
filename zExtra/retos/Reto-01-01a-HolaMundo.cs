/*
 * VIRGINIA (...)
 * 
 * Entrada
 * La entrada consta de una única línea que contiene un número n, 0 ≤ n ≤ 5, 
 * que indica cuántos mensajes hay que emitir.
 * 
 * Salida
 * Cada mensaje a escribir aparecerá en una única línea y será la cadena 
 * "Hola mundo.".
 */

using System;

class Reto1_01
{
    static void Main()
    {
        int n,i;
        
        n = Convert.ToInt32(Console.ReadLine());
      
        for (i = 1; i <= n; i++)
        {
            Console.WriteLine("Hola mundo.");
        }                          
    }
}
