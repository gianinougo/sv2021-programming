// Ejercicio 137

/*
137 - Crea una Clase Documento, con atributos para el título, autor y número de 
páginas. Debe tener un constructor que recibirá los tres atributos (los 
parámetros deben tener el mismo nombre que los atributos, por lo que deberás 
usar "this"). Crea también los setters y getters convencionales para esos 
atributos. Crea también un constructor que solo reciba el título y que prefije 
el autor a "Anónimo" y el número de páginas a 0. También contendrá un método 
MostrarDatos que mostrará el texto "Autor = a, Título = t" (con el autor y 
título reales, claro).

Crea una clase Libro, que herede de Documento. Esta nueva clase contendrá un 
atributo, "tapa", que será un "char" ("D" para tapa dura, "B" para tapa 
blanda). La clase Libro tendrá un único constructor que reciba todos los datos. 
Su método MostrarDatos mostrará también ", Portada = p"

Crea un Main, con un array de "Documentos" en el que alguno sea un "Libro". 
Rellena datos de ejemplo y muestra los datos de todos ellos.
*/

using System;

class Documento
{
    // Atributos
    protected string titulo;
    protected string autor;
    protected ushort paginas;

    // Constructores
    public Documento(string titulo, string autor, ushort paginas)
    {
        this.titulo = titulo;
        this.autor = autor;
        this.paginas = paginas;
    }

    public Documento(string titulo) 
        : this (titulo, "Anónimo", 0)
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
    
    // ToString
    public override string ToString()
    {
        return autor + " - " + titulo + " - " + paginas;
    }

    // Resto de métodos auxiliares: MostrarDatos
    public virtual void MostrarDatos()
    {
        Console.Write("Autor = " + autor + ",  Título = " + titulo);
    }
}

// ----------------------------------

class Libro : Documento
{
    protected char tapa;

    public Libro(string titulo, string autor, ushort paginas, char tapa) 
        : base(titulo, autor, paginas)
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

// ----------------------------------

class Ejercicio137
{
    static void Main()
    {
        const ushort MAX = 3;
        
        Documento[] documentos = new Documento[MAX];
        documentos[0] = new Documento("Doc 1", "Autor 1", 12);
        documentos[1] = new Libro("Libro 1", "Autor 2", 253, 'D');                     
        documentos[2] = new Documento("Doc 2", "Autor 3", 179);

        for (int i = 0; i < MAX; i++)
        {
            documentos[i].MostrarDatos();
            Console.WriteLine();
        }
        
    }   
}
