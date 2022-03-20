// Ejercicio recomendado 184
// Javier (...)

using System;
using System.IO;
using System.Collections.Generic;

class ConversorCsharpPython
{
    public static void Main()
    {
        Console.WriteLine("Introduce el nombre del fichero C# a convertir:");
        string nombreFichero = Console.ReadLine();

        try
        {
            string[] datos = File.ReadAllLines(nombreFichero);
            List<string> lineas = new List<string>(datos);
            bool necesitaTabular = false;

            for (int i = 0; i < lineas.Count; i++)
            {
                lineas[i] = lineas[i].Trim();

                if (ContieneTextoSobrante(lineas[i]))
                {
                    lineas.RemoveAt(i);
                    i--;
                }
                else
                {                    
                    if (lineas[i].Contains(";"))
                        lineas[i] = EliminarPuntoComa(lineas[i]);

                    if (lineas[i].Contains("Write"))
                    {
                        lineas[i] = ConvertirWrite(lineas[i]);
                        if (necesitaTabular)
                        {
                            lineas[i] = lineas[i].Insert(0, "\t");
                            necesitaTabular = false;
                        }
                    }

                    if (lineas[i].Contains("Convert.ToInt32"))
                    {
                        lineas[i] = ConvertirConvertIn32(lineas[i]);
                        if (necesitaTabular)
                        {
                            lineas[i].Insert(0, "tabulacion");
                            necesitaTabular = false;
                        }
                    }

                    if (lineas[i].Contains("ReadLine"))
                    {
                        lineas[i] = ConvertirReadLine(lineas[i]);
                        if (necesitaTabular)
                        {
                            lineas[i].Insert(0, "\t");
                            necesitaTabular = false;
                        }
                    }

                    if (lineas[i].StartsWith("if"))
                    {
                        lineas[i] = ConvertirIf(lineas[i]);
                        necesitaTabular = true;
                    }

                    if (lineas[i].StartsWith("else"))
                    {
                        lineas[i] = AnyadirDosPuntos(lineas[i]);
                        necesitaTabular = true;
                    }

                    if (lineas[i].StartsWith("for"))
                    {
                        lineas[i] = ConvertirFor(lineas[i]);
                        necesitaTabular = true;
                    }
                }
            }

            nombreFichero = nombreFichero.Replace(".cs", ".py");
            File.WriteAllLines(nombreFichero, lineas.ToArray());
            Console.WriteLine("Conversión a Python finalizada");
        }
        catch (PathTooLongException pe)
        {
            Console.WriteLine("Error: " + pe.Message);
        }
        catch (FileNotFoundException fe)
        {
            Console.WriteLine("Error: " + fe.Message);
        }
        catch (IOException ioe)
        {
            Console.WriteLine("Error: " + ioe.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }

    private static string ConvertirFor(string texto)
    {
        texto = EliminarParentesis(texto);
        string textoDentroFor = texto.Substring(3);
        textoDentroFor = EliminarEspacios(textoDentroFor);

        int posicion = textoDentroFor.IndexOf('=');
        char letraVariable = textoDentroFor[posicion - 1];
        char numInicial = textoDentroFor[posicion + 1];
        posicion = textoDentroFor.IndexOf('<') + 1;
        char numFinal = textoDentroFor[posicion];

        textoDentroFor = letraVariable + " in range (" + numInicial + "," +
            numFinal + "):";
        texto = texto.Substring(0, 3)+ " " + textoDentroFor;

        return texto;
    }

    private static string EliminarEspacios(string textoDentroFor)
    {
        while (textoDentroFor.Contains(" "))
            textoDentroFor = textoDentroFor.Replace(" ", "");
        return textoDentroFor;
    }

    private static string AnyadirDosPuntos(string texto)
    {
        return texto + ":";
    }

    private static string ConvertirIf(string texto)
    {
        texto = EliminarParentesis(texto);
        texto = AnyadirDosPuntos(texto);
        return texto;
    }

    private static string EliminarParentesis(string texto)
    {
        texto = texto.Replace("(", "");
        texto = texto.Replace(")", "");
        return texto;
    }

    private static string ConvertirReadLine(string texto)
    {
        return texto.Replace("Console.ReadLine", "input");
    }

    private static string ConvertirConvertIn32(string texto)
    {
        return texto.Replace("Convert.ToInt32", "int");
    }

    private static string ConvertirWrite(string texto)
    {
        if (texto.Contains("WriteLine"))
            texto = texto.Replace("Console.WriteLine", "print");
        else
            texto = texto.Replace("Console.Write", "print");

        if (texto.Contains("\","))
        {
            texto = texto.Replace("\",", "\".format(");
            texto += ")";
        }

        return texto;
    }

    private static string EliminarPuntoComa(string texto)
    {
        return texto.Replace(";", "");
    }

    private static bool ContieneTextoSobrante(string texto)
    {
        if (texto.Contains("using") || texto.Contains("class")
            || texto.Contains("Main") || texto == "{" ||
            texto == "}" || texto.StartsWith("int") || texto == "")
        {
            return true;
        }
        else
            return false;
    }
}
