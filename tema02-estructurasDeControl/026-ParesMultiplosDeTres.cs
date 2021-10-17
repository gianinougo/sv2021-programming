// Ejercicio recomendado 26

// Pide 2 números y responde cuántos hay entre ellos que sean
// pares y múltiplos de 3

// Javier (...)

using System;

class Pares
{
    static void Main()
    {
        int n1, n2, mayor, menor, cantidad=0;
        
        Console.Write("Número inicial? ");
        n1=Convert.ToInt32(Console.ReadLine());
        Console.Write("Número final? ");
        n2=Convert.ToInt32(Console.ReadLine());
        
        // Nota: buscar el menor de los dos números es una mejora que
        // no se pedía en este ejercicio; bastaba con que sólo se 
        // comportase bien cuando el primero es el menor
        if (n1>n2)
        {
            mayor=n1;
            menor=n2;
        }
        else 
        {
            mayor=n2;
            menor=n1;
        }
            
        for (int i=menor; i<=mayor; i++)
        {
            if ((i%2 == 0) && (i%3 == 0))
                cantidad++;
        }
        Console.Write("Números pares y a la vez múltiplos de 3 ");
        Console.WriteLine("encontrados: {0}", cantidad);
    }
}
