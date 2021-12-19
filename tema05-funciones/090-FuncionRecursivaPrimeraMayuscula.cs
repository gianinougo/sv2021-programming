// Ejercicio recomendado 90
// Javier (...)

/*
 * 90. Crea una función "PrimeraMayuscula(txt)", que devuelva la primera letra 
 * en mayúsculas de una cadena que se le pase como parámetros. No devolverá un 
 * dato de tipo "char", sino un "string", de modo que se pueda devolver una 
 * cadena vacía en caso de que no exista ninguna letra en mayúsculas. Hazlo 
 * tanto de forma iterativa ("PrimeraMayuscula") como de forma recursiva 
 * ("PrimeraMayusculaRec"). Prueba ambas desde Main, con tres cadenas 
 * prefijadas.
 */

using System;

class RecursividadConCadenas
{
    static void Main()
    {
        const string TEXTO1 = "en un lugar de la Mancha";
        const string TEXTO2 = "De cuyo nombre";
        const string TEXTO3 = "no quiero acordarme.";

        string letra1 = PrimeraMayuscula(TEXTO1);
        string letra2 = PrimeraMayuscula(TEXTO2);
        string letra3 = PrimeraMayuscula(TEXTO3);
        string letraRec1 = PrimeraMayusculaRec(TEXTO1);
        string letraRec2 = PrimeraMayusculaRec(TEXTO2);
        string letraRec3 = PrimeraMayusculaRec(TEXTO3);

        Console.WriteLine(TEXTO1 );
        Console.WriteLine(letra1);
        Console.WriteLine(letraRec1);
        Console.WriteLine(TEXTO2);
        Console.WriteLine(letra2);
        Console.WriteLine(letraRec2);
        Console.WriteLine(TEXTO3);
        Console.WriteLine(letra3);
        Console.WriteLine(letraRec3);
    }

    static string PrimeraMayuscula(string texto)
    {
        bool encontrado = false;
        int i = 0;
        char l = ' ';

        while (!encontrado && i < texto.Length)
        {
            l = texto[i];
            if (l >= 'A' && l <= 'Z')
                encontrado = true;
            
            i++;
        }

        if (encontrado)
            return l.ToString();
        else
            return "";
    }

    static string PrimeraMayusculaRec(string texto)
    {
        if (texto.Length == 0)
            return "";

        if (texto[0] >= 'A' && texto[0] <= 'Z')
            return texto[0].ToString();

        return PrimeraMayusculaRec(texto.Substring(1));
    }
}
