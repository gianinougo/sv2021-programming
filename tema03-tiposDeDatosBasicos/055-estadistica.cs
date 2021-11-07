//JOSE (...)
/* 55. Escribe un programa que pida al usuario números reales de doble 
    * precisión y muestre su máximo, mínimo, suma y media después de cada paso. 
    * Terminará cuando introduzca la palabra "fin":


    Dato: 5
    Max = 5, Min = 5, Suma = 5, Media = 5
    Dato: 2.2
    Max = 5, Min = 2.2, Suma = 7.2, Media = 3.6
    Dato: fin
    ¡Hasta otra!
    */

using System;

class Ejer_3_55
{
    static void Main()
    {
        string dato;
        double numero, max = 0, min = 0, suma = 0, media;
        int cantidad = 1;
        bool salir;

        do
        {          
            Console.Write("Introduce un número: ");
            dato = Console.ReadLine();

            salir = dato == "fin";
            if (!salir)
            {
                numero = Convert.ToDouble(dato);

                if (cantidad == 1)
                {
                    max = numero;
                    min = numero;
                    suma += numero;
                    media = numero;
                }
                else
                {
                    if (numero > max) max = numero;
                    if (numero < min) min = numero;
                    suma += numero;
                    media = suma / cantidad;
                }

                Console.WriteLine("Max = {0}, Min = {1}, Suma = {2}, Media =" +
                    " {3}", max, min, suma, media);
                cantidad++;
            }
        } 
        while (! salir) ;

        Console.WriteLine("¡Hasta otra!");
    }
}
