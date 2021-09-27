/*
Muestra la tabla de multiplicar del número escogido por el usuario, usando las 
estructuras que consideres más adecuadas... de las que conoces por ahora. El 
programa será MUY repetitivo, pero en el próximo tema veremos cómo hacerlo más 
eficiente usando bucles.
*/

// Víctor (...)

using System;

class TablaMulti
{
    static void Main()
    {   
        int n;
        
        Console.Write("Escribe un número para ver su tabla de multiplicar ");
        n = Convert.ToInt32( Console.ReadLine() );

        Console.WriteLine("{0} x 0 = {1}", n, n * 0);
        Console.WriteLine("{0} x 1 = {1}", n, n * 1);
        Console.WriteLine("{0} x 2 = {1}", n, n * 2);
        Console.WriteLine("{0} x 3 = {1}", n, n * 3);
        Console.WriteLine("{0} x 4 = {1}", n, n * 4);
        Console.WriteLine("{0} x 5 = {1}", n, n * 5);
        Console.WriteLine("{0} x 6 = {1}", n, n * 6);
        Console.WriteLine("{0} x 7 = {1}", n, n * 7);
        Console.WriteLine("{0} x 8 = {1}", n, n * 8);
        Console.WriteLine("{0} x 9 = {1}", n, n * 9);
        Console.WriteLine("{0} x 10 = {1}", n, n * 10);
    }
}

