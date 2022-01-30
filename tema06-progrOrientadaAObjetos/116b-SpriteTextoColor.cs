// SpriteTexto + SpriteTextoColor
// Ejercicio recomendado 116
// Javier (...)

/*
116. Crea una clase "SpriteTextoColor", que será un subtipo de "SpriteTexto", y 
tendrá un nuevo atributo llamado "color", de tipo "string". En esta primera 
versión, ese atributo podrá tener los valores "blanco" (que cambiará el color 
del texto haciendo "Console.ForegroundColor = ConsoleColor.White;"), "cyan" 
(que hará "Console.ForegroundColor = ConsoleColor.Cyan;") y "amarillo" (que 
usará "Console.ForegroundColor = ConsoleColor.Yellow;"). Añade también un 
constructor a esta clase, que permita fijar, además de los tres atributos 
anteriores, el color. Pruébalo desde Main para dibujar, en las coordenadas (30, 
8), un carácter "X" en color amarillo.
*/

using System;

class SpriteTexto
{
    protected int x, y;
    protected char caracter;

    public SpriteTexto()
    {

    }
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

// -----------------------

class SpriteTextoColor : SpriteTexto
{
    private string color;

    public SpriteTextoColor(int nuevoX, int nuevoY, char nuevoCaracter, 
        string nuevoColor)
    {
        x = nuevoX;
        y = nuevoY;
        caracter = nuevoCaracter;
        color = nuevoColor;
    }

    public new void Dibujar()
    {
        switch (color)
        {
            case "blanco": Console.ForegroundColor = ConsoleColor.White; break;
            case "cyan": Console.ForegroundColor = ConsoleColor.Cyan; break;
            case "amarillo": Console.ForegroundColor = ConsoleColor.Yellow; break;            
        }

        Console.SetCursorPosition(x, y);
        Console.Write(caracter);
        Console.ResetColor();
    }
}

// -----------------------

class PruebaDeSprite
{
    static void Main()
    {
        SpriteTexto s = new SpriteTexto();
        s.SetX(40);
        s.SetY(12);
        s.SetCaracter('A');
        s.Dibujar();
        
        SpriteTexto s2 = new SpriteTexto(2, 20, '#');
        s2.Dibujar();

        SpriteTextoColor s3 = new SpriteTextoColor(30, 8, 'X', "amarillo");
        s3.Dibujar();
    }
}
