using System;

class R03  // Propuesta de Victor (...)
{
    public bool EsPalindromo(string texto)
    {
        if (texto.Length <2)
            return true;
        else
        {
            if (texto[0] == texto[texto.Length - 1])
                return EsPalindromo(texto.Substring(1, texto.Length - 2)); 
            else
                return false;
        }       
    }
    static void Main()
    {
        R03 r = new R03();
        string[] texto = { "oso", "Maria", "rata", "Orejero", "rayar",
                            "sosos", "Ajedrez", "puente", "rotor","o" };
        Console.WriteLine("Verificando palabras palíndromas o no.");
        for(int i = 0; i < texto.Length; i++)
        {
            Console.WriteLine("{0}={1}",texto[i],r.EsPalindromo(texto[i]));
        }
    }
}
