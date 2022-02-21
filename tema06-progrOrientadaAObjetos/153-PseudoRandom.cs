using System;

/*
153. Crea una clase llamada "PseudoRandom" para generar "falsos números 
aleatorios". En ella, crea un método estático "Get" que devolverá los 
milisegundos del reloj del sistema actual (deberás usar 
"DateTime.Now.Millisecond"). Crea un "Main" para probarla.
*/

// Rocío (...)

class PseudoRandom
{
    public static int Get()
    {
       return DateTime.Now.Millisecond;
    }
}

// ---------

class Prueba
{
    static void Main()
    {
        Console.WriteLine("Al azar... " + PseudoRandom.Get());
    }
}
