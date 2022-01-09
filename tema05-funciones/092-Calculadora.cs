// Tema 5 semana 3, recomendado 92
// Ejercicios de C# 2do trimestre, por Ezequiel (...) 1º DAM

/*
Crea un programa llamado "calculadora", que reciba dos números enteros y un 
operador (+, -, *, /) en la línea de comandos y muestre el resultado de la 
operación, como en este ejemplo:

calculadora 5 * 3        
15

*/
using System;
public class Calculadora
{
    static void Main(string[] args)
    {
        if(args.Length == 0)
        {
            Console.WriteLine("No ha indicado parámetros.");
        }
        else if(args.Length != 3)
        {
            Console.WriteLine("No ha indicado el número correcto" + 
                                "de parámetros.");
        }
        else
        {
            int num1 = Convert.ToInt32(args[0]);
            int num2 = Convert.ToInt32(args[2]);
            
            switch (args[1])
            {
                case "+": Console.WriteLine("{0}", num1 + num2); break;
                case "-": Console.WriteLine("{0}", num1 - num2); break;
                case "*": Console.WriteLine("{0}", num1 * num2); break;
                case "/": Console.WriteLine("{0}", num1 / num2); break;
                default: Console.WriteLine("El operando NO es correcto."); break;
            }
        }
    }
}
