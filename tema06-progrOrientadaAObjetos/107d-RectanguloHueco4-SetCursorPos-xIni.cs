// Ejercicio recomendado 38
// Dibuja un rectángulo hueco con un número como símbolo
// Variante con Console.SetCursorPosition y comienzo distinto de (1,1)

using System;

class Rectangulo
{
    static void Main()
    {
        int ancho = 10, alto = 5, xIni = 20, yIni = 8, num = 0;
                
        for (int fila=yIni; fila<=yIni+alto-1; fila++)
        {
            for (int col=xIni; col<=xIni+ancho-1; col++)
            {
                if ((fila==yIni)||(fila==yIni+alto-1) 
                    || (col==xIni)||(col==xIni+ancho-1))
                {
                    Console.SetCursorPosition(col, fila);
                    Console.Write(num);
                }
            }
            Console.WriteLine();
        }
    }
}
                
                
