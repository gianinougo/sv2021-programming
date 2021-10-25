// Ejercicio recomendado 38
// Dibuja un rectángulo hueco con un número como símbolo

// Francisco José (...)

using System;

class RectanguloHueco
{
    static void Main()
    {
        int ancho, alto, numero;

        Console.WriteLine("Digame el ancho");
        ancho = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Digame el alto");
        alto = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Digame el número");
        numero = Convert.ToInt32(Console.ReadLine());

        
        // Primera fila
        for (int a = 1; a <= ancho; a++)
        {
            Console.Write(numero);
        }
        Console.WriteLine();

        // Filas intermedias
        for (int a = 1; a < alto - 1; a++)
        {
            Console.Write(numero);
            for (int b = 1; b <= ancho - 2; b++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(numero);
        }
        
        // Ultima fila
        for (int a = 1; a <= ancho; a++)
        {
            Console.Write(numero);
        }
        Console.WriteLine();    
    }
}
