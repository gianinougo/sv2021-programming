//Tema 3 Semana 2 recomendado 52 
// Ezequiel (...)
/* Crea un programa que le pida al usuario dos números (reales de simple 
 * precisión) y una operación para realizar en ellos (+, -, *, x, ·, /) y 
 * muestre el resultado de esa operación, como en este ejemplo:
Introduzca el primer número: 5
Introduzca la operación: ·
Introduzca el segundo número: 7
5 · 7 = 35*/

using System;

public class T3s1
{
    public static void Main()
    {
        float primerNumero, segundoNumero;
        char operando;
        
        Console.Write("Introduzca el primer número: ");
        primerNumero = Convert.ToSingle(Console.ReadLine());

        Console.Write("Introduzca la operación: ");
        operando = Convert.ToChar(Console.ReadLine());
            
        Console.Write("Introduzca el segundo número: ");
        segundoNumero = Convert.ToSingle(Console.ReadLine());
            
        switch (operando)
        {
            case '+': 
                Console.Write("{0} + {1} = {2}", 
                    primerNumero, segundoNumero, 
                    primerNumero + segundoNumero);
                break;
            
            case '-': 
                Console.Write("{0} - {1} = {2}", 
                    primerNumero, segundoNumero, 
                    primerNumero - segundoNumero); 
                break;
                    
            case '*': 
            case '·': 
            case 'x': 
                Console.Write("{0} * {1} = {2}", 
                    primerNumero, segundoNumero, 
                    primerNumero * segundoNumero); 
                break;
                    
            case '/': 
                Console.Write("{0} / {1} = {2}", 
                    primerNumero, segundoNumero, 
                    primerNumero / segundoNumero); 
                break; 
        }
    }
}
