/*
136 - Crea una nueva versión de la clase Vector3D, con los siguientes cambios:

- En vez de usar getters y setters convencionales, utiliza propiedades en 
  formato compacto.

- Sobrecarga el operador "+", para sumar dos vectores pasados como parámetros.
*/

using System;

class Vector3D
{
    public double X {get; set; }
    public double Y {get; set; }
    public double Z { get; set; }

    public Vector3D(double x, double y, double z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public override string ToString()
    {
        return "<" + X + ", " + Y + ", " + Z + ">";
    }

    public double GetModulo()
    {
        return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
    }

    public void Sumar(Vector3D v3)
    {
        X += v3.X;
        Y += v3.Y;
        Z += v3.Z;
    }

    public static Vector3D operator + (Vector3D a, Vector3D b)
    {
        return new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    static void Main()
    {
        Vector3D vector = new Vector3D(2, -3, 0.5);
        Console.WriteLine(vector);

        Console.WriteLine("Módulo: " + vector.GetModulo());

        Vector3D otro = new Vector3D(-5, -2.7, 31);
        vector.Sumar(otro);
        Console.WriteLine("Ahora es " + vector);

        Vector3D v1 = new Vector3D(1, 2, 3);
        Vector3D v2 = new Vector3D(0.5, 0, -0.5);
        Console.WriteLine("v1+v2 = " + (v1 + v2));
    }
}

