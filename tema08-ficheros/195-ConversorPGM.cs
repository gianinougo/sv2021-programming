/*
VIRGINIA (...)

195.  [Tiempo máximo recomendado: 1 hora] El formato PGM es una de las 
versiones de formatos de imagen NetPBM. En concreto, es la variante capaz de 
manejar imágenes en tonos de gris. Su cabecera comienza con una línea que 
contiene P2 (si los datos de la imagen están en ASCII) o P5 (si están en 
binario). La segunda línea (opcional) puede contener un comentario, precedido 
por #. La siguiente línea contiene el ancho y el alto, separados por un 
espacio. La cuarta línea (tercera si no hay comentario) contiene el valor de 
intensidad que corresponde al blanco (típicamente 255, aunque también podría 
ser 15 u otro valor).

 A partir de ahí comienzan los colores (tonos de gris) de los puntos que forman
la imagen. En el formato ASCII (P2) son números de 0 a 255 separados por 
espacios y quizá por saltos de línea. En el formato binario (P5), son bytes 
contiguos, del 0 (negro) al 255 (blanco).

Debes crear un programa capaz de leer un fichero en formato PGM ASCII (cabecera
P2) y crear un fichero PGM binario (cabecera P5), con comentarios (si los 
hubiera en el fichero original). El programa deber comportarse correctamente
con imágenes de distinto ancho y alto.

Por ejemplo a partir de un fichero de entrada como éste:

P2
# Imagen en formato PGM
12 12
255
0 0 0 0 0 0 0 0 0 0 0
0 0 255 255 255 255 255 255 255 255 255 255 0 0 255 0 255 0 255 0 0 0 255 255 0
0 255 0 255 0 255 0 255 255 0 255 0 0 255 0 255 0 255 0 255 255 0 255 0 0 255
255 0 255 255 0 255 255 0 255 0 0 255 255 0 255 255 0 255 255 0 255 0 0 255 255
0 255 255 0 255 255 0 255 0 0 255 255 0 255 255 0 255 255 0 255 0 0 255 255 0
255 255 255 0 0 0 255 0 0 255 255 255 255 255 255 255 255 255 255 0 0 0 0 0 0 0
0 0 0 0 0 0
Deberás generar un fichero cuya primera línea será P5, el resto de la cabecera 
será igual (líneas 2 a 4 si hay comentario, o líneas 2 y 3 si no lo hay), y 
los datos (quinta línea) serían bytes 0 y bytes 255, que no se podrían ver 
correctamente mediante un lector de ficheros de texto.

El nombre del fichero de entrada se leerá de línea de comandos y, si no se ha 
indicado nada en línea de comandos, se preguntará al usuario.

El nombre del fichero de salida será el mismo que el de entrada, pero terminado
en 2, y con la misma extensión. Por ejemplo, si el fichero de entrada se llama
"imagen.pgm", el de salida será "imagen2.pgm". Si el fichero de salida ya 
existe, el programa interrumpirá la ejecución y mostrará un mensaje de aviso.

En GitHub, en la carpeta de ejemplos, tendrás dos ficheros PGM ASCII de prueba,
llamados "imagen_gris_ascii.pbm" e "imagen_gris_ascii2.pbm".

Los pasos que debes seguir y su valoración si fuera un ejercicio con nota, son:

Leer las tres primeras líneas del fichero de entrada (quizá con nombre 
prefijado) y volcarlas a uno de salida, también de texto: hasta 2 puntos.
Leer el nombre desde línea de comandos o, si no hay línea de comandos, pedirlo.
Volcar algún dato binario al final del fichero de salida: hasta 4 puntos.
Volcar un array de tamaño ancho*alto tras la cabecera: hasta 6 puntos.
Volcar correctamente los datos de la imagen en una única línea, como en el 
primer fichero de ejemplo: hasta 8 puntos.
Manejar bien datos de entrada en líneas irregulares, quizá con comentarios y 
quizá con una cantidad distinta de tonalidades de gris: hasta 10 punto
*/

using System;
using System.IO;
using System.Collections.Generic;

class Ejercicio195
{
    static string nombreFicheroIn = "";
    static string nombreFicheroOut = "";

    static void Main(string[] args)
    {
        
        List<string> datos = new List<string>();

        if (args.Length == 0)
        {
            Console.WriteLine("Nombre del fichero: ");
            nombreFicheroIn = Console.ReadLine();
        }
        else if (args.Length == 1)
        {
            nombreFicheroIn = args[0];
        }
        else
            Console.WriteLine("Cantidad de parámetros incorrecta.");

        if (!nombreFicheroIn.Contains(".pgm"))
            Console.WriteLine("Formato del fichero incorrecto.");
        else
        {
            nombreFicheroOut = nombreFicheroIn.Split('.')[0] + "2" + ".pgm";

            if (File.Exists(nombreFicheroOut))
                Console.WriteLine("El fichero de salida ya existe. " +
                    "Se interrumpirá la ejecución.");
            else
            {
                datos = CargarDatos();
                GenerarNuevoPGM(datos);
            }
            
        }
    }
    

    static List<string> CargarDatos()
    {
        List<string> datos = new List<string>();
        try
        {
            StreamReader ficheroIn = new StreamReader(nombreFicheroIn);
            string linea = ficheroIn.ReadLine();

            while (linea!= null)
            {
                datos.Add(linea);
                linea = ficheroIn.ReadLine();
            }
            ficheroIn.Close();
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("Ruta demasiado larga");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("No existe el fichero.");
        }
        catch (IOException)
        {
            Console.WriteLine("No se pudo leer el fichero.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        return datos;
    }
    

    static void GuardarCabecera(List<string> datos)
    {
        try
        {
            StreamWriter ficheroOut = new StreamWriter(nombreFicheroOut);

            foreach (string linea in datos)
            {
                ficheroOut.WriteLine(linea);
            }
            ficheroOut.Close();
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("Ruta demasiado larga.");
        }
        catch (IOException)
        {
            Console.WriteLine("No se pudo escribir en el fichero.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
    

    static void GenerarNuevoPGM(List<string> datos)
    {
        List<string> salida = new List<string>();
        string dimensiones;
        byte valorBlanco;

        salida.Add("P5");
        if (datos[1].Contains("#"))
        {
            salida.Add(datos[1]);
            salida.Add(datos[2]);
            salida.Add(datos[3]);
            dimensiones = datos[2];
            valorBlanco = Convert.ToByte(datos[3]);

            datos.RemoveAt(3);
        }
        else
        {
            salida.Add(datos[1]);
            salida.Add(datos[2]);
            dimensiones = datos[1];
            valorBlanco = Convert.ToByte(datos[2]);
        }

        datos.RemoveAt(2);
        datos.RemoveAt(1);
        datos.RemoveAt(0);

        GuardarCabecera(salida);

        int ancho = Convert.ToInt32(dimensiones.Split()[0]);
        int alto = Convert.ToInt32(dimensiones.Split()[1]);

        string[] imagen = datos.ToArray();

        FileStream ficheroOut;
        ficheroOut = File.OpenWrite(nombreFicheroOut);
        ficheroOut.Seek(-1,SeekOrigin.End);
        for (int i = 0; i < imagen.Length; i++)
        {
            string[] valores = imagen[i].Split();
            
            foreach(string valor in valores)
            {
                byte nuevoValor = Convert.ToByte(valor);
                ficheroOut.WriteByte(nuevoValor);
            }          
        }
        ficheroOut.Close();            
    }
}
