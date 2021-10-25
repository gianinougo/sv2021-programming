// Tema 2 Semana 4 recomendado 36 
// Ezequiel (...)

/*Muestra un calendario, pidiendo al usuario la cantidad de días del mes 
(por ejemplo, 31) y el número en la semana del primer día (por ejemplo, 
 2 para el martes*/
 
using System;
public class T2s4r36
{
    public static void Main()
    {
        int diasMes, diasInicio, numeroDiaSemana = 1;
    
        Console.Write("Cuantos días tiene el mes(28-31)? ");
        diasMes = Convert.ToInt32(Console.ReadLine());

        Console.Write("Que día inicia el calendario(1-7)? ");
        diasInicio = Convert.ToInt32(Console.ReadLine());
        
        if(diasMes >= 28 && diasMes <= 31 && diasInicio >= 1 && diasInicio <= 7)
        {
            Console.WriteLine(" L   M   X   J   V   S   D");
            
            if (diasInicio > 1)
            {
                for(int j = 1; j < diasInicio; j++)Console.Write("    ");
                numeroDiaSemana = diasInicio;
            }
                
            for(int dia = 1; dia <= diasMes; dia++)
            {
                if (dia < 10) 
                    Console.Write(" {0}  ", dia);
                else 
                    Console.Write("{0}  ", dia);
                numeroDiaSemana++;
                
                if(numeroDiaSemana > 7)
                {
                    numeroDiaSemana = 1;
                    Console.WriteLine();
                }
                
            }
        }
        else
            Console.WriteLine("No has introducido datos correctos");
        
    }
}
