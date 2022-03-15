/*
VIRGINIA (...), retoques menores por Nacho
  
178. Crea un programa en C# que permita llevar el control de una colección de 
libros. En esta primera versión, para cada libro deseamos guardar:
 
- Código (por ejemplo, ISBN)
- Título
- Autor 
- Comentarios
- Paginas
- Ubicación

Además, querremos distinguir también "libros electrónicos", para los que 
también querremos anotar la URL de origen. En ambos casos, se deben crear 
(únicamente) constructores para dar valores a todos los atributos, así como 
propiedades (no getters y setter convencionales) para acceder a dichos 
atributos y poder cambiar su valor (excepto el código, que se podrá leer pero 
no cambiar).

El programa debe permitir al usuario realizar las siguientes operaciones:

1 - Añadir un nuevo libro (a una tabla hash o una SortedList, que se almacenará 
en memoria y que tendrá como clave el código del libro y como valor asociado el 
conjunto de todos los detalles). Tras pedir todos los datos que son comunes a 
todos los libros, se preguntará al usuario “Introduzca la URL de origen, en 
caso de ser un libro electrónico”. Si este dato se deja en blanco, se 
almacenará la información como libro genérico, pero si no es así, se guardará 
como libro electrónico. El código y el título no deben estar vacíos, y la 
dificultad deberá ser numérica y no negativa (aunque sí se podrá aceptar un 
valor 0, para los casos en lo que no se disponga de esa información).

2 - Buscar libros que contengan un cierto texto (en el título, autor o 
comentarios, sin distinguir mayúsculas y minúsculas). Deberá ayudarse de un 
método booleano “Contiene”, que será parte de la clase Libro, y que estará 
sobrecargado en LibroElectronico para que en esta subclase también busque en la 
URL. Para cada libro que lo contenga, debe mostrar el código, título y autor, 
todo ello en una misma línea y separado por “ – “, junto con la URL en el caso 
de los libros electrónicos, apoyándose en un método ToString que deberá existir 
en las clases correspondientes.

3 - Mostrar todos los detalles de un libro, a partir de su código. Si los 
comentarios ocupan más de 40 letras, se cortarán tras cada 40 letras, añadiendo 
un guion en caso de que eso suponga partir una palabra. Esa operación se 
realizará sobre el resultado de eliminar los espacios redundantes a los 
comentarios (espacios iniciales, finales y duplicados). Se debe avisar si el 
código introducido no existe.

4 - Modificar un libro: debe pedir al usuario su código, mostrar el valor 
anterior de cada campo y permitir que el usuario presione Intro si decide no 
modificar alguno de los datos. Si introduce un código incorrecto, se le volverá 
a pedir tantas veces como sea necesario (pero podrá introducir una cadena vacía 
para indicar que desea salir sin llegar a modificar nada). Se debe avisar al 
usuario si introduce un título o un autor cuya primera letra no esté en 
mayúsculas.

5 - Eliminar un libro, a partir de su código. Se le debe avisar (pero no volver 
a pedir) si introduce un código incorrecto. El programa debe mostrar el 
registro que se eliminará (usando el mismo formato que en la opción 3) y pedir 
confirmación antes del borrado.

6 – Mostrar un resumen ordenado en formato Titulo – Autor – Ubicación, o Autor 
– Titulo – Ubicación, según elija el usuario..

S - Salir (en la versión original de este ejercicio, los datos se debían 
guardar automáticamente en fichero de texto tras cada añadido, modificación o 
borrado; los datos existentes se debían cargar al volver a entrar al programa, 
pero en esta primera versión no será necesario cargar y guardar).

*/

using System;
using System.Collections.Generic;

class Ejercicio178
{
    static void Main()
    {
        Biblioteca biblioteca = new Biblioteca();
        biblioteca.Ejecutar();
    }
}

// ---------------------

class Libro : IComparable<Libro>
{
    protected string codigo;
    protected string titulo;
    protected string autor;
    protected string comentarios;
    protected uint paginas;
    protected string ubicacion;

    public Libro(string codigo, string titulo, string autor,
        string comentarios, uint paginas, string ubicacion)
    {
        this.codigo = codigo;
        this.titulo = titulo;
        this.autor = autor;
        this.comentarios = comentarios;
        this.paginas = paginas;
        this.ubicacion = ubicacion;
    }

    public string Codigo
    {
        get { return codigo; }
    }

    public string Titulo
    {
        get { return titulo; }
        set { titulo = value; }
    }

    public string Autor
    {
        get { return autor; }
        set { autor = value; }
    }

    public string Comentarios
    {
        get { return comentarios; }
        set { comentarios = value; }
    }

    public uint Paginas
    {
        get { return paginas; }
        set { paginas = value; }
    }

    public string Ubicacion
    {
        get { return ubicacion; }
        set { ubicacion = value; }
    }

    public virtual bool Contiene(string texto)
    {
        texto = texto.ToLower();
        if (titulo.ToLower().Contains(texto)
            || autor.ToLower().Contains(texto)
            || comentarios.ToLower().Contains(texto))
        {
            return true;
        }
        else
            return false;
    }

    public override string ToString()
    {
        return codigo + " - " + titulo + " - " + autor;
    }

    public virtual void Mostrar()
    {
        if (Comentarios.Length > 40)
        {
            int lineas = Comentarios.Length % 40;
            Console.Write(this + " - ");
            for (int i = 0; i < lineas; i++)
            {
                if (Comentarios[(i + 1) * 40].ToString() != " " &&
                    Comentarios[(i + 1) * 40 - 1].ToString() != " ")
                    Console.Write(
                        Comentarios.Substring(i * 40, 40) + " - \n");
                else
                    Console.Write(
                        Comentarios.Substring(i * 40, 40) + "\n");
            }
            Console.Write(" - " + paginas + " - " + ubicacion);
        }
        else
            Console.Write(this);
    }

    public int CompareTo(Libro otroLibro)
    {
        if (titulo != otroLibro.titulo)
            return titulo.CompareTo(otroLibro.titulo);
        else if (autor != otroLibro.autor)
            return autor.CompareTo(otroLibro.autor);
        else
            return ubicacion.CompareTo(otroLibro.ubicacion);
    }
}

// ---------------------

class LibroElectronico : Libro
{
    protected string url;

    public LibroElectronico(string codigo, string titulo, string autor,
        string comentarios, uint paginas, string ubicacion, string url)
        : base(codigo, titulo, autor, comentarios, paginas, ubicacion)
    {
        this.url = url;
    }

    public string URL
    {
        get { return url; }
        set { url = value; }
    }

    public override bool Contiene(string texto)
    {
        if (base.Contiene(texto) || url.ToLower().Contains(texto.ToLower()))
            return true;
        else
            return false;
    }

    public override string ToString()
    {
        return base.ToString() + " - " + url;
    }

    public override void Mostrar()
    {
        base.Mostrar();
        Console.Write(" - " + url);
    }
}


// ---------------------

class Biblioteca
{
    private SortedList<string, Libro> libros = new SortedList<string, Libro>();

    public void Ejecutar()
    {
        bool salir = false;

        do
        {
            MostrarMenu();
            switch (ElegirOpcion())
            {
                case '1':
                    AnyadirLibro();
                    break;
                case '2':
                    BuscarLibro();
                    break;
                case '3':
                    MostrarLibro();
                    break;
                case '4':
                    ModificarLibro();
                    break;
                case '5':
                    EliminarLibro();
                    break;
                case '6':
                    MostrarResumen();
                    break;
                case 's':
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;

            }
        } while (!salir);

    }

    //Funciones del menu:
    private void MostrarMenu()
    {
        Console.WriteLine("------------MENU----------------");
        Console.WriteLine("1. Añadir libro");
        Console.WriteLine("2. Buscar libros por texto");
        Console.WriteLine("3. Mostrar detalles de un libro");
        Console.WriteLine("4. Modificar un libro");
        Console.WriteLine("5. Eliminar un libro");
        Console.WriteLine("6. Mostrar resumen ordenado");
        Console.WriteLine("S. Salir");
        Console.WriteLine("---------------------------------");
    }

    private void AnyadirLibro()
    {
        string codigo = PedirDato("codigo");
        while (codigo == "")
        {
            codigo = PedirDato("codigo");
        }

        string titulo = PedirDato("titulo");
        while (titulo == "")
        {
            titulo = PedirDato("titulo");
        }

        string autor = PedirDato("autor");
        string comentarios = PedirDato("comentarios");

        string numeroPaginas = PedirDato("número de páginas");
        uint paginas = 0;

        if (numeroPaginas != "")
        {
            try
            {
                paginas = Convert.ToUInt32(numeroPaginas);
            }
            catch
            {
                Console.WriteLine("Número de páginas no válido. " +
                    "Se guardará con valor 0");
            }
        }

        string ubicacion = PedirDato("ubicación");
        string url = PedirDato("URL");

        if (url == "")
        {
            Libro libro = new Libro(codigo, titulo, autor, comentarios,
                paginas, ubicacion);
            libros.Add(codigo, libro);
        }
        else
        {
            LibroElectronico libro = new LibroElectronico(codigo, titulo,
                autor, comentarios, paginas, ubicacion, url);
            libros.Add(codigo, libro);
        }
    }

    private void BuscarLibro()
    {
        bool encontrado = false;
        string textoBuscar = PedirDato("texto a buscar");

        foreach (Libro libro in libros.Values)
        {
            if (libro.Contiene(textoBuscar))
            {
                Console.WriteLine(libro);
                encontrado = true;
            }
        }
        if (!encontrado)
            Console.WriteLine("No se han encontrado coincidencias");
    }

    private void MostrarLibro()
    {
        string codigo = PedirDato("código");
        if (libros.ContainsKey(codigo))
        {
            EliminarEspacios(codigo);
            libros[codigo].Mostrar();
            Console.WriteLine(); ;
        }
        else
            Console.WriteLine("El código introducido no existe");
    }

    private void ModificarLibro()
    {
        string codigo = PedirDato("código a modificar");

        while (!libros.ContainsKey(codigo) && codigo != "")
        {
            Console.WriteLine("Código incorrecto");
            codigo = PedirDato("código");
        }

        if (codigo != "")
        {
            string titulo = Modificar("título", libros[codigo].Titulo);
            string autor = Modificar("autor", libros[codigo].Autor);
            string comentarios = Modificar("comentarios",
                                            libros[codigo].Comentarios);
            uint paginas = Convert.ToUInt32(Modificar("número de páginas",
                                        libros[codigo].Paginas.ToString()));
            string ubicacion = Modificar("ubicación",
                                           libros[codigo].Ubicacion);

            if (libros[codigo] is LibroElectronico)
            {
                string url = Modificar("URL",
                                ((LibroElectronico)libros[codigo]).URL);
                LibroElectronico libro =
                    new LibroElectronico(codigo, titulo, autor, comentarios,
                                            paginas, ubicacion, url);
                libros[codigo] = libro;
            }
            else
            {
                Libro libro = new Libro(codigo, titulo, autor, comentarios,
                                        paginas, ubicacion);
                libros[codigo] = libro;
            }
        }
        else
            Console.WriteLine("Sin cambios");
    }

    private void EliminarLibro()
    {
        string codigo = PedirDato("código a eliminar");

        if (libros.ContainsKey(codigo))
        {
            Console.WriteLine("Registro a borrar: ");
            libros[codigo].Mostrar();
            Console.WriteLine();
            Console.WriteLine("¿Borrar definitivamente? S/N");
            char opcion = ElegirOpcion();
            if (opcion == 's')
            {
                libros.Remove(codigo);
            }
            else
                Console.WriteLine("No se ha borrado el registro");
        }
        else
            Console.WriteLine("El código no existe");
    }

    private void MostrarResumen()
    {
        Console.WriteLine("Mostrar un resumen ordenado en formato: ");
        Console.WriteLine("1. Titulo – Autor – Ubicación");
        Console.WriteLine("2. Autor – Titulo – Ubicación");
        List<string> respuestas = new List<string>();

        switch (ElegirOpcion())
        {
            case '1':
                foreach (Libro libro in libros.Values)
                {
                    string respuesta = libro.Titulo + " - " + libro.Autor +
                        " - " + libro.Ubicacion;
                    respuestas.Add(respuesta);
                }
                break;
            case '2':
                foreach (Libro libro in libros.Values)
                {
                    string respuesta = libro.Autor + " - " + libro.Titulo +
                        " - " + libro.Ubicacion;
                    respuestas.Add(respuesta);
                }
                break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
        respuestas.Sort();
        foreach (string resumenLibro in respuestas)
        {
            Console.WriteLine(resumenLibro);
        }
    }

    //Otras funciones:
    private char ElegirOpcion()
    {
        Console.WriteLine("Elige una opción: ");
        char opcion = Convert.ToChar(Console.ReadLine().ToLower());
        return opcion;
    }

    private string PedirDato(string campo)
    {
        Console.WriteLine("Introduce el campo \"" + campo + "\" ");
        string dato = Console.ReadLine();
        return dato;
    }

    private void EliminarEspacios(string codigo)
    {
        libros[codigo].Comentarios = libros[codigo].Comentarios.Trim();

        while (libros[codigo].Comentarios.Contains("  "))
        {
            libros[codigo].Comentarios =
                libros[codigo].Comentarios.Replace("  ", " ");
        }
    }

    private string Modificar(string campo, string valorAnterior)
    {
        Console.WriteLine("Valor anterior: " + valorAnterior);
        string nuevoValor = PedirDato(campo);
        if (nuevoValor == "")
            return valorAnterior;
        else
        {
            if (campo == "autor" || campo == "título")
            {
                if (nuevoValor[0] >= 'a' && nuevoValor[0] <= 'z')
                {
                    Console.WriteLine(
                        "La primera letra no está en mayúsculas");
                }
            }
            return nuevoValor;
        }
    }
}
