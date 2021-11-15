/*

Crea un primer acercamiento al esqueleto de un programa que permita anotar
datos de contactos (amistades, familiares, etc).

Esta primera versión mostrará un menú con las opciones:

1. Añadir datos de un contacto.
2. Buscar entre los contactos existentes.
3. Modificar los datos de un contacto.
4. Borrar un contacto.
5. Ver estadísticas.
S. Salir.

Deberá repetirse hasta que el usuario escoja la opción "S" (que será aceptable
tanto en mayúsculas como en minúsculas).

Si escoge una opción entre la 2 y la 4, se le responderá con el mensaje "Opción
todavía no disponible" (y se volverá al menú).

Si elige la opción 1, se le avisará de que el programa aún está en fase de
pruebas y de que no se guardarán los datos, y luego se le pedirá el nombre del
contacto (por ejemplo "Chuck Norris"), su correo electrónico (por ejemplo
"chuck@chucknorris.com"), su año de anyoNacimiento (por ejemplo 1940, que nos
interesará para poder suponer a qué tipo de sesiones de juego le podemos
invitar) y su estatura (en metros, por ejemplo 1.78, que es vital por si le
invitamos a un partido de baloncesto o volleyball).

Cada vez que se añada un contacto, aumentará un contador de contactos
introducidos (aunque realmente por ahora sólo se conservará el último), y este
contador se mostrará a continuación del menú, con el formato:

Contactos disponibles: 23

La opción 5 mostrará también la edad media (para cada edad supondremos que
basta con restar al año actual, 2021, el año de anyoNacimiento) y la estatura media
de nuestros contactos.

Los tipos de datos deben estar optimizados para cada bloque de información. La
estructura repetitiva del programa debe ser adecuada, y emplear un booleano de
control. El fuente debe estar correctamente tabulado y resultar fácil de leer.

Debes entregar exclusivamente el fichero ".cs" (no todo el proyecto), sin
comprimir, y deberá tener un comentario con tu nombre al principio.

*/

using System;

class Nota02
{
    static void Main()
    {
        char opcion;

        string nombre, email;
        ushort anyoNacimiento;
        float estatura = 0;

        ushort contactos = 0;
        bool terminado = false;
        int sumaEdades = 0;
        float sumaEstaturas = 0;

        do
        {
            Console.WriteLine();
            Console.WriteLine("MENÚ");
            Console.WriteLine("1. Añadir datos de un contacto.");
            Console.WriteLine("2. Buscar entre los contactos existentes.");
            Console.WriteLine("3. Modificar los datos de un contacto.");
            Console.WriteLine("4. Borrar un contacto.");
            Console.WriteLine("5. Ver estadísticas.");
            Console.WriteLine("S. Salir.");
            Console.WriteLine();
            Console.WriteLine("Contactos disponibles: " + contactos);
            Console.WriteLine();

            Console.Write("Elige una opción: ");
            opcion = Convert.ToChar(Console.ReadLine());
            Console.WriteLine();

            switch (opcion)
            {
                case '1':
                    Console.WriteLine("Programa en fase de pruebas. " +
                        "No se guardarán los datos.");

                    Console.Write( "Nombre del contacto: " );
                    nombre = Console.ReadLine();

                    Console.Write( "Correo electrónico: " );
                    email = Console.ReadLine();

                    Console.Write( "Año de anyoNacimiento: " );
                    anyoNacimiento = Convert.ToUInt16(Console.ReadLine());

                    Console.Write( "Estatura (en metros): " );
                    estatura = Convert.ToSingle(Console.ReadLine());

                    contactos++;

                    sumaEdades += 2021 - anyoNacimiento;
                    sumaEstaturas += estatura;
                    break;

                case '2':
                case '3':
                case '4':
                    Console.WriteLine("Opción todavía no disponible");
                    break;

                case '5':
                    if (contactos != 0)
                    {
                        Console.WriteLine("Edad media: " +
                            (sumaEdades / contactos));
                        Console.WriteLine("Estatura media: " +
                            (sumaEstaturas / contactos));
                    }
                    else
                    {
                        Console.WriteLine( "No hay datos disponibles." );
                    }
                    break;

                case 's':
                case 'S':
                    terminado = true;
                    break;

                default:
                    Console.WriteLine( "No es una opción válida." );
                    break;
            }
        }
        while (!terminado);
    }
}
