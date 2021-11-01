/*
 *  Alejandro (...)
 *  
 *  42. Calcula la superficie de un círculo, a partir de su radio, que introducirá
 *  el usuario en una variable real de doble precisión (area = pi * radio al cuadrado).
 *  Tanto el valor de "pi" como el resultado (la superficie) deben estar almacenados
 *  en variables, que también serán números reales de doble precisión. Recuerda
 *  que para elevar x al cuadrado, basta con hacer x*x.
 */

using System;
class Ejercicio_42
{
    static void Main()
    {
        double radio, pi = 3.14159265359, superficie;

        Console.WriteLine("Introduzca el radio: ");
        radio = Convert.ToDouble(Console.ReadLine());

        superficie = pi * radio * radio;

        Console.WriteLine("La superficie de un círculo con radio {0} es de {1}",
            radio, superficie);

        // Forma alternativa, con Math.Pow y probando formatos numéricos
        
        superficie = pi * Math.Pow(radio, 2);

        Console.WriteLine("La superficie de un círculo con radio {0} es de {1}",
            radio.ToString("0.00"), superficie.ToString("N2"));

    }
}
