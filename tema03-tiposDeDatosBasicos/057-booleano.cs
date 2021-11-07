// Ejer.  57.
// Pide al usuario un número, que guardarás en una variable "numero".
//  Dale a una variable booleana llamada "par" el valor "true" 
// si "numero" es par, o un valor "false" si es impar.
//  Hazlo de dos formas: primero con "if" y luego con el operador ternario.

// Autor: Josep F. (...)

using System;

class Ejer_57
{
    static void Main()
    {
        int numero;
        bool par;

        Console.Write("Escribe un número: ");
        numero = Convert.ToInt32(Console.ReadLine());
            
        if ( numero % 2 == 0)
            par = true;
        else   
            par = false;
        Console.WriteLine("El número {0} es par: {1}", numero, par);
       
        par = numero %2 == 0 ? true : false ;
        Console.WriteLine("El número {0} es par: {1}", numero, par);
    }
}
