/* 142. A partir de la "solución oficial" del ejercicio 137 (Documento y 
Libro), crea una variante en la que la clase "Documento" no incluya el número 
de páginas, sea abstracta y de ella hereden tanto una clase "DocumentoImpreso", 
que sí tendrá número de páginas, como una "DocumentoDigital", que tendrá una 
URL en vez de un número de páginas. El "Libro" será un subtipo de 
DocumentoImpreso. Retoca el resto de métodos y el programa de prueba como creas 
conveniente, de modo que se cree tanto algún documento digital, como alguno 
impreso y algún libro. */

using System;

abstract class Documento
{
    // Atributos
    protected string titulo;
    protected string autor;

    // Constructores
    public Documento(string titulo, string autor)
    {
        this.titulo = titulo;
        this.autor = autor;
    }

    public Documento(string titulo) 
        : this (titulo, "Anónimo")
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

    public string GetTitulo()
    {
        return titulo;
    }

    public string GetAutor()
    {
        return autor;
    }
    
    public override string ToString()
    {
        return autor + " - " + titulo;
    }

    public virtual void MostrarDatos()
    {
        Console.Write("Autor = " + autor + ",  Título = " + titulo);
    }
}

// ----------------------------------

class DocumentoDigital : Documento
{
    protected string url;

    public DocumentoDigital(string titulo, string autor,string url)
        : base(titulo,autor)
    {
        this.url = url;
    }


    public override  string  ToString()
    {
        return base.ToString() + " - " + url;
    }
    
    public override void MostrarDatos()
    {
        base.MostrarDatos(); 
        Console.Write(", URL = " + url);
    }
   
}
    
// ----------------------------------

class DocumentoImpreso : Documento
{
    protected ushort paginas;

    public DocumentoImpreso(string autor, string titulo, ushort paginas) 
        : base(autor, titulo)
    {
        this.paginas = paginas;
    }
    
    public ushort GetPaginas()
    {
        return paginas;
    }
    
    
    public void SetPaginas(ushort nuevoPaginas)
    {
        paginas = nuevoPaginas;
    }
    

    public override string ToString()
    {
        return base.ToString() + " - " + paginas;
    }
    
    public override void MostrarDatos()
    {
        base.MostrarDatos(); 
        Console.Write(", Páginas = " + paginas);
    }
}

// ----------------------------------

class Libro : DocumentoImpreso
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
        documentos[0] = new DocumentoImpreso("Doc 1", "Autor 1", 12);
        documentos[1] = new Libro("Libro 1", "Autor 2", 253, 'D');                     
        documentos[2] = new DocumentoDigital("Doc 2", "Autor 3", "www.w.com");

        for (int i = 0; i < MAX; i++)
        {
            documentos[i].MostrarDatos();
            Console.WriteLine();
        }
        
    }   
}
