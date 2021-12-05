/*
 *  Alejandro (...), correcciones por Nacho
 *  
 *  Ejercicio 83: frase con mayúsculas alternas.

 * Crea una función llamada "MayusculasAlternas", que recibirá una cadena como 
 parámetro y devolverá otra cadena que tendrá en mayúsculas las letras en la 
 primera, tercera y resto de posiciones impares (contando desde 1) y en 
 minúsculas las que están en posiciones pares (segunda, cuarta y sucesivas). 
 Por ejemplo, a partir de "eJEmplo" debería devolver "EjEmPlO".

 */

using System;

class Ejercicio_83
{
    static string MayusculasAlternas (string frase)
    {
        string fraseMayusculas, fraseMinusculas;
        string respuesta = "";

        fraseMayusculas = frase.ToUpper();
        fraseMinusculas = frase.ToLower();

        for (int i = 0; i < frase.Length; i++)
        {
            if (i % 2 == 0)
            {
                respuesta += fraseMayusculas[i];
            }
            else
            {
                respuesta += fraseMinusculas[i];
            }
        }
        return respuesta;
    }
    
    static void Main()
    {
        Console.WriteLine("Introduzca una frase.");
        string frase = Console.ReadLine();

        Console.WriteLine( MayusculasAlternas(frase) );
    }
}
