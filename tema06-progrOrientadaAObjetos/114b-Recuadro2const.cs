// Rocio (...), retoques menores por Nacho

using System;

class Recuadro
{
    protected int x, y, ancho, alto;
    protected char caracter;
    
    public int GetX() { return x; }
    public int GetY() { return y; }
    public int GetAncho() { return ancho; }
    public int GetAlto() { return alto; }
    public char GetCaracter() { return caracter; }
    
    public void SetX(int nuevoX) { x = nuevoX; }
    public void SetY(int nuevoY) { y = nuevoY; }
    public void SetAncho(int nuevoAncho) { ancho = nuevoAncho; }
    public void SetAlto(int nuevoAlto) { alto = nuevoAlto; }
    public void SetCaracter(char nuevoCaracter) { caracter = nuevoCaracter; }
    
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

    public void Dibujar()
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
        x = valorX;
        y = valorY;
        ancho = valorAncho;
        alto = valorAlto;
        caracter = valorCaracter;
    }
    
    public new void Dibujar()
    {
      
        for (int fila = y; fila <= y + alto - 1; fila++)
        {
            for (int col = x; col <= x + ancho - 1; col++)
            {
                Console.SetCursorPosition(col, fila);
                Console.Write(caracter);
            }
            Console.WriteLine();
        }
    }
}

// ---------------------

class PruebaDeRecuadro
{
    static void Main()
    {
        Recuadro prueba = new Recuadro(1,4,8,10, 'x');
        prueba.Dibujar();
        
        Recuadro prueba2 = new Recuadro(20, 10, 20, 5, '+');
        prueba2.Dibujar();
        
        RecuadroRelleno prueba3 = new RecuadroRelleno(18, 12, 8, 8, '-');
        prueba3.Dibujar();
        
        Recuadro prueba4 = new Recuadro(2, 3);
        prueba4.Dibujar();
    }
}

