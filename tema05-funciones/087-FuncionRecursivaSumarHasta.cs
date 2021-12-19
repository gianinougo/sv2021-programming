/*
87. Crea una función "SumarHasta(n)", que calcule y devuelva la suma de los 
números enteros desde 1 hasta n, calculada de forma iterativa (con un bucle 
"for"). Por ejemplo, para n=4, deberá devolver 10 (que es el resultado de 
1+2+3+4). Crea una variante llamada "SumarHastaR(n)" que haga el mismo proceso 
de forma recursiva. Crea un Main de prueba que compruebe si ambas funciones se 
comportan igual para todos
los números desde 0 hasta 1000.
*/

// Rocio (...)

using System;

class FuncionRecursividad87
{
    static void Main()
    {
        int num = 1000;
        Console.WriteLine("Funcion: "+SumarHasta(num));
        Console.WriteLine("Recursiva: "+SumarHastaR(num));
    }

    private static int SumarHasta(int n)
    {
        int totalSuma = 0;
        for (int i = 0; i <= n; i++)
        {
            totalSuma = totalSuma + i;
        }
        return totalSuma;
    }
    
    private static int SumarHastaR(int n)
    {
        if (n==1) 
        {
            return 1;
        }
        else
        {
            return n + (SumarHastaR(n - 1)); 
        }
    }
}
