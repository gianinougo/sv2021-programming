/* Ivan (...)
 * 19. Crea un programa que muestre los números del 10 al 20, separados por un 
 * espacio, sin avanzar de línea, usando "while".
 */
 
using System;

class Contador
{
    static void Main()
    {
        int n = 10;
        while (n <= 20)
        {
            Console.Write("{0} ", n);
            n = n + 1;
        }
        Console.WriteLine();
    }
}
