// Ejer. 14 Muestre la "nota de texto" correspondiente a una 
// determinada "nota numérica"

// Autor: Josep F. (...)

using System;

class Ejer_14
{
    static void Main()
    {
        int NumNota;
        
        Console.Write("Escribe la nota del examen: ");
        NumNota = Convert.ToInt32(Console.ReadLine());

        if (NumNota <= 4) 
            Console.WriteLine("Suspenso");
        else if (NumNota == 5)
            Console.WriteLine("Aprobado");
        else if (NumNota == 6)
            Console.WriteLine("Bien");
        else if (NumNota <= 8)
            Console.WriteLine("Notable");
        else if (NumNota <= 10)
            Console.WriteLine("Sobresaliente");
        else
            Console.WriteLine("Has introducido una nota incorrecta.");


        switch (NumNota)
        {
            case 0: 
            case 1: 
            case 2: 
            case 3: 
            case 4: 
                Console.Write("Suspenso");
                break;
            case 5:
                Console.Write("Aprobado");
                break;
            case 6: 
                Console.Write("Bien");
                break;
            case 7: 
            case 8: 
                Console.Write("Notable");
                break;          
            case 9: 
            case 10: 
                Console.Write("Sobresaliente");
                break;      
            default : 
                Console.Write("Has introducido una nota incorrecta.");
                break;
        }
    }    
}
