//Author: Franco (...),retoques por Nacho
/*
 * 181. Crea un "convertidor básico de texto a HTML", 
 * que leerá un archivo de texto de origen 
 * y creará un archivo HTML a partir de su contenido. 
 * 
 * Por ejemplo, si el archivo contiene:
 * 
 * Hola
 * Soy yo
 * Ya he terminado
 * 
 * El archivo HTML resultante debe contener
 * 
 * <html>
 * <body>
 * <p>Hola</p>
 * <p>Soy yo</p>
 * <p>Ya he terminado</p>
 * </body>
 * </html>
 * 
 * El nombre del fichero de destino debe ser el mismo que el nombre del fichero de origen, 
 * pero con la extensión ".html" 
 * (que reemplazará a la extensión anterior ".txt", en caso de que la hubiera).  
 * 
 * Comprueba los posibles errores.
 */

using System;
using System.IO;

class ej181 
{
    static void Main()
    {               
        string nombreFichero;
        string nombreNuevoFichero;
        StreamReader ficheroLectura;
        StreamWriter ficheroEscritura;
        string linea;

        Console.WriteLine("Introduce el nombre de un fichero:");
        nombreFichero = Console.ReadLine();
        if (nombreFichero.Contains(".txt"))
            nombreNuevoFichero = nombreFichero.Replace(".txt", ".html");
        else
            nombreNuevoFichero = nombreFichero + ".html";


        try
        {
            ficheroLectura = File.OpenText(nombreFichero);
            ficheroEscritura = File.CreateText(nombreNuevoFichero);

            ficheroEscritura.WriteLine("<html>");
            ficheroEscritura.WriteLine("<body>");

            do
            {
                linea = ficheroLectura.ReadLine();

                if (linea != null)
                    ficheroEscritura.WriteLine("<p>" + linea + "</p>");

            } while (linea != null);

            ficheroLectura.Close();

            ficheroEscritura.WriteLine("</body>");
            ficheroEscritura.WriteLine("</html>");
            ficheroEscritura.Close();
            Console.WriteLine("Conversión terminada");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("Nombre demasiado largo");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Ese fichero no existe");
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
}
