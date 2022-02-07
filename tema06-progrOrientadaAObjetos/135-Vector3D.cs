/*
 * Ejercicio 135. Crea una clase Vector3D que represente un vector en el 
 espacio tridimensional (con coordenadas X, Y, Z). Debe tener:

- Un constructor para establecer los valores de X, Y, Z.

- Setters y getters en formato convencional.

- Un método "ToString", que devolvería algo como "<2, -3, 0.5>"

- Un método "GetModulo" para devolver la longitud (módulo) del vector 
  (raíz cuadrada de x^2 + y^2 + z^2)

- Un método "Sumar", para sumar un vector (que se pasará como parámetro) al 
  actual (el resultado será la suma componente a componente: 
  <x1 + x2, y1 + y2, z1 + z2>)

Crea un programa de prueba, que permita probar estas funcionalidades.
 */

// Por Ugo (...)

using System;

class Vector3D
{
    private double x;
    private double y;
    private double z;

    public Vector3D(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public double GetX() { return x; }
    public double GetY() { return y; }
    public double GetZ() { return z; }
    
    public void SetX(double newX) { x = newX; }
    public void SetY(double newY) { y = newY; }
    public void SetZ(double newZ) { z = newZ; }

    public override string ToString()
    {
        return "<" + x + ", " + y + ", " + z + ">";
    }

    public double GetModulo()
    {
        return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
    }

    public void Sumar(Vector3D v3)
    {
        x += v3.x;
        y += v3.y;
        z += v3.z;
    }

    static void Main()
    {
        Vector3D vector = new Vector3D(2, -3, 0.5);
        Console.WriteLine(vector);
        
        Console.WriteLine("Módulo: " + vector.GetModulo());

        Vector3D otro = new Vector3D(-5, -2.7, 31);
        vector.Sumar(otro);
        Console.WriteLine("Ahora es " + vector);
    }
}

