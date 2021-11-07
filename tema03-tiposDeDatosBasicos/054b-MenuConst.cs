// Ejercicio recomendado 54b
// Javier (...)
// Muestra un menú y muestra la opción seleccionada usando constantes

using System;

class Menu
{    static void Main()
    {
        byte opcion;
        const byte JUGAR = 1, CARGAR = 2, PUNTUACIONES = 3, SALIR = 0;

        Console.WriteLine(JUGAR + ". Jugar");
        Console.WriteLine(CARGAR + ". Cargar partida");
        Console.WriteLine(PUNTUACIONES + ". Ver mejores puntuaciones");
        Console.WriteLine(SALIR + ". Salir");
        opcion = Convert.ToByte(Console.ReadLine());

        switch (opcion)
        {
            case JUGAR:
                Console.WriteLine("Has escogido la opción \"{0}\": \"Jugar\"",
                    JUGAR);
                break;
            case CARGAR:
                Console.WriteLine("Has escogido la opción " +
                    "\"{0}\": \"Cargar partida\"", CARGAR);
                break;
            case PUNTUACIONES:
                Console.WriteLine("Has escogido la opción " +
                    "\"{0}\": \"Ver mejores puntuaciones\"",
                    PUNTUACIONES);
                break;
            case SALIR:
                Console.WriteLine("Has escogido la opción " +
                    "\"{0}\": \"Salir\"", SALIR);
                break;
            default:
                Console.WriteLine("Opción incorrecta");
                break;
        }
    }
}
