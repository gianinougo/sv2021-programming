/* Juan Manuel (...) 1º DAM Sem */

/*Ejercicio 84.Crea tres versiones de una función para duplicar números y
 * prueba todas ellas desde un único Main:
 * -La primera será una función entera llamada "Duplicar1", que devolverá
 * duplicado el valor del número entero pasado como parámetro (por ejemplo,
 * si el parámetro es 6, se devolverá 12).
 * -La segunda será un procedimiento (función "void") llamado "Duplicar2",
 * que duplicará el valor del número entero pasado como parámetro 
 * (por ejemplo, si el parámetro es 5, se convertirá en 10), sin usar "ref".
 * Tras llamar a la función, comprueba ha cambiado el valor de la variable 
 * que has pasado como parámetro.
 * - La tercera será un procedimiento llamado "Duplicar3", que duplicará el
 * valor de un número entero que se le pasará como parámetro ref (por ejemplo,
 * si el parámetro es 3, se convertirá en 6). Tras llamar a la función,
 * comprueba ha cambiado el valor de la variable que has pasado como parámetro.*/


using System;



class Ejercicio84
{
    
    static int Duplicar1(int numero)
    {
        return numero * 2;
    }

    static void Duplicar2(int numero)
    {
      numero *= 2;
    }

    static void Duplicar3(ref int numero)
    {
        numero *= 2;
    }

    static void Main()
    {
        int numeroOriginal, numeroAux1, numeroAux2, numeroAux3;
        Console.Write(" Dame un número entero : ");
        numeroOriginal = Convert.ToInt32(Console.ReadLine());
        numeroAux1 = numeroAux2 = numeroAux3 = numeroOriginal;

        Console.WriteLine(" Duplicar1 entrada {0} salida {1}", 
            numeroOriginal, Duplicar1(numeroAux1));

        Duplicar2(numeroAux2);
        Console.WriteLine(" Duplicar2 entrada {0} salida {1}", 
            numeroOriginal, numeroAux2);

        Duplicar3(ref numeroAux3);
        Console.WriteLine(" Duplicar3 entrada {0} salida {1}", 
            numeroOriginal, numeroAux3);
    }
}
