//Ejercicio 50 
//Esteban (...)
//Crea un programa que pida al usuario un símbolo y responda si se trata de un operador (+ - * / %),
//un símbolo de puntuación (. , ; : ), un dígito (0 al 9), o algún otro símbolo.
//Debes emplear el tipo de datos "char" y hacerlo de dos formas distintas (en un mismo programa):
//primero usando "if" y después empleando "switch".


using System;


class Program
{
    static void Main()
    {
        char x;
        Console.WriteLine("Introduzca un simbolo: ");
        x =Convert.ToChar (Console.ReadLine());

        if (x >= '0' && x <= '9')
            Console.WriteLine("Dígito.");

        else if (x == '+' || x == '-' || x == '*' || x == '/')
            Console.WriteLine("Operador.");

        else if (x == '.' || x == ',' || x == ';' || x == ':') 
        Console.WriteLine("Signo de puntuacion.");
        
        else
            Console.WriteLine("Desconocido");

        switch (x)
        {
           
            case '1': 
            case '2': 
            case '3': 
            case '4': 
            case '5': 
            case '6': 
            case '7': 
            case '8': 
            case '9':
            case '0': Console.WriteLine("Dígito.");break;
            case '.':
            case ',':
            case ';':
            case ':': Console.WriteLine("Signo de puntuacion.");break;
            case '+': 
            case '-': 
            case '*': 
            case '/': 
            case '%': Console.WriteLine("Operador.");break;

            default:
                Console.WriteLine("Desconocido");break;
        }
    }
}

