//Victor (...)
/*Ejercicio 68. Crea un "struct" para almacenar algunos datos de juegos de ordenador o consola, 
 de momento sólo: título (cadena de texto), espacio ocupado (en MB, número entero). Pide al usuario
datos de 3 juegos (que serán parte de un array) y luego muéstralos.*/

using System;

class StructDatos
{
    struct datos
    {
        public String titulo;
        public int espacio;
    }
    
    static void Main()
    {
        datos[] juegos = new datos[3];
        for(int i = 0; i < 3; i++)
        {
            Console.WriteLine("Escribe el título del juego {0}", i+1);
            juegos[i].titulo = Console.ReadLine();
            Console.WriteLine("Escribe el espacio del juego {0}", i+1);
            juegos[i].espacio = Convert.ToInt32(Console.ReadLine());
        }
        
        for(int j = 0; j < 3; j++)
        {
            Console.WriteLine("{0} - {1} Mb",
                juegos[j].titulo, juegos[j].espacio);
        }       
    }
}

