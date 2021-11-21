/*Ejercicio 67
 * Esteban (...), retoques por Nacho
 * Crea una variante del programa anterior, que pregunte al usuario cuántos
 * datos guardará en un primer bloque de números reales de simple precisión,
 * luego cuántos datos guardará en un segundo bloque, y finalmente pida los 
 * datos en sí. Los debe guardar en un array de arrays. Después mostrará el 
 * promedio de los valores que hay guardados en el primer subarray, luego el 
 * promedio de los valores en el segundo subarray y finalmente el promedio global.
*/

using System;

class ArraysDeArrays
{
    static void Main()
    {
        const int FILAS = 2;
        float[][] datos = new float[FILAS][];

        for (int fila = 0; fila < FILAS; fila++)
        {
            Console.WriteLine("Tamaño de esta fila: ");
            int columnas = Convert.ToInt32(Console.ReadLine());
            datos[fila]= new float[columnas];

            for (int columna = 0; columna < columnas; columna++)
            {
                Console.WriteLine("Diga su dato:{0},{1} ", fila+1, columna+1);
                datos[fila][columna] = Convert.ToSingle(Console.ReadLine());
            }
        }
        
        
        for (int fila = 0; fila < datos.Length; fila++)
        {
            float sumaFila = 0;
            for (int columna = 0; columna < datos[fila].Length; columna++)
            {
                sumaFila += datos[fila][columna];
            }
            Console.WriteLine("La media de la fila es: "+ 
                sumaFila / datos[fila].Length);
        }
        
        float suma = 0;
        int contador = 0;
        foreach (float[] filas in datos)
        {
            foreach (float dato  in filas)
            {
                suma += dato;
                contador++;
            }
        }
        Console.WriteLine("La media global es: "+suma/contador);
    }
}

