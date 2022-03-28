//Victor (...), retoques por Nacho
/*186. Crea una programa que extraiga los caracteres imprimibles 
(código ASCII 32 a 127, además del 7, el 10 y el 13) de un fichero 
y los vuelque a otro fichero, usando BinaryReader y BinaryWriter. El 
nombre del fichero de origen se tomará de la línea de comandos y el de 
destino se creará añadiendo ".txt" al nombre de origen. Si el fichero 
de destino ya existe, lo sobreescribirás sin preguntar.*/

using System;
using System.IO;

class Ejercicio186
{
    static void Main(string []args)
    {
        if (args.Length == 0)
            Console.WriteLine("Sin nombre de fichero");
        else
        {
            string nombre = args[0];

            if (!File.Exists(nombre))
            {
                Console.WriteLine("El fichero no existe");
                return;
            }
            else
            {
                try
                {
                    BinaryReader reader = new BinaryReader(
                        File.Open(nombre,FileMode.Open));
                    BinaryWriter writer = new BinaryWriter(
                        File.Open(nombre + ".txt", FileMode.Create));
                    
                    for (int i = 0; i < reader.BaseStream.Length; i++)
                    {
                        int uno=reader.ReadByte();
                        byte letra = Convert.ToByte(uno);
                        if(letra >= 32 && letra <= 127 
                                || letra == 7 || letra == 10 || letra == 13)
                            writer.Write(letra);
                    }
                    
                    writer.Close();
                    reader.Close();
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error de lectura o escritura: " + e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                Console.WriteLine("Extracción terminada");
            }
        }
    }
}
