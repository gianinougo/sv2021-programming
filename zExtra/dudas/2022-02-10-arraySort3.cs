// Ejemplo de "Array.Sort", con datos complejos (class)
// y dos criterios de ordenación consecutivos

using System;

class ArraySort3
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
            if (this.Nombre != otro.Nombre)
                return this.Nombre.CompareTo(otro.Nombre);
            else
                return this.Edad - otro.Edad;
        }
    }

    static void Main()
    {
        MiDato[] datos = new MiDato[4];
        datos[0] = new MiDato("Jones", 22);
        datos[1] = new MiDato("Tadeo", 20);
        datos[2] = new MiDato("Amber", 21);
        datos[3] = new MiDato("Tadeo", 18);

        Array.Sort(datos);
        foreach (MiDato dato in datos) 
            Console.WriteLine(dato);
        Console.WriteLine();

    }
}
