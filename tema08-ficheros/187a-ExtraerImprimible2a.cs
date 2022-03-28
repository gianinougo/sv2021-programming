using System.IO;
using System;
/*
 * 187. Crea un programa que extraiga los caracteres imprimibles 
 * (código ASCII 32 a 127, además del 7, el 10 y el 13) de un fichero y los 
 * vuelque a otro fichero. Todos los demás caracteres se convertirán a espacio 
 * (ASCII 32). El nombre del fichero de origen se tomará de la línea de comandos
 * y el de destino se creará añadiendo ".2.txt" al nombre de origen. Debes usar 
 * FileStream y un bloque con el tamaño de todo el archivo. Si el fichero de 
 * destino ya existe, lo sobreescribirás sin preguntar.
 * 
 * Rocio (...)
 */

class Ejercicio187
{
    static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Indique el nombre de fichero");
            return;
        }
        string entrada = args[0];
        Console.WriteLine("Nombre del formato del archivo");
        string salida = entrada + ".2.txt";

        FileStream f = File.OpenRead(entrada);
        FileStream fileOut = File.Create(salida);
        int maximo = (int)f.Length;
       
        byte[] datos = new byte[maximo];
        f.Read(datos, 0, maximo);
        for (int i = 0; i < maximo; i++)
        {
            if ((datos[i] >= 32 && datos[i] <= 127) || datos[i] == 7 ||
                datos[i] == 10 || datos[i] == 13)
            {
                fileOut.WriteByte(datos[i]);
            }
            else
            {
                fileOut.WriteByte(32);

            }
        }
        fileOut.Close();
        f.Close();
    }
}

