/*
193. [Tiempo máximo recomendado: 1 hora] Debes crear un programa capaz 
de extraer el texto contenido en un fichero HTML y volcarlo en formato 
"markdown". Partirá de un fichero que se leerá de parámetros (o se 
pedirá al usuario en caso de no existir parámetros) y creará un fichero 
con el mismo nombre y en el que la extensión ".html" (o ".htm", quizá 
en mayúsculas) será reemplazada por ".md".


A partir de un fichero con un contenido como

<!DOCTYPE html>
<html>
<body>
  <h1>Título</h1>
  <p>Párrafo
  con <b>varias</b> palabras.</p>
  <ul>
    <li>Dato uno</li>
    <li>Dato dos</li>
  </ul>
</body>
</html>

Se debería generar otro con el contenido:

# Título

Párrafo 
con varias palabras.

* Dato uno
* Dato dos

Es decir: no se mostrarán cabeceras, se eliminarán los sangrados del 
texto, si los hay; los títulos y los párrafos tendrán a continuación 
una línea en blanco; los elementos de lista se precederán por asterisco 
y espacio; los títulos se precederán por una almohadilla; se eliminarán 
todas las etiquetas.
*/

// Rocio (...), retoques por Nacho

using System;
using System.IO;

class Ejercicio192
{
    static void Main()
    {
        string linea;

        Console.WriteLine("Introduce el nombre de un fichero:");
        string nombreFichero = Console.ReadLine();
        string nombreNuevoFichero;
        if (nombreFichero.Contains(".html"))
        {
            nombreNuevoFichero = nombreFichero.Replace(".html", ".md");
        }
        else if (nombreFichero.Contains(".htm"))
        {
            nombreNuevoFichero = nombreFichero.Replace(".htm", ".md");
        }
        else
            nombreNuevoFichero = nombreFichero + ".md";

        try
        {
            StreamReader ficheroLectura = File.OpenText(nombreFichero);
            StreamWriter ficheroEscritura = File.CreateText(nombreNuevoFichero);

            do
            {
                linea = ficheroLectura.ReadLine();

                if (linea != null)
                {
                    linea = linea.Replace("<!DOCTYPE html>", "");
                    linea = linea.Replace("<html>", "");
                    linea = linea.Replace("</html>", "");
                    linea = linea.Replace("<body>", "");
                    linea = linea.Replace("</body>", "");
                    linea = linea.Replace("<p>", "");
                    linea = linea.Replace("</li>", "");
                    linea = linea.Replace("<ul>", "");
                    linea = linea.Replace("</ul>", "");
                    linea = linea.Replace("<b>", "");
                    linea = linea.Replace("</b>", "");
                    linea = linea.Trim();
                    
                    linea = linea.Replace("<h1>", "# ");
                    linea = linea.Replace("<li>", "* ");
                    linea = linea.Replace("</p>", "\n");
                    linea = linea.Replace("</h1>", "\n");
                }
                ficheroEscritura.WriteLine(linea);
            } while (linea != null);

            ficheroLectura.Close();
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
