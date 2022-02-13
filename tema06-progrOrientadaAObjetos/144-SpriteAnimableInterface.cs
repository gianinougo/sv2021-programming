/*
 * 144. Crea una interfaz "Dibujable", con un método Dibujar, y una interfaz 
 * "Animable", con un método CambiarFotograma. Crea una clase SpriteAnimable, 
 * con atributos x e y, que implemente ambas interfaces (aunque de momento esos
 * métodos "no hagan nada interesante").
 */

// Ugo (...)

using System;

interface IDibujable
{
    void Dibujar();
}

// -------

interface IAnimable
{
    void CambiarFotograma();
}

// -------

class SpriteAnimable : IDibujable, IAnimable
{
    public int X { get;  set; }
    public int Y { get;  set; }


    public SpriteAnimable(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Dibujar()
    {
        Console.WriteLine("Dibujando");
    }

    public void CambiarFotograma()
    {
        Console.WriteLine("Animando");
    }
}

// -------

class Prueba
{
    static void Main()
    {
        SpriteAnimable s = new SpriteAnimable(10, 12);
        s.Dibujar();
        s.CambiarFotograma();
        s.Dibujar();
    }
}


