// Ejercicio recomendado 79
// Javier (...)

/*
Crea una función booleana llamada "EsPalindromo", que devolverá "true" si el 
parámetro es una palabra palíndroma (que se lee igual de izquierda a derecha 
que de derecha a izquierda), o "false" en caso contrario. Pide al usuario un 
texto y responde si es palíndromo.
*/

using System;

class CompruebaPalindromo
{
    static bool EsPalindromo(string texto)
    {
        string textoAlReves="";
        bool espalindromo = false;

        for (int i=texto.Length-1; i>=0; i--)
        {
            char letra = texto[i];
            textoAlReves += letra;
        }

        if (texto == textoAlReves)
            espalindromo = true;

        return espalindromo;
    }

    static void Main()
    {
        Console.WriteLine("Introduce un texto: ");
        string texto = Console.ReadLine();

        if (EsPalindromo(texto))
            Console.WriteLine("Sí es palíndromo");
        else
            Console.WriteLine("No es palíndromo");
    }
}
