//author: Franco (...)
/*
    46. Pide un número entero al usuario y calcula su 
    raíz cuadrada con una cifra decimal por aproximación, 
    tanteando los valores que sea necesario. 
    Por ejemplo, si el usuario introduce 84, el 
    resultado debería ser 9,1, porque 9,1 al cuadrado 
    es menor que 84, pero 9,2 al cuadrado es mayor que 84.
*/


using System;

class RaizCuadradaDecimal 
{
    static void Main() 
    {
        float numero, cuadrado = 0, contador = 0;
        try 
        {

            Console.Write("Dame un número y te calculo la raíz cuadrada: ");
            numero = Convert.ToSingle(Console.ReadLine());

            if (numero >= 0) 
            {

                while (cuadrado < numero) 
                {
                    contador += 0.1f;
                    cuadrado = contador * contador;
                }
                
                if (cuadrado == numero) 
                {
                    Console.WriteLine("Su raiz cuadrada es {0} (exacta).",
                        contador);
                }
                else 
                {
                    Console.WriteLine("Su raiz cuadrada es {0} (aproximada).",
                        (contador - 0.1f).ToString("N1"));
                }

            } 
            else 
            { 
                // No existe raiz cuadrada para negativos
                Console.WriteLine(" No puedo calcular la raiz " +
                    "cuadrada de {0}.", numero);
            }
        }

        catch (FormatException) 
        {
            Console.WriteLine(" No es un número válido.");
        }
    }
}
