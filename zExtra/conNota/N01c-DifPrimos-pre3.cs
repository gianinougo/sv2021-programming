/*
Ejercicio con nota N01. (Tema 2).

Crea un programa que pida al usuario dos números enteros y muestre la 
diferencia entre el menor número primo y el mayor número primo que hay entre 
esos dos números, ambos incluidos.

Aproximación 3: Número primo más cercano a un número pero menor que él
*/

using System;

class N01Pre3
{
    static void Main()
    {
        int divisores;
        int primoMasAlto = -1;

        Console.Write("Teclea el número tope para buscar el primo más alto: ");
        int fin = Convert.ToInt32(Console.ReadLine());
        
        int numero = fin;
        while ((numero > 1) && (primoMasAlto == -1))
        {
            divisores = 0;
            for (int divisorActual=1; divisorActual <= numero; divisorActual++)
                if (numero % divisorActual == 0)
                    divisores++;

            if (divisores == 2)
            {
                primoMasAlto = numero;
            }
            
            numero--;
        }
        Console.Write("Primo más alto encontrado: ");

        if (primoMasAlto != -1)
            Console.WriteLine(primoMasAlto);
        else
            Console.WriteLine("Ninguno");
    }
}
