using System;

class R07
{
    static void Main()
    {
        bool fallos = false;

        for (int i = 0; i < 10000; i++)
        {
            if (ContarDigitosIt((ulong)i) != ContarDigitosRe((ulong)i))
            {
                fallos = true;
                Console.WriteLine("Detectado fallo en el número: " + i);
            }
        }
        if (!fallos)
            Console.WriteLine("Todo correcto");
    }

    static byte ContarDigitosIt(ulong n)
    {
        byte contador = 0;

        while (n > 0)
        {
            n /= 10;
            contador++;
        }

        return contador;
    }

    static byte ContarDigitosRe(ulong n)
    {
        if (n == 0)
            return 0;
        else
            return (byte) (1 + ContarDigitosRe(n / 10));
    }
}
