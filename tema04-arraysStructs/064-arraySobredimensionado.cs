// Ejercicio recomendado 64
// Javier (...)
// Crea un menú con diferentes opciones sobre un array de string

/*
64. Crea un array que permita almacenar hasta 1000 nombres de juegos de 
ordenador, como primera aproximación para ordenar nuestra colección de juegos. 
Deberás mostrar un menú que permita: Añadir un nuevo dato (al final de los 
existentes), insertar un dato (en una cierta posición que se preguntará al 
usuario), borrar un dato (a partir de su número de posición), ver todos los 
datos, buscar un cierto dato, salir. La opción de Buscar preguntará el nombre a 
buscar y responderá si es parte de nuestra colección.
*/

using System;

class Juegos
{
    static void Main()
    {
        const int MAX = 1000;
        string[] juegos = new string[MAX];
        string juego;
        int cantidad=0, opcion, posicion;

        do
        {
            Console.WriteLine("Selecciona una opción");
            Console.WriteLine("1: Añadir nuevo juego");
            Console.WriteLine("2: Insertar juego en una posición determinada");
            Console.WriteLine("3: Borrar un juego");
            Console.WriteLine("4: Mostrar todos los juegos");
            Console.WriteLine("5: Buscar un juego");
            Console.WriteLine("0: Salir");
            Console.WriteLine();
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    if (cantidad < MAX)
                    {
                        Console.Write("Introduce el nombre del juego: ");
                        juegos[cantidad] = Console.ReadLine();
                        cantidad++;
                    }
                    else
                    {
                        Console.WriteLine("No caben más juegos");
                    }
                    Console.WriteLine();
                    break;

                case 2:
                    if (cantidad < MAX)
                    {
                        Console.Write("Introduce el nombre del juego: ");
                        juego = Console.ReadLine();
                        Console.Write("Introduce la posición: ");
                        posicion = Convert.ToInt32(Console.ReadLine());
                        if (posicion <= cantidad)
                        {
                            for (int i = cantidad; i > posicion-1; i--)
                                juegos[i] = juegos[i - 1];
                            juegos[posicion - 1] = juego;
                            cantidad++;
                        }
                        else
                        {
                            Console.WriteLine("La posición introducida debe"
                                + " estar entre 1 y {0}", cantidad+1);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No caben más juegos");
                    }
                    Console.WriteLine();
                    break;

                case 3:
                    Console.Write("Introduce la posición a borrar: ");
                    posicion = Convert.ToInt32(Console.ReadLine());
                    if (posicion > 0 && posicion <= cantidad)
                    {
                       for (int i = posicion - 1; i < cantidad; i++)
                            juegos[i] = juegos[i + 1];
                       cantidad--;
                    }
                    else
                    {
                        Console.WriteLine("La posición está vacía");
                    }
                    Console.WriteLine();
                    break;

                case 4:
                    if (cantidad>0)
                        for (int i = 0; i < cantidad; i++)
                            Console.WriteLine("{0} - {1}", i+1, juegos[i]);
                    else
                        Console.WriteLine("No hay juegos en la colección");
                    Console.WriteLine();
                    break;

                case 5:
                    bool encontrado = false;
                    int pos = 0;
                    if (cantidad > 0)
                    {
                        Console.Write("Introduce el juego a buscar: ");
                        juego = Console.ReadLine();
                        while (pos <= cantidad && !encontrado)
                        {
                            if (juegos[pos] == juego)
                                encontrado = true;
                            pos++;
                        }
                        if (encontrado)
                        {
                            Console.WriteLine("El juego está en la posición "
                                + pos);
                            encontrado = false;
                        }
                        else
                            Console.WriteLine("El juego no forma parte de"
                                + " la colección");
                    }
                    else
                        Console.WriteLine("No hay juegos en la colección");
                    Console.WriteLine();
                    break;

                case 0:
                    Console.WriteLine("Hasta la próxima");
                    break;

                default:
                    Console.WriteLine("Opción incorrecta");
                    Console.WriteLine();
                    break;
            }
        }
        while (opcion != 0);
    }
}
