// Ejercicio recomendado 48
// Javier (...)
// Calcula las soluciones de y=Ax^2 + Bx + C

using System;

// y=Ax^2 + Bx + C
// Ax^2 + Bx + C-y = 0
// x = (-b +- sqrt(b^2 - 4a(c-y))) /2a

class Ecuacion
{
    static void Main()
    {
        double a, b, c, discriminante, x1, x2;

        Console.Write("Introduce el valor de a: ");
        a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Introduce el valor de b: ");
        b = Convert.ToDouble(Console.ReadLine());
        Console.Write("Introduce el valor de c: ");
        c = Convert.ToDouble(Console.ReadLine());

        if (a == 0)
        {
            if (b == 0)
            {
                if (c == 0)
                {
                    Console.WriteLine("El resultado es la igualdad 0==0");
                }
                else
                {
                    Console.WriteLine("No hay solución posible");
                }
            }
            else
            {
                // x=-c/b
                x1 = -c / b;
                Console.WriteLine("El resultado es -{0}/{1} = {2}", c, b, x1);
            }
        }
        else
        {
            discriminante = b * b - 4 * a * c;
            if (discriminante < 0)
                Console.WriteLine("No hay solución posible");
            else
            {
                x1 = (-b + Math.Sqrt(discriminante)) / (2 * a);
                x2 = (-b - Math.Sqrt(discriminante)) / (2 * a);
                Console.WriteLine("Solución 1: {0}", x1);
                Console.WriteLine("Solución 2: {0}", x2);
            }
        }
    }
}
