// Reto 1.06

/*
The digital Clock

You have a digital, 7 led segment, clock. One day, while waking up from a 
sci-fi dream, you wonder: how many times will the individual leds turn on after 
X seconds, from a 00:00:00 position?

Yeah, geeks. But as a good geek you will not that question stay on your mind 
forever, right? ;)

Take into account that every second, all leds turn off and then the ones for 
the next position will turn on.
*/

// Javier (...)

/*
Sample input
0
4
1000
36000


Sample output
36
172
30630
1069232
*/

using System;

class Reloj
{
    static void Main()
    {
        // 0 = 6 = 9 = 6 leds, 1 = 2 leds, 2 = 3 = 5 = 5 leds, 4 = 4 leds,
        // 7 = 3 leds, 8=7 leds

        int segundos, leds = 0;
        int h=0, h1=0, m=0, m1=0, s=0, s1=0;

        segundos=Convert.ToInt32(Console.ReadLine());

        while (segundos>=0)
        {
            s = segundos;
            if (s>=3600)
            {
                h = segundos / 3600;
                s = segundos % 3600;
            }             
            if (s>=60)
            {
                m = s / 60;
                s %= 60;
            }           
            
            h1 = h / 10;
            h %= 10;
            switch (h)
            {
                case 0: case 6: case 9: leds += 6; break;
                case 1: leds += 2; break;
                case 2: case 3: case 5: leds += 5; break;
                case 4: leds += 4; break;
                case 7: leds += 3; break;
                case 8: leds += 7; break;
            }
            switch (h1)
            {
                case 0: case 6: case 9: leds += 6; break;
                case 1: leds += 2; break;
                case 2: case 3: case 5: leds += 5; break;
                case 4: leds += 4; break;
                case 7: leds += 3; break;
                case 8: leds += 7; break;
            }
            m1 = m / 10;
            m %= 10;
            switch (m)
            {
                case 0: case 6: case 9: leds += 6; break;
                case 1: leds += 2; break;
                case 2: case 3: case 5: leds += 5; break;
                case 4: leds += 4; break;
                case 7: leds += 3; break;
                case 8: leds += 7; break;
            }
            switch (m1)
            {
                case 0: case 6: case 9: leds += 6; break;
                case 1: leds += 2; break;
                case 2: case 3: case 5: leds += 5; break;
                case 4: leds += 4; break;
                case 7: leds += 3; break;
                case 8: leds += 7; break;
            }
            s1 = s / 10;
            s %= 10;
            switch (s)
            {
                case 0: case 6: case 9: leds += 6; break;
                case 1: leds += 2; break;
                case 2: case 3: case 5: leds += 5; break;
                case 4: leds += 4; break;
                case 7: leds += 3; break;
                case 8: leds += 7; break;
            }
            switch (s1)
            {
                case 0: case 6: case 9: leds += 6; break;
                case 1: leds += 2; break;
                case 2: case 3: case 5: leds += 5; break;
                case 4: leds += 4; break;
                case 7: leds += 3; break;
                case 8: leds += 7; break;
            }
            h = h1 = m = m1 = s = s1 = 0;
            segundos--;
        }
        Console.WriteLine(leds);
    }       
}
