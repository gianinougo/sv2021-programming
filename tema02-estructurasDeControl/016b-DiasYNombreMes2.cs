/*
 *  Alejandro (...)
 *  
 *  16. Crea una versión mejorada del ejercicio 15, que responda algo más
 *  amigable, como "Marzo, 31 días" (incluyendo también el nombre del mes).
 *  Puedes usar "if", "switch" o una combinación de ambos, de modo que el
 *  programa resultante sea tan legible y compacto como sea posible.
 */

using System;

class Ejercicio_16
{
    static void Main()
    {
        int mes;

        Console.Write("Introduzca el número de mes: ");
        mes = Convert.ToInt32(Console.ReadLine());
        
        switch (mes)
        {
            case 1: Console.Write("Enero, "); break;
            case 2: Console.Write("Febrero, "); break;
            case 3: Console.Write("Marzo "); break;
            case 4: Console.Write("Abril, "); break;
            case 5: Console.Write("Mayo, "); break;
            case 6: Console.Write("Junio, "); break;
            case 7: Console.Write("Julio, "); break;
            case 8: Console.Write("Agosto, "); break;
            case 9: Console.Write("Septiembre, "); break;
            case 10: Console.Write("Octubre, "); break;
            case 11: Console.Write("Noviembre, "); break;
            case 12: Console.Write("Diciembre, "); break;  
        }
        
        
        if ((mes == 1) || (mes == 3) || (mes == 5) || (mes == 7) || (mes == 8) ||
            (mes == 10) || (mes == 12))
        {
            Console.WriteLine("31 días.");
        }
        else if (mes == 2)
        {
            Console.WriteLine("28 días.");
        }
        else if ((mes == 4) || (mes == 6) || (mes == 9) || (mes == 11))
        {
            Console.WriteLine("30 días.");
        }
    }
}
