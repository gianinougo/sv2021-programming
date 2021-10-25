//JOSE (...)
/* 33. Pide al usuario dos números enteros y muestra su división. Usa 
 * excepciones para comprobar los posibles errores.
 */
using System;

class ejer_02_33
{
    static void Main()
    {
         int numero1, numero2, resultado;

        try
        {
           
            Console.Write("Introduce un primer número: ");
            numero1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Introduce un segundo número: ");
            numero2 = Convert.ToInt32(Console.ReadLine());
            resultado = numero1/numero2;
            
            Console.WriteLine("{0} / {1} = {2}", numero1, numero2, resultado);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("No se puede dividir entre cero.");
        }  
        catch (FormatException)
        {
            Console.WriteLine("Formato de número incorrecto.");
        }
    }
}

