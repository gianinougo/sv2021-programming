//185.Crea un programa que pida el nombre de un fichero GIF y compruebe si
//realmente se trata de una imagen en ese formato. Debes hacerlo de dos formas
//distintas (que pueden ser parte de un mismo programa): con FileStream y con
//BinaryReader. Para conseguirlo, deberás leer byte a byte, y comprobar que
//los 4 primeros bytes corresponden a los caracteres G, I, F, 8. El quinto
//byte permite saber la versión concreta de fichero GIF del que se trata
//(GIF87 o GIF89). Deberás indicar en pantalla si se trata de un fichero
//GIF y, en caso afirmativo, de qué versión.

//Por Ugo (...), retoques por Nacho

using System;
using System.IO;

class IsAGIF
{
    static void Main()
    {
        Console.Write("Filename: ");
        FileStream file = new FileStream(Console.ReadLine(), FileMode.Open);

        byte firstByte = (byte)file.ReadByte();
        byte secondByte = (byte)file.ReadByte();
        byte thirdByte = (byte)file.ReadByte();
        byte fourthByte = (byte)file.ReadByte();
        byte fifthdByte = (byte)file.ReadByte();

        file.Close();

        if (firstByte == 'G' && secondByte == 'I' && thirdByte == 'F' && 
            fourthByte == '8')
        {
            Console.Write("Archivo GIF, ");
            if (fifthdByte == '7')
            {
                Console.WriteLine("Version 7");
            }
            else if (fifthdByte == '9')
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

