// Author: Franco (...)
/*
 * Ejercicio 194. 
 * [Tiempo máximo recomendado: 1 hora 30 min]
 * 
 * Debes crear un programa capaz de convertir fuentes sencillos en C# a JavaScript, 
 * como el que se muestra a continuación.
 * Partirá de un fichero que se leerá de parámetros 
 * (o se pedirá al usuario en caso de no existir parámetros)
 * y creará un fichero con el mismo nombre 
 * y en el que la extensión ".cs" será reemplazada por ".js".

using System;
class Javascript
{
    static void Main()
    {
       Console.WriteLine("Hola, bienvenido a JavaScript");
 
       Console.WriteLine("\"Console.WriteLine\" escribe string e int en C#");
 
        int numero = 3;
        if (numero>2) {
           Console.WriteLine("El numero es mayor que 2");
        }
 
        if (numero == 3) {
           Console.WriteLine("El numero es 3");
        }
 
        for (int i = 10; i<= 20; i+=2) {
           Console.WriteLine(i);
        }
 
        string frase="ejemplo de frase con Trim y Split";
        frase = frase.Replace("de", "con");
        frase = frase.ToUpper();
        frase = frase.Trim();
        string[] palabras = frase.Split(' ');
        foreach (string unaPalabra in palabras) 
           Console.WriteLine(unaPalabra);
    }
}
 

  *
  * Su resultado sería:
  *


console.log("Hola, bienvenido a JavaScript");
 
console.log("\"Console.WriteLine\" escribe string e int en C#");
 
let numero = 3;
if (numero>2) {
    console.log("El numero es mayor que 2");
}
 
if (numero === 3) {
    console.log("El numero es 3");
}
 
for (let i = 10; i <= 20; i+=2) {
    console.log(i);
}
 
let frase="ejemplo de frase con Trim y Split";
frase = frase.replace("de", "con");
frase = frase.toUpperCase();
frase = frase.trim();
let palabras = frase.split(" ");
for (let unaPalabra of palabras) 
    console.log(unaPalabra);

  * En “Aules” (y GitHub), en la carpeta de ejercicios de clase, 
  * tendrás dos ficheros de prueba, llamados "cs2js1.cs" y "cs2js2.cs".
  * 
  * Los pasos que debes seguir y su valoración si fuera un ejercicio con nota, son:
  * 
  * Leer un archivo de texto de principio a fin, 
  * cuyo nombre será introducido por el usuario en línea de comandos 
  * o (si no se indica en línea de comandos) de forma interactiva: hasta 2 puntos.
  * 
  * Volcar todo el contenido a otro archivo de texto, cuyo nombre será el mismo, 
  * pero con la extensión ".js" en lugar de ".cs": hasta 4 puntos.
  * 
  * Reemplazar "Console.WriteLine" con "console.log", "==" con "===", "!=" con "!==" y 
  * cambiar por su equivalente que comience por minúsculas los métodos "Trim", "Replace", 
  * "ToUpper" (que será "toUpperCase") : hasta 5 puntos.
  * 
  * Cambiar string, int y demás tipos de datos por “let”, 
  * sólo donde corresponda: hasta 6 puntos.
  * 
  * Eliminar las líneas using, class, Main y tabular adecuadamente: hasta 7 puntos.
  * 
  * Que "split" funcione con cualquier separador y que los corchetes se conviertan 
  * en "charAt": hasta 8 puntos.
  * 
  * Formato correcto para "foreach": hasta 9 puntos.
  * 
  * Que cualquier método (letra que siga a un punto) se convierta a minúsculas 
  * (como ".startsWith") y que el programa resultante funcione correctamente 
  * en la consola del navegador (pulsando F12),
  * para ambos programas de prueba: hasta 10 puntos.
  * 
  * Es deseable que el fuente resultante quede correctamente tabulado (si el original lo estaba). 
  * 
  * DEBES emplear StreamReader y StreamWriter, no ReadAllLines ni ReadAllText.
 */


using System;
using System.Collections.Generic;
using System.IO;

class ej194
{
    static void Main(string[] args)
    {
        string nombreFichero;
        string nombreNuevoFichero;
        StreamReader ficheroLectura;
        StreamWriter ficheroEscritura;
        string linea;

        if (args.Length < 1)
        {
            Console.WriteLine("No se han introducido parametros.");
            Console.WriteLine();
            Console.Write("Introduce el nombre del fichero: ");
            nombreFichero = Console.ReadLine();
        }
        else
            nombreFichero = args[0];

        nombreFichero = nombreFichero.ToLower();

        if (nombreFichero.Contains(".cs"))
            nombreNuevoFichero = nombreFichero.Replace(".cs", ".js");
        else
            nombreNuevoFichero = nombreFichero + ".js";

        try
        {
            ficheroLectura = File.OpenText(nombreFichero);
            ficheroEscritura = File.CreateText(nombreNuevoFichero);

            do
            {
                linea = ficheroLectura.ReadLine();

                if (linea != null)
                {

                    /*
                     * Reemplazar "Console.WriteLine" con "console.log", "==" con "===", "!=" con "!==" y 
                     * cambiar por su equivalente que comience por minúsculas los métodos "Trim", "Replace", 
                     * "ToUpper" (que será "toUpperCase") : hasta 5 puntos.
                     */

                    SortedList<string, string> sintaxisACambiar = 
                        new SortedList<string, string>();

                    sintaxisACambiar.Add("Console.WriteLine(", "console.log(");
                    sintaxisACambiar.Add("==", "===");
                    sintaxisACambiar.Add("!=", "!==");
                    sintaxisACambiar.Add(".Trim", ".trim");
                    sintaxisACambiar.Add(".Split", ".split");
                    sintaxisACambiar.Add(".Replace", ".replace");
                    sintaxisACambiar.Add(".ToUpper", ".toUpperCase");

                    for (int i = 0; i < sintaxisACambiar.Count; i++)
                    {
                        if (linea.Contains(sintaxisACambiar.Keys[i])) 
                        {
                            linea = linea.Replace(
                                sintaxisACambiar.Keys[i], 
                                sintaxisACambiar.Values[i]);
                        }
                    }

                    /*
                     * Cambiar string, int y demás tipos de datos por “let”, 
                     * sólo donde corresponda: hasta 6 puntos.
                     */

                    string[] tipoDeDatos = { "string ", "int ", "long ", "short ", "byte " };

                    foreach (string tipoDato in tipoDeDatos) 
                    {
                        if (linea.Contains(tipoDato))
                        {
                            linea = linea.Replace(tipoDato, "let ");

                            if (linea.Contains("[]"))
                                linea = linea.Replace("[]", "");
                        }
                    }

                    /*
                     * Eliminar las líneas using, class, Main y 
                     * tabular adecuadamente: hasta 7 puntos.
                     */

                    string[] lineaAEliminar = { "using ", "class ", " Main"/*, "{", "}"*/ };

                    foreach (string elemento in lineaAEliminar)
                    {
                        if (linea.Contains(elemento))
                            linea = "";
                    }

                    /*
                     * Que "split" funcione con cualquier separador 
                     * y que los corchetes se conviertan 
                     * en "charAt": hasta 8 puntos.
                     */
                     if (linea.Contains("[]"))
                     {
                            linea = linea.Replace("[", ".charAt(");
                            linea = linea.Replace("]", ")");
                     }

                    /*Formato correcto para "foreach": hasta 9 puntos.*/
                    if (linea.Contains("foreach ") && linea.Contains(" in "))
                        linea = linea.Replace("foreach ", "for ").Replace(" in ", " of ");

                   ficheroEscritura.WriteLine(linea);
                }

            } while (linea != null);

            ficheroLectura.Close();
            ficheroEscritura.Close();

            Console.WriteLine("Conversión terminada");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("Nombre demasiado largo");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Ese fichero no existe");
        }
        catch (IOException e)
        {
            Console.WriteLine("Error de E/S: {0}", e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error inesperado: {0}", e.Message);
        }
    }
}
