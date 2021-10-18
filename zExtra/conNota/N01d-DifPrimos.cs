/*
Ejercicio con nota N01. (Tema 2).

Crea un programa que pida al usuario dos números enteros y muestre la 
diferencia entre el menor número primo y el mayor número primo que hay entre 
esos dos números, ambos incluidos. Por ejemplo, si los números son el 1 y el 
10, el menor número primo de ese intervalo es el 2 y el mayor número primo es 
7, por lo que la respuesta sería 5 (el resultado de restar 7-2). Si no hubiera 
números primos en ese intervalo (por ejemplo, si los números son el 8 y el 9), 
la respuesta sería "No se ha encontrado ningún número primo". Daremos por 
sentado que el usuario va a introducir primero el menor de ambos números y 
luego el mayor. Si no lo hace en ese orden, no nos preocuparemos de que el 
programa no se comporte correctamente.

*/

using System;

class N01
{
    static void Main()
    {
        int divisores;
        int primoMasAlto = -1;
        int primoMasBajo = -1;

        Console.Write("Teclea el número inicial para buscar primos: ");
        int inicio = Convert.ToInt32(Console.ReadLine());
        Console.Write("Teclea el número final para buscar primos: ");
        int fin = Convert.ToInt32(Console.ReadLine());
        
        // Primero buscamos el más alto de ese rango
        int numero = fin;
        while ((numero >= inicio) && (primoMasAlto == -1))
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
        Console.WriteLine("Primo más alto encontrado: {0}", primoMasAlto);
        
        // Y luego el más bajo
        numero = inicio;
        while ((numero <= fin) && (primoMasBajo == -1))
        {
            divisores = 0;
            for (int divisorActual=1; divisorActual <= numero; divisorActual++)
                if (numero % divisorActual == 0)
                    divisores++;

            if (divisores == 2)
            {
                primoMasBajo = numero;
            }
            
            numero++;
        }
        Console.WriteLine("Primo más bajo encontrado: {0}", primoMasBajo);

        // Y finalmente respondemos
        if (primoMasAlto != -1)
            Console.WriteLine("Diferencia: {0}", primoMasAlto - primoMasBajo);
        else
            Console.WriteLine("No se ha encontrado ningún número primo");
    }
}
