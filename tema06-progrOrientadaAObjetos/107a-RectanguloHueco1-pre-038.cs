// Ejercicio recomendado 38
// Javier (...)
// Dibuja un rectángulo hueco con un número como símbolo

using System;

class Rectangulo
{
    static void Main()
    {
        int num, ancho, alto;
        
        do
        {
            Console.Write("Introduce el ancho: ");
            ancho=Convert.ToInt32(Console.ReadLine());
            if (ancho<1)
                Console.WriteLine("El ancho debe ser mayor que 0");
        }
        while (ancho<1);
        do
        {
            Console.Write("Introduce el alto: ");
            alto=Convert.ToInt32(Console.ReadLine());
            if (alto<1)
                Console.WriteLine("El alto debe ser mayor que 0");
        }
        while (alto<1);
            
        do 
        {
            Console.Write("Introduce un número del 0 al 9: ");
            num=Convert.ToInt32(Console.ReadLine());
            if ((num<0)||(num>9))
                Console.WriteLine("Número fuera de rango");
        }
        while ((num<0)||(num>9));
        
        for (int fila=1; fila<=alto; fila++)
        {
            for (int col=1; col<=ancho; col++)
            {
                if ((fila==1)||(fila==alto))
                    Console.Write(num);
                else if ((col==1)||(col==ancho))
                    Console.Write(num);
                else 
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
                
                
