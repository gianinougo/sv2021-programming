/* 
 * VIRGINIA (...)
 * 43.Calcula el volumen de un cono, a partir de su radio y su altura, que 
 * introducirá el usuario. El volumen será "pi por el radio al cuadrado, 
 * multiplicado por la altura y dividido entre 3". Debes utilizar variables 
 * de tipo "float" y mostrar los resultados con dos decimales.
 */

using System;

class Ejercicio43
{
    static void Main()
    {
        float radio, altura, pi = 3.141592653589793238f, volumen;

        Console.Write("Radio? ");
        radio = Convert.ToSingle(Console.ReadLine());
        Console.Write("Altura? ");
        altura = Convert.ToSingle(Console.ReadLine());

        volumen = pi * radio * radio * altura / 3;

        Console.WriteLine("El volumen del cono es {0}.", 
            volumen.ToString("N2"));
    }
}
