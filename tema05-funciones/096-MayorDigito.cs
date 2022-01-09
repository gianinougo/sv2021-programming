/*
 * VIRGINIA (...)
 * 96. Crea una función "ObtenerMayorDigito", que devuelva la cifra más alto 
 * que aparece en un número entero largo que recibirá como parámetro. Crea una
 * versión recursiva y otra iterativa y comprueba que se comportan igual. 
 * Ejemplos de su uso:
 * 
 * Console.Write(ObtenerMayorDigito(32)); // Debería mostrar 3
 * if ( ObtenerMayorDigito(276) != 7 )
 * Console.WriteLine("Algo no va bien!");
 */

using System;

class Ejercicio96
{
    //Versión iterativa:
    static byte ObtenerMayorDigito(long numero)
    {
        byte mayor = 0;
        while (numero != 0)
        {
            byte digito = Convert.ToByte(numero % 10);

            if (digito > mayor)
            {
                mayor = digito;
            }

            numero /= 10;
        }
        return mayor;
    }

    //Versión recursiva:
    static byte ObtenerMayorDigitoR(long numero)
    {
        if (numero == 0)
        {
            return 0;
        }
        else if (numero % 10 > ObtenerMayorDigitoR(numero / 10))
        {
            return Convert.ToByte(numero % 10);
        }
        else
        {
            return ObtenerMayorDigitoR(numero / 10);
        }
    }

    static void Main()
    {
        Console.WriteLine(ObtenerMayorDigito(7369567));
        Console.WriteLine(ObtenerMayorDigitoR(7365967));
    }
}
