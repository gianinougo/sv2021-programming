// Ejercicio 124: array de "Recuadro", propiedades en formato breve

/*
124. Crea una nueva versión del ejercicio 123, pero esta vez usando propiedades 
en formato compacto.
*/

using System;

class Recuadro
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Ancho { get; set; }
    public int Alto { get; set; }
    public char Caracter { get; set; }
 
    public Recuadro()
    {
    }
    
    public Recuadro(int valorX, int valorY) 
    {
        X = valorX;
        Y = valorY;
        Ancho = 40;
        Alto = 10;
        Caracter = '*';
    }
    
    public Recuadro(int valorX, int valorY, 
        int valorAncho, int valorAlto,char valorCaracter) 
    {
        X = valorX;
        Y = valorY;
        Ancho = valorAncho;
        Alto = valorAlto;
        Caracter = valorCaracter;
    }

    public virtual void Dibujar()
    {
        for (int fila = Y; fila <= Y + Alto - 1; fila++)
        {
            for (int col = X; col <= X + Ancho - 1; col++)
            {
                if ((fila==Y)||(fila==Y+Alto-1) 
                    || (col==X)||(col==X+Ancho-1))
                {
                    Console.SetCursorPosition(col, fila);
                    Console.Write(Caracter);
                }
            }
        }
    }
}

// ---------------------

class RecuadroRelleno : Recuadro
{
    public RecuadroRelleno(int valorX, int valorY, 
        int valorAncho, int valorAlto, char valorCaracter)
    {
        X = valorX;
        Y = valorY;
        Ancho = valorAncho;
        Alto = valorAlto;
        Caracter = valorCaracter;
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
        recuadros[0] = new Recuadro(1,4,8,10, 'x');
        recuadros[0].X = 5;
        recuadros[0].Caracter = 'M';
        
        recuadros[1] = new Recuadro(20, 10, 20, 5, '+');
        recuadros[2] = new RecuadroRelleno(18, 12, 8, 8, '-');
        recuadros[3] = new Recuadro(2, 3);
        
        for (int i = 0; i < 4; i++)
        {
            recuadros[i].Dibujar();
        }
    }
}

