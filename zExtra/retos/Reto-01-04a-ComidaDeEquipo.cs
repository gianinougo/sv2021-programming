// Author: Franco (...)
// https://contest.tuenti.net/resources/2016/Question_1.html

/*
Entrada de ejemplo
8
2
4
6
5
7
3
26073
59794

Salida de ejemplo
Case #1: 1
Case #2: 1
Case #3: 2
Case #4: 2
Case #5: 3
Case #6: 1
Case #7: 13036
Case #8: 29896
*/ 

using System;

class NumeroPersonasMesa 
{
    static void Main () 
    {

        int casos, dato, mesas=0;

        casos = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= casos; i++) 
        {

            dato = Convert.ToInt32(Console.ReadLine());

            if (dato == 0) 
            {
                mesas = 0;
            } 
            else if (dato <= 4) 
            {
                mesas = 1;                
            } 
            else if (dato % 2 == 0) 
            {
                mesas = (dato - 2) / 2;
            } 
            else if (dato % 2 != 0) 
            {
                mesas = (dato - 1) / 2;
            }

            Console.WriteLine("Case #{0}: {1}", i, mesas);

        }
    }
}

