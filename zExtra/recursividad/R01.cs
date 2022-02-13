/*
R01. 

Crea una función SumarHastaIt( n ), que calcule la suma de los n 
primeros números naturales, de forma iterativa.

Crea una función SumarHastaRe( n ),  que calcule la suma de los n 
primeros números naturales, de forma recursiva.

Crea un programa de prueba que compruebe si ambas funciones dan el 
mismo resultado para todos los números desde el 0 hasta el 100.
*/

using System;

class R01
{
    static void Main()
    {
        bool falla = false;
        for (int i = 1; i <= 100; i++)
        {
            int suma1 = SumarHastaIt(i);
            int suma2 = SumarHastaRe(i);
            if (suma1 == suma2)
            {
                Console.Write( i + " OK. ");
            }
            else
            {
                Console.Write( i + " falla!!! ");
                falla = true;
            }
        }
        if (falla)
            Console.WriteLine("Algo no va bien...");
    }

    static int SumarHastaIt(int n)
    {
        int suma = 0;
        for (int i = 1; i <= n; i++)
        {
            suma += i;
        }
        return suma;
    }

    static int SumarHastaRe(int n)
    {
        if (n == 1)
            return 1;
        else
            return n + SumarHastaRe(n - 1);
    }
}
