// Ejemplo de "Array.Sort", con datos complejos (class)

using System;

class ArraySort2
{
    class MiDato : IComparable<MiDato>
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public MiDato(string nombre, int edad)
        {
            this.Nombre = nombre;
            this.Edad = edad;
        }

        public override string ToString()
        {
            return Nombre + " " + Edad;
        }

        public int CompareTo(MiDato otro)
        {
            return this.Nombre.CompareTo(otro.Nombre);
        }
    }

    static void Main()
    {
        MiDato[] datos = new MiDato[3];
        datos[0] = new MiDato("Jones", 22);
        datos[1] = new MiDato("Tadeo", 20);
        datos[2] = new MiDato("Amber", 21);

        Array.Sort(datos);
        foreach (MiDato dato in datos) 
            Console.WriteLine(dato);
        Console.WriteLine();

    }
}
