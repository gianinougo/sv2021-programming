// Ejercicio recomendado 16 del Tema 2
// Javier (...)

/*
Crea una versión mejorada del ejercicio 15, que responda algo más amigable, 
como "Marzo, 31 días". Puedes usar "if", "switch" o una combinación de ambos, 
de modo que el programa resultante sea tan legible y compacto como sea posible.
*/

using System;

class Meses
{
    static void Main()
    {
        int mes;
        
        Console.Write("Introduce el número del mes: ");
        mes=Convert.ToInt32(Console.ReadLine());
            
        switch (mes)
        {
            case 1: Console.WriteLine("Enero tiene 31 días"); break;
            case 2: Console.WriteLine("Febrero tiene 28 días"); break;
            case 3: Console.WriteLine("Marzo tiene 31 días"); break;
            case 4: Console.WriteLine("Abril tiene 30 días"); break;
            case 5: Console.WriteLine("Mayo tiene 31 días"); break;
            case 6: Console.WriteLine("Junio tiene 30 días"); break;
            case 7: Console.WriteLine("Julio tiene 31 días"); break;
            case 8: Console.WriteLine("Agosto tiene 31 días"); break;
            case 9: Console.WriteLine("Septiembre tiene 30 días");break;
            case 10: Console.WriteLine("Octubre tiene 31 días"); break;
            case 11: Console.WriteLine("Noviembre tiene 30 días");break;
            case 12: Console.WriteLine("Diciembre tiene 31 días");break;
            default: Console.WriteLine("Número de mes incorrecto");
                     break;
        }
    }
}       
            
        
