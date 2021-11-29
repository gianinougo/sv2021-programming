// 74. Ejercicio biblioteca.
// Rocio (...)

/*
Crea un programa en C# que pueda almacenar hasta 25000 libros. Para cada libro,
debe permitir al usuario almacenar la siguiente información:

• Título (por ejemplo, El resplandor)

• Autor (por ejemplo, Stephen King)

• Año de publicación (p. Ej., 1977)


El programa debe permitir al usuario realizar las siguientes operaciones:

1 - Añadir un libro nuevo. El título y el autor no pueden estar vacíos. Si el
usuario introduce un año vacío, se guardará un -1 en su lugar. Los datos deben
ordenarse automáticamente por título.

2 - Mostrar todos los libros (número de registro, título, autor y año, en una
misma línea), haciendo una pausa tras cada 21 filas. Si para un libro no se
introdujo año, debe mostrar "Año desconocido" en lugar de -1.

3 - Buscar libros que contengan un texto determinado (búsqueda parcial, en
cualquier campo de texto, sin distinguir entre mayúsculas y minúsculas). Debe
mostrar el número de registro, el título, el autor y el año, en una misma
línea, haciendo una pausa después de cada 21 filas.

4 - Buscar libros publicados entre dos fechas (por ejemplo, 1970 y 1985), ambas
incluidas. Nuevamente, debe mostrar el número de registro, el título, el autor
y el año, pero no es necesario hacer una pausa. Debe comportarse correctamente
si el usuario introduce las fechas en orden inverso (primero el mayor año y
luego el menor).

5 - Modificar un registro: solicitará al usuario su número, mostrará el valor
anterior de cada campo y permitirá al usuario pulsar Intro sin escribir nada,
si opta por no modificar alguno de los campos. Se avisará al usuario (pero no
se le volverá a preguntar) si introduce un número de registro incorrecto. Antes
de almacenar los datos, deben eliminarse los espacios iniciales y finales de
cada campo de texto. Se advertirá al usuario si el título o el autor están
completamente en mayúsculas, completamente en minúsculas o si contienen
espacios redundantes.

6 - Eliminar un registro, en la posición ingresada por el usuario. Se debe
avisar (pero no volver a preguntar) si introduce un número de registro
incorrecto. Deberá mostrar el registro que se eliminará y solicitar
confirmación antes de la eliminación.

7 - Corregir la ortografía en los títulos: mostrará los registros que contengan
en el título: dos espacios consecutivos, espacios iniciales o finales, o una
letra mayúscula justo después de una letra minúscula. Después de mostrar cada
registro, le preguntará al usuario "¿Desea arreglar este registro (s/n)?" Si el
usuario responde "s", el programa corregirá su título: eliminará los espacios
finales, los espacios iniciales y los espacios duplicados, y cambiará el texto
a minúsculas, excepto la primera letra y las que siguen a un punto.

S - Salir de la aplicación (como no almacenamos la información en fichero, los
datos se perderán).

*/

using System;
using System.Text;

class Biblioteca
{
    struct TipoLibro
    {
        public string titulo;
        public string autor;
        public short publicacion;
    }

    enum OpcMenu { NUEVO = '1', MOSTRAR, BUSCARLIBROS, BUSCARFECHA,
        MODIFICAR, ELIMINAR, CORREGIR, SALIR = 's' }

    static void Main()
    {
        bool salir = false;
        int cantidad = 0;
        const int MAXIMO = 25000;
        int fila = 0;
        TipoLibro[] datos = new TipoLibro[MAXIMO];
        do
        {
            Console.WriteLine((char)OpcMenu.NUEVO + " .Añadir un nuevo libro");
            Console.WriteLine((char)OpcMenu.MOSTRAR + " .Mostrar todo los libros");
            Console.WriteLine((char)OpcMenu.BUSCARLIBROS + " .buscar libros");
            Console.WriteLine((char)OpcMenu.BUSCARFECHA + " .buscar por fecha");
            Console.WriteLine((char)OpcMenu.MODIFICAR + ". modificar un registro");
            Console.WriteLine((char)OpcMenu.ELIMINAR + ". eliminar un registro");
            Console.WriteLine((char)OpcMenu.CORREGIR + ". corregir registro");
            Console.WriteLine((char)OpcMenu.SALIR + ". salir");
            Console.WriteLine("Seleccione la opcion que desea realizar: ");
            char opcion = Convert.ToChar(Console.ReadLine().ToLower());

            switch (opcion)
            {
                case (char) OpcMenu.NUEVO:

                    if (fila < MAXIMO)
                    {
                        Console.Write("Introduzca titulo: ");
                        datos[cantidad].titulo = Console.ReadLine();
                        while (datos[cantidad].titulo == "")
                        {
                            Console.WriteLine("El campo no puede estar vacio");
                            Console.Write("Introduzca titulo: ");
                            datos[cantidad].titulo = Console.ReadLine();
                        }

                        Console.Write("Introduzca autor: ");
                        datos[cantidad].autor = Console.ReadLine();
                        while (datos[cantidad].autor == "")
                        {
                            Console.WriteLine("El campo no puede estar vacio");
                            Console.Write("Introduzca autor: ");
                            datos[cantidad].autor = Console.ReadLine();
                        }

                        Console.Write("Introduzca año publicacion: ");
                        string publicacion = (Console.ReadLine());
                        if (publicacion == "")
                        {
                            datos[cantidad].publicacion = -1;
                        }
                        else
                        {
                            datos[cantidad].publicacion = Convert.ToInt16(publicacion);
                        }

                        cantidad++;
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("No hay más espacio");
                    }
                    break;

                case (char) OpcMenu.MOSTRAR:
                    fila = 0;
                    for (int i = 0; i < cantidad; i++)
                    {
                        Console.Write("{0}. {1} titulo; {2} autor;",
                            i + 1, datos[i].titulo, datos[i].autor);
                        if (datos[i].publicacion == -1)
                        {
                            Console.WriteLine("año desconocido");
                        }
                        else
                        {
                            Console.WriteLine("{0} publicacion", datos[i].publicacion);
                        }
                        fila++;
                        if (fila == 21)
                        {
                            Console.WriteLine("Para continuar pulse ENTER");
                            Console.ReadLine();
                            fila = 0;
                        }
                    }
                    break;

                case (char) OpcMenu.BUSCARLIBROS:
                    Console.Write("Palabra por la que desea buscar: ");
                    string busquedaTexto = Console.ReadLine().ToLower();
                    fila = 0;
                    for (int i = 0; i < cantidad; i++)
                    {
                        if (datos[i].titulo.ToLower().Contains(busquedaTexto) ||
                            datos[i].autor.ToLower().Contains(busquedaTexto))
                        {
                            Console.WriteLine("{0}. {1} titulo; {2} autor;",
                            i + 1, datos[i].titulo, datos[i].autor);
                        }
                        fila++;
                        if (fila == 21)
                        {
                            Console.WriteLine("Para continuar pulse ENTER");
                            Console.ReadLine();
                            fila = 0;
                        }
                    }
                    break;

                case (char) OpcMenu.BUSCARFECHA:
                    Console.WriteLine("Introduzca el año de comienzo");
                    ushort primerano = Convert.ToUInt16(Console.ReadLine());
                    Console.WriteLine("Introduzca el año final");
                    ushort segundoano = Convert.ToUInt16(Console.ReadLine());
                    for (int i = 0; i < cantidad; i++)
                    {
                        if (primerano > segundoano)
                        {
                            ushort aux = primerano;
                            primerano = segundoano;
                            segundoano = aux;
                        }

                        if ( (datos[i].publicacion >= primerano)
                            && (datos[i].publicacion <= segundoano) )
                        {
                            Console.Write("{0}. {1} titulo; {2} autor;", i + 1, datos[i].titulo, datos[i].autor);
                            if (datos[i].publicacion == -1)
                            {
                                Console.WriteLine("año desconocido");
                            }
                            else
                            {
                                Console.WriteLine("{0} publicacion", datos[i].publicacion);
                            }
                        }

                    }
                    break;

                case (char) OpcMenu.MODIFICAR:
                    Console.WriteLine();
                    Console.Write("¿Qué posición desea modificar? ");
                    int indice = Convert.ToInt32(Console.ReadLine()) - 1;
                    if ((indice < 0) || (indice >= cantidad))
                    {
                        Console.WriteLine("Posicion no valida");
                    }
                    else
                    {
                        Console.WriteLine("Titulo: " + datos[indice].titulo);
                        Console.WriteLine("Nuevo título (Intro para no cambiar): ");
                        string nuevotitulo = Console.ReadLine();
                        if (nuevotitulo != "")
                        {
                            datos[indice].titulo = nuevotitulo.Trim();
                        }
                        if (datos[indice].titulo.ToUpper() == datos[indice].titulo)
                        {
                            Console.WriteLine("El titulo esta completamente en mayusculas");
                        }
                        if (datos[indice].titulo.ToLower() == datos[indice].titulo)
                        {
                            Console.WriteLine("El titulo esta completamente en minusculas");
                        }
                        if (datos[indice].titulo.Contains("  "))
                        {
                            Console.WriteLine("El Titulo tiene espacios redundantes");
                        }

                        Console.WriteLine("Autor: " + datos[indice].autor);
                        Console.WriteLine("Nuevo autor (Intro para no cambiar): ");
                        string nuevoautor = Console.ReadLine();
                        if (nuevoautor != "")
                        {
                            datos[indice].autor = nuevoautor.Trim();
                        }
                        if (datos[indice].autor.ToUpper() == datos[indice].autor)
                        {
                            Console.WriteLine("El autor esta completamente en mayusculas");
                        }
                        if (datos[indice].autor.ToLower() == datos[indice].autor)
                        {
                            Console.WriteLine("El autor esta completamente en minisuclas");
                        }
                        if (datos[indice].autor.Contains("  "))
                        {
                            Console.WriteLine("El autor tiene espacios redundantes");
                        }

                        Console.WriteLine("Año: " + datos[indice].publicacion);
                        Console.WriteLine("Dato modificado: ");
                        string nuevafecha = Console.ReadLine();
                        if (nuevafecha != "")
                        {
                            datos[indice].publicacion = Convert.ToInt16(nuevafecha);
                        }
                    }
                    break;

                case (char) OpcMenu.ELIMINAR:
                    Console.Write("Posicion que desea eliminar?: ");
                    int eliminar = Convert.ToInt32(Console.ReadLine()) - 1;
                    if ((eliminar < 0) || (eliminar >= cantidad))
                    {
                        Console.WriteLine("numero no valido");
                    }
                    else
                    {
                        Console.WriteLine("Desea eliminar: ");
                        Console.Write("{0}. {1} titulo; {2} autor;", eliminar + 1, datos[eliminar].titulo, datos[eliminar].autor);
                        if (datos[eliminar].publicacion == -1)
                        {
                            Console.WriteLine("año desconocido");
                        }
                        else
                        {
                            Console.WriteLine("{0} publicacion", datos[eliminar].publicacion);
                        }
                        Console.WriteLine("Desea eliminar? s/n");
                        string decision = Console.ReadLine().ToLower();
                        if (decision == "s")
                        {
                            for (int i = eliminar; i < cantidad; i++)
                            {
                                datos[i] = datos[i + 1];
                            }
                            cantidad--;
                        }
                        else
                        {
                            Console.WriteLine("No se ha eliminado");
                        }
                        Console.WriteLine();
                    }
                    break;

                case (char) OpcMenu.CORREGIR:
                    for (int i = 0; i < cantidad; i++)
                    {
                        string titulo = datos[i].titulo;
                        bool hayProblemas = false;
                        // Espacios redundantes?
                        if (titulo.Contains("  "))
                            hayProblemas = true;
                        // Comienza o termina con espacio?
                        if (titulo.StartsWith(" ") || titulo.EndsWith(" "))
                            hayProblemas = true;
                        // Máyúscula justo después de minúscula?
                        for (int j = 0; j < titulo.Length - 1; j++)
                        {
                            if ((titulo[j] >= 'a') &&
                                (titulo[j] <= 'z') &&
                                (titulo[j+1] >= 'A') &&
                                (titulo[j+1] <= 'Z'))
                            {
                                hayProblemas = true;
                            }
                        }
                        if (hayProblemas)
                        {
                            Console.WriteLine("El autor {0} tiene problemas", titulo);
                            Console.WriteLine("¿Desea arreglar este registro (s/n)?");
                            string decision = Console.ReadLine().ToLower();
                            if (decision == "s")
                            {
                                datos[i].titulo = datos[i].titulo.Replace("  ", " ");
                                datos[i].titulo = datos[i].titulo.Trim();
                                datos[i].titulo = datos[i].titulo.ToLower();
                                string[] fragmentos = datos[i].titulo.Split('.');
                                string titulofinal = "";
                                for (int j = 0; j < fragmentos.Length; j++)
                                {
                                    string mays = fragmentos[i].ToUpper();
                                    string mins = fragmentos[i].ToLower();
                                    titulofinal += mays[0] + mins.Substring(1) + ".";
                                }
                                datos[i].titulo = titulofinal;
                            }
                            else
                            {
                                Console.WriteLine("No se realizarán cambios");
                            }
                        }
                    }
                    break;

                case (char) OpcMenu.SALIR:
                    Console.WriteLine("Ha seleccionado salir");
                    salir = true;
                    break;

                default:
                    break;
            }
        }
        while ( ! salir );
    }
}

