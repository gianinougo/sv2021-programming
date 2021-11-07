// Ejercicio recomendado 54c
// Javier (...)
// Muestra un menú y muestra la opción seleccionada usando enumeracion

using System;

class Menu
{
    enum opciones { SALIR, JUGAR, CARGAR, PUNTUACIONES };
    static void Main()
    {
        byte opcion;

        Console.WriteLine((byte)opciones.JUGAR + ". Jugar");
        Console.WriteLine((byte)opciones.CARGAR + ". Cargar partida");
        Console.WriteLine((byte)opciones.PUNTUACIONES + ". Ver mejores puntuaciones");
        Console.WriteLine((byte)opciones.SALIR + ". Salir");
        opcion = Convert.ToByte(Console.ReadLine());

        switch (opcion)
        {
            case (byte) opciones.JUGAR:
                Console.WriteLine("Has escogido la opción \"{0}\": \"Jugar\"",
                    (byte)opciones.JUGAR);
                break;
            case (byte) opciones.CARGAR:
                Console.WriteLine("Has escogido la opción " +
                    "\"{0}\": \"Cargar partida\"", (byte)opciones.CARGAR);
                break;
            case (byte) opciones.PUNTUACIONES:
                Console.WriteLine("Has escogido la opción " +
                    "\"{0}\": \"Ver mejores puntuaciones\"",
                    (byte)opciones.PUNTUACIONES);
                break;
            case (byte) opciones.SALIR:
                Console.WriteLine("Has escogido la opción " +
                    "\"{0}\": \"Salir\"", (byte)opciones.SALIR);
                break;
            default:
                Console.WriteLine("Opción incorrecta");
                break;
        }
    }
}
