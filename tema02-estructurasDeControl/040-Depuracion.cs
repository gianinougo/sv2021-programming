/* 40. Depuración: Crea un programa que muestre ciertos valores de la función 
 * y = x^2 - 6x + 9 (usando para x valores enteros para x, en el rango desde 
 * -10 a +10) Añade un punto de interrupción en el momento en que calculas el 
 * valor de Y, y comprueba los valores de x^2 y de 6x.
*/

using System;

class Depuracion
{
    static void Main()
    {
        for (int x = -10; x <= 10; x++)
        {
            // Poner punto de interrupción en la siguiente orden
            // Y añadir "watch" para x*x y para 6*x
            int y = x*x - 6*x + 9;

            Console.WriteLine("{0} -> {1}", x, y);
        }
    }
}
  

