// Francis (...)- DAM Semipresencial

/* 65. Crea un programa que pida al usuario un número entero positivo y 
 * muestre su equivalente en forma binaria, usando un array como paso 
 * intermedio para guardar los resultados temporales. Supondremos que el 
 * número cabe en 8 bits (un byte).
 * 
 * El algoritmo es el siguiente: divide el número entre 2 tantas veces como 
 * sea posible hasta que el número se convierta en uno, y toma todos los 
 * restos en orden inverso:
 * 
 * 35: 2 = 17, resto 1
 * 17: 2 = 8, resto 1
 * 8: 2 = 4, resto 0
 * 4: 2 = 2, resto 0
 * 2: 2 = 1, resto 0
 * 1, terminado
 * 
 * por lo que el número sería 00100011 (o 100011, sin los 0 iniciales).
 * Puedes usar ".ToString" para verificar que tu algoritmo funciona bien, 
 * pero no como único método de resolución.*/

using System;

class Ejercicio65
{
    static void Main ()
    {
        int capacidadBinario = 8;
        int numUsuario = 0;
        int resto = 0;
        int i;
        int[] numBinario = new int [capacidadBinario];
        
        Console.WriteLine ("Escribe un número entero positivo: ");
        numUsuario = Convert.ToInt32 (Console.ReadLine () );
        Console.WriteLine("Resultado esperado: " + Convert.ToString(numUsuario,2));
          
        for (i = 0; i < capacidadBinario; i++)
        {
            Console.WriteLine ("{0} : {1} = {2}, resto {3}", 
            numUsuario, 2, numUsuario / 2, numUsuario % 2);
            
            resto = numUsuario % 2;
            numUsuario /= 2;
            numBinario[i] = resto;
        }
        
        for (i = 7; i >= 0; i--)
        {
            Console.Write (numBinario[i]);
        }
        Console.WriteLine();
        
    }
}
