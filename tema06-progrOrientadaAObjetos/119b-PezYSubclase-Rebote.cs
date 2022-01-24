/*
 * 119. Crea otra clase que herede de Pez (la que tú desees), y que cambie
 * ligeramente el comportamiento y/o la apariencia. Haz que dos peces de
 * clases distintas naden en la pantalla. Como mejora opcional, puedes
 * hacer que su "imagen" cambie cuando "reboten" en un extremo de la 
 * pantalla, por ejemplo para pasar de ser "><=>" a ser ""<=><".
 */
 
// Ezequiel + Ugo, retoques por Nacho
// Versión 119b, con "rebote"

using System;

class Pez
{
    protected string nombre;
    protected string especie;
    protected byte x;
    protected byte y;
    protected string imagenDerecha;
    protected string imagenIzquierda;
    protected sbyte velocidad;
    
    public Pez()
    {
    }

    public Pez(string nuevoNombre, string nuevaEspecie)
    {
        nombre = nuevoNombre;
        especie = nuevaEspecie;
        x = 40;
        y = 10;
        imagenDerecha = "><=>";
        imagenIzquierda = "<=><";
        velocidad = 1;
    }
    
    public Pez(string nuevoNombre, string nuevaEspecie,
        int nuevoX, int nuevoY)
    {
        nombre = nuevoNombre;
        especie = nuevaEspecie;
        x = (byte) nuevoX;
        y = (byte) nuevoY;
        imagenDerecha = "><=>";
        imagenIzquierda = "<=><";
        velocidad = 1;
    }

    ~Pez()
    {
        Console.WriteLine("Aquí acaba la vida del pez");
    }

    public string GetNombre() { return nombre; }
    public string GetEspecie() { return especie; }
    public int GetX() { return x; }
    public int GetY() { return y; }
    
    public void SetNombre(string n) { nombre = n; }
    public void SetEspecie(string e) { especie = e; }
    public void SetX(int nuevoX) { x = (byte)nuevoX; }
    public void SetY(int nuevoY) { y = (byte)nuevoY; }

    public void Nadar()
    {
        Console.SetCursorPosition(x, y);
        
        // Dibujamos la imagen que corresponda según el sentido
        if (velocidad > 0)
            Console.Write(imagenDerecha);
        else
            Console.Write(imagenIzquierda);

        // Pasamos a la siguiente posición
        x = (byte) (x+velocidad);
        
        // Y comprobamos si hay que dar la vuelta
        if ((x >= 60) || (x <= 3))
            velocidad = (sbyte) (-velocidad);
    }
}

// ----------

class PezEspada : Pez
{

    public PezEspada(string nuevoNombre, string nuevaEspecie,
        byte nuevoX, byte nuevoY)
    {
        nombre = nuevoNombre;
        especie = nuevaEspecie;
        x = nuevoX;
        y = nuevoY;
        imagenDerecha = ">-->--";
        imagenIzquierda = "--<--<";
        velocidad = -2;
    }
}

// ----------

class SimuladorDePecera
{
    static void Main()
    {
        bool salir = false;
        Pez dorada = new Pez("goldeen", "dorada", 15, 15);
        PezEspada espada = new PezEspada("espi", "pez espada", 5, 10);
        
        while (!salir)
        {
            Console.Clear();
            dorada.Nadar();
            espada.Nadar();
            
            ConsoleKeyInfo tecla = Console.ReadKey();
            if (tecla.Key == ConsoleKey.Escape)
                salir = true;
        }
    }
}
