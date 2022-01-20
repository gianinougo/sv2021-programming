/*
 * 119. Crea otra clase que herede de Pez (la que tú desees), y que cambie
 * ligeramente el comportamiento y/o la apariencia. Haz que dos peces de
 * clases distintas naden en la pantalla. Como mejora opcional, puedes
 * hacer que su "imagen" cambie cuando "reboten" en un extremo de la 
 * pantalla, por ejemplo para pasar de ser "><=>" a ser ""<=><".
 */
 
// Ezequiel + Ugo, retoques por Nacho
// Versión 119a, sin "rebote"

using System;

class Pez
{
    protected string nombre;
    protected string especie;
    protected byte x;
    protected byte y;
    
    public Pez()
    {
    }

    public Pez(string nuevoNombre, string nuevaEspecie)
    {
        nombre = nuevoNombre;
        especie = nuevaEspecie;
        x = 40;
        y = 10;
    }
    
    public Pez(string nuevoNombre, string nuevaEspecie,
        byte nuevoX, byte nuevoY)
    {
        nombre = nuevoNombre;
        especie = nuevaEspecie;
        x = nuevoX;
        y = nuevoY;
    }

    ~Pez()
    {
        Console.WriteLine("Aquí acaba la vida del pez");
    }

    public string GetNombre()
    {
        return nombre;
    }
    public void SetNombre(string cadenaTexto)
    {
        nombre = cadenaTexto;
    }

    public string GetEspecie()
    {
        return especie;
    }
    public void SetEspecie(string cadenaTexto)
    {
        especie = cadenaTexto;
    }

    public int GetX() { return x; }
    public void SetX(int nuevoX) { x = (byte)nuevoX; }
    
    public int GetY() { return y; }
    public void SetY(int nuevoY) { y = (byte)nuevoY; }


    public void Nadar()
    {
        Console.SetCursorPosition(x, y);
        Console.Write("><=>");
        
        x++;
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
    }
    
    public void Nadar()
    {
        Console.SetCursorPosition(x, y);
        Console.Write(">-->--");
        
        x+=2;
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
