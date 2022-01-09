// Tema 5 semana 2 recomendado 93
// Ejercicios de C# 2do trimestre, por Ezequiel (...), retoques por Nacho

/*
 * Crea una versión mejorada de la "calculadora", que también permita calcular 
 * potencias (con el símbolo ^), que devuelva al sistema operativo el código de 
 * error 0 si todo ha sido correcto, el código 1 si se ha indicado un operador 
 * no válido o el código 2 si alguno de los números no era válido, además de 
 * mostrar en consola un mensaje de aviso adecuado:

calculadora 2 ^ 3
8
calculadora 2 ** 3
Operador desconocido
calculadora 3 + Hola
Número no válido

*/

using System;

public class Calculadora
{
    static int potencia(int numero1, int numero2)
    {
        int resultado = 1;
        for(int i = 1; i <= numero2; i++)
            resultado = resultado * numero1;
        
        return resultado;
    }
    
    static int Main(string[] args)
    {
        if(args.Length != 3)
        {
            Console.WriteLine("No ha indicado el número correcto" + 
                                " de parámetros.");
            return 2;
        }
        else
        {
            int num1 = 0, num2 = 0;
            
            if(Int32.TryParse(args[0], out num1) && 
                    Int32.TryParse(args[2], out num2) )  
            {   
                switch (args[1])
                {
                    case "+": Console.WriteLine("{0}", num1 + num2); break;
                    case "-": Console.WriteLine("{0}", num1 - num2); break;
                    case "*": Console.WriteLine("{0}", num1 * num2); break;
                    case "/": Console.WriteLine("{0}", num1 / num2); break;
                    case "^":
                    case "p": 
                        Console.WriteLine("{0}", potencia(num1, num2)); 
                        break;
                    default: Console.WriteLine("Operador desconocido."); 
                        return 1; 
                }
            }
            else
            {
                Console.WriteLine("Número no válido.");
                return 2;;
            }
        }            
            
        return 0;
    }
}
