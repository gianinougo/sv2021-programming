// Jorge (...), retoques por Nacho

/* Crea un programa de C# que pueda almacenar hasta 10000 contactos (amistades, 
familiares, etc). Para cada contacto, debe permitir al usuario almacenar la 
siguiente información:

Nombre
Correo electrónico
Año de nacimiento
Aficiones
Estatura (en metros)
Comentarios


Esta versión mostrará un menú con las opciones:

1.Añadir datos de un contacto.

2. Buscar entre los contactos existentes.

3. Ver detalles de un contacto.

4. Modificar los datos de un contacto.

5. Borrar un contacto.

6. Ordenar datos.

7. Ver estadísticas.

8. Corregir errores frecuentes.

S. Salir.



Es decir, debe permitir al usuario realizar las siguientes operaciones:

1 - Añadir un nuevo contacto (al final de los datos existentes). El nombre no 
debe estar vacío (si introduce un nombre vacío, se le volverá a pedir tantas 
veces como sea necesario). Si se introduce una cadena vacía como respuesta al 
año de nacimiento, éste se guardará como 0, y lo mismo ocurrirá con la 
estatura. No se debe realizar ninguna otra validación.

2 - Buscar contactos que contengan un determinado texto (búsqueda parcial, en 
cualquier campo de texto, sin distinción de mayúsculas y minúsculas). Debe 
mostrar el número de registro y el nombre, en la misma línea, haciendo una 
pausa después de cada 22 líneas en pantalla.

3 - Ver todos los datos de un contacto determinado, a partir de su número de 
registro. Se debe avisar (pero no volver a pedir) si el número no es válido.

4 - Modificar un registro: pedirá al usuario su número (por ejemplo, 1 para la 
primera ficha), mostrará el valor anterior de cada campo (por ejemplo, dirá: 
"Nombre anterior: Elon Musk") y permitirá escribir un nuevo valor para ese 
campo, o bien pulsar Intro para dejarlo sin modificar. Se debe avisar al 
usuario (pero no volver a pedir) si introduce un número de registro incorrecto.

5 - Eliminar un registro, en la posición indicada por el usuario. Se le debe 
avisar (pero no volver a preguntar) si introduce un número de registro 
incorrecto. Debe mostrar el registro que se va a eliminar y solicitar 
confirmación antes de la eliminación.

6 - Ordenar los datos alfabéticamente, por nombre.

7 - Ver estadísticas: mostrará la cantidad de contactos, la edad media (para 
cada edad supondremos que basta con restar al año actual, 2021, el año de 
nacimiento) de todos nuestros contactos (salvo los que tengan 0 como año de 
nacimiento) y la estatura media de nuestros contactos (salvo los que tengan 0 
como estatura).

8 - Corregir errores frecuentes: eliminará espacios finales, espacios iniciales 
y espacios duplicados en el nombre, aficiones y comentarios de todos los 
registros existentes. Si alguna estatura es negativa o superior a tres metros, 
se guardará un 0 en su lugar. Si algún año de nacimiento es anterior a 1850 o 
posterior a 2100, se guardará como 0.

S - Salir de la aplicación (como no guardamos la información en fichero, los 
datos se perderán).

El menú deberá repetirse hasta que el usuario escoja la opción "S" (que será 
aceptable tanto en mayúsculas como en minúsculas).

*/

using System;

class Nota03
{
    struct AgendaContactos
    {
        public string nombre;
        public string email;
        public ushort anyoNacimiento;
        public string aficiones;
        public float estatura;
        public string comentarios;
    }
    static void Main()
    {
        const int MAX_CONTACTOS = 10000;
        AgendaContactos[] contacto = new AgendaContactos[MAX_CONTACTOS];

        int contactos = 0;
        bool terminado = false;
        int sumaEdades = 0;
        float sumaEstaturas = 0;

        do
        {
            Console.WriteLine();
            Console.WriteLine("------------MENÚ------------");
            Console.WriteLine("1. Añadir datos de un contacto.");
            Console.WriteLine("2. Buscar entre los contactos existentes.");
            Console.WriteLine("3. Ver detalles de un contacto.");
            Console.WriteLine("4. Modificar los datos de un contacto.");
            Console.WriteLine("5. Borrar un contacto.");
            Console.WriteLine("6. Ordenar datos.");
            Console.WriteLine("7. Ver estadísticas.");
            Console.WriteLine("8. Corregir errores frecuentes");
            Console.WriteLine("S. Salir.");
            Console.WriteLine();
            Console.WriteLine("Contactos disponibles: " + contactos);
            Console.WriteLine();

            Console.Write("Elige una opción: ");
            char opcion = Convert.ToChar(Console.ReadLine());
            Console.WriteLine();

            switch (opcion)
            {
                case '1': // Añadir datos
                    if (contactos < MAX_CONTACTOS)
                    {
                        do
                        {
                            Console.Write("Nombre del contacto: ");
                            contacto[contactos].nombre = Console.ReadLine();

                            if (contacto[contactos].nombre == "")
                            {
                                Console.WriteLine("No puede estar vacío");
                            }
                        }
                        while (contacto[contactos].nombre == "");

                        Console.Write("Correo electrónico: ");
                        contacto[contactos].email = Console.ReadLine();

                        Console.Write("Año de nacimiento: ");
                        string anyoComoTexto = Console.ReadLine();
                        if (anyoComoTexto == "")
                            contacto[contactos].anyoNacimiento = 0;
                        else
                            contacto[contactos].anyoNacimiento =
                                Convert.ToUInt16(anyoComoTexto);

                        Console.Write("Aficiones:");
                        contacto[contactos].aficiones = Console.ReadLine();

                        Console.Write("Estatura (en metros): ");
                        string estaturaComoTexto = Console.ReadLine();
                        if (estaturaComoTexto == "")
                            contacto[contactos].estatura = 0;
                        else
                            contacto[contactos].estatura =
                                Convert.ToSingle(estaturaComoTexto);

                        Console.Write("Comentarios:");
                        contacto[contactos].comentarios = Console.ReadLine();

                        contactos++;
                    }
                    else
                    {
                        Console.WriteLine("No es posible añadir más contactos");
                    }

                    break;

                case '2': // Buscar
                    Console.WriteLine("Buscar contacto");
                    Console.Write("Nombre o Categoría: ");
                    string buscarContacto = Console.ReadLine().ToUpper();
                    Console.WriteLine();

                    for (int i = 0; i < contactos; i++)
                    {
                        if ((contacto[i].nombre.ToUpper().Contains(buscarContacto)
                           || (contacto[i].email.ToUpper().Contains(buscarContacto)
                           || (contacto[i].aficiones.ToUpper().Contains(buscarContacto)
                           || (contacto[i].comentarios.ToUpper().Contains(buscarContacto))))))
                        {
                            Console.Write("Nº " + (i + 1) + " - Nombre: "
                                + contacto[i].nombre);
                            Console.WriteLine();

                            if (i % 20 == 19)
                            {
                                Console.Write("Pulse intro para continuar... ");
                                Console.ReadLine();
                            }

                        }
                        Console.WriteLine();
                    }
                    break;

                case '3': // Ver detalles
                    Console.Write("Qué número de contacto quieres ver? ");
                    int contactoVer = Convert.ToInt32(Console.ReadLine());

                    if ((contactoVer < 1) || (contactoVer > contactos))
                    {
                        Console.WriteLine("Número de contacto no válido");
                    }
                    else
                    {
                        Console.Write("Contacto {0}: {1}, {2}, {3}, {4}, {5}",
                            contactoVer,
                            contacto[contactoVer - 1].nombre,
                            contacto[contactoVer - 1].email,
                            contacto[contactoVer - 1].anyoNacimiento,
                            contacto[contactoVer - 1].aficiones,
                            contacto[contactoVer - 1].estatura);
                        Console.WriteLine();
                    }
                    break;

                case '4': // Modificar
                    Console.Write("Qué número de contacto quieres modificar?: ");
                    int registro = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (registro >= 0 && registro < contactos)
                    {
                        Console.Write("Nombre (era {0}): ",
                            contacto[registro].nombre);
                        string nuevoValor = Console.ReadLine();
                        if (nuevoValor != "")
                            contacto[registro].nombre = nuevoValor;

                        Console.Write("Correo electrónico (era {0}): ",
                            contacto[registro].email);
                        nuevoValor = Console.ReadLine();
                        if (nuevoValor != "")
                            contacto[registro].email = nuevoValor;

                        Console.Write("Año de nacimiento (era {0}): ",
                            contacto[registro].anyoNacimiento);
                        nuevoValor = Console.ReadLine();
                        if (nuevoValor != "")
                            contacto[registro].anyoNacimiento =
                                Convert.ToUInt16(nuevoValor);

                        Console.Write("Aficiones (era {0}): ",
                            contacto[registro].aficiones);
                        nuevoValor = Console.ReadLine();
                        if (nuevoValor != "")
                            contacto[registro].aficiones =
                                Convert.ToString(nuevoValor);

                        Console.Write("Estatura en metros (era {0}): ",
                            contacto[registro].estatura);
                        nuevoValor = Console.ReadLine();
                        if (nuevoValor != "")
                            contacto[registro].estatura =
                                Convert.ToSingle(nuevoValor);

                        Console.Write("Comentarios (era {0}): ",
                            contacto[registro].comentarios);
                        nuevoValor = Console.ReadLine();
                        if (nuevoValor != "")
                            contacto[registro].comentarios =
                                Convert.ToString(nuevoValor);
                    }
                    else
                        Console.Write("Número de contacto incorrecto");

                    Console.WriteLine();
                    break;


                case '5': // Borrar
                    Console.Write("Introduce la posición a borrar: ");
                    int posicionBorrar = Convert.ToInt32(Console.ReadLine()) - 1;

                    if ((posicionBorrar < 0) || (posicionBorrar >= contactos))
                    {
                        Console.WriteLine("Número de contacto no válido");
                    }
                    else
                    {
                        for (int i = posicionBorrar; i < contactos; i++)
                        {
                            contacto[i] = contacto[i + 1];
                        }
                        contactos--;
                    }
                    break;

                case '6': // Ordenar
                    for (int i = 0; i < contactos - 1; i++)
                    {
                        for (int j = i; j < contactos; j++)
                        {
                            if (String.Compare(contacto[i].nombre,
                                contacto[j].nombre, true) > 0)
                            {
                                AgendaContactos aux = contacto[i];
                                contacto[i] = contacto[j];
                                contacto[j] = aux;
                            }
                        }
                    }
                    Console.WriteLine("Ordenado");
                    break;

                case '7': // Ver estadísticas
                    if (contactos != 0)
                    {
                        int cantidadEstaturas = 0;
                        int cantidadEdades = 0;
                        for (int i = 0; i < contactos; i++)
                        {
                            if (contacto[i].anyoNacimiento != 0)
                            {
                                cantidadEdades++;
                                sumaEdades += 2021 - contacto[i].anyoNacimiento;
                            }

                            if (contacto[i].estatura != 0)
                            {
                                cantidadEstaturas++;
                                sumaEstaturas += contacto[i].estatura;
                            }
                        }
                        
                        Console.WriteLine("Contactos: " +
                            contactos);

                        if (cantidadEdades > 0)
                            Console.WriteLine("Edad media: " +
                                (sumaEdades / cantidadEdades));

                        if (cantidadEstaturas > 0)
                            Console.WriteLine("Estatura media: " +
                                (sumaEstaturas / cantidadEstaturas));
                    }
                    else
                    {
                        Console.WriteLine("No hay datos disponibles.");
                    }
                    break;

                case '8': // Corregir errores
                    Console.WriteLine("Vamos a proceder a corregir errores " +
                       "frecuentes");
                    Console.WriteLine();

                    // Espacios iniciales y finales
                    for (int x = 0; x < contactos; x++)
                    {
                        contacto[x].nombre = contacto[x].nombre.Trim();
                        contacto[x].aficiones = contacto[x].aficiones.Trim();
                        contacto[x].comentarios = contacto[x].comentarios.Trim();
                    }

                    // Espacios intermedios redundantes
                    for (int x = 0; x < contactos; x++)
                    {
                        while (contacto[x].nombre.Contains("  ")
                            || contacto[x].aficiones.Contains("  ")
                            || contacto[x].comentarios.Contains("  "))
                        {
                            contacto[x].nombre =
                                contacto[x].nombre.Replace("  ", " ");
                            contacto[x].aficiones =
                                contacto[x].aficiones.Replace("  ", " ");
                            contacto[x].comentarios =
                                contacto[x].comentarios.Replace("  ", " ");
                        }
                    }

                    // Corregir estatura
                    for (int x = 0; x < contactos; x++)
                    {
                        if (contacto[contactos].estatura < 0
                            || contacto[contactos].estatura > 3)
                        {
                            contacto[contactos].estatura = 0;
                        }
                    }

                    // Corregir año de nacimiento
                    for (int x = 0; x < contactos; x++)
                    {
                        if (contacto[contactos].anyoNacimiento < 1850
                            || contacto[contactos].anyoNacimiento > 2100)
                        {
                            contacto[contactos].anyoNacimiento = 0;
                        }
                    }
                    Console.WriteLine("Errores frecuentes corregidos");
                    break;

                case 's': // Salir
                case 'S':
                    terminado = true;
                    break;

                default:
                    Console.WriteLine("No es una opción válida.");
                    break;
            }
        }
        while (!terminado);
        Console.WriteLine("Sesión terminada");
    }
}
