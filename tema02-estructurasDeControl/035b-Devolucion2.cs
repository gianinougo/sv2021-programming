/*35.Programa devuelva el cambio de una compra, utilizandosiempre en primer 
lugar monedas (o billetes) del valor más grande posible
Rocio (...) */
using System;
class Devolucion35
{
    static void Main()
    {
        Console.Write("Introduzca el precio a pagar: ");
        int precio = Convert.ToInt32(Console.ReadLine());
        Console.Write("Introduzca el efectivo entregado: ");
        int pagado = Convert.ToInt32(Console.ReadLine());
        int devolucion = pagado - precio;
        
        
        Console.WriteLine("Total a devolver: "+devolucion);
        while (devolucion != 0)
        {
            if (devolucion >= 50)
            {
                Console.Write("50 ");
                devolucion = devolucion - 50;
            }
            else if (devolucion >= 10)
            {
                Console.Write("10 ");
                devolucion = devolucion - 10;
            }
            else if (devolucion >= 5)
            {
                Console.Write("5 ");
                devolucion = devolucion - 5;
            }
            else if (devolucion >= 1)
            {
                Console.Write("1 ");
                devolucion = devolucion - 1;
            }
        }
        Console.WriteLine();
    }
}
