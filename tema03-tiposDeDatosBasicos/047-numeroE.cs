// Ejercicio recomendado 47
// Javier (...) + Nacho
// Muestra el valor aproximado de e, a partir de una cantidad de sumandos

using System;

class AproximacionE
{
    static void Main()
    {
        Console.Write("Sumandos? ");
        int sumandos = Convert.ToInt32(Console.ReadLine());

        double e = 0;
        if (sumandos >= 1)
        {
            e = 1;
            for (int sumando = 1; sumando <= sumandos-1; sumando++)
            {
                long divisorActual = 1;
                for (int cifraDivisor = 1; cifraDivisor <= sumando; cifraDivisor++)
                {
                    divisorActual *= cifraDivisor;
                }
                e += 1.0 / divisorActual;
            }
        }
        Console.WriteLine("e vale aproximadamente {0}", e);
    }
}
