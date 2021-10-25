/* Juan Manuel (...) */

/* Ejercicio34.Haz un programa que calcule una raíz cuadrada (entera) por
 * aproximación, tanteando los valores que sea necesario. Por ejemplo, 
 * si el usuario introduce 82, el cuadrado debería ser 9, porque 9*9=81,
 * que es menor (o igual) que 82, pero 10 * 10 = 100, que es mayor que 82.
 * Usa las estructuras de programación que consideres más adecuadas. Además,
 * deberá decir si la reíz es exacta o aproximada. Por ejemplo, para el 
 * número 81, la respuesta será "9 (exacta)", y para el 99 la respuesta
 * será "9 (aproximada)".*/

using System;


class Ejercicio34
{
    static void Main()
    {
        int numero, cuadrado = 0, contador = 0;
        try
        {
            Console.Write("Dame un número y te calculo la raíz cuadrada: ");
            numero = Convert.ToInt32(Console.ReadLine());
            if (numero >= 1)   //Solo enteros positivos
            {
                while (cuadrado < numero)
                {
                    contador++;
                    cuadrado = contador * contador;

                }
                
                if (cuadrado == numero)
                {
                    Console.WriteLine(" El cuadrado es {0} (exacta).",
                        contador);
                }
                else
                {
                    Console.WriteLine(" El cuadrado es {0} (aproximada).",
                        contador - 1);
                }

            }
            else // No existe raiz cuadrada para 0 y enteros negativos
            {
                Console.WriteLine(" No puedo calcular la raiz " +
                    "cuadrada de {0}.", numero);

            }

        }

        catch (FormatException) // Capturamos el error de conversión. 
        {
            Console.WriteLine(" No es un número válido.");
        }
    }
}

