/*
 * VIRGINIA (...)
 * 
 * Goteras.
 * Entrada:
 * La entrada estará compuesta de un primer número indicando cuántos casos de 
 * prueba vendrán a continuación.
 * Cada caso de prueba será un número mayor que cero con el número de gotas 
 * que entran en el cubo.
 * Salida: 
 * Para cada caso de prueba, el programa escribirá en una línea el tiempo 
 * máximo que puedes estar sin cambiar el cubo en el formato HH:MM:SS.
 * Ningún cubo es tan grande como para poder estar más de un día completo 
 * sin cambiarse.
 */

using System;

class Reto1_05
{
    static void Main()
    {
        int casos, gotas, horas, min, seg;

        casos = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= casos; i++)
        {
            gotas = Convert.ToInt32(Console.ReadLine());

            horas = gotas / 3600;
            seg = gotas % 3600;
            min = seg / 60;
            seg = seg % 60;

            Console.WriteLine("{0}:{1}:{2}", horas.ToString("00"),
               min.ToString("00"), seg.ToString("00"));
        }
    }
}
