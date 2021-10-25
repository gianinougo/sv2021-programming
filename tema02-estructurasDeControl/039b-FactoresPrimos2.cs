/*
    39. Escribe un programa que le pida al 
    usuario un número entero y muestre sus 
    factores primos, usando la estructura 
    repetitiva que consideres más adecuada. 
    Por ejemplo, para 15 deberá responder 
    "3 5", para 24 responderá "2 2 2 3" 
    y para 60 deberá escribir "2 2 3 5".
*/

// Franco (...)

using System;

class MuestraFactoresPrimos 
{
    static void Main() 
    {
        int numUsuario;

        Console.Write("Numero? ");
        numUsuario = Convert.ToInt32(Console.ReadLine());

        int divisor = 2; 
        while (numUsuario > 1) 
        {
            while (numUsuario % divisor == 0)
            {
                Console.Write("{0} ", divisor);
                numUsuario /= divisor;
            }
            divisor++;
        }
        Console.WriteLine();
    }
}
