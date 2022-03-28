//185.Crea un programa que pida el nombre de un fichero GIF y compruebe si
//realmente se trata de una imagen en ese formato. Debes hacerlo de dos formas
//distintas (que pueden ser parte de un mismo programa): con FileStream y con
//BinaryReader. Para conseguirlo, deberás leer byte a byte, y comprobar que
//los 4 primeros bytes corresponden a los caracteres G, I, F, 8. El quinto
//byte permite saber la versión concreta de fichero GIF del que se trata
//(GIF87 o GIF89). Deberás indicar en pantalla si se trata de un fichero
//GIF y, en caso afirmativo, de qué versión.

//Por Ugo (...), retoques por Nacho
//Version 2: BinaryReader

using System;
using System.IO;

class IsAGIF2
{
    static void Main()
    {
        Console.Write("Filename: ");
        BinaryReader file = new BinaryReader(
                        File.Open(Console.ReadLine(),FileMode.Open));

        byte firstByte =  file.ReadByte();
        byte secondByte = file.ReadByte();
        byte thirdByte =  file.ReadByte();
        byte fourthByte = file.ReadByte();
        byte fifthdByte = file.ReadByte();

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

