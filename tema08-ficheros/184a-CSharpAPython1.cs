/*
VIRGINIA (...), retoques menores por Nacho

184. Examen de 2012-2013 del tema 8, grupo presencial : C# a Python

using System;
public class DivideTwoNumbers
{
    public static void Main()
    {
        int number1, number2;
        
        Console.Write("Enter the first number:");
        number1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the second number:");
        number2 = Convert.ToInt32(Console.ReadLine());
        
        if (number2 != 0)
        {
            Console.WriteLine("The result for {0} / {1} is {2}", number1, 
                                number2, number1/number2);
        }
        else
            Console.WriteLine("Cannot be divided");
        for (int i=1; i<4; i++)
            Console.WriteLine("Bye!"); 
    }
}
y convertirlo en algo como:
 
print("Enter the first number:")
number1 = int(input())
print("Enter the second number:")
number2 = int(input())
if number2 != 0:
        print("The result for {0} / {1} is {2}".format(number1, number2, 
                                                        number1/number2))
else:
        print("Cannot be divided")
for i in range (1,4):
    print("Bye!")
El nombre del fichero a analizar se le debe preguntar al usuario.
*/

using System;
using System.IO;
using System.Collections.Generic;

class Ejercicio184
{
    static void Main()
    {
        Console.WriteLine("Nombre del fichero: ");
        string nombreFichero = Console.ReadLine();
        
        string[] contenido;

        try
        {
            contenido = File.ReadAllLines(nombreFichero);
        }
        catch (Exception)
        {
            Console.WriteLine("No se ha podido leer el fichero");
            return;
        }

        for (int i = 0; i < contenido.Length; i++)
        {
            //contenido[i] = contenido[i].Trim();
            if (contenido[i].Contains("using") ||
                contenido[i].Contains("public class") ||
                contenido[i].Trim() == "{" ||
                contenido[i].Trim() == "}" ||
                contenido[i].Contains("static void Main()") ||
                contenido[i].Trim().Split()[0] == "int")
            {
                contenido[i] = "";
            }

            if (contenido[i].Contains("Console.Write"))
            {
                string[] trozos = contenido[i].Split('"');
                int cantidadEspacios = contenido[i].IndexOf("Console.");
                               
                //if (trozos[2] != ");")
                if (contenido[i].Contains("\","))
                {
                    trozos[2] = trozos[2].Substring(2);
                    trozos[2] = trozos[2].Replace(";", ")");
                    contenido[i] = new string(' ', cantidadEspacios) +
                        "print(\"" + trozos[1] + 
                        "\".format(" + trozos[2];
                }
                else
                {
                    contenido[i] = new string(' ', cantidadEspacios) +
                        "print(\"" + trozos[1] + "\")";
                }
            }

            if (contenido[i].Contains("Console.ReadLine"))
            {
                string[] trozos = contenido[i].Split('=');
                contenido[i] = trozos[0] + " =  int(input())";
            }

            if (contenido[i].Contains("if"))
            {
                contenido[i] = contenido[i].Replace("(","");
                contenido[i] = contenido[i].Replace(")", ":");                              
            }

            if (contenido[i].Contains("else"))
            {
                contenido[i] += ":";
            }

            if (contenido[i].Contains("for ("))
            {
                int cantidadEspacios = contenido[i].IndexOf("for");
                contenido[i] = contenido[i].Replace("(", "");
                contenido[i] = contenido[i].Replace(")", "");
                char desde = contenido[i].Split('=')[1][0];              
                char hasta = contenido[i].Split('<')[1][0];            
                contenido[i] = new string(' ', cantidadEspacios) +
                    "for i in range (" + desde + "," + hasta + "):";
            }
        }

        StreamWriter fichero;
        fichero = File.CreateText(nombreFichero.Replace(".cs", ".py"));

        foreach (string linea in contenido)
        {
            if (linea != "")
            {
                // Eliminamos dos saltos de tabulación, si los hay
                if (linea.StartsWith("        "))
                    fichero.WriteLine(linea.Substring(8));
                else
                    fichero.WriteLine(linea);
            }
        }
        fichero.Close();
        
        Console.WriteLine("Fuente convertido");
    }
}
