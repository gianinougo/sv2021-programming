//Francis (...), retoques por Nacho - DAM Semipresencial

/* 86. Un número Harshad es un número que es divisible por la suma de sus
 * dígitos. Crea una función booleana "EsNumeroHarshad", que devuelva true
 * verdadero si el número entero largo indicado como parámetro es un número
 * Harshad: if (EsNumeroHarshad(152) ....). Crea también un programa de
 * prueba, que pida al usuario un número entero largo y responda si es
 * Harshad o no lo es. Para gestionar los errores de introducción de datos,
 * no debes usar "try-catch" sino "TryParse" (apartado 5.7.4 de los apuntes).*/

using System;
class FunctionAddDigitsNumber
{
    static bool EsNumeroHarshad(long num)
    {
        long sum = 0;
        string numDigitos = Convert.ToString(num);

        for (int i = 0; i < numDigitos.Length; i++)
        {
            sum += Convert.ToInt64(numDigitos.Substring(i, 1));
        }

        if (num % sum == 0)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public static void Main()
    {
        long num;
        Console.WriteLine("Escribe un número entero largo:");

        if (Int64.TryParse(Console.ReadLine(), out num))
        {
            if (EsNumeroHarshad(num))
            {
                Console.WriteLine("Es número Harshad");
            }
            else
            {
                Console.WriteLine("No es número Harshad");
            }
        }
        else
        {
            Console.WriteLine("Eso no es un número!");
        }
    }
}
