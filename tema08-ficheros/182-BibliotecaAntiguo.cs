/*
VIRGINIA (...), retoques por Nacho

182. Crea una nueva versión del gestor de biblioteca, en su primera versión 
(ej.091), partiendo de la versión oficial, en la que guardes datos tras cada 
cambio (añadir, modificar, etc.) usando StreamWriter y cargues datos al 
comenzar la ejecución con StreamReader. Guarda en fichero los datos de cada 
libro usando única línea, en la que los datos estén separados por algún 
carácter especial (como "-", "@", "#" o "¬"), de modo que puedas hacer ".Split"
al leerlos para analizarlos con facilidad. Debes gestionar los posibles 
errores de forma adecuada. Opcionalmente, puedes hacer que los datos no se 
guarden en un array, sino en una lista.
*/

using System;
using System.IO;
using System.Collections.Generic;

class Biblioteca
{    
    struct TipoLibro
    {
        public string titulo;
        public string autor;
        public short publicacion;
    }

    public static string nombreFichero = "Biblioteca.txt";
    public static char caracterDivisor = '@';

    static void MostrarMenu()
    {
        Console.WriteLine();
        Console.WriteLine("1. Añadir un nuevo libro");
        Console.WriteLine("2. Mostrar todo los libros");
        Console.WriteLine("3. Buscar libros");
        Console.WriteLine("4. Buscar por fecha");
        Console.WriteLine("5. Modificar un registro");
        Console.WriteLine("6. Eliminar un registro");
        Console.WriteLine("7. Corregir registro");
        Console.WriteLine("S. Salir");
    }

    static void ElegirOpcion(out string opc, out bool salir)
    {
        Console.WriteLine("Seleccione la opcion que desea realizar: ");
        opc = Console.ReadLine().ToUpper();
        salir = opc == "S";
    }
    

    static void AnyadirDatos(List<TipoLibro> datos)
    {               
        TipoLibro dato;
        
        Console.Write("Introduzca titulo: ");
        dato.titulo = Console.ReadLine();
        while (dato.titulo == "")
        {
            Console.WriteLine("El campo no puede estar vacio");
            Console.Write("Introduzca titulo: ");
            dato.titulo = Console.ReadLine();
        }

        Console.Write("Introduzca autor: ");
        dato.autor = Console.ReadLine();
        while (dato.autor == "")
        {
            Console.WriteLine("El campo no puede estar vacio");
            Console.Write("Introduzca autor: ");
            dato.autor = Console.ReadLine();
        }

        Console.Write("Introduzca año publicacion: ");
        string respuesta = (Console.ReadLine());
        if (respuesta == "")
        {
            dato.publicacion = -1;
        }
        else
        {
            dato.publicacion = Convert.ToInt16(respuesta);
        }

        datos.Add(dato);
        GuardarDatos(datos);
    }

    static void MostrarLibros(List<TipoLibro> datos)
    {
        int posicion = 0;
        for (int i = 0; i < datos.Count; i++)
        {
            Console.Write("{0}. {1}, {2}, ",
                i + 1, datos[i].titulo, datos[i].autor);
            if (datos[i].publicacion == -1)
            {
                Console.WriteLine("año desconocido");
            }
            else
            {
                Console.WriteLine(datos[i].publicacion);
            }
            posicion++;
            if (posicion == 21)
            {
                Console.WriteLine("Para continuar pulse ENTER");
                Console.ReadLine();
                posicion = 0;
            }
        }
    }

    static void BuscarLibros(List<TipoLibro> datos)
    {
        Console.Write("Palabra por la que desea buscar: ");
        string busquedaTexto = Console.ReadLine().ToLower();
        int posicion = 0;
        for (int i = 0; i < datos.Count; i++)
        {
            if (datos[i].titulo.ToLower().Contains(busquedaTexto) ||
                datos[i].autor.ToLower().Contains(busquedaTexto))
            {
                Console.WriteLine("{0}. {1}, {2}.",
                i + 1, datos[i].titulo, datos[i].autor);
            }
            posicion++;
            if (posicion == 21)
            {
                Console.WriteLine("Para continuar pulse ENTER");
                Console.ReadLine();
                posicion = 0;
            }
        }
    }

    static void BuscarPorFecha(List<TipoLibro> datos)
    {
        Console.WriteLine("Introduzca el año de comienzo");
        ushort primerano = Convert.ToUInt16(Console.ReadLine());
        Console.WriteLine("Introduzca el año final");
        ushort segundoano = Convert.ToUInt16(Console.ReadLine());
        for (int i = 0; i < datos.Count; i++)
        {
            if (primerano > segundoano)
            {
                ushort aux = primerano;
                primerano = segundoano;
                segundoano = aux;
            }

            if ((datos[i].publicacion >= primerano)
                && (datos[i].publicacion <= segundoano))
            {
                Console.Write("{0}. {1}, {2}.", i + 1, datos[i].titulo,
                    datos[i].autor);
                if (datos[i].publicacion == -1)
                {
                    Console.WriteLine("año desconocido");
                }
                else
                {
                    Console.WriteLine(datos[i].publicacion);
                }
            }
        }
    }

    static void Modificar(List<TipoLibro> datos)
    {
        Console.Write("¿Qué posición desea modificar? ");
        int indice = Convert.ToInt32(Console.ReadLine()) - 1;
        if ((indice < 0) || (indice >= datos.Count))
        {
            Console.WriteLine("Posicion no valida");
        }
        else
        {
            Console.WriteLine("Titulo: " + datos[indice].titulo);
            Console.WriteLine("Nuevo título (Intro para no cambiar): ");
            string nuevoTitulo = Console.ReadLine();
            if (nuevoTitulo != "")
            {
                nuevoTitulo = nuevoTitulo.Trim();

                if (nuevoTitulo.ToUpper() == nuevoTitulo)
                {
                    Console.WriteLine("El titulo esta completamente en " +
                        "mayusculas");
                }
                if (nuevoTitulo.ToLower() == nuevoTitulo)
                {
                    Console.WriteLine("El titulo esta completamente en " +
                        "minusculas");
                }
                if (nuevoTitulo.Contains("  "))
                {
                    Console.WriteLine("El Titulo tiene espacios redundantes");
                }
            }
            else
            {
                nuevoTitulo = datos[indice].titulo;
            }

            Console.WriteLine("Autor: " + datos[indice].autor);
            Console.WriteLine("Nuevo autor (Intro para no cambiar): ");
            string nuevoAutor = Console.ReadLine();
            if (nuevoAutor != "")
            {
                nuevoAutor = nuevoAutor.Trim();

                if (nuevoAutor.ToUpper() == nuevoAutor)
                {
                    Console.WriteLine("El autor esta completamente en mayusculas");
                }
                if (nuevoAutor.ToLower() == nuevoAutor)
                {
                    Console.WriteLine("El autor esta completamente en minisuclas");
                }
                if (nuevoAutor.Contains("  "))
                {
                    Console.WriteLine("El autor tiene espacios redundantes");
                }
            }
            else
            {
                nuevoAutor = datos[indice].autor;
            }

            Console.WriteLine("Año: " + datos[indice].publicacion);
            Console.WriteLine("Dato modificado: ");
            string respuesta = Console.ReadLine();
            short nuevaPublicacion;
            if (respuesta != "")
            {
                nuevaPublicacion = Convert.ToInt16(respuesta);
            }
            else
            {
                nuevaPublicacion = datos[indice].publicacion;
            }

            TipoLibro dato;
            dato.titulo = nuevoTitulo;
            dato.autor = nuevoAutor;
            dato.publicacion = nuevaPublicacion;
            
            datos.RemoveAt(indice);
            datos.Insert(indice, dato);
            
            GuardarDatos(datos);
        }
    }

    static void Eliminar(List<TipoLibro> datos)
    {
        Console.Write("Posicion que desea eliminar?: ");
        int eliminar = Convert.ToInt32(Console.ReadLine()) - 1;
        if ((eliminar < 0) || (eliminar >= datos.Count))
        {
            Console.WriteLine("numero no valido");
        }
        else
        {
            Console.WriteLine("Desea eliminar: ");
            Console.Write("{0}. {1} titulo; {2} autor;", eliminar + 1,
                datos[eliminar].titulo, datos[eliminar].autor);
            if (datos[eliminar].publicacion == -1)
            {
                Console.WriteLine("año desconocido");
            }
            else
            {
                Console.WriteLine(datos[eliminar].publicacion);
            }
            Console.WriteLine("Desea eliminar? s/n");
            string decision = Console.ReadLine().ToUpper();
            if (decision == "S")
            {
                datos.RemoveAt(eliminar);
                GuardarDatos(datos);
            }
            else
            {
                Console.WriteLine("No se ha eliminado");
            }
            Console.WriteLine();
        }
    }

    static void Corregir(List<TipoLibro> datos)
    {
        for (int i = 0; i < datos.Count; i++)
        {
            string titulo = datos[i].titulo;
            bool hayProblemas = false;
            // Espacios redundantes?
            if (titulo.Contains("  "))
                hayProblemas = true;
            // Comienza o termina con espacio?
            if (titulo.StartsWith(" ") || titulo.EndsWith(" "))
                hayProblemas = true;
            // Mayúscula justo después de minúscula?
            for (int j = 0; j < titulo.Length - 1; j++)
            {
                if ((titulo[j] >= 'a') &&
                    (titulo[j] <= 'z') &&
                    (titulo[j + 1] >= 'A') &&
                    (titulo[j + 1] <= 'Z'))
                {
                    hayProblemas = true;
                }
            }
            if (hayProblemas)
            {
                Console.WriteLine("El título {0} tiene problemas", titulo);
                Console.WriteLine("¿Desea arreglar este registro (s/n)?");
                string decision = Console.ReadLine().ToLower();
                
                if (decision == "s")
                {                   
                    string tituloCorregido = 
                        datos[i].titulo.Replace("  ", " ");
                    tituloCorregido = tituloCorregido.Trim();
                    tituloCorregido = tituloCorregido.ToLower();

                    string[] fragmentos = tituloCorregido.Split('.');
                    string tituloFinal = "";
                    for (int j = 0; j < fragmentos.Length; j++)
                    {
                        string mays = fragmentos[i].ToUpper();
                        string mins = fragmentos[i].ToLower();
                        tituloFinal += mays[0] + mins.Substring(1) + ".";
                    }
                    datos.RemoveAt(i);
                    datos.Insert(i, new TipoLibro 
                    { 
                        titulo = tituloFinal,
                        autor = datos[i].autor,
                        publicacion = datos[i].publicacion
                    });
                }
                else                
                    Console.WriteLine("No se realizarán cambios");                
            }
            else
                Console.WriteLine("Todos los títulos son correctos.");
        }
        GuardarDatos(datos);
    }

    static void MostrarError()
    {
        Console.WriteLine("Opción incorrecta.");
    }
    
    static List<TipoLibro> CargarDatos()
    {
        List<TipoLibro> datos = new List<TipoLibro>();
        
        try
        {
            StreamReader ficheroLibros;
            ficheroLibros = File.OpenText(nombreFichero);
            string linea = ficheroLibros.ReadLine();
            while (linea != null)
            {
                string[] trozos = linea.Split(caracterDivisor);
                TipoLibro dato;
                dato.titulo = trozos[0];
                dato.autor = trozos[1];
                dato.publicacion = Convert.ToInt16(trozos[2]);
                datos.Add(dato);
                linea = ficheroLibros.ReadLine();
            }
            ficheroLibros.Close();
        }
        catch
        {

        }
        
        return datos;
    }
    
    static void GuardarDatos(List<TipoLibro> datos)
    {
        try
        {
            StreamWriter ficheroLibros;
            ficheroLibros = File.CreateText(nombreFichero);
            foreach (TipoLibro libro in datos)
            {
                ficheroLibros.WriteLine(libro.titulo + caracterDivisor + 
                                        libro.autor + caracterDivisor + 
                                        libro.publicacion);
            }            
            ficheroLibros.Close();
        }
        catch (FileNotFoundException existsExc)
        {
            Console.WriteLine("No existe el fichero." +
                                "Error: " + existsExc.Message);
        }
        catch (PathTooLongException pathExc)
        {
            Console.WriteLine("Ruta demasiado larga. " +
                                "Error: " + pathExc.Message);
        }
        catch (IOException ioExc)
        {
            Console.WriteLine("No se puede escribir en el fichero." +
                                "Error: " + ioExc.Message);
        }
        catch (Exception exc)
        {
            Console.WriteLine("Se ha producido un error. " +
                                "Error: " + exc.Message);
        }
    }

    static void Main()
    {
        List<TipoLibro> datos = CargarDatos();

        string opcion;
        bool salir = false;
        do
        {
            MostrarMenu();
            ElegirOpcion(out opcion, out salir);

            switch (opcion)
            {
                case "1":
                    AnyadirDatos(datos);
                    break;

                case "2":
                    MostrarLibros(datos);
                    break;

                case "3":
                    BuscarLibros(datos);
                    break;

                case "4":
                    BuscarPorFecha(datos);
                    break;

                case "5":
                    Modificar(datos);
                    break;

                case "6":
                    Eliminar(datos);
                    break;

                case "7":
                    Corregir(datos);
                    break;

                case "S":
                    salir = true;
                    break;

                default:
                    MostrarError();
                    break;
            }
        }
        while (!salir);
        Console.WriteLine("Ha seleccionado salir");
    }
}
