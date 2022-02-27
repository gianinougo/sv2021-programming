// Ejercicio recomendado 162
// Javier (...)

/*
Crea una lista que permita almacenar hasta 1000 juegos de ordenador o consola.
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

(En esta versión se utilizará una lista con tipo en lugar de array)
*/

using System;
using System.Collections.Generic;

public class JuegosDeOrdenador
{
    struct tipoFecha
    {
        public int mes;
        public int anyo;
    }

    struct tipoJuego
    {
            public string titulo;
            public string plataforma;
            public int espacio;
            public tipoFecha fecha;
    }

    static void Main()
    {
        List<tipoJuego> coleccion = new List<tipoJuego>();
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

            switch(opcion)
            {
                case "1":  //nuevo juego
                    Console.WriteLine("Juego: " + (coleccion.Count + 1));
                    tipoJuego j;
                    Console.Write("Nombre: ");
                    j.titulo = Console.ReadLine();

                    Console.Write("Plataforma: ");
                    j.plataforma = Console.ReadLine();

                    Console.Write("Espacio(en mb): ");
                    j.espacio = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Mes de lanzamiento: ");
                    j.fecha.mes = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Año de lanzamiento: ");
                    j.fecha.anyo = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine();

                    coleccion.Add(j);

                    break;

                case "2":  //mostrar datos de todos los juegos
                    if (coleccion.Count == 0)
                    {
                        Console.WriteLine("No hay juegos que mostrar");
                    }
                    else
                    {
                        for(int i = 0; i < coleccion.Count; i++)
                        {
                            Console.WriteLine("Juego {0}: {1}({2}) ",
                                i + 1, coleccion[i].titulo, coleccion[i].plataforma);
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
                        Console.Write("Juego {0}: {1}({2}mb) ",
                            juegoVer, 
                            coleccion[juegoVer-1].titulo,
                            coleccion[juegoVer-1].espacio);
                        Console.Write("para {0}({1}/{2})",
                            coleccion[juegoVer-1].plataforma,
                            coleccion[juegoVer-1].fecha.mes,
                            coleccion[juegoVer-1].fecha.anyo);

                        Console.WriteLine();
                    }
                    break;

                case "4": // Modificar una ficha
                    Console.Write("Qué número de juego quieres modificar? ");
                    int juego = Convert.ToInt32(Console.ReadLine()) - 1;

                    if(juego >= 0 && juego < coleccion.Count)
                    {
                        Console.WriteLine("Juego: " + juego + 1);
                        string nuevoTitulo = coleccion[juego].titulo;
                        Console.Write("Nombre {0}: ", nuevoTitulo);

                        string nuevoValor = Console.ReadLine();                        
                        if (nuevoValor != "")
                            nuevoTitulo = nuevoValor;

                        string nuevaPlataforma = coleccion[juego].plataforma;
                        Console.Write("Plataforma {0}: ", nuevaPlataforma);
                        nuevoValor = Console.ReadLine();
                        if (nuevoValor != "")
                            nuevaPlataforma = nuevoValor;

                        int nuevoEspacio = coleccion[juego].espacio;
                        Console.Write("Espacio(en mb) {0}: ", nuevoEspacio);
                        nuevoValor = Console.ReadLine();
                        if (nuevoValor != "")
                            nuevoEspacio = Convert.ToInt32(nuevoValor);

                        int nuevoMes = coleccion[juego].fecha.mes;
                        Console.Write("Mes de lanzamiento {0}: ", nuevoMes);
                        nuevoValor = Console.ReadLine();
                        if (nuevoValor != "")
                            nuevoMes = Convert.ToInt32(nuevoValor);

                        int nuevoAnyo = coleccion[juego].fecha.anyo;
                        Console.Write("Año de lanzamiento {0}: ", nuevoAnyo);
                        nuevoValor = Console.ReadLine();
                        if (nuevoValor != "")
                            nuevoAnyo = Convert.ToInt32(nuevoValor);


                        tipoFecha nuevaFecha;
                        nuevaFecha.mes = nuevoMes;
                        nuevaFecha.anyo = nuevoAnyo;

                        tipoJuego juegoModificado;
                        juegoModificado.titulo = nuevoTitulo;
                        juegoModificado.plataforma = nuevaPlataforma;
                        juegoModificado.espacio = nuevoEspacio;
                        juegoModificado.fecha = nuevaFecha;

                        coleccion[juego] = juegoModificado;

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
        while(!terminado);
    }
}
