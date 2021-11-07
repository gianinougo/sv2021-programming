// Ejercicio recomendado 54a
// Javier (...)
// Muestra un menú y muestra la opción seleccionada usando switch normal

using System;

class Menu
{
    static void Main()
    {
        byte opcion;
        
        Console.WriteLine("1. Jugar");
        Console.WriteLine("2. Cargar partida");
        Console.WriteLine("3. Ver mejores puntuaciones");
        Console.WriteLine("0. Salir");
        opcion = Convert.ToByte(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                Console.WriteLine("Has escogido la opción \"1\": \"Jugar\"");
                break;
            case 2:
                Console.WriteLine("Has escogido la opción \"2\": \"Cargar partida\"");
                break;
            case 3:
                Console.WriteLine("Has escogido la opción \"3\": \"" +
                    
                    "\"Ver mejores puntuaciones\"");
                break;
            case 0:
                Console.WriteLine("Has escogido la opción \"0\": \"Salir\"");
                break;
            default:
                Console.WriteLine("Opción incorrecta");
                break;
        }
    }
}
