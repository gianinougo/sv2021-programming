//Francis (...), retoques por Nacho

/* 85. Crea una función llamada "GetMinMax", que devolverá el mínimo y el máximo
 * del array de números reales de simple precisión que se pase como parámetro. 
 * Si el array está vacío, no devolverá ningún valor, sino que se deberá lanzar 
 * una excepción (para lo que no necesitas hacer nada especial: el programa 
 * fallará al acceder a la posición [0], y es un comportamiento aceptable). Crea 
 * un Main de prueba.*/


using System;
class ejercicio_85
{
    static void GetMinMax(float[] a, ref float min, ref float max)
    {
        max = min = a[0];
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] > max)
            {
                max = a[i];
            }

            if (a[i] < min)
            {
                min = a[i];
            }
        }
    }

    static void Main()
    { 
        Console.WriteLine("Longitud del array:");
        int longitud = Convert.ToInt32(Console.ReadLine());
        float[] array = new float[longitud];

        float minimo = 0;
        float maximo = 0;

        for (int i = 0; i < longitud; i++)
        {
            try
            {
                Console.WriteLine("Valor {0}:", i+1);
                array[i] = Convert.ToSingle(Console.ReadLine());
            }

            catch (Exception)
            {
                Console.WriteLine("Número incorrecto");
            }
        }

        GetMinMax(array, ref minimo, ref maximo);
        Console.WriteLine("Min = {0}, max = {1}", minimo, maximo);
    }
}
