/* Juan Manuel (...) 1º DAM Sem. */


/*Ejercicio89.Crea una función "SumaDigitos ", que devuelva la suma de los
 * dígitos de un entero largo que reciba como parámetros. Hazlo tanto de
 * forma iterativa ("SumaDigitos") como de forma recursiva ("SumaDigitosR").
 * Prueba ambas desde Main, para un dato introducido por el usuario.
 * Pista: recuerda que, aunque el parámetro que recibes es un número,
 * puedes convertirlo a cadena dentro de la función si consideras que eso te
 * puede simplificar la solución.*/


using System;

class Ejercicio89
{

    static long SumaDigitos(long n)
    {
        long sumaDigitos = 0;
        while (n != 0)
        {
            sumaDigitos += n % 10;
            n /= 10;
        }
        return sumaDigitos;
    }


    static long SumaDigitosR(long n)
    {
        if (n == 0)
        {
            return 0;
        }
        else
        {
            return n % 10 + SumaDigitosR(n / 10);
        }
    }

    static void Main()
    {
        long n = 258978; // suma 39
        Console.WriteLine(" " + SumaDigitos(n) + " " + SumaDigitosR(n));
    }
}

