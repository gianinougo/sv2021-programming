// Tema 2 Semana 3 recomendado 27 
// Ezequiel (...)
// Muestra la tabla de multiplicar que escoja el usuario, usando "for"

using System;

class T2s3r27
{
    static void Main()
    {
        int numero, contador;
        
        Console.Write("Dime un número: ");
        numero = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Tabla del {0}", numero);
        for(contador = 0; contador <=10; contador++)
        {
            Console.WriteLine("{0} X {1} = {2}",
                numero, contador, numero * contador);
        }
        
    }
}
