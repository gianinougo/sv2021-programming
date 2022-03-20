/* Juan Manuel (...), retoques por Nacho */

/*
Ejercicio 180.Crea una versión alternativa del ejercicio 179 (fichero a
mayúsculas), empleado StreamReader y StreamWriter. Debes comprobar si el
fichero de entrada existe, y avisar en caso de que no sea así.
*/

using System;
using System.IO;

class Ejercicio180
{
    static void Main(string[] args)
    {
        Console.WriteLine("Introduce el nombre del fichero a convertir a mayúsculas");
        string nombreEntrada = Console.ReadLine();
        string nombreSalida = nombreEntrada + ".mays.txt";
        
        if (! File.Exists(nombreEntrada))
        {
            Console.WriteLine("Fichero de entrada no encontrado.");
        }
        else
        {
            string linea;
            try
            {
                StreamReader ficheroEntrada = new StreamReader(nombreEntrada);
                StreamWriter ficheroSalida = new StreamWriter(nombreSalida);
                
                do
                {
                    linea = ficheroEntrada.ReadLine();
                    if (linea != null)
                    {
                        ficheroSalida.WriteLine(linea.ToUpper());
                    }
                }
                while (linea != null);
                
                ficheroSalida.Close();
                ficheroEntrada.Close();
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Nombre demasiado largo");
            }
            catch (IOException e)
            {
                Console.WriteLine("Error de E/S: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error inesperado: {0}", e.Message);
            }
        }
        Console.WriteLine("Conversión terminada");
    }
}

