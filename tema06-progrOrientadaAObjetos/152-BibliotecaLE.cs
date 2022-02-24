//Author: Franco (...)
/*
152. Crea una versión ampliada de la biblioteca (ejercicio 151), en la 
que añadas una categoría "LibroElectronico", que será un tipo de libro 
para el que además indicaremos en qué formato tenemos nuestra copia 
(por ejemplo, EPUB o PDF). El funcionamiento debe ser básicamente el 
mismo que el anterior, con la diferencia de que al añadir un libro 
preguntará si es un libro electrónico y, en caso afirmativo, en qué 
formato. 
*/

using System;
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


// ----------------------------------

class LibroElectronico : Libro
{
    public string Formato { get ; set; }

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
        if (Formato.ToLower().Contains(texto.ToLower()) 
        {
            return true;
        }
        return base.Contiene(texto);
        
        // Alternativa:
        // return (Formato.ToLower().Contains(texto.ToLower()) 
        //  || base.Contiene(texto));
    }
}

// -----------------------------------

class Biblioteca
{

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

    static void AnyadirDatos(Libro[] datos, ref int cantidad)
    {

        if (cantidad < datos.Length)
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
                datos[cantidad] = new Libro(titulo, autor, publicacion);
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
                datos[cantidad] = new LibroElectronico(titulo, autor, publicacion, formato);
            }

            cantidad++;
        }
        else
        {
            Console.WriteLine("No caben más datos");
        }
    }

    static void MostrarLibros(Libro[] datos, int cantidad)
    {
        int posicion = 0;
        for (int i = 0; i < cantidad; i++)
        {
            Console.Write("{0}. ", i + 1);
            Console.WriteLine(datos[i]);

            posicion++;

            if (posicion == 21)
            {
                Console.WriteLine("Para continuar pulse ENTER");
                Console.ReadLine();
                posicion = 0;
            }
        }
    }

    static void BuscarLibros(Libro[] datos, int posicion, int cantidad,
        string dato)
    {
        Console.Write("Palabra por la que desea buscar: ");
        string busquedaTexto = Console.ReadLine().ToLower();
        posicion = 0;
        for (int i = 0; i < cantidad; i++)
        {
            if (datos[i].Contiene(busquedaTexto))
            {
                Console.Write("{0}. ", i + 1);
                Console.WriteLine(datos[i]);
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

    static void BuscarPorFecha(Libro[] datos, int cantidad)
    {
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

            if ((datos[i].Publicacion >= primerano)
                && (datos[i].Publicacion <= segundoano))
            {
                Console.Write("{0}. ", i + 1);
                Console.WriteLine(datos[i]);
            }
        }
    }

    static void Modificar(Libro[] datos, int cantidad)
    {
        Console.Write("¿Qué posición desea modificar? ");
        int indice = Convert.ToInt32(Console.ReadLine()) - 1;
        if ((indice < 0) || (indice >= cantidad))
        {
            Console.WriteLine("Posicion no valida");
        }
        else
        {
            Console.WriteLine("Titulo: " + datos[indice].Titulo);
            Console.WriteLine("Nuevo título (Intro para no cambiar): ");
            string nuevotitulo = Console.ReadLine();
            if (nuevotitulo != "")
            {
                datos[indice].Titulo = nuevotitulo.Trim();
            }
            if (datos[indice].Titulo.ToUpper() == datos[indice].Titulo)
            {
                Console.WriteLine("El titulo esta completamente en mayusculas");
            }
            if (datos[indice].Titulo.ToLower() == datos[indice].Titulo)
            {
                Console.WriteLine("El titulo esta completamente en minusculas");
            }
            if (datos[indice].Titulo.Contains("  "))
            {
                Console.WriteLine("El Titulo tiene espacios redundantes");
            }

            Console.WriteLine("Autor: " + datos[indice].Autor);
            Console.WriteLine("Nuevo autor (Intro para no cambiar): ");
            string nuevoautor = Console.ReadLine();
            if (nuevoautor != "")
            {
                datos[indice].Autor = nuevoautor.Trim();
            }
            if (datos[indice].Autor.ToUpper() == datos[indice].Autor)
            {
                Console.WriteLine("El autor esta completamente en mayusculas");
            }
            if (datos[indice].Autor.ToLower() == datos[indice].Autor)
            {
                Console.WriteLine("El autor esta completamente en minisuclas");
            }
            if (datos[indice].Autor.Contains("  "))
            {
                Console.WriteLine("El autor tiene espacios redundantes");
            }

            Console.WriteLine("Año: " + datos[indice].Publicacion);
            Console.WriteLine("Dato modificado: ");
            string nuevafecha = Console.ReadLine();
            if (nuevafecha != "")
            {
                datos[indice].Publicacion = Convert.ToInt16(nuevafecha);
            }
        }
    }

    static void Eliminar(Libro[] datos, ref int cantidad)
    {
        Console.Write("Posicion que desea eliminar?: ");
        int eliminar = Convert.ToInt32(Console.ReadLine()) - 1;
        if ((eliminar < 0) || (eliminar >= cantidad))
        {
            Console.WriteLine("numero no valido");
        }
        else
        {
            Console.WriteLine("Desea eliminar: ");
            Console.Write("{0}. {1} titulo; {2} autor;", eliminar + 1,
                datos[eliminar].Titulo, datos[eliminar].Autor);
            if (datos[eliminar].Publicacion == -1)
            {
                Console.WriteLine("año desconocido");
            }
            else
            {
                Console.WriteLine(datos[eliminar].Publicacion);
            }
            Console.WriteLine("Desea eliminar? s/n");
            string decision = Console.ReadLine().ToUpper();
            if (decision == "S")
            {
                for (int i = eliminar; i < cantidad - 1; i++)
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
    }

    static void Corregir(Libro[] datos, int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            string titulo = datos[i].Titulo;
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
                    datos[i].Titulo = datos[i].Titulo.Replace("  ", " ");
                    datos[i].Titulo = datos[i].Titulo.Trim();
                    datos[i].Titulo = datos[i].Titulo.ToLower();
                    string[] fragmentos = datos[i].Titulo.Split('.');
                    string titulofinal = "";
                    for (int j = 0; j < fragmentos.Length; j++)
                    {
                        string mays = fragmentos[i].ToUpper();
                        string mins = fragmentos[i].ToLower();
                        titulofinal += mays[0] + mins.Substring(1) + ".";
                    }
                    datos[i].Titulo = titulofinal;
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
        int cantidad = 0;
        const int MAXIMO = 25000;
        int posicion = 0;
        Libro[] datos = new Libro[MAXIMO];
        string opcion;

        do
        {
            MostrarMenu();
            ElegirOpcion(out opcion, out salir);

            switch (opcion)
            {
                case "1":
                    AnyadirDatos(datos, ref cantidad);
                    break;

                case "2":
                    MostrarLibros(datos, cantidad);
                    break;

                case "3":
                    BuscarLibros(datos, posicion, cantidad, opcion);
                    break;

                case "4":
                    BuscarPorFecha(datos, cantidad);
                    break;

                case "5":
                    Modificar(datos, cantidad);
                    break;

                case "6":
                    Eliminar(datos, ref cantidad);
                    break;

                case "7":
                    Corregir(datos, cantidad);
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
}
