// Tema 2 Semana 1 Recomendado 12 
// Ezequiel (...)
// Devuelve el nombre de un día de la semana a partir de su número, usando if
using System;

public class T2s1r12
{
    public static void Main()
    {
        int diaSemana;
        
        Console.WriteLine("Dime un día de la semana (entre 1 y 7)");
        diaSemana = Convert.ToInt32(Console.ReadLine());
        
        if (diaSemana == 1) Console.WriteLine("Es Lunes.");
        else if (diaSemana == 2) Console.WriteLine("Es Martes.");
        else if (diaSemana == 3) Console.WriteLine("Es Miércoles.");
        else if (diaSemana == 4) Console.WriteLine("Es Jueves.");
        else if (diaSemana == 5) Console.WriteLine("¡Es Viernes!.");
        else if (diaSemana == 6) Console.WriteLine("¡Es Sabado!.");
        else if (diaSemana == 7) Console.WriteLine("¡Es Domingo!.");
        else Console.WriteLine("El número debe estar entre 1 y 7.");
    }
}
