/*
 * VIRGINIA (...)
 * 
 * 88. Crea una función "Potencia(n1, n2)", que calcule y devuelva el resultado
 * de elevar un primer número natural que se indique como parámetro a otro 
 * segundo número natural que también se indique como parámetro, a base de 
 * potencias repetitivas, de forma "iterativa" (no recursiva), usando la orden 
 * "for" (por ejemplo, "Potencia(3,2)" calculará (y devolverá) 3*3, mientras
 * que "Potencia(2,3)" calculará 2*2*2. Crea una función "PotenciaR", que 
 * calcule y devuelva una potencia como la anterior, pero de forma recursiva 
 * (por ejemplo, puede tomar como caso base que el segundo número sea 0). 
 * Prueba ambas desde Main.
 */

using System;

class Ejercicio88
{
    static long Potencia(int n1, int n2)
    {
        long resultado = 1;

        for (int i = 1; i <= n2; i++)
        {
            resultado *= n1;
        }          

        return resultado;
    }

    static long PotenciaR(int n1, int n2)
    {
        if (n2 == 0)
            return 1;
        return n1 * PotenciaR(n1, n2 - 1);
    }

    static void Main()
    {
        Console.WriteLine(Potencia(2,5));
        Console.WriteLine(PotenciaR(2,5));
    }
}
