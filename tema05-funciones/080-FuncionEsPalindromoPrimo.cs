/*
 * VIRGINIA (,,,)
 * 80. Crea una función booleana llamada "EsPalindromoPrimo", que devolverá 
 * "true" si el parámetro, un número entero largo, es un número primo que 
 * también es palíndromo, o "false" en caso contrario. En vez de que esta 
 * función tenga toda la carga lógica, apóyate en la función "EsPalindromo" 
 * que ya has creado antes, y una "EsPrimo" que permita saber si un número es 
 * primo o no. Úsala para mostrar los primos palíndromos que hay entre el 1 y
 * el 1000.
 */

using System;

class Ejercicio80
{
    static bool EsPalindromo(string cadena)
    {
        bool palindromo = true;
        int posicion = 0;

        do
        {
            if (cadena[posicion] != cadena[cadena.Length - 1 - posicion])
            {
                palindromo = false;
            }
            posicion++;
        }
        while (palindromo && posicion < cadena.Length);

        return palindromo;
    }

    static bool EsPrimo(long numero)
    {
        bool esPrimo = false;
        long divisorActual = 1, divisores = 0;

        while(divisorActual <= numero)
        {
            if(numero % divisorActual == 0)
            {
                divisores++;
            }
            divisorActual++;
        }

        if(divisores == 2)
        {
            esPrimo = true;
        }
        return esPrimo;
    }

    static bool EsPalindromoPrimo(long numero)
    {
        bool palindromoPrimo = false;

        if(EsPalindromo(Convert.ToString(numero)) && EsPrimo(numero))
        {
            palindromoPrimo = true;
        }
        return palindromoPrimo;
    }

    static void Main()
    {
        const long MINIMO = 1;
        const long MAXIMO = 1000;

       Console.WriteLine("Primos palíndromos entre 1 y 1000: ");
       for(long numero=MINIMO; numero<=MAXIMO; numero++)
        {
            if (EsPalindromoPrimo(numero))
            {
                Console.WriteLine("{0}", numero);
            }
        }
    }
}
