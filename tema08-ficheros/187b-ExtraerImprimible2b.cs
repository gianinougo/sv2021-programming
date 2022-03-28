// Ejercicio recomendado 187
// Javier (...), retoques por Nacho

/* Crea un programa que extraiga los caracteres imprimibles 
 * (código ASCII 32 a 127, además del 7, el 10 y el 13) de un fichero y los 
 * vuelque a otro fichero. Todos los demás caracteres se convertirán a espacio 
 * (ASCII 32). El nombre del fichero de origen se tomará de la línea de 
 * comandos y el de destino se creará añadiendo ".2.txt" al nombre de origen.
 * Debes usar FileStream y un bloque con el tamaño de todo el archivo. 
 * Si el fichero de destino ya existe, lo sobreescribirás sin preguntar.
 */

using System;
using System.IO;
using System.Collections.Generic;

class ExtraerCaracteresImprimibles2
{
    public static void Main(string[] args)
    {
        if (args.Length == 1)
        {
            string nombreFichero = args[0];

            if (File.Exists(nombreFichero))
            {
                try
                {
                    FileStream entrada = File.OpenRead(nombreFichero);
                    int tamanyo = (int)entrada.Length;
                    byte[] datos = new byte[tamanyo];   
                    int cantidadLeida = entrada.Read(datos, 0, tamanyo);
                    entrada.Close();
                    
                    if (cantidadLeida < tamanyo)
                    {
                        Console.WriteLine("No se ha podido leer completo");
                    }
                    else
                    {
                        for (int i = 0; i < tamanyo; i++)
                        {
                            byte d = datos[i];
                            if ( ! (d == 7 || d == 10 || d == 13 ||
                                (d >= 32 && d <= 127)))
                            {
                                datos[i] = 32;
                            }
                        }

                        FileStream salida = File.Create(nombreFichero + ".2.txt");
                        salida.Write(datos, 0, tamanyo);
                        salida.Close();
                    }

                    Console.WriteLine("Extracción de caracteres imprimibles " +
                        "finalizada");
                }
                catch (PathTooLongException ptee)
                {
                    Console.WriteLine("Error en el nombre: " + ptee.Message);
                }
                catch (IOException ioe)
                {
                    Console.WriteLine("Error de lectura/escritura, " + ioe.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            else
                Console.WriteLine("El fichero no existe");
        }
        else
            Console.WriteLine("No se ha introducido el nombre del fichero");
    }
}
