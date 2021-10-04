/*
 13. Pregunta al usuario el número de un día de la semana
 y muestra su nombre, usando "switch".
 
 Franco (...)
*/

using System;

class DiasSemanaSwitch
{

    static void Main()
    {
        int numeroDia;

        Console.WriteLine("Introduce un numero: ");
        numeroDia = Convert.ToInt32(Console.ReadLine());

        switch (numeroDia)
        {
            case 1:
                Console.WriteLine("El dia {0} es Lunes", numeroDia);
                break;
            case 2:
                Console.WriteLine("El dia {0} es Martes", numeroDia);
                break;
            case 3:
                Console.WriteLine("El dia {0} es Miercoles", numeroDia);
                break;
            case 4:
                Console.WriteLine("El dia {0} es Jueves", numeroDia);
                break;
            case 5:
                Console.WriteLine("El dia {0} es Viernes", numeroDia);
                break;
            case 6:
                Console.WriteLine("El dia {0} es Sabado", numeroDia);
                break;
            case 7:
                Console.WriteLine("El dia {0} es Domingo", numeroDia);
                break;
            default:
                Console.WriteLine("Error. Introduce un numero valido. [1-7]");
                break;
        }
    }
}
