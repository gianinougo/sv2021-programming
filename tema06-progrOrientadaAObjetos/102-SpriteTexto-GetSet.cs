/* Juan Manuel (...), retoques por Nacho */

/*
Ejercicio 102.Crea una nueva versión de la clase "SpriteTexto". Sus atributos
serán privados y tendrá "getters" y "setters" que permitan cambiar el valor de
éstos. Además,tendrá un método "MoverDerecha" que incrementará la X en una
unidad y otro "MoverIzquierda", que la disminuirá en una unidad. Modifica
el programa y "Main" según sea necesario. 
Deberás entregar sólo el fichero .cs.*/

using System;

class SpriteTexto
{
    private int x, y;
    private char caracter;
    
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
        SpriteTexto s = new SpriteTexto();

        s.SetX(40);
        s.SetY(12);
        s.SetCaracter('A');
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

