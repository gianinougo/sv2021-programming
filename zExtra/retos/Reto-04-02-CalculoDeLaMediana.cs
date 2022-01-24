﻿// Reto 4.02
// Javier (...)

/*
Reto 4.02: Cálculo de la Mediana (propuesto, sin nota)
Cálculo de la Mediana
Dado un conjunto (o muestra) de valores positivos ordenados, se define la
mediana como el valor que ocupa la posición central de los datos dados.
En el caso de tener un número impar de valores, la mediana está clara: 
será aquel valor que tenga el mismo número de valores más pequeños y más
grandes que él en la muestra. En el caso de tener un número par de valores,
habría dos candidatos a ser mediana. En vez de decidirnos por uno, en este
caso la mediana viene dada por la media aritmética de esos dos valores que
ocupan las posiciones centrales. Dada una colección de números positivos,
nos piden calcular la mediana. Para evitar tener que trabajar con números
decimales en algunos casos, habrá que calcular su doble.

Entrada
La entrada consta de una serie de casos de prueba. Cada uno comienza con un
número, menor o igual que 25.000, que indica la cantidad de valores que tiene
la muestra. A continuación se dan los valores de la muestra,
todos números enteros positivos, de los que habrá que calcular la mediana multiplicada
por dos.
La entrada terminará con una serie de 0 valores.

Salida
Para cada caso de prueba se mostrará el doble de la mediana de los valores dados.
Entrada de ejemplo
11
1 2 6 17 18 22 35 46 109 153 200
5
5 3 1 2 8
4
4 5 9 2
0
Salida de ejemplo
44
6
9

(Original en: https://www.aceptaelreto.com/problem/statement.php?id=161 )
*/

using System;

class CalcularMediana
{

    static int[] RecogerDatos(ref int muestrasTotales)
    {
        muestrasTotales = Convert.ToInt32(Console.ReadLine());
        int[] valores = new int[muestrasTotales];

        if (muestrasTotales != 0)
        {
            string entrada = Console.ReadLine();
            string[] partes = entrada.Split();            

            for (int i = 0; i < muestrasTotales; i++)
                valores[i] = Convert.ToInt32(partes[i]);

            Array.Sort(valores);
        }        

        return valores;
    }

    static float Media(int n1, int n2)
    {
        return (n1 + n2) / 2.0f;
    }

    static void Main()
    {
        int muestrasTotales = 0;
        int[] valores;
        int posicionMediana;
        float mediana;

        do
        {
            valores = RecogerDatos(ref muestrasTotales);
            if (muestrasTotales != 0)
            {
                if (muestrasTotales % 2 == 0)
                {
                    posicionMediana = (muestrasTotales / 2) - 1;
                    mediana = 2*(Media(valores[posicionMediana],
                        valores[posicionMediana + 1]));
                }
                else
                {
                    posicionMediana = muestrasTotales / 2;
                    mediana = 2 * valores[posicionMediana];
                }

                Console.WriteLine(mediana);
            } 
        }
        while (muestrasTotales != 0);
    }
}
