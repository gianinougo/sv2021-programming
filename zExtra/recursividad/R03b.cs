using System;

class R03

// Propuesta de Virginia (...)
// Esta variante ignora espacios y mayúsculas

{
    static void Main()
    {
        string[] cadenas = {"palindromo", "oso", "palabras", 
            "en un lugar de la Mancha", "Dabale arroz a la zorra el abad", 
            "Somos o no somos", "Arenera", "reconocer", "nueve", "diez"};

        for (int i = 0; i < cadenas.Length; i++)
        {
            Console.Write( cadenas[i] + ": ");
            Console.Write( EsPalindromoRe(cadenas[i]) );
            if (EsPalindromoIt(cadenas[i]) == EsPalindromoRe(cadenas[i]))
                Console.WriteLine(" --> OK");
            else
                Console.WriteLine(" ...");
        }
    }

    static bool EsPalindromoRe(string texto)
    {
        texto = texto.ToLower().Trim();
        if (texto.Length == 1)
            return true;
        else
        {
            if (texto[0] == texto[texto.Length - 1])
                return EsPalindromoRe(texto.Substring(1, texto.Length - 2));
            else
                return false;          
        }            
    }

    static bool EsPalindromoIt(string cadena)
    {
        cadena = cadena.ToLower().Trim();
        bool palindromo = true;

        while (palindromo && cadena.Length > 1)
        {
            if (cadena[0] == cadena[cadena.Length - 1])
            {
                cadena = cadena.Substring(1, cadena.Length - 2);
                cadena = cadena.Trim();
            }
            else
                palindromo = false;
        }
        return palindromo;
    }
}
