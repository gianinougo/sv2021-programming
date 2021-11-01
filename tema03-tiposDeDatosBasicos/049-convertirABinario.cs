//JOSE (...)
/* 49. Pide al usuario un número binario (por ejemplo 1101) y muestra su 
 * equivalente en decimal. Debes hacerlo de la siguiente forma:  leerás un 
 * número entero largo n, e irás extrayendo cada vez su última cifra 
 * (con "cifra = n % 10") y eliminando esa cifra (con "n = n / 10"); si esa 
 * cifra es 1, deberás sumar la correspondiente potencia de 2 (que será 1 para 
 * la primera cifra que elimines, luego 2 para la siguiente, después 4, 8 y así 
 * sucesivamente). Finalmente, muestra también el equivalente en binario de ese 
 * número que has obtenido, pero esta vez usando "Convert.ToString(n, 2)" (si 
 * todo ha ido bien, deberían coincidir ambos resultados).
 */

using System;

class Ejer_03_49
{
    static void Main()
    {
        long n, cifra;
        int potencia = 1;
        long resultado = 0;

        Console.Write("Introduce un número binario: ");
        n = Convert.ToInt64(Console.ReadLine());

        while (n > 0)
        {
            cifra = n % 10;
            n /= 10;
            if (cifra == 1)
            {
                resultado = resultado + potencia;
            }
            potencia *= 2;
        }
        
        Console.WriteLine("Decimal: " + resultado);
        Console.WriteLine("Binario: " + Convert.ToString(resultado, 2));
    }
}
