// Ejercicio 138
// Propuesta creada por: Virginia
// Versión completa 3, usando "GetType" en el "Modificar" (línea 276)

/*
137. Crea una Clase Documento, con atributos para el título, autor y número de 
páginas. Debe tener un constructor que recibirá los tres atributos (los 
parámetros deben tener el mismo nombre que los atributos, por lo que deberás 
usar "this"). Crea también los setters y getters convencionales para esos 
atributos. Crea también un constructor que solo reciba el título y que prefije 
el autor a "Anónimo" y el número de páginas a 0. También contendrá un método 
MostrarDatos que mostrará el texto "Autor = a, Título = t" (con el autor y 
título reales, claro).

138. Crea una nueva versión del ejercicio anterior, en la que de cada documento 
habrá también una "ubicación" (...) se utilizará un método ToString, como 
alternativa más compacta que comprobar campo a campo; este ToString devolverá 
"autor - titulo - ubicacion - páginas" para los documentos genéricos
*/

using System;

class Documento
{
    // Atributos
    protected string titulo;
    protected string autor;
    protected ushort paginas;
    protected string ubicacion;

    // Constructores
    public Documento(string titulo, string autor, ushort paginas, 
        string ubicacion)
    {
        this.titulo = titulo;
        this.autor = autor;
        this.paginas = paginas;
        this.ubicacion = ubicacion;
    }

    public Documento(string titulo) 
    : this (titulo, "Anónimo", 0, "Ubicación desconocida")
    {
    }

    //Getters y Setters:
    public void SetTitulo(string nuevoTitulo)
    {
        titulo = nuevoTitulo;
    }

    public void SetAutor(string nuevoAutor)
    {
        autor = nuevoAutor;
    }

    public void SetPaginas(ushort nuevoPaginas)
    {
        paginas = nuevoPaginas;
    }

    public void SetUbicacion(string ubicacion)
    {
        this.ubicacion = ubicacion;
    }

    public string GetTitulo()
    {
        return titulo;
    }

    public string GetAutor()
    {
        return autor;
    }

    public ushort GetPaginas()
    {
        return paginas;
    }

    public string GetUbicacion()
    {
        return ubicacion;
    }
    
    // ToString
    public override string ToString()
    {
        return autor + " - " + titulo + " - " + ubicacion + " - " + paginas;
    }

    // Resto de métodos auxiliares: MostrarDatos
    public virtual void MostrarDatos()
    {
        Console.Write("Autor = " + autor + ",  Título = " + titulo);
    }
}

/*
137b. Crea una clase Libro, que herede de Documento. Esta nueva clase contendrá 
un atributo, "tapa", que será un "char" ("D" para tapa dura, "B" para tapa 
blanda). La clase Libro tendrá un único constructor que reciba todos los datos. 
Su método MostrarDatos mostrará también ", Portada = p"
*/

class Libro : Documento
{
    protected char tapa;

    public Libro(string titulo, string autor, ushort paginas, 
        string ubicacion, char tapa) 
        : base(titulo, autor, paginas, ubicacion)
    {
        this.tapa = tapa;
    }
    
    public void SetTapa(char tapa)
    {
        this.tapa = tapa; 
    }

    public char GetTapa()
    {
        return tapa;
    }

    public override void MostrarDatos()
    {
        base.MostrarDatos(); 
        Console.Write(", Portada = " + tapa);
    }

    public override string ToString()
    {
        return base.ToString() + " - " + tapa;
    }
}

/*
138b. Crea una nueva versión del ejercicio anterior, en la que de cada 
documento habrá también una "ubicación", y los datos no estarán prefijados, 
sino que se mostrará un menú al usuario, mediante el cual pueda:

1 - Añadir un nuevo documento (se le preguntará si es un documento genérico o 
un libro y se le pedirán los campos pertinentes).

2 - Buscar entre los documentos (para lo cual se utilizará un método ToString, 
como alternativa más compacta que comprobar campo a campo; este ToString 
devolverá "autor - titulo - ubicacion - páginas" para los documentos genéricos 
y lo mismo terminado en " - tapa" para los libros).

3 - Modificar un documento, a partir de su posición en el array (1 para el 
primer documento, 2 para el segundo, etc).

4 - Ordenar los datos, por título y (en caso de coincidir) por autor.

S - Salir
*/

class GestorDeDocumentos
{
    public void Ejecutar()
    {
        const ushort MAX = 500;
        bool salir = false;
        ushort contador = 0;
        Documento[] documentos = new Documento[MAX];

        do
        {
            MostrarMenu();

            switch (ElegirOpcion())
            {
                case '1':
                    AnyadirDocumento(ref documentos, ref contador);
                    break;
                case '2':
                    BuscarDocumento(documentos, contador);
                    break;
                case '3':
                    ModificarDocumento(ref documentos, contador);
                    break;
                case '4':
                    OrdenarDocumentos(ref documentos, contador);
                    break;
                case 's':
                    salir = true;
                    Console.WriteLine("Hasta pronto!");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (!salir);
    }

    //Funciones del menú:
    private void MostrarMenu()
    {
        Console.WriteLine("------------- MENU ----------------");
        Console.WriteLine("1. Añadir un nuevo documento.");
        Console.WriteLine("2. Buscar entre los documentos.");
        Console.WriteLine("3. Modificar un documento.");
        Console.WriteLine("4. Ordenar los datos.");
        Console.WriteLine("S. Salir.");
        Console.WriteLine("------------------------------------");
    }

    private void AnyadirDocumento(ref Documento[] documentos,
        ref ushort contador)
    {
        Console.WriteLine("¿Es un documento genérico(D) o un libro(L)? D/L");

        char opcion = ElegirOpcion();

        if (opcion != 'd' && opcion != 'l')
            Console.WriteLine("No es una opción válida.");
        else
        {
            string titulo = PedirDato("título");
            string autor = PedirDato("autor");
            string ubicacion = PedirDato("ubicación");
            ushort paginas = Convert.ToUInt16(PedirDato("páginas"));

            if (opcion == 'd')
                documentos[contador] = new Documento(titulo, autor, 
                    paginas, ubicacion);
            else
            {
                char tapa = Convert.ToChar(PedirDato("tapa (D/B)"));
                documentos[contador] = new Libro(titulo, autor, 
                    paginas, ubicacion, tapa);
            }
            contador++;
        }
    }

    private void BuscarDocumento(Documento[] documentos, ushort contador)
    {
        string palabra = PedirDato("palabra a buscar");
        bool encontrado = false;

        for (int i = 0; i < contador; i++)
        {
            if (documentos[i].ToString().Contains(palabra))
            {
                Console.Write( (i+1) + " : ");
                documentos[i].MostrarDatos();
                Console.WriteLine();
                encontrado = true;
            }
        }
        if ( ! encontrado )
            Console.WriteLine("No se han encontrado coincidencias.");
    }

    private void ModificarDocumento(ref Documento[] documentos, ushort contador)
    {
        Console.WriteLine("¿Qué documento quieres modificar?");
        int regMod = Convert.ToInt32(PedirDato("número del documento")) - 1;

        if (regMod >= contador)
            Console.WriteLine("Número de documento no válido.");
        else
        {
            Console.WriteLine("--- Registro a modificar ---");
            Console.WriteLine(documentos[regMod]);

            string titulo = PedirDato("título");
            string autor = PedirDato("autor");
            string ubicacion = PedirDato("ubicación");
            ushort paginas = Convert.ToUInt16(PedirDato("páginas"));

            if (documentos[regMod].GetType() == Type.GetType("Libro"))
            {
                char tapa = Convert.ToChar(PedirDato("tapa (D/B)"));
                documentos[regMod] = new Libro(titulo, autor, 
                    paginas, ubicacion,tapa);
            }
            else
                documentos[regMod] = new Documento(titulo, autor, 
                    paginas, ubicacion);
        }
    }

    private void OrdenarDocumentos(ref Documento[] documentos, ushort contador)
    {
        for (int i = 0; i < contador - 1; i++)
        {
            int menor = i;
            for (int j = i + 1; j < contador; j++)
            {
                if (documentos[menor].GetTitulo().CompareTo(
                    documentos[j].GetTitulo()) > 0)
                {
                    menor = j;
                }
                else if (documentos[menor].GetTitulo().CompareTo(
                         documentos[j].GetTitulo()) == 0)
                {
                    if (documentos[menor].GetAutor().CompareTo(
                        documentos[j].GetAutor()) > 0)
                    {
                        menor = j;
                    }
                }
            }
            if (menor != i)
            {
                Documento temporal = documentos[i];
                documentos[i] = documentos[menor];
                documentos[menor] = temporal;
            }
        }
        Console.WriteLine("Documentos ordenados!");
    }

    //Funciones para tareas recurrentes:
    private char ElegirOpcion()
    {
        Console.WriteLine("Elige una opción: ");
        char opcion = Convert.ToChar(Console.ReadLine().ToLower());
        return opcion;
    }

    private string PedirDato(string campo)
    {
        Console.Write("Introduce el campo \"" + campo + "\": ");
        string respuesta = Console.ReadLine();
        return respuesta;
    }
}

// ----------------------------------

class Ejercicio138
{
    static void Main()
    {
        GestorDeDocumentos gestor = new GestorDeDocumentos();
        gestor.Ejecutar();
    }   
}
