using System.IO;
/*
 190. Crea un programa que sea capaz de encriptar y desencriptar una imagen en 
formato BMP, intercambiando el orden de sus dos primeros bytes de modo que los 
visores de imágenes no la detecten como una imagen válida.

Rocio (...)
 */
class Ejercicio190
{
    static void Main()
    {
        FileStream f = File.Open("img.bmp",FileMode.Open,FileAccess.ReadWrite);
        byte c1 = (byte)f.ReadByte();
        byte c2 = (byte)f.ReadByte();

        f.Seek(0, SeekOrigin.Begin);
        f.WriteByte(c2);
        f.WriteByte(c1);
        f.Close();
    }
}
