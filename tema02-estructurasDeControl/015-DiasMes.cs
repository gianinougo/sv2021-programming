// 15. Programa con "if" y "switch" que muestre 
// cuántos días tiene el mes indicado

// Rocio (...)

using System;

class DiasdelMesIfandSwitch15
{
    static void Main()
    {
        int mes;
        Console.WriteLine("Indique el numero de un mes");
        mes = Convert.ToInt32(Console.ReadLine());

        if ((mes == 1) || (mes == 3) || (mes == 5) || (mes == 7)
            || (mes == 8) || (mes == 10) || (mes == 12))
        {
            Console.WriteLine("31 dias");
        }
        else if (mes == 2)
        {
            Console.WriteLine("28 dias");
        }
        else if ((mes == 4) || (mes == 6) || (mes == 9) || (mes == 11))
        {
            Console.WriteLine("30 dias");
        }
        else
        {
            Console.WriteLine("El numero indicado no coincide con ningun numero del mes");
        }


        switch (mes)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                Console.WriteLine("31 dias");
                break;
            case 2:
                Console.WriteLine("28 dias");
                break;
            case 4:
            case 6:
            case 9:
            case 11:
                Console.WriteLine(" 30 dias");
                break;
            default:
                Console.WriteLine("El numero indicado no coincide con ningun numero del mes");
                break;
        }
    }
}

