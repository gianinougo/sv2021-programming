// Ejercicio recomendado 115
// Javier (...)

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
