// Ejercicio 121: array de "Recuadro"

/*
121. Crea una nueva versión del proyecto de las clases Recuadro y 
RecuadroRelleno (ejercicio 114), en la que los 4 recuadros del programa de 
ejemplo no sean variables independientes, sino que formen parte de un array de 
"Recuadro". Es de esperar que el rectángulo relleno no se dibuje correctamente, 
pero lo solucionaremos en el siguiente ejercicio.
*/

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
        recuadros[1] = new Recuadro(20, 10, 20, 5, '+');
        recuadros[2] = new RecuadroRelleno(18, 12, 8, 8, '-');
        recuadros[3] = new Recuadro(2, 3);
        
        for (int i = 0; i < 4; i++)
        {
            recuadros[i].Dibujar();
        }
    }
}

