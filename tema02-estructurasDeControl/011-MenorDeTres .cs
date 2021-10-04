//Tres numeros y decir el más bajo
//Por Fran (...)

using System;

namespace Ejercicio11
{
    class Elmenor
    {
        public static void Main()

        {
            int uno, dos, tres;

            Console.WriteLine("Dime el primer número");
            uno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Dime el segundo número");
            dos = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Dime el tercero número");
            tres = Convert.ToInt32(Console.ReadLine());

            if ((uno <= dos) && (uno <= tres))
            {
                Console.WriteLine("El número más bajo es: {0}", uno);
            }
            else if ((dos <= uno) && (dos <= tres))
            {
                Console.WriteLine("El número más bajo es: ", dos);
            }
            else
            {
                Console.WriteLine("El número más bajo es: ", tres);
            }
            
        }
    }
}
