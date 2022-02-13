using System;

class R02
{
    static void Main()
    {
        uint n1 = 2;
        uint n2 = 10;
        bool falla = false;

        //Multiplicaciones desde 2*0 hasta 2*10:
        for (uint i = 0; i <= n2; i++)
        {
            uint prodIt = ProductoIt(n1, i);
            uint prodRe = ProductoRe(n1, i);

            if (prodIt == prodRe)
                Console.Write(i + " OK. ");
            else
            {
                Console.Write(i + " falla!!! ");
                falla = true;
            }
        }
        if (falla)
            Console.WriteLine("Algo ha fallado... ");

        Console.WriteLine();

        //Multiplicación 0*5:
        if (ProductoIt(0, 5) == ProductoRe(0, 5))
            Console.WriteLine("Todo OK con (0,5)");
        else
            Console.WriteLine("Fallo con (0,5).");

        //Multiplicación 100*100:
        if (ProductoIt(100, 100) == ProductoRe(100, 100))
            Console.WriteLine("Todo OK con (100,100)");
        else
            Console.WriteLine("Fallo con (100,100).");
    }

    static uint ProductoIt(uint n1, uint n2)
    {
        uint producto = 0;

        for (uint i = 0; i < n2; i++)
        {
            producto += n1;
        }

        return producto;
    }

    static uint ProductoRe(uint n1, uint n2)
    {
        if (n2 == 0)
            return 0;
        else
            return n1 + ProductoRe(n1, n2 - 1);
    }
}
