// SpriteTexto + constructor
// Versión 1: sólo un constructor

// Ejercicio recomendado 115
// Javier (...)

/*
115. Crea una nueva versión de la clase "SpriteTexto" (ejercicio 103), con un 
constructor que permita asignar valores a sus tres atributos. Adapta el 
programa de prueba para que use ese constructor.
*/

using System;

class SpriteTexto
{
    private int x, y;
    private char caracter;

    public SpriteTexto(int nuevoX, int nuevoY, char nuevoCaracter)
    {
        x = nuevoX;
        y = nuevoY;
        caracter = nuevoCaracter;
    }
    
    public int GetX() { return x; }
    public int GetY() { return y; }
    public char GetCaracter() { return caracter; }
    
    public void SetX(int nuevoX) { x = nuevoX; }
    public void SetY(int nuevoY) { y = nuevoY; }
    public void SetCaracter(char nuevoCaracter) { caracter = nuevoCaracter; }

    public void MoverDerecha()
    {
        x++;
    }

    public void MoverIzquierda()
    {
        x--;
    }

    public void Dibujar()
    {
        Console.SetCursorPosition(x, y);
        Console.Write(caracter);
    }

}

class PruebaDeSprite
{
    static void Main()
    {
        SpriteTexto s = new SpriteTexto(40, 12, 'A');
        s.Dibujar();
        
        Console.ReadLine();
        s.MoverDerecha();
        s.Dibujar();
        
        Console.ReadLine();
        s.MoverDerecha();
        s.Dibujar();
        
        Console.ReadLine();
        s.MoverDerecha();
        s.Dibujar();
        
        Console.ReadLine();
    }
}
