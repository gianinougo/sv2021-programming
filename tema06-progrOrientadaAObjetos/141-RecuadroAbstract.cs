/*
141. A partir de la "solución oficial" del ejercicio 132 (Recuadro y 
RecuadroRelleno), crea una variante en la que la clase "Recuadro" sea abstracta 
y de ella hereden tanto "RecuadroRelleno" como una nueva "RecuadroHueco" (que 
absorberá la lógica que antes tenía "Recuadro"), ambas selladas.
*/

using System;

abstract class Recuadro
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Ancho { get; set; }
    public int Alto { get; set; }
    public char Caracter { get; set; }

    public Recuadro(int valorX, int valorY,
        int valorAncho, int valorAlto, char valorCaracter)
    {
        X = valorX;
        Y = valorY;
        Ancho = valorAncho;
        Alto = valorAlto;
        Caracter = valorCaracter;
    }

    public Recuadro(int valorX, int valorY)
        : this(valorX, valorY, 40, 10, '*')
    {
    }

    public abstract void Dibujar();
   

}

// ---------------------

sealed class RecuadroHueco : Recuadro
{
    public RecuadroHueco(int valorX, int valorY,
        int valorAncho, int valorAlto, char valorCaracter) 
        : base(valorX, valorY, valorAncho, valorAlto, valorCaracter)
    {

    }
    public RecuadroHueco(int valorX, int valorY)
    : this(valorX, valorY, 40, 10, '*')
    {
    }
    public override void Dibujar()
    {
        for (int fila = Y; fila <= Y + Alto - 1; fila++)
        {
            for (int col = X; col <= X + Ancho - 1; col++)
            {
                if ((fila == Y) || (fila == Y + Alto - 1)
                    || (col == X) || (col == X + Ancho - 1))
                {
                    Console.SetCursorPosition(col, fila);
                    Console.Write(Caracter);
                }
            }
        }
    }
    
}

// ---------------------

sealed class RecuadroRelleno : Recuadro
{
    public RecuadroRelleno(int valorX, int valorY, 
            int valorAncho, int valorAlto, char valorCaracter)
        : base (valorX, valorY, valorAncho, valorAlto, valorCaracter)
    {
    }
    
    public override void Dibujar()
    {      
        for (int fila = Y; fila <= Y + Alto - 1; fila++)
        {
            for (int col = X; col <= X + Ancho - 1; col++)
            {
                Console.SetCursorPosition(col, fila);
                Console.Write(Caracter);
            }
        }
    }
}

// ---------------------

class PruebaDeRecuadro
{
    static void Main()
    {
        Recuadro[] recuadros = new Recuadro[4];
        recuadros[0] = new RecuadroHueco(1,4,8,10, 'x');
        recuadros[0].X = 5;
        recuadros[0].Caracter = 'M';
        
        recuadros[1] = new RecuadroHueco(20, 10, 20, 5, '+');
        recuadros[2] = new RecuadroRelleno(18, 12, 8, 8, '-');
        recuadros[3] = new RecuadroHueco(2, 3);
        
        for (int i = 0; i < 4; i++)
        {
            recuadros[i].Dibujar();
        }
    }
}

