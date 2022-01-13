// Ejercicio recomendado 38
// Dibuja un rectángulo hueco con un número como símbolo
// Variante con Console.SetCursorPosition compactada

using System;

class Rectangulo
{
    static void Main()
    {
        int ancho = 10, alto = 5, num = 0;
                
        for (int fila=1; fila<=alto; fila++)
        {
            for (int col=1; col<=ancho; col++)
            {
                if ((fila==1)||(fila==alto) || (col==1)||(col==ancho))
                {
                    Console.SetCursorPosition(col, fila);
                    Console.Write(num);
                }
            }
            Console.WriteLine();
        }
    }
}
                
                
