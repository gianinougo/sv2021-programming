// 125: Array de NaveJugador y NaveEnemiga

/*
125. Crea una nueva versión del proyecto de NaveJugador y NaveEnemiga (117) en 
la que haya un array de 5 objetos de tipo SpriteTexto: 4 de subtipo NaveEnemiga 
y uno de NaveJugador. Usa "new" en vez de "virtual+override" y comprueba si se 
comporta bien (es previsible que no sea así) using System;
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
        SpriteTexto[] naves = new SpriteTexto[5];
        naves[0] = new NaveJugador();
        naves[1] = new NaveEnemiga();
        naves[2] = new NaveEnemiga();
        naves[3] = new NaveEnemiga();
        naves[4] = new NaveEnemiga();
        
        for (int i = 1; i < 5; i++)
        {
            naves[i].SetX(i*10);
            naves[i].SetY(10);
        }

        naves[0].SetX(5);
        naves[0].SetY(20);


        while (true)
        {
            Console.Clear();
            for (int i = 0; i < 5; i++)
                naves[i].Dibujar();
                
            ConsoleKeyInfo tecla = Console.ReadKey();            

            if (tecla.Key == ConsoleKey.LeftArrow)
                naves[0].MoverIzquierda();
            else if (tecla.Key == ConsoleKey.RightArrow)
                naves[0].MoverDerecha();
        }
    }
}
