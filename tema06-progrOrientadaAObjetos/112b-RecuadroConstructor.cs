﻿// Recuadro + constructor
// Rocio (...)

/*
112. Crea una nueva versión de la clase Recuadro, que, en vez del método 
"Inicializar", incluya un constructor para dar valores iniciales. Pruébalo 
desde "Main".
*/

using System;

class Recuadro
{
    private int x, y, ancho, alto;
    private char caracter;
    
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

class PruebaDeRecuadro
{
    static void Main()
    {
        Recuadro prueba = new Recuadro(1,4,8,10, '*');
        prueba.Dibujar();
        
        Recuadro prueba2 = new Recuadro(20, 10, 20, 5, '+');
        prueba2.Dibujar();
    }
}

