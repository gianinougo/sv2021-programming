/*
R05.

Crea una función Invertir1, que devuelva invertida la cadena pasada como 
parámetro. Hazlo utilizando un bucle.

Crea también una función Invertir2, que devuelva invertida la cadena pasada 
como parámetro, pero de forma recursiva. Como pista: como caso base, una cadena 
de 1 letra o menos se quedará como está; para una cadena de mayor longitud, se 
puede tomar su primer carácter y añadirlo al final de la subcadena invertida (o 
tomar el último carácter y añadirlo al principio).

Prueba ambas funciones para comprobar que se comportan igual a la hora de 
invertir al menos 5 palabras prefijadas.
*/

using System;

class R05
{
    static string Invertir1(string texto)
    {
        string textoInvertido = "";

        for (int i = texto.Length - 1; i >= 0; i--)
            textoInvertido += texto[i];

        return textoInvertido;
    }

    static string Invertir2(string texto)
    {
        if (texto.Length == 0)
            return texto;
        else
            return Invertir2(texto.Substring(1)) + texto[0];
    }

    static void Main()
    {
        string[] pruebas = {"Esta es un frase", "hola", "que tal",
            "radar", "1"};
        foreach (string prueba in pruebas)
        {
            if (Invertir1(prueba) == Invertir2(prueba))
            {
                Console.Write("Ok ");
            }
            else
            {
                Console.Write("OOOPS! ");
            }
                    
        }
    }
}
