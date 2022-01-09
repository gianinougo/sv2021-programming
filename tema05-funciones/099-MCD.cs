//Victor (...), retoques por Nacho

/* 99. El máximo común divisor (MCD) de dos números A y B se puede calcular de 
forma recursiva utilizando el algoritmo de Euclides: si B es 0, la respuesta es 
A; De lo contrario, la respuesta será el MCD de B y A%B. Crea dos funciones que 
devuelvan el MCD de dos números enteros largos: uno debe ser iterativo (NO 
recursivo, sino usando "for" o "while"), y debe llamarse "Mcd". La segunda 
función debe hacerlo de forma recursiva, utilizando el algoritmo de Euclides y 
debe llamarse "McdR".   */

using System;

class Ejercicio99
{
    static void Main()
    {
        int a, b;
        Console.WriteLine("Número 1?");
        a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Número 2?");
        b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(McDR(a, b));
        Console.WriteLine(McD(a, b));
    }
    
    static int McD(int a, int b)
    {
        while (b != 0)
        {
            int auxiliar = b;
            b = a % b;
            a = auxiliar;
        } 
        return a;
    }
    
    static int McDR(int a, int b)
    {
        if (b == 0)
            return a;
        else
            return McDR(b, a % b);
    }
}

