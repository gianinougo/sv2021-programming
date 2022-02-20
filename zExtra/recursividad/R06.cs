using System;

class Permutaciones
{
    static void EscribirPermutaciones(string cadenaRestante, string letrasUsadas)
    {
        if (cadenaRestante.Length == 0) Console.WriteLine(letrasUsadas);
        else for (int i = 0; i < cadenaRestante.Length; i++)
                EscribirPermutaciones(cadenaRestante.Remove(i,1), 
                    letrasUsadas+cadenaRestante[i]);
    }
    
    static void EscribirPermutaciones(string cadena)
    {
        EscribirPermutaciones(cadena, "");
    }
    
    static void Main()
    {
        EscribirPermutaciones("123");
        EscribirPermutaciones("hola");
    }
}
