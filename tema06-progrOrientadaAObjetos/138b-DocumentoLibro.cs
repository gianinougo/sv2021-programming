// Ejercicio 138
// Propuesta creada por: Virginia
// Segundo acercamiento: clases Documento y Libro

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
