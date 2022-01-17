/*
Reto 3.01: ¿Es matriz identidad?

Se dice que una matriz es identidad cuando todos sus elementos son cero a 
excepción de la diagonal principal, que se encuentra rellena de unos:

I3 = [
100
010
001
]

Para que una matriz sea identidad debe de ser cuadrada, es decir, tener el 
mismo número de filas que de columnas.

Entrada

La entrada consta de una serie de casos de prueba. Cada uno comienza con un 
número que representa el número de filas, como máximo 50, de una matriz 
cuadrada. Tras él, aparecen los elementos que forman la matriz, que serán 
valores entre -1.000 y 1.000 (incluídos).

La entrada terminará con una matriz de 0 filas.

Salida

Para cada caso de prueba se indicará SI si la matriz es identidad y NO en caso 
contrario.

Entrada de ejemplo
3
1 0 0
0 1 0
0 0 1
2
0 1
1 0
5
1 0 0 0 0
0 5 0 0 0
0 0 1 0 0
0 0 0 1 0
0 0 0 0 1
0

Salida de ejemplo
SI
NO
NO
*/

// Javier (...)

using System;

class Reto301
{
    static void Main()
    {
        bool esIdentidad = true;
        byte filas;

        do
        {            
            byte fila = 0, columna = 0;
            filas = Convert.ToByte(Console.ReadLine());
            int[,] matriz = new int[filas, filas];

            if (filas != 0)
            {
                for (int i = 0; i < filas; i++)
                {
                    string datos = Console.ReadLine();
                    string[] partes = datos.Split();
                    for (int j = 0; j < filas; j++)
                        matriz[i, j] = Convert.ToInt32(partes[j]);                    
                }

                while (esIdentidad && fila < filas)
                {
                    while (esIdentidad && columna < filas)
                    {
                        if (fila == columna && matriz[fila, columna] != 1)
                            esIdentidad = false;
                        else if (fila != columna && matriz[fila, columna] != 0)
                            esIdentidad = false;

                        columna++;
                    }
                    columna = 0;
                    fila++;
                }

                if (esIdentidad)
                    Console.WriteLine("SI");
                else
                {
                    Console.WriteLine("NO");
                    esIdentidad = true;
                }
            }            
        }
        while (filas != 0);
    }
}
