// Ej.045: Cifras de un número, dividiendo varias veces entre 10.

// Joaquin (...)

using System;

class Ej45
{
    static void Main()
    {
        Console.Write("introduce un entero largo: ");
        long n = Convert.ToInt64( Console.ReadLine() );
        
        byte cifras = 0; 
        do
        {
            n /= 10;
            cifras++;
        }
        while ( n != 0 );
        
        Console.Write("{0} cifras", cifras);
    }
    
}
