/*
143. Crea una clase "Encriptador" que utilizaremos para cifrar y descifrar 
textos.

Tendrá un método "Encriptar", abstracto, que recibirá una cadena y devolverá 
otra cadena, y en método "Desencriptar", también abstracto, y con mismo 
parámetro y valor devuelto.

Crea una clase "EncriptadorXOR", que herede de "Encriptador" y que haga una 
operación "XOR 1" a cada carácter, tanto para obtener el texto cifrado como 
para descrifrarlo (recuerda que habíamos estudiado las operaciones a nivel de 
bits en el apartado 3.1.6, del tema 3).
*/

// VIRGINIA (...)

using System;

class Ejercicio143
{
    static void Main()
    {
        Encriptador encripXOR = new EncriptadorXOR();

        string cadena = "Hola, que tal estas?";

        Console.WriteLine(cadena);

        string cifrada = encripXOR.Encriptar(cadena);
        Console.WriteLine(cifrada);
        string descifrada = encripXOR.Desencriptar(cifrada);
        Console.WriteLine(descifrada);
    }
}

// ----------------------------------------

abstract class Encriptador
{
    public abstract string Encriptar(string cadena);

    public abstract string Desencriptar(string cadena);

}

// ----------------------------------------

class EncriptadorXOR : Encriptador
{

    public override string Encriptar(string cadena)
    {
        string encriptada = "";
        foreach (char letra in cadena)
        {
            encriptada += (char)(letra ^ 1);
        }
        return encriptada;
    }

    public override string Desencriptar(string cadena)
    {
        string desencriptada = "";
        foreach (char letra in cadena)
        {
            desencriptada += (char)(letra ^ 1);
        }
        return desencriptada;
    }
}
