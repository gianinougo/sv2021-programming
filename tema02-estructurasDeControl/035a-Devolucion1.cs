/*
 * VIRGINIA (...)
 * 35. Crea un programa devuelva el cambio de una compra, utilizando siempre 
 * en primer lugar monedas (o billetes) del valor más grande posible. 
 * Supondremos que tenemos una cantidad ilimitada de monedas (o billetes) de 
 * 50, 10, 5 y 1, y que no hay decimales. La ejecución podría ser algo como :
 * Precio? 222
 * Pagado? 300
 * Tu cambio es 78: 50 10 10 5 1 1 1 
 */

using System;

class Ejercicio35
{
    static void Main()
    {
        int precio, pagado, cambio;

        Console.Write("Precio? ");
        precio = Convert.ToInt32(Console.ReadLine());
        Console.Write("Pagado? ");
        pagado = Convert.ToInt32(Console.ReadLine());

        cambio = pagado - precio; 

        Console.Write("Tu cambio es {0}:", pagado - precio);

        while (cambio >= 50)
        {
            Console.Write(" 50 ");
            cambio = cambio - 50;
        }
        
        while (cambio >= 10)
        {
            Console.Write(" 10 ");
            cambio = cambio - 10;
        }
        
        while (cambio >= 5)
        {
            Console.Write(" 5 ");
            cambio = cambio - 5;
        }
        
        while (cambio >= 1)
        {
            Console.Write(" 1 ");
            cambio = cambio - 1;
        }
        
        Console.WriteLine();
    }
}
