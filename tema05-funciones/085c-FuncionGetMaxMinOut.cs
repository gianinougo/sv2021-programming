// Ejercicio recomendado 85
// Javier (...)

/* 85. Crea una función llamada "GetMinMax", que devolverá el mínimo y el máximo
 * del array de números reales de simple precisión que se pase como parámetro. 
 * Si el array está vacío, no devolverá ningún valor, sino que se deberá lanzar 
 * una excepción (para lo que no necesitas hacer nada especial: el programa 
 * fallará al acceder a la posición [0], y es un comportamiento aceptable). Crea 
 * un Main de prueba.*/

using System;

class Ejercicio85
{
    static void Main()
    {
        const int MAX = 10;
        Random generador = new Random();
        float[] datos = new float[MAX];

        for (int i = 0; i < MAX; i++)
            datos[i] = (float)generador.NextDouble()*100;

        float minimo, maximo;

        GetMinMax(datos, out minimo, out maximo);
        foreach (float d in datos)
            Console.Write("{0} ", d.ToString("N3"));
        Console.WriteLine();
        Console.WriteLine("Mínimo: {0}", minimo.ToString("N3"));
        Console.WriteLine("Máximo: {0}", maximo.ToString("N3"));
    }

    static void GetMinMax(float[] datos, out float min, out float max)
    {
        min = datos[0];
        max = datos[0];
        foreach (float d in datos)
        {
            if (min > d)
                min = d;
            if (max < d)
                max = d;
        }
    }
}
