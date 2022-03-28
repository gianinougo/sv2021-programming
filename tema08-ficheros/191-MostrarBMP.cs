/*
VIRGINIA (...)
191. Mostrar un BMP en consola (examen del tema 8, grupo presencial, 2013-2014)

Crea un programa que sea capaz de mostrar una imagen en blanco y negro en 
formato BMP de 256 colores en la consola, como el archivo de ejemplo que tienes
compartido, llamado "welcome8.bmp".

La estructura de la cabecera de un fichero BMP es:

TYPE OF INFORMATION   POSITION IN THE FILE

File type (letters BM)  0-1
File Size  2-5
Reserved 6-7 
Reserved 8-9
Start of image data 10-13
Size of bitmap header 14-17
Width (pixels) 18-21
Height (pixels) 22-25
Number of planes 26-27
Size of each point 28-29
Compression (0=not compressed) 30-33
Image size 34-37
Horizontal resolution 38-41
Vertical resolution 42-45
Size of color table 46-49
Important colors counter 50-53
Puedes leer el ancho (bytes 18 a 21) y el alto (bytes 22 a 25) de la imagen, 
ya sea usando BinaryReader (cada uno es un entero de 32 bits) o FileStream (de 
la forma que puedes ver en la página 24 de los apuntes).

Los bytes 10 a 13 (que también forman un Int32) se pueden usar para saber en 
qué posición del fichero comienzan los datos de la imagen. Como alternativa, 
ya que cada píxel corresponde a un byte, puedes situarte a "-ancho*alto" desde 
el final del archivo y comenzar a leer desde ahí. 

Debes dibujar un "." si el valor del píxel es > 127, o un "*" en caso 
contrario.
*/

using System;
using System.IO;

class Ejercicio191
{
    static void Main()
    {
        try
        {
            FileStream imagen = new FileStream(
                    "welcome8.bmp", FileMode.Open);
            int tamanyo = (int)imagen.Length;
            byte[] datos = new byte[tamanyo];
            imagen.Read(datos, 0, tamanyo);
            imagen.Close();

            if (datos.Length != tamanyo)
                Console.WriteLine("No se han podido leer todos los datos.");
            else
            {
                byte ancho = datos[18];
                byte alto = datos[22];
                int inicioImagen = datos[10] + datos[11] * 256;

                byte[,] imagenMostrar = new byte[alto, ancho];

                int i = 0;
                for (int fila = 0; fila < alto; fila++)
                {
                    for (int col = 0; col < ancho; col++)
                    {
                        byte pixel = datos[inicioImagen + i];
                        imagenMostrar[alto - fila - 1, col] = pixel;
                        i++;
                    }
                    Console.WriteLine();
                }

                for (int fila = 0; fila < alto; fila++)
                {
                    for (int col = 0; col < ancho; col++)
                    {
                        byte pixel = imagenMostrar[fila, col];
                        if (pixel > 127)
                            Console.Write(".");
                        else
                            Console.Write("*");                       
                    }
                    Console.WriteLine();
                }
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("El fichero no existe.");
        }
        catch (PathTooLongException e)
        {
            Console.WriteLine("Ruta demasiado larga.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }        
    }
}
