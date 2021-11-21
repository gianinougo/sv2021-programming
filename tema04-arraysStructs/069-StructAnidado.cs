// JOSE (...)
/* 69. Crea un "struct" para almacenar algunos datos de juegos de ordenador o 
 * consola, de momento sólo: título (cadena de texto), plataforma (cadena de 
 * texto), espacio ocupado (en MB, número entero) y fecha de lanzamiento (mes 
 * y año, en forma de struct anidado). Pide al usuario datos de 3 juegos (que 
 * serán parte de un array) y luego muéstralos.
 */

using System;

class Ejer_04_69
{
    struct fecha
    {
        public byte mes;
        public ushort anyo;
    }
    
    struct juego
    {
        public string titulo;
        public string plataforma;
        public int espacio;
        public fecha publicacion;
    }
    
    static void Main()
    {
        const int MAXIMO = 3;
        juego[] juegos = new juego[MAXIMO];

        for (int i = 0; i < juegos.Length; i++)
        {
            Console.Write("Introduce el título del juego: ");
            juegos[i].titulo = Console.ReadLine();

            Console.Write("Introduce la plataforma del juego: ");
            juegos[i].plataforma = Console.ReadLine();

            Console.Write("Introduce el peso del juego (MB): ");
            juegos[i].espacio = Convert.ToInt32(Console.ReadLine());

            Console.Write("Introduce el año de publicación: ");
            juegos[i].publicacion.anyo = Convert.ToUInt16(Console.ReadLine());

            Console.Write("Introduce el mes de publicación: ");
            juegos[i].publicacion.mes = Convert.ToByte(Console.ReadLine());

            Console.WriteLine();
        }
        Console.WriteLine();

        for (int i = 0; i < MAXIMO; i++)
        {
            Console.WriteLine("{0}. {1}, {2}, {3}, fecha de publicación: " +
                "{4}/{5}", i+1, juegos[i].titulo, juegos[i].plataforma, 
                juegos[i].espacio, juegos[i].publicacion.mes, 
                juegos[i].publicacion.anyo);
        }
        Console.WriteLine();
    }
}
