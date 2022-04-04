// Ejercicio recomendado 194
// Conversor básico de C# a JS
// Javier (...)

using System;
using System.IO;
using System.Collections.Generic;

class ConversorCSharpJavascript
{
    public static void Main(string[] args)
    {
        string nombreFichero;       
        if (args.Length == 1)
            nombreFichero = args[0];
        else
        {
            Console.Write("Introduce el nombre del fichero cs a convertir: ");
            nombreFichero = Console.ReadLine();
        }

        List<string> datos = ExtraerDatosFichero(nombreFichero);
        if (datos != null)
        {
            bool necesitaTabular = false;
            string linea = "";
            EliminarLineasInicialesYFinales(datos);
            for (int i = 0; i < datos.Count; i++)
            {
                linea = datos[i].Trim();
                if (linea != "")
                {
                    if (necesitaTabular)
                    {
                        if (linea != "{" && linea != "}")
                            linea = linea.Insert(0, "    ");
                        else if (linea == "}")
                            necesitaTabular = false;
                    }

                    linea = SustituirCW(linea);
                    linea = SustituirVariables(linea);
                    linea = SustituirIgualdad(linea);
                    linea = SustituirMayusculaInicial(linea);
                    linea = SustituirSplit(linea);
                    linea = SustituirCorchetes(linea);
                    linea = ConvertirFor(linea);
                    linea = ConvertirForeach(linea);
                    if (!necesitaTabular && linea != "{" && linea != "}")
                        necesitaTabular = TabularLinea(linea);
                }
                datos[i] = linea;
            }

            foreach (string d in datos)
                Console.WriteLine(d);

            string nombreFicheroJS = ConvertirNombreFichero(nombreFichero);
            GuardarDatosEnFichero(datos, nombreFicheroJS);
        }
    }

    private static bool TabularLinea(string linea)
    {
        bool necesitaTabular = false;
        if (linea.StartsWith("if") || linea.StartsWith("for") ||
            linea.StartsWith("while"))
        {
            necesitaTabular = true;

        }
        return necesitaTabular;
    }

    private static string ConvertirForeach(string linea)
    {
        if (linea.StartsWith("foreach"))
        {
            linea = Sustituir(linea, 0, 7, "for");
            linea = linea.Replace(" in ", " of ");
        }
        return linea;
    }

    private static string ConvertirFor(string linea)
    {
        if (linea.StartsWith("for"))
        {
            int posInt = linea.IndexOf("int");
            if (posInt >= 0)
            {
                linea = linea.Remove(posInt, 3);
                linea = linea.Insert(posInt, "let");
            }
        }
        return linea;
    }

    private static string SustituirCorchetes(string linea)
    {
        if (linea.Contains("["))
        {
            int corcheteIni = 0, corcheteFin = 0;
            while (corcheteIni >= 0)
            {
                corcheteIni = linea.IndexOf("[");
                corcheteFin = linea.IndexOf("]");
                if (corcheteIni >= 0 && corcheteFin >= 0)
                {
                    linea = linea.Remove(corcheteFin, 1);
                    linea = linea.Remove(corcheteIni, 1);
                    linea = linea.Insert(corcheteFin -1, ")");
                    linea = linea.Insert(corcheteIni, ".charAt(");   
                 }
            }
        }
        return linea;
    }

    private static string SustituirSplit(string linea)
    {
        if (linea.Contains(".Split"))
        {
            linea = linea.Replace(".Split('",".split(\"");
            int posSplit = linea.IndexOf(".split");
            linea = linea.Remove(posSplit + 9, 1);
            linea = linea.Insert(posSplit + 9, "\"");
        }
        return linea;
    }

    private static void EliminarLineasInicialesYFinales(List<string> datos)
    {
        for (int i = 0; i < 5; i++) 
            datos.RemoveAt(0);

        datos.RemoveAt(datos.Count - 1);
        datos.RemoveAt(datos.Count - 1);
    }

    private static string SustituirMayusculaInicial(string linea)
    {
        int posPunto = linea.IndexOf('.') + 1;
        if (posPunto >= 0 && posPunto < linea.Length-1)
        {
            if (linea[posPunto] >= 'A' && linea[posPunto] <= 'Z')
            {
                string letra = "" + char.ToLower(linea[posPunto]);
                linea = linea.Remove(posPunto, 1);
                linea = linea.Insert(posPunto, letra);
            }
        }
        return linea;
    }

    private static string SustituirIgualdad(string linea)
    {
        linea = linea.Replace("==", "===");
        linea = linea.Replace("!=", "!==");
        return linea;
    }

    private static string SustituirVariables(string linea)
    {
        bool variableEncontrada = false;

        if (linea.StartsWith("int"))
        {
            linea = linea.Remove(0, 3);
            variableEncontrada = true;
        }
        else if (linea.StartsWith("short") || linea.StartsWith("float"))
        { 
            linea = linea.Remove(0, 5);
            variableEncontrada = true;
        }
        else if (linea.StartsWith("decimal"))
        { 
            linea = linea.Remove(0, 7);
            variableEncontrada = true;
        }
        else if (linea.StartsWith("string"))
        { 
            linea = linea.Remove(0, 6);
            variableEncontrada = true;
        }
        else if (linea.StartsWith("char") || linea.StartsWith("byte")
            || linea.StartsWith("long") || linea.StartsWith("bool"))
        { 
            linea = linea.Remove(0, 4);
            variableEncontrada = true;
        }

        if (variableEncontrada)
        {
            linea = linea.Insert(0, "let");
            if (linea.StartsWith("let[]"))
            {
                linea = linea.Remove(3, 2); 
            }
        }

        return linea;
    }
    
    private static string SustituirCW(string linea)
    {
        if (linea.Trim().StartsWith("Console.WriteLine"))
            linea = Sustituir(linea, 0, 17, "console.log");
        return linea;
    }

    private static string Sustituir(string linea, int inicio, int fin, string texto)
    {
        linea = linea.Remove(inicio, fin);
        return linea.Insert(0, texto);        
    }

    private static void GuardarDatosEnFichero(List<string> datos, string nombreFicheroJS)
    {
        try
        {
            StreamWriter sw = new StreamWriter(nombreFicheroJS);
            for (int i = 0; i < datos.Count; i++)
                sw.WriteLine(datos[i]);

            sw.Close();
            Console.WriteLine();
            Console.WriteLine("Fichero creado correctamente");
        }
        catch (PathTooLongException pe)
        {
            Console.WriteLine("Error: " + pe.Message);
        }
        catch (IOException ioe)
        {
            Console.WriteLine("Error de escritura: " + ioe.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }

    private static string ConvertirNombreFichero(string nombreFichero)
    {
        return nombreFichero.Substring(0, nombreFichero.Length - 3) + ".js";
    }

    private static List<string> ExtraerDatosFichero(string nombreFichero)
    {
        List<string> datos = new List<string>();
        if (File.Exists(nombreFichero))
        {            
            try
            {
                StreamReader sr = new StreamReader(nombreFichero);
                string linea;
                do
                {
                    linea = sr.ReadLine();
                    if (linea != null)
                        datos.Add(linea);
                }
                while (linea != null);
                sr.Close();
            }
            catch (PathTooLongException pe)
            {
                Console.WriteLine("Error: " + pe.Message);
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Error de lectura: " + ioe.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        else
            Console.WriteLine("El fichero no existe");

        return datos;
    }
}
