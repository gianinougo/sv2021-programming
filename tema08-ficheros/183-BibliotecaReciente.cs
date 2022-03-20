// Ejercicio recomendado 183
// Javier (...)

/*
 * Nueva versión del gestor de biblioteca (ej.161) en la que guardes datos tras 
 * cada cambio (añadir, modificar, etc.) usando StreamWriter y cargues datos al 
 * comenzar la ejecución con StreamReader. Guarda en fichero los datos de cada 
 * libro usando varias líneas: una para el tìtulo, otra para el autor, otra 
 * para el año de publicación. Para simplificar la lectura, puedes guardar al 
 * principio del fichero la cantidad de registros que hay, así como una primera 
 * línea antes de cada registro que sea "l" para un libro convencional o "e" 
 * para un libro electrónico (y en ese caso, el "formato" se guardará en una 
 * línea adicional, después del año de publicación). Debes gestionar los 
 * posibles errores de forma adecuada.
 */

using System;
using System.IO;
using System.Collections.Generic;

// ------

class Libro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public short Publicacion { get; set; }

    public Libro(string titulo, string autor, short publicacion)
    {
        this.Titulo = titulo;
        this.Autor = autor;
        this.Publicacion = publicacion;
    }

    public override string ToString()
    {
        if (Publicacion == -1)
        {
            return Titulo + ", " + Autor + ", " + "año desconocido";
        }
        else
        {
            return Titulo + ", " + Autor + ", " + Publicacion;
        }
    }

    public virtual bool Contiene(string texto)
    {
        bool contiene = false;
        if (Titulo.ToLower().Contains(texto.ToLower()) ||
            Autor.ToLower().Contains(texto.ToLower()))
        {
            contiene = true;
        }
        return contiene;
    }
}

// ------


class LibroElectronico : Libro
{
    public string Formato { get; set; }

    public LibroElectronico(string titulo, string autor, short publicacion, string formato)
        : base(titulo, autor, publicacion)
    {
        this.Formato = formato;
    }

    public override string ToString()
    {
        return base.ToString() + ", " + Formato;
    }

    public override bool Contiene(string texto)
    {
        if (Formato.ToLower().Contains(texto.ToLower()))
        {
            return true;
        }
        return base.Contiene(texto);

        // Alternativa:
        // return (Formato.ToLower().Contains(texto.ToLower()) 
        //  || base.Contiene(texto));
    }
}
// ------

class Biblioteca
{
    const string NOMBRE_FICHERO = "datos.txt";

    static void MostrarMenu()
    {
        Console.WriteLine();
        Console.WriteLine("1. Añadir un nuevo libro");
        Console.WriteLine("2. Mostrar todo los libros");
        Console.WriteLine("3. Buscar libros");
        Console.WriteLine("4. Buscar por fecha");
        Console.WriteLine("5. Modificar un registro");
        Console.WriteLine("6. Eliminar un registro");
        Console.WriteLine("7. Correcciones automáticas");
        Console.WriteLine("S. Salir");
    }

    static void ElegirOpcion(out string opc, out bool salir)
    {
        Console.WriteLine("Seleccione la opcion que desea realizar: ");
        opc = Console.ReadLine().ToUpper();
        salir = opc == "S";
    }

    static void AnyadirDatos(List<Libro> listaLibros)
    {
        string titulo;
        string autor;
        short publicacion;
        string formato = "";

        Console.WriteLine("Libro electronico? s/n");
        string electronico = Console.ReadLine().ToLower();

        Console.Write("Introduzca titulo: ");
        titulo = Console.ReadLine();
        while (titulo == "")
        {
            Console.WriteLine("El campo no puede estar vacio");
            Console.Write("Introduzca titulo: ");
            titulo = Console.ReadLine();
        }

        Console.Write("Introduzca autor: ");
        autor = Console.ReadLine();
        while (autor == "")
        {
            Console.WriteLine("El campo no puede estar vacio");
            Console.Write("Introduzca autor: ");
            autor = Console.ReadLine();
        }

        Console.Write("Introduzca año publicacion: ");
        string publi = Console.ReadLine();
        if (publi == "")
        {
            publicacion = -1;
        }
        else
        {
            publicacion = Convert.ToInt16(publi);
        }

        if (electronico != "s")
            listaLibros.Add(new Libro(titulo, autor, publicacion));
        else
        {
            Console.Write("Introduzca el formato (pdf, epub...): ");
            formato = Console.ReadLine();
            while (formato == "")
            {
                Console.WriteLine("El campo no puede estar vacio");
                Console.Write("Introduzca el formato (pdf, epub...): ");
                formato = Console.ReadLine();
            }
            listaLibros.Add(new LibroElectronico(titulo, autor, publicacion, formato));
        }

        GuardarDatos(listaLibros);
    }

    static void MostrarLibros(List<Libro> listaLibros)
    {
        int posicion = 0;
        for (int i = 0; i < listaLibros.Count; i++)
        {
            Console.WriteLine((i + 1) + " " + listaLibros[i]);

            posicion++;

            if (posicion == 21)
            {
                Console.WriteLine("Para continuar pulse ENTER");
                Console.ReadLine();
                posicion = 0;
            }
        }
    }

    static void BuscarLibros(List<Libro> listaLibros)
    {
        Console.Write("Palabra por la que desea buscar: ");
        string busquedaTexto = Console.ReadLine().ToLower();
        int posicion = 0;
        for (int i = 0; i < listaLibros.Count; i++)
        {
            if (listaLibros[i].Contiene(busquedaTexto))
            {
                Console.WriteLine((i + 1) + " " + listaLibros[i]);
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

    static void BuscarPorFecha(List<Libro> listaLibros)
    {
        Console.WriteLine("Introduzca el año de comienzo");
        ushort primerano = Convert.ToUInt16(Console.ReadLine());
        Console.WriteLine("Introduzca el año final");
        ushort segundoano = Convert.ToUInt16(Console.ReadLine());
        for (int i = 0; i < listaLibros.Count; i++)
        {
            if (primerano > segundoano)
            {
                ushort aux = primerano;
                primerano = segundoano;
                segundoano = aux;
            }

            if ((listaLibros[i].Publicacion >= primerano)
                && (listaLibros[i].Publicacion <= segundoano))
            {
                Console.WriteLine((i + 1) + " " + listaLibros[i]);
            }
        }
    }

    static void Modificar(List<Libro> listaLibros)
    {
        Console.Write("¿Qué posición desea modificar? ");
        int indice = Convert.ToInt32(Console.ReadLine()) - 1;
        if ((indice < 0) || (indice >= listaLibros.Count))
        {
            Console.WriteLine("Posicion no valida");
        }
        else
        {
            Console.WriteLine("Titulo: " + listaLibros[indice].Titulo);
            Console.WriteLine("Nuevo título (Intro para no cambiar): ");
            string nuevotitulo = Console.ReadLine();
            if (nuevotitulo != "")
            {
                listaLibros[indice].Titulo = nuevotitulo.Trim();
            }
            if (listaLibros[indice].Titulo.ToUpper() == listaLibros[indice].Titulo)
            {
                Console.WriteLine("El titulo esta completamente en mayusculas");
            }
            if (listaLibros[indice].Titulo.ToLower() == listaLibros[indice].Titulo)
            {
                Console.WriteLine("El titulo esta completamente en minusculas");
            }
            if (listaLibros[indice].Titulo.Contains("  "))
            {
                Console.WriteLine("El Titulo tiene espacios redundantes");
            }

            Console.WriteLine("Autor: " + listaLibros[indice].Autor);
            Console.WriteLine("Nuevo autor (Intro para no cambiar): ");
            string nuevoautor = Console.ReadLine();
            if (nuevoautor != "")
            {
                listaLibros[indice].Autor = nuevoautor.Trim();
            }
            if (listaLibros[indice].Autor.ToUpper() == listaLibros[indice].Autor)
            {
                Console.WriteLine("El autor esta completamente en mayusculas");
            }
            if (listaLibros[indice].Autor.ToLower() == listaLibros[indice].Autor)
            {
                Console.WriteLine("El autor esta completamente en minisuclas");
            }
            if (listaLibros[indice].Autor.Contains("  "))
            {
                Console.WriteLine("El autor tiene espacios redundantes");
            }

            Console.WriteLine("Año: " + listaLibros[indice].Publicacion);
            Console.WriteLine("Dato modificado: ");
            string nuevafecha = Console.ReadLine();
            if (nuevafecha != "")
            {
                listaLibros[indice].Publicacion = Convert.ToInt16(nuevafecha);
            }

            GuardarDatos(listaLibros);
        }
    }

    static void Eliminar(List<Libro> listaLibros)
    {
        Console.Write("Posicion que desea eliminar?: ");
        int eliminar = Convert.ToInt32(Console.ReadLine()) - 1;
        if ((eliminar < 0) || (eliminar >= listaLibros.Count))
        {
            Console.WriteLine("numero no valido");
        }
        else
        {
            Console.WriteLine("Desea eliminar: ");
            Console.Write("{0}." + listaLibros[eliminar], eliminar + 1);

            Console.WriteLine("Desea eliminar? s/n");
            string decision = Console.ReadLine().ToUpper();
            if (decision == "S")
                listaLibros.RemoveAt(eliminar);
            else
                Console.WriteLine("No se ha eliminado");

            Console.WriteLine();

            GuardarDatos(listaLibros);
        }
    }

    static void Corregir(List<Libro> listaLibros)
    {
        foreach (Libro libro in listaLibros)
        {
            string titulo = libro.Titulo;
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
                    (titulo[j + 1] >= 'A') &&
                    (titulo[j + 1] <= 'Z'))
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
                    libro.Titulo = libro.Titulo.Replace("  ", " ");
                    libro.Titulo = libro.Titulo.Trim();
                    libro.Titulo = libro.Titulo.ToLower();
                    string[] fragmentos = libro.Titulo.Split('.');
                    string titulofinal = "";
                    for (int j = 0; j < fragmentos.Length; j++)
                    {
                        string mays = fragmentos[j].ToUpper();
                        string mins = fragmentos[j].ToLower();
                        titulofinal += mays[0] + mins.Substring(1) + ".";
                    }
                    libro.Titulo = titulofinal;

                    GuardarDatos(listaLibros);
                }
                else
                {
                    Console.WriteLine("No se realizarán cambios");
                }
            }
        }
        Console.WriteLine("Correcciones automáticas terminadas");
    }

    static void Salir(bool salir)
    {
        Console.WriteLine("Ha seleccionado salir");
    }

    static void MostrarError()
    {
        Console.WriteLine("Opción incorrecta.");
    }

    static void Main()
    {
        bool salir;
        List<Libro> listaLibros = new List<Libro>();
        string opcion;

        listaLibros = CargarDatos();

        do
        {
            MostrarMenu();
            ElegirOpcion(out opcion, out salir);

            switch (opcion)
            {
                case "1":
                    AnyadirDatos(listaLibros);
                    break;

                case "2":
                    MostrarLibros(listaLibros);
                    break;

                case "3":
                    BuscarLibros(listaLibros);
                    break;

                case "4":
                    BuscarPorFecha(listaLibros);
                    break;

                case "5":
                    Modificar(listaLibros);
                    break;

                case "6":
                    Eliminar(listaLibros);
                    break;

                case "7":
                    Corregir(listaLibros);
                    break;

                case "S":
                    Salir(salir);
                    break;

                default:
                    MostrarError();
                    break;
            }
        }
        while (!salir);
    }

    private static void GuardarDatos(List<Libro> listaLibros)
    {
        /* formato de los registros en el fichero
         * número de registros
         * "l" para libro o "e" para libro electrónico
         * titulo
         * autor
         * publicacion
         * si es electronico aparecerá el formato
         * linea en blanco
        */

        try
        {
            StreamWriter sw = File.CreateText(NOMBRE_FICHERO);

            if (listaLibros.Count > 0)
            {
                sw.WriteLine(listaLibros.Count);
                
                foreach (Libro libro in listaLibros)
                {
                    if (libro is LibroElectronico)
                        sw.WriteLine("e");
                    else 
                        sw.WriteLine("l");

                    sw.WriteLine(libro.Titulo);
                    sw.WriteLine(libro.Autor);
                    sw.WriteLine(libro.Publicacion);
                    if (libro is LibroElectronico)
                        sw.WriteLine(((LibroElectronico)libro).Formato);

                    // añado una línea en blanco tras cada registro
                    sw.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No hay datos, el fichero se queda vacío");
            }
            sw.Close();
        }
        catch (PathTooLongException pe)
        {
            Console.WriteLine(pe.Message);
        }
        catch (FileNotFoundException fe)
        {
            Console.WriteLine(fe.Message);
        }
        catch (IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }        
    }

    private static List<Libro> CargarDatos()
    {
        List<Libro> listaLibros = new List<Libro>();
        try
        {
            /* formato de los registros en el fichero
                 * número de registros
                 * "l" para libro o "e" para libro electrónico
                 * titulo
                 * autor
                 * publicacion
                 * si es electronico aparecerá el formato
                 * linea en blanco
                 */

            StreamReader sr = File.OpenText(NOMBRE_FICHERO);
            string linea = sr.ReadLine();
            int numRegistros = 0;
            
            if (linea != null)
                numRegistros = Convert.ToInt32(linea);

            for (int i = 0; i < numRegistros; i++)
            {
                string tipoLibro = sr.ReadLine();
                string titulo = sr.ReadLine();
                string autor = sr.ReadLine();
                short publicacion = Convert.ToInt16(sr.ReadLine());

                string formato;
                if (tipoLibro == "e")
                {
                    formato = sr.ReadLine();
                    listaLibros.Add(new LibroElectronico(titulo, autor,
                        publicacion, formato));
                }
                else
                    listaLibros.Add(new Libro(titulo, autor, publicacion));

                sr.ReadLine(); // retiro la línea en blanco de separación       
            }

            sr.Close();
        }
        catch (PathTooLongException pe)
        {
            Console.WriteLine(pe.Message);
        }
        catch (FileNotFoundException fe)
        {
            Console.WriteLine(fe.Message);
        }
        catch (IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return listaLibros;
    }
}
