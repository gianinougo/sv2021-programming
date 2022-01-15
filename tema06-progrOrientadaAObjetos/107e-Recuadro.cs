/*
107. Crea, desde Visual Studio, una clase llamada "Recuadro", cuyos atributos 
(privados) serán las coordenadas x e y de comienzo (números enteros), la 
anchura y la altura (también enteros) y el carácter con el que se dibuje ese 
recuadro (hueco). Crea "getters" y "setters" que permitan cambiar el valor de 
los atributos. Tendrá también un método "Dibujar", que muestre el recuadro en 
pantalla (usando Console.SetCursorPosition). Crea, en un segundo fichero 
fuente, una clase "PruebaDeRecuadro", que tendrá un "Main" capaz de crear dos 
recuadros en distintas posiciones, con distintos tamaños y distintos caracteres 
de borde, y los dibujará en pantalla. Entrega todo el proyecto de Visual 
Studio, comprimido en un fichero ZIP.
*/

// Rocio (...), retoques por Nacho

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
        Recuadro prueba = new Recuadro();
        prueba.SetX(20);
        prueba.SetY(4);
        prueba.SetAncho(8);
        prueba.SetAlto(10);
        prueba.SetCaracter('*');
        prueba.Dibujar();
        
        Recuadro prueba2 = new Recuadro();
        prueba2.SetX(2);
        prueba2.SetY(10);
        prueba2.SetAncho(20);
        prueba2.SetAlto(5);
        prueba2.SetCaracter('+');
        prueba2.Dibujar();
    }
}

