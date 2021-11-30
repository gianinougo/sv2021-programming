// Ejercicio recomendado 38
// Dibuja un rectángulo hueco con un número como símbolo

// Versión alternativa con "new string"

using System;

class RectanguloHueco3
{
    static void Main()
    {
        Console.WriteLine("Digame el ancho");
        int ancho = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Digame el alto");
        int alto = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Digame el simbolo");
        char simbolo = Convert.ToChar(Console.ReadLine());
        
        string lineaAsteriscos = new string(simbolo, ancho);
        string lineaCentral = simbolo + new string(' ', ancho-2) + simbolo;
        
        Console.WriteLine(lineaAsteriscos);
        for (int fila = 1; fila <= alto - 2; fila++)
            Console.WriteLine(lineaCentral);
        Console.WriteLine(lineaAsteriscos);
    }
}
