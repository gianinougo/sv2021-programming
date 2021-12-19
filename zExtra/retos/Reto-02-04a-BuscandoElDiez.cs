// Reto 2.04 - Buscando el 10
// Javier (...)

/*Reto 2.04: Buscando el 10 (propuesto, sin nota) Buscando el diez
 * Te dan todas las notas que has obtenido en una asignatura. Cada nota es un
 * número entero entre 0 y 10 inclusive.
 * Suponiendo que en todas tus próximas tareas obtengas un 10, determina la
 * cantidad de tareas necesarias para obtener un 10. Recibirás un 10 si tu
 * promedio es de 9.5 o superior. Por ejemplo, si sus calificaciones son 8, 9,
 * entonces requerirá 4 tareas adicionales en las que tendrá que obtener 10. 
 * Con cada tarea, su promedio aumentará a 9, 9.25, 9.4 y 9.5.
 * 
 * Entrada
 * La entrada está en una línea que contiene todas las notas que se han
 * obtenido, separadas por una coma.
 * 
 * Salida
 * Escribe en una línea el número de tareas requeridas para obtener un 10.
 * 
 * Ejemplos de entrada
 * 9,10,10,9
 * 8,9
 * 0,0,0,0,0,0,0,0,0,0,0,0,0
 * 10,10,10,10
 * 
 * Ejemplos de salida
 * 0
 * 4
 * 247
 * 0
 * 
 * El problema que debes resolver:
 * Para la próxima entrada, escribe un programa que encuentre la respuesta.
 * 7,7,10,10,4,6,4,6,0,6,7,4,6,6,9
 * La respuesta que debes obtener es:
 * 101
 * 
 * (Primera Olimpiada de Computación Boliviana, Nivel 3, Tipo 1, Problema 1)*/

using System;

class BuscandoEl10
{

    static float CalcularMedia(string[] notas)
    {
        float suma = 0;

        foreach (string n in notas)
            suma += Convert.ToSingle(n);           

        return suma / notas.Length;
    }

    static void Main()
    {
        int tareas = 0;

        string texto = Console.ReadLine();
        string[] notas = texto.Split(',');
        float notaMedia = CalcularMedia(notas);
        
        while (notaMedia < 9.5)
        {
            texto = texto + ",10";
            notas = texto.Split(',');
            notaMedia = CalcularMedia(notas);
            tareas++;
        }

        Console.WriteLine(tareas);
    }
}
