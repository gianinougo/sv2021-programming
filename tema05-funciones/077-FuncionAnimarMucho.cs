/* Juan Manuel (...) 1º DAM Sem.*/

/* Ejercicio77.Crea una función llamada "AnimarMucho", que escriba
 * "Voy a aprobar " seguido del texto indicado en un primer 
 * parámetro (string). Esa frase se repetirá tantas veces como se
 * indique en un segundo parámetro numérico entero. 
 * Aplícala a un programa de prueba, que pregunte el nombre de la 
 * asignatura (o módulo) que sabes que vas a aprobar. En ese programa
 * de prueba, tu función estará declarada antes de Main.*/


using System;


class Ejercicio77
{

    static void AnimarMucho(string asignatura, int repetirVeces)
    {
        for (int i = 0; i < repetirVeces; i++)
        {
            Console.WriteLine("Voy a aprobar " + asignatura);
        }

    }

    static void Main(string[] args)
    {
        Console.WriteLine("Dime la asignatura : ");
        string asignatura = Console.ReadLine();
        Console.WriteLine("Dime las repetiones del texto : ");
        int repetirVeces = Convert.ToInt32(Console.ReadLine());
        
        AnimarMucho(asignatura, repetirVeces);
    }
}

