// Joaquin Selma Mirete
// Ejercicio 10

/*
Pide dos números al usuario y responde cuántos de ellos son impares. No debes 
usar un contador, sino condiciones encadenadas.
*/

using System;

class Ej10
{

    static void Main()
    {
        
        int n1, n2;
        
        Console.Write("Introduce un numero: ");
        n1 = Convert.ToInt32( Console.ReadLine() );
        Console.Write("Introduce otro numero: ");
        n2 = Convert.ToInt32( Console.ReadLine() );
        
        if ( ( n1 % 2 != 0) && (n2 % 2 !=0 ) )
        {
            Console.Write("Ambos numeros son impares");
        }
        else if ( ( n1 % 2 == 0) && (n2 % 2 ==0 ) )
        {
            Console.Write("Ninguno es impar");
        }
        else
        {
            Console.Write("Uno de los numeros es impar.");
        }
        
        /* Alternativa más larga para ver si uno es impar: 
        if ( (( n1 % 2 == 0 ) && ( n2 % 2 != 0 )) || 
                (( n1 % 2 != 0 ) && ( n2 % 2 == 0 )) )
        */
    }
}
