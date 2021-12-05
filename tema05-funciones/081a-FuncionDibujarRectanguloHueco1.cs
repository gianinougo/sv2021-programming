// 81. Función llamada "DibujarRectanguloHueco", que mostrará un rectángulo hueco

// Rocio (...)

/* Crea una función llamada "DibujarRectanguloHueco", que mostrará un 
rectángulo hueco con el ancho, el alto y el carácter que se indiquen como 
parámetros. Añade un "Main" de prueba. */

using System;

class DibujarRectanguloHueco81
{
    static void Main()
    {
      
        DibujarRectanguloHueco(8,6,'j');
    }

    static void DibujarRectanguloHueco(int alto,int ancho, char caracter)
    {
        for (int fila = 1; fila <= alto; fila++)
        {
            for (int columna = 1; columna <= ancho; columna++)
            {
                if (columna == 1 || columna == ancho || 
                    fila == 1 || fila == alto)
                {
                    Console.Write(caracter);
                }
                else
                {
                    Console.Write(' ');
                }
            }
            Console.WriteLine();
        }
    }
}

