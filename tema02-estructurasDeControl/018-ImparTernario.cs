/* Pide al usuario un número, que guardarás en una variable "numero". 
 * Dale a una variable llamada "impar" el valor 1 si "numero" es impar, 
 * o un valor 0 si es par. Hazlo de dos formas: primero con "if" y luego 
 * con el operador ternario. Recuerda que para saber si es par o impar, 
 * puedes mirar el resto de su división entre 2.*/

// Ugo ...

using System;


class Ejercicio118
{
    static void Main()
    {
        int numero, impar;

        Console.Write("Dime un número: ");
        numero = Convert.ToInt32(Console.ReadLine());

        // Versión con "if"
        if (numero % 2 == 0)
            impar = 0;
        else
            impar = 1;
        
        Console.WriteLine("Impar? {0}", impar);

        // Versión con "operador condicional"
        impar = numero % 2 == 0 ? 0 : 1;
        Console.WriteLine("Impar? {0}", impar);

    }
}

