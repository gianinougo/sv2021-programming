// SpriteTexto + SpriteTextoColor + NaveEnemiga y NaveJugador + teclado

/*
117. Crea una clase "NaveEnemiga", que herede de "SpriteTextoColor", y cuyo 
constructor prefije el color a cyan y el carácter a "W". Crea una clase 
"NaveJugador", que herede de "SpriteTextoColor", y cuyo constructor prefije el 
color a amarillo y el carácter a "A".  Crea un programa que permita mover la 
nave del jugador cuando se pulsen las flechas del teclado, para lo que te 
puedes ayudar del siguiente fragmento de código:

ConsoleKeyInfo tecla = Console.ReadKey();

if (tecla.Key == ConsoleKey.LeftArrow)
    n.MoverIzquierda();
else if (tecla.Key == ConsoleKey.RightArrow)
    n.MoverDerecha();

Quizá te interese borrar la pantalla con Console.Clear();
*/

// Ejercicio recomendado 117
// Javier (...)

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
    protected string color;
    
    public SpriteTextoColor()
    {
    }

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

class NaveJugador : SpriteTextoColor
{
    public NaveJugador()
    {
        color = "amarillo";
        caracter = 'A';
    }
}

// -----------------------

class NaveEnemiga : SpriteTextoColor
{
    public NaveEnemiga()
    {
        color = "cyan";
        caracter = 'W';
    }
}

// -----------------------

class PruebaDeSprite
{
    static void Main()
    {
        NaveJugador jugador = new NaveJugador();
        NaveEnemiga enemigo = new NaveEnemiga();

        jugador.SetX(5);
        jugador.SetY(10);
        jugador.Dibujar();

        enemigo.SetX(10);
        enemigo.Dibujar();

        while (true)
        {
            ConsoleKeyInfo tecla = Console.ReadKey();
            Console.Clear();

            if (tecla.Key == ConsoleKey.LeftArrow)
                jugador.MoverIzquierda();
            else if (tecla.Key == ConsoleKey.RightArrow)
                jugador.MoverDerecha();

            jugador.Dibujar();
            enemigo.Dibujar();
        }
    }
}
