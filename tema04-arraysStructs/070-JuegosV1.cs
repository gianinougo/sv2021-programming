// Ezequiel (...), retoques por Nacho
// Tema 4 Semana 2, Ejercicio Recomendado 70

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
*/

using System;

public class T4s2
{
    const int MAXIMO = 1000;

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
        tipoJuego[] coleccion = new tipoJuego[MAXIMO];
        bool terminado = false;
        string opcion = "";
        int contadorJuegos = 0;

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
                    if (contadorJuegos < MAXIMO)
                    {
                        Console.Write("Nombre: ", contadorJuegos + 1);
                        coleccion[contadorJuegos].titulo = Console.ReadLine();

                        Console.Write("Plataforma: ", contadorJuegos + 1);
                        coleccion[contadorJuegos].plataforma = Console.ReadLine();

                        Console.Write("Espacio(en mb): ", contadorJuegos + 1);
                        coleccion[contadorJuegos].espacio =
                            Convert.ToInt32(Console.ReadLine());

                        Console.Write("Mes de lanzamiento: ", contadorJuegos + 1);
                        coleccion[contadorJuegos].fecha.mes =
                            Convert.ToInt32(Console.ReadLine());

                        Console.Write("Año de lanzamiento: ", contadorJuegos + 1);
                        coleccion[contadorJuegos].fecha.anyo =
                            Convert.ToInt32(Console.ReadLine());

                        contadorJuegos++;
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("No caben más juegos");
                    }
                    break;

                case "2":  //mostrar datos de todos los juegos
                    if (contadorJuegos == 0)
                    {
                        Console.WriteLine("No hay juegos que mostrar");
                    }
                    else
                    {
                        for(int i = 0; i < contadorJuegos; i++)
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
                    
                    if ((juegoVer < 1) || (juegoVer > contadorJuegos))
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

                    if(juego >= 0 && juego < contadorJuegos)
                    {
                        Console.Write("Nombre: ", contadorJuegos + 1);
                        string nuevoValor = Console.ReadLine();
                        if (nuevoValor != "")
                            coleccion[juego].titulo = nuevoValor;

                        Console.Write("Plataforma: ", contadorJuegos + 1);
                        nuevoValor = Console.ReadLine();
                        if (nuevoValor != "")
                            coleccion[juego].plataforma = nuevoValor;

                        Console.Write("Espacio(en mb): ", contadorJuegos + 1);
                        nuevoValor = Console.ReadLine();
                        if (nuevoValor != "")
                            coleccion[juego].espacio = Convert.ToInt32(nuevoValor);

                        Console.Write("Mes de lanzamiento: ", contadorJuegos + 1);
                        nuevoValor = Console.ReadLine();
                        if (nuevoValor != "")
                            coleccion[juego].fecha.mes = Convert.ToInt32(nuevoValor);

                        Console.Write("Año de lanzamiento: ", contadorJuegos + 1);
                        nuevoValor = Console.ReadLine();
                        if (nuevoValor != "")
                            coleccion[juego].fecha.anyo = Convert.ToInt32(nuevoValor);
                    }
                    else
                        Console.Write("Incorrecto");

                    Console.WriteLine();
                    break;

                case "5": // Borrar un dato
                    Console.Write("Introduce la posición a borrar");
                    int posicionBorrar = Convert.ToInt32(Console.ReadLine()) - 1;

                    for (int i = posicionBorrar; i < contadorJuegos; i++)
                    {
                        coleccion[i] = coleccion[i+1];
                    }
                    contadorJuegos--;
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
