/* 146. Crea una versión mejorada del ejercicio 145, en la que las tareas se 
ordenen de mayor a menor prioridad y, en caso de coincidir la prioridad, por 
descripción creciente. */

using System;

public class Tarea: IComparable<Tarea>
{
    protected string descripcion;
    protected int prioridad;
    protected bool completada;
    
    public int Prioridad
    {
        get { return prioridad; }
        set { prioridad = value; }
    }

    public string Descripcion
    {
        get { return descripcion; }
        set { descripcion = value; }
    }

    public bool Completada
    {
        get { return completada; }
        set { completada = value; }
    }

    public Tarea(string descripcion, int prioridad, bool completada)
    {
        this.descripcion = descripcion;
        this.prioridad = prioridad;
        this.completada = completada;
    }
    
    public override string ToString()
    {
        return descripcion + " (" + prioridad +")" +
            (completada? " (completada)" : "");
    }
    
    public int CompareTo(Tarea t1)
    {
        if (this.prioridad !=t1.prioridad)
        {
            return -1 * prioridad.CompareTo(t1.prioridad); // Descendente
        }
        else
        {
            return Descripcion.ToUpper().CompareTo(t1.Descripcion.ToUpper()); 
        }
    }
}


// ---------------------

class GestorDeTares
{
    enum menu { 
        ANADIR = '1', VER, MARCAR, MODIFICAR, BUSCAR, ORDENAR, SALIR = 'S' }

    static void Main()
    {
        const int CAPACIDAD = 100;
        Tarea[] tarea = new Tarea[CAPACIDAD];
        char opcion;
        int posicion=0;

        do
        {
            Console.WriteLine((char)menu.ANADIR + " - Añadir una nueva tarea");
            Console.WriteLine((char)menu.VER + " - Ver todas las tareas pendientes");
            Console.WriteLine((char)menu.MARCAR + " - Marcar una tarea como completada,");
            Console.WriteLine((char)menu.MODIFICAR + " - Modificar una tarea");
            Console.WriteLine((char)menu.BUSCAR + " - Buscar entre todas las tareas " +
                "que contengan un cierto texto");
            Console.WriteLine((char)menu.ORDENAR + " - Ordenar las tareas alfabéticamente.");
            Console.WriteLine((char)menu.SALIR + " - Salir");

            Console.WriteLine("Accion a realizar?");
            opcion = Convert.ToChar(Console.ReadLine().ToUpper());
            switch (opcion)
            {
                case (char)menu.ANADIR:
                    if (posicion < CAPACIDAD)
                    {
                        Console.Write("Descripcion de la tarea? ");
                        string descripcion = Console.ReadLine(); 
                        Console.Write("Prioridad de la tarea? ");
                        int prioridad = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Tarea completada (s/n)? ");
                        bool completada = Console.ReadLine().ToLower() == "s";

                        tarea[posicion] = new Tarea(
                            descripcion, prioridad, completada);
                        posicion++;
                    }
                    break;

                case (char)menu.VER:
                    for (int i = 0; i < posicion; i++)
                    {
                        if (! tarea[i].Completada)
                        {
                            Console.WriteLine((i+1) + ": " + tarea[i]);
                        }
                    }
                    break;

                case (char)menu.MARCAR:
                    Console.Write("Posicion de la tarea completada? ");
                    int posicionCompleta = Convert.ToInt32(Console.ReadLine())-1;
                    tarea[posicionCompleta].Completada = true;
                    break;

                case (char)menu.MODIFICAR:
                    Console.Write("Posicion de tarea a modificar?");
                    int posicionModificar = Convert.ToInt32(Console.ReadLine())-1;
                    Console.Write("Nueva descripción? ");
                    string nuevaDescripcion = Console.ReadLine();
                    tarea[posicionModificar].Descripcion = nuevaDescripcion;
                    break;

                case (char)menu.BUSCAR:
                    Console.WriteLine("Texto a buscar?");
                    string texto = Console.ReadLine();
                    for (int i = 0; i < posicion; i++)
                    {
                        if (tarea[i].Descripcion.ToUpper().
                            Contains(texto.ToUpper()))
                        {
                            Console.WriteLine((i+1) + ": " + tarea[i]);
                        }
                    }
                   break;

                case (char)menu.ORDENAR:
                    Array.Sort(tarea, 0, posicion);
                    Console.WriteLine("Ordenado.");
                    break;

                case (char)menu.SALIR:
                    Console.WriteLine("Ha decicidido salir");
                    break;
            }

        } while (opcion!='S');
    }
}

