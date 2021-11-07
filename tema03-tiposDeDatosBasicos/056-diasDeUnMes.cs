using System;

/* Ivan (...)
56. Haz un programa que pida al usuario el nombre de un mes (por ejemplo "marzo") y le 
responda cuántos días tiene (usando el formato "marzo tiene 31 días").
*/

class Program
{
    static void Main()
    {
        string mes;

        Console.WriteLine("Ingrese el nombre de un mes");
        mes = Console.ReadLine();

        switch(mes)
        {

            case "Enero":
            case "Marzo":
            case "Mayo":
            case "Julio":
            case "Agosto":
            case "Octubre":
            case "Diciembre":
                Console.WriteLine("El mes {0} tiene 31 días", mes);
                break;
            case "Febrero":
                Console.WriteLine("El mes {0} tiene 28 días", mes);
                break;
            default: Console.WriteLine("El mes {0} tiene 30 días", mes);
                break;
        }
    }
}
