// 127: Array de peces

/*
127. Crea una nueva versión del ejercicio 119b (Pez y clase derivada), en la 
que al menos 3 peces de distintas clases naden en pantalla, formando parte de 
un mismo array. Recuerda usar "virtual" y "override" para que el comportamiento 
sea correcto.

Puedes mejorarlo para que los peces se muevan solos, una vez cada 100 
milisegundos, en vez de detenerse hasta que se pulse una tecla, si usas el 
fragmento de código:

Thread.Sleep(100);
if (Console.KeyAvailable)
{
    ConsoleKeyInfo tecla = Console.ReadKey();
    if (tecla.Key == ConsoleKey.Escape)
        salir = true;
}

*/

using System;
using System.Threading;

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
        byte nuevoX, byte nuevoY)
    {
        nombre = nuevoNombre;
        especie = nuevaEspecie;
        x = nuevoX;
        y = nuevoY;
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
        const int MAX_PECES = 3;
        Pez[] peces = new Pez[MAX_PECES];
        
        peces[0] = new Pez("goldeen", "dorada", 15, 15);
        peces[1] = new PezEspada("espi", "pez espada", 5, 10);
        peces[2] = new Pez("lub", "lubina", 20, 6);
        
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            for (int i = 0; i < MAX_PECES; i++)
            {
                peces[i].Nadar();
            }
            
            Thread.Sleep(100);
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo tecla = Console.ReadKey();
                if (tecla.Key == ConsoleKey.Escape)
                    salir = true;
            }
        }
    }
}
