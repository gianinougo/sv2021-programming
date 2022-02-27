// Ejercicio recomendado 163
// Javier (...)

/*
Crea un array que permita almacenar hasta 1000 juegos de ordenador o consola.
De cada juego se guardará: título (cadena de texto), plataforma (cadena
de texto), espacio ocupado (en MB, número entero) y fecha de lanzamiento
(mes y año, en forma de struct anidado).
El programa debe permitir al usuario realizar las siguientes operaciones:
1- Añadir datos de un nuevo juego.
2- Mostrar los nombres y plataformas de todos los juegos almacenados (ambos
   datos en una misma líena, con el formato "The last of us (PS3)". Cada juego
   debe aparecer en una línea distinta, precedido por el número de registro
   (empezando a contar desde 1). Si hay más de 20 juegos, se deberá hacer una
   pausa tras mostrar cada bloque de 20 juegos, y esperar a que el usuario pulse
   Intro antes de seguir. Se deberá avisar si no hay datos.
3- Ver todos los datos de un cierto programa (a partir de su número de registro,
   contando desde 1). Se deberá avisar (pero no volver a pedir) si el número no
   es válido.
4- Modificar una ficha (se pedirá el número y se volverá a introducir el valor
   de todos los campos. Se debe avisar (pero no volver a pedir) si introduce un
   número de ficha incorrecto.
5- Borrar un cierto dato, a partir del número de registro que indique el
   usuario. Se debe avisar (pero no volver a pedir) si introduce un número
   incorrecto.
T- Terminar el uso de la aplicación (como no sabemos almacenar la información,
   los datos se perderán).

En esta versión se utilizan clases en lugar de struct
*/

using System;
using System.Collections.Generic;

// -----------

class Fecha
{
    protected int mes;
    protected int anyo;

    public Fecha(int mes, int anyo)
    {
        this.mes = mes;
        this.anyo = anyo;
    }

    public int GetMes() { return mes; }
    public int GetAnyo() { return anyo; }
    public void SetMes(int mes) { this.mes = mes; }
    public void SetAnyo(int anyo) { this.anyo = anyo; }

    public override string ToString()
    {
        return mes + "/"+ anyo;
    }
}

// -----------

class Juego
{ 
    private string titulo;
    private string plataforma;
    private int espacio;
    private Fecha fecha;

    public Juego(string titulo, string plataforma, int espacio, Fecha fecha)
    {
        this.titulo = titulo;
        this.plataforma = plataforma;
        this.espacio = espacio;
        this.fecha = fecha;
    }

    public string GetTitulo() { return titulo; }
    public string GetPlataforma() { return plataforma; }
    public int GetEspacio() { return espacio; }
    public Fecha GetFecha() { return fecha; }
    public void SetTitulo(string titulo) { this.titulo = titulo; }
    public void SetPlataforma(string plataforma) { this.plataforma = plataforma; }
    public void SetEspacio(int espacio) { this.espacio = espacio; }
    public void SetFecha(Fecha fecha) { this.fecha = fecha; }

    public override string ToString()
    {
        return titulo + "(" + espacio + " mb) para " + plataforma + 
            "(" + fecha + ")";
    }

}

// -----------

public class T4s2
{
    static void Main()
    {
        List<Juego> coleccion = new List<Juego>();
        bool terminado = false;
        string opcion = "";

        do
        {
            Console.WriteLine("1- Añadir datos de un nuevo juego. ");
            Console.WriteLine("2- Mostrar los nombres y plataformas de todos los juegos");
            Console.WriteLine("3- Ver todos los datos de juego");
            Console.WriteLine("4- Modificar una ficha");
            Console.WriteLine("5- Borrar un juego");
            Console.WriteLine("T- Terminar el uso de la aplicación");
            Console.WriteLine();

            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":  //nuevo juego
                    Console.WriteLine("Juego: " + (coleccion.Count + 1));

                    Console.Write("Nombre: ");
                    string titulo = Console.ReadLine();

                    Console.Write("Plataforma: ");
                    string plataforma = Console.ReadLine();

                    Console.Write("Espacio(en mb): ");
                    int espacio = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Mes de lanzamiento: ");
                    int mes = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Año de lanzamiento: ");
                    int anyo = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine();

                    coleccion.Add(new Juego(titulo, plataforma, espacio, 
                        new Fecha(mes, anyo)));

                    break;

                case "2":  //mostrar datos de todos los juegos
                    if (coleccion.Count == 0)
                    {
                        Console.WriteLine("No hay juegos que mostrar");
                    }
                    else
                    {
                        for (int i = 0; i < coleccion.Count; i++)
                        {
                            Console.WriteLine("Juego {0}: {1}({2}) ",
                                i + 1, coleccion[i].GetTitulo(), 
                                coleccion[i].GetPlataforma());
                            if (i % 20 == 19)
                            {
                                Console.Write("Pulse Intro para seguir...");
                                Console.ReadLine();
                            }
                        }
                    }
                    Console.WriteLine();
                    break;

                case "3": //Ver todos los datos de un cierto programa
                    Console.Write("Qué número de juego quieres ver? ");
                    int juegoVer = Convert.ToInt32(Console.ReadLine());

                    if ((juegoVer < 1) || (juegoVer > coleccion.Count))
                    {
                        Console.WriteLine("Número de juego no válido");
                    }
                    else
                    {
                        Console.Write("Juego {0}: {1}",
                            juegoVer, coleccion[juegoVer - 1]);     
                        Console.WriteLine();
                    }
                    break;

                case "4": // Modificar una ficha
                    Console.Write("Qué número de juego quieres modificar? ");
                    int juego = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (juego >= 0 && juego < coleccion.Count)
                    {
                        Console.WriteLine("Juego: " + juego + 1);
                        titulo = coleccion[juego].GetTitulo();
                        Console.Write("Nombre {0}: ", titulo);
                        string nuevoValor = Console.ReadLine();

                        if (nuevoValor != "")
                            titulo = nuevoValor;

                        plataforma = coleccion[juego].GetPlataforma();
                        Console.Write("Plataforma {0}: ", plataforma);
                        nuevoValor = Console.ReadLine();
                        if (nuevoValor != "")
                            plataforma = nuevoValor;

                        espacio = coleccion[juego].GetEspacio();
                        Console.Write("Espacio(en mb) {0}: ", espacio);
                        nuevoValor = Console.ReadLine();
                        if (nuevoValor != "")
                            espacio = Convert.ToInt32(nuevoValor);

                        mes = coleccion[juego].GetFecha().GetMes();
                        Console.Write("Mes de lanzamiento {0}: ", mes);
                        nuevoValor = Console.ReadLine();
                        if (nuevoValor != "")
                            mes = Convert.ToInt32(nuevoValor);

                        anyo = coleccion[juego].GetFecha().GetAnyo();
                        Console.Write("Año de lanzamiento {0}: ", anyo);
                        nuevoValor = Console.ReadLine();
                        if (nuevoValor != "")
                            anyo = Convert.ToInt32(nuevoValor);

                        coleccion[juego] = new Juego(titulo, plataforma, espacio, 
                            new Fecha(mes, anyo));
                    }
                    else
                        Console.Write("Incorrecto");

                    Console.WriteLine();
                    break;

                case "5": // Borrar un dato
                    Console.Write("Introduce la posición a borrar");
                    int posicionBorrar = Convert.ToInt32(Console.ReadLine()) - 1;
                    coleccion.RemoveAt(posicionBorrar);

                    break;

                case "t":
                case "T":
                    terminado = true;
                    break;

            }
        }
        while (!terminado);
    }
}
