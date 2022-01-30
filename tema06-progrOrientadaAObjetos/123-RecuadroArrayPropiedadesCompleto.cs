// Ejercicio 123: array de "Recuadro", propiedades en formato largo

/*
123. Crea una variante del ejercicio 122, empleando propiedades (en formato 
largo) en vez de "getters" y "setters" convencionales. Haz que los atributos 
sean privados, en vez de protegidos, de modo que la clase RecuadroRelleno use 
las propiedades, en vez de los atributos. Además, desde Main, cambia la X y el 
Caracter del primer rectángulo usando propiedades.
*/

using System;

class Recuadro
{
    private int x, y, ancho, alto;
    private char caracter;
    
    public int X
    {
        get { return x; }
        set { x = value; }
    }
    
    public int Y
    {
        get { return y; }
        set { y = value; }
    }
    
    public int Ancho
    {
        get { return ancho; }
        set { ancho = value; }
    }
    
    public int Alto
    {
        get { return alto; }
        set { alto = value; }
    }
    
    public char Caracter
    {
        get { return caracter; }
        set { caracter = value; }
    }

    public Recuadro()
    {
    }
    
    public Recuadro(int valorX, int valorY) 
    {
        x = valorX;
        y = valorY;
        ancho = 40;
        alto = 10;
        caracter = '*';
    }
    
    public Recuadro(int valorX, int valorY, 
        int valorAncho, int valorAlto,char valorCaracter) 
    {
        x =valorX;
        y = valorY;
        ancho = valorAncho;
        alto = valorAlto;
        caracter = valorCaracter;
    }

    public virtual void Dibujar()
    {
        for (int fila=y; fila<=y+alto-1; fila++)
        {
            for (int col=x; col<=x+ancho-1; col++)
            {
                if ((fila==y)||(fila==y+alto-1) 
                    || (col==x)||(col==x+ancho-1))
                {
                    Console.SetCursorPosition(col, fila);
                    Console.Write(caracter);
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

