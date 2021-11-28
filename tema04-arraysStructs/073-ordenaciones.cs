// Ejercicio recomendado 73
// Javier (...)
// Ordenaciones simples de un array de 10 enteros

/*
Crea un programa que pida al usuario 10 números enteros, los guarde en un array 
llamados "datosOriginales", y luego:

- Los copie a un array "datos1", ordene este array mediante intercambio directo 
(ya sea ascendente, descendente o burbuja, como prefieras) y muestre su 
contenido.

- Los copie a un array "datos2", ordene este array mediante selección directa y 
muestre su contenido.

- Los copie a un array "datos3", ordene este array mediante inserción directa y 
muestre su contenido.
*/

using System;

class Ordenaciones
{
    static void Main()
    {
        const int MAX = 10;
        
        int[] datosOriginales = new int [MAX];
        int[] datos1 = new int[MAX];
        int[] datos2 = new int[MAX];
        int[] datos3 = new int[MAX];

        // Pedimos los datos al usuario
        Console.WriteLine("Introduce 10 números:");
        for (int i = 0; i < MAX; i++)
        {
            Console.Write("Número {0}: ", i+1);
            datosOriginales[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Hacemos las tres copias
        for (int i=0; i<MAX; i++)
        {
            datos1[i] = datosOriginales[i];
            datos2[i] = datosOriginales[i];
            datos3[i] = datosOriginales[i];
        }

        Console.WriteLine("Datos originales:");
        foreach (int d in datosOriginales)
            Console.Write("{0} ", d);
        Console.WriteLine();
        
        // Ordenación burbuja (comparar cada uno con todos los siguientes)
        for (int i = 0; i < datos1.Length-1; i++)
        {
            for (int j = i+1; j < datos1.Length; j++)
            {
                if (datos1[i]>datos1[j])
                {
                    int aux = datos1[i];
                    datos1[i] = datos1[j];
                    datos1[j] = aux;
                }
            }
        }
        foreach (int d in datos1)
            Console.Write("{0} ", d);
        Console.WriteLine();

        // Ordenación por selección directa (se intercambia el menor)
        for (int i = 0; i < datos2.Length-1; i++)
        {
            int posicMenor = i;
            for (int j = i+1; j < datos2.Length; j++)
            {
                if (datos2[j] < datos2[posicMenor])
                    posicMenor = j;
            }
            if (posicMenor != i)
            {
                int aux = datos2[i];
                datos2[i] = datos2[posicMenor];
                datos2[posicMenor] = aux;
            }
        }
        foreach (int d in datos2)
            Console.Write("{0} ", d);
        Console.WriteLine();

        // Ordenación por inserción directa (insertar cada dato en la parte izqda)
        for (int i=1; i<datos3.Length; i++)
        {
            int j = i - 1;
            while (j >= 0 && datos3[j]>datos3[j+1])
            {
                int aux = datos3[j];
                datos3[j] = datos3[j + 1];
                datos3[j + 1] = aux;
                j--;
            }
        }
        foreach (int d in datos3)
            Console.Write("{0} ", d);
    }
}
