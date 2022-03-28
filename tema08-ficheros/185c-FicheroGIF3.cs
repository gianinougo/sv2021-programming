//185.Crea un programa que pida el nombre de un fichero GIF y compruebe si
//realmente se trata de una imagen en ese formato. Debes hacerlo de dos formas
//distintas (que pueden ser parte de un mismo programa): con FileStream y con
//BinaryReader. Para conseguirlo, deberás leer byte a byte, y comprobar que
//los 4 primeros bytes corresponden a los caracteres G, I, F, 8. El quinto
//byte permite saber la versión concreta de fichero GIF del que se trata
//(GIF87 o GIF89). Deberás indicar en pantalla si se trata de un fichero
//GIF y, en caso afirmativo, de qué versión.

//Por Ugo (...), retoques por Nacho
//Version 3: FileStream + bloques

using System;
using System.IO;

class IsAGIF3
{
    static void Main()
    {
        Console.Write("Filename: ");
        FileStream file = new FileStream(Console.ReadLine(), FileMode.Open);
        byte[] datos = new byte[5];
        file.Read(datos, 0, 5);
        file.Close();

        if (datos[0] == 'G' && datos[1] == 'I' && datos[2] == 'F' && 
            datos[3] == '8')
        {
            Console.Write("Archivo GIF, ");
            if (datos[4] == '7')
            {
                Console.WriteLine("Version 7");
            }
            else if (datos[4] == '9')
            {
                Console.WriteLine("Version 9");
            }
            else
            {
                Console.WriteLine("Version incorrecta");
            }
        }
        else
        {
            Console.WriteLine("No es un archivo GIF");
        }
    }
}

