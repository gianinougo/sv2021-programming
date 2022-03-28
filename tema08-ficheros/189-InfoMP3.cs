/*
VIRGINIA (...)
189. Crea un programa que muestre la información almacenada en un archivo MP3 
(que tenga una cabecera en formato "ID3 TAG V1"): título, artista, álbum, año. 
Deberás comprobar el contenido de los últimos 128 bytes del fichero. En caso 
de tratarse de un MP3 que tenga cabecera en dicho formato, deberías encontrar 
la siguiente secuencia de bytes a partir de esa posición:

Los caracteres TAG (3 bytes)
Título: 30 caracteres (30 bytes).
Artista: 30 caracteres (ídem).
Álbum: 30 caracteres.
Año: 4 caracteres.
Un comentario: 30 caracteres.
Género (musical): un byte.
Todas las etiquetas usan caracteres ASCII (terminados en caracteres nulos o 
quizá en espacios), excepto el género, que es un número entero almacenado en
un único byte.
*/

using System;
using System.IO;

class Ejercicio189
{
    static void Main()
    {
        Console.WriteLine("Nombre de fichero? ");
        string nombreFichero = Console.ReadLine();

        if (!File.Exists(nombreFichero))
        {
            Console.WriteLine("El fichero no existe.");
        }
        else
        {
            byte[] cabecera = new byte[128];
            
            try
            {
                FileStream fichero = File.OpenRead(nombreFichero);
                fichero.Seek(-128, SeekOrigin.End);
                
                fichero.Read(cabecera, 0, 128);
                fichero.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Vaya!");
            }

            string tag = "" + (char)cabecera[0] +
                (char)cabecera[1] + (char)cabecera[2];

            if (tag == "TAG")
            {
                string titulo = "";
                for (int i = 3; i < 33; i++)
                {
                    if (cabecera[i] != 0)
                    {
                        titulo += (char)cabecera[i];
                    }
                }

                string artista = "";
                for (int i = 33; i < 63; i++)
                {
                    if (cabecera[i] != 0)
                    {
                        artista += (char)cabecera[i];
                    }
                }

                string album = "";
                for (int i = 63; i < 93; i++)
                {
                    if (cabecera[i] != 0)
                    {
                        album += (char)cabecera[i];
                    }
                }

                string anyo = "";
                for (int i = 93; i < 97; i++)
                {
                    if (cabecera[i] != 0)
                    {
                        anyo += (char)cabecera[i];
                    }
                }

                string comentario = "";
                for (int i = 97; i < 127; i++)
                {
                    if (cabecera[i] != 0)
                    {
                        comentario += (char)cabecera[i];
                    }
                }

                int genero = (int)cabecera[127];               
                
                Console.WriteLine("Título: " + titulo);
                Console.WriteLine("Artista: " + artista);
                Console.WriteLine("Album: " + album);
                Console.WriteLine("Año: " + anyo);
                Console.WriteLine("Comentarios: " + comentario);
                Console.WriteLine("Género: " + genero);
            }
            else
            {
                Console.WriteLine("No es un archivo MP3");
            }           
        }        
    }
}
