/* Crea un programa que permita copiar un archivo de origen a un archivo de 
destino. El nombre de ambos ficheros se tomará de la línea de comandos. Debes 
usar FileStream y un bloque de 10 KiB (10240 bytes) de tamaño. Un ejemplo de 
uso podría ser:

micopiador fichero1.txt e:\fichero2.txt

Debe comportarse correctamente si el archivo de origen no existe y debe avisar 
(pero no sobrescribirlo) si el archivo de destino existe.
*/

using System;
using System.IO;

class Ejercicio188
{
    static void Main(string[] args)
    {
        const int TAMANYO_BLOQUE = 10240; // 10 Kib = 10240 bytes
        if (args.Length == 1)
        {
            string nombre = args[0];
            int cantidadLeida;

            try
            {
                FileStream entrada = File.OpenRead(nombre);
                FileStream salida = File.Create(nombre + ".txt");
                byte[] datos = new byte[TAMANYO_BLOQUE];
                do
                {
                    cantidadLeida = entrada.Read(datos, 0, TAMANYO_BLOQUE);
                    salida.Write(datos, 0, cantidadLeida);
                }
                while ( cantidadLeida == TAMANYO_BLOQUE);

                entrada.Close();
                salida.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Archivo no encontrado");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Nombre de archivo o ruta demasiado larga");
            }
            catch (IOException)
            {
                Console.WriteLine("Error de lectura o escritura");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        else
            Console.WriteLine("Uso: nombreFichero");
    }
}
