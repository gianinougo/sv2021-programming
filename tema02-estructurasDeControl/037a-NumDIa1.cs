/*Pide al usuario el número de un mes y el número de un día, y muestre de qué
 número de día dentro del año se trata, en un año no bisiesto.*/

// Francisco José (...)
 
using System;

class NumeroDia
{
    static void Main()
    {
        int mes, dia;

        Console.WriteLine("Dime el mes en numero");
        mes = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Dime el dia del mes");
        dia = Convert.ToInt32(Console.ReadLine());


        switch (mes)
        {
            case 1:
                Console.WriteLine(dia);
                break;
            case 2:
                Console.WriteLine(31 + dia);
                break;
            case 3:
                Console.WriteLine(59 + dia);
                break;
            case 4:
                Console.WriteLine(90 + dia);
                break;
            case 5:
                Console.WriteLine(120 + dia);
                break;
            case 6:
                Console.WriteLine(151 + dia);
                break;
            case 7:
                Console.WriteLine(181 + dia);
                break;
            case 8:
                Console.WriteLine(212 + dia);
                break;
            case 9:
                Console.WriteLine(243 + dia);
                break;
            case 10:
                Console.WriteLine(273 + dia);
                break;
            case 11:
                Console.WriteLine(304 + dia);
                break;
            case 12:
                Console.WriteLine(334 + dia);
                break;

        }
    }
}
