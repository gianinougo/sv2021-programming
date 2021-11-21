//Francis (...), retoques por Nacho

/* 66. Crea un programa que pida al usuario 12 números reales de simple 
 * precisión, los guarde en una matriz bidimensional de 2x6 datos, y luego 
 * muestre el promedio de los valores que hay guardados en la primera mitad 
 * de la matriz, luego el promedio de los valores en la segunda mitad de la 
 * matriz y finalmente el promedio global.*/

using System;

class ejercicio66
{
    static void Main ()
    {
        const byte FILAS = 2, COLUMNAS = 6;
        float[,] numeros = new float[FILAS, COLUMNAS];
        float numIntroducido, totalBloque1 = 0, totalBloque2 = 0;
        
        for (byte i = 0; i < FILAS; i++)
        {
            for (byte j = 0; j < COLUMNAS; j++)
            {
                Console.Write("Escribe el número {0} del bloque {0}: ",
                    j+1, i+1);
                numIntroducido = Convert.ToSingle(Console.ReadLine());
                
                numeros[i, j] = numIntroducido;
            }
            
            Console.WriteLine();
        }
        
        // Cálculo de medias, forma 1
        for (byte j = 0; j < COLUMNAS; j++)
        {
            totalBloque1 += numeros[0, j];
        }   
        Console.WriteLine("El promedio del bloque 1 es: {0}",
            totalBloque1 / COLUMNAS);
                    
        for (byte j = 0; j < COLUMNAS; j++)
        {
            totalBloque2 += numeros[1, j];
        }   
        Console.WriteLine("El promedio del bloque 2 es: {0}",
            totalBloque2 / COLUMNAS);
                    
        Console.WriteLine("El promedio Global es: {0}",
            (totalBloque1 + totalBloque2) / (COLUMNAS*FILAS) );
            
            
        // Cálculo de medias, forma 2
        for (byte i = 0; i < FILAS; i++)
        {
            float totalFila = 0;
            for (byte j = 0; j < COLUMNAS; j++)
            {
                totalFila += numeros[i, j];
            }    
            Console.WriteLine("El promedio del bloque {0} es: {1}",
                i, totalFila / COLUMNAS);
        }
        
        float totalGlobal = 0;
        foreach(float dato in numeros)
            totalGlobal += dato;
                    
        Console.WriteLine("El promedio Global es: {0}",
            totalGlobal / (COLUMNAS*FILAS) );
    }
}
