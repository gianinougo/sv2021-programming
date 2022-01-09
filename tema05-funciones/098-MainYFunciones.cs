/*
 * VIRGINIA (...)
 * 98. Crea una función "Main" para probar las últimas 4 funciones. Debe 
 * analizar los parámetros de la línea de comandos (que pueden estar en 
 * mayúsculas, minúsculas o en mayúsculas y minúsculas mezcladas) y debe 
 * comportarse de la siguiente manera:
 * 
 * Si el primer parámetro es "rec", seguido de dos números (rec 8 3), mostrará
 * un recuadro redondeado con ese ancho y ese alto.
 * Si el primer parámetro es "md", seguido de un número (md 34512), mostrará 
 * el mayor dígito de ese número.
 * Si el primer parámetro es "ld", seguido de un texto (mm Hola3), mostrará la 
 * cantidad de letras y dígitos de este texto.
 * Si el primer parámetro es "mc", seguido de una o varias palabras (mc hola. 
 * que tal), mostrará las palabras con mayúsculas correctas ("Hola. Que tal").
 * Si no se usan parámetros, o si se especifica un primer parámetro incorrecto,
 * mostrará "Uso: rec / md / mm / mc" y regresará al sistema operativo con el 
 * código de error 1. Por otra parte, si se usan menos parámetros de los 
 * esperados (es decir, : "md" y ningún número, "rec" y menos de dos números, 
 * y así sucesivamente), mostrará "Faltan parámetros" y regresará al sistema 
 * operativo con el código de error 2. Si todo es correcto, regresará al 
 * sistema operativo con código de error 0.
 */

using System;

class Ejercicio98
{
    static int Main(string[] args)
    {
        if (args[0].ToLower() == "rec")
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Faltan parámetros");
                return 2;
            }
            else
            {
                MostrarRecuadroRedondeado(Convert.ToInt32(args[1]), 
                                          Convert.ToInt32(args[2]));
                return 0;
            }
        }
        else if (args[0].ToLower() == "md")
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Faltan parámetros");
                return 2;
            }
            else
            {
                Console.WriteLine("Mayor dígito: " + ObtenerMayorDigitoR(
                    Convert.ToInt64(args[1])).ToString());
                return 0;
            }
        }
        else if (args[0].ToLower() == "ld")
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Faltan parámetros");
                return 2;
            }
            else
            {               
                ContarLd(args[1], out int letras, out int digitos);
                Console.WriteLine("Letras: " + letras.ToString());
                Console.WriteLine("Dígitos: " + digitos.ToString());
                return 0;
            }
        }
        else if (args[0].ToLower() == "mc")
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Faltan parámetros");
                return 2;
            }
            else
            {
                Console.WriteLine(MayusculasCorrectas(args[1]));
                return 0;
            }
        }
        else
        {
            Console.WriteLine("Uso: rec / md / mm / mc");
            return 1;
        }
    }
    static void MostrarRecuadroRedondeado(int anchura, int altura)
    {
        for (int alto = 0; alto < altura; alto++)
        {
            if (alto == 0)
            {
                Console.Write("/");
                for (int i = 1; i < anchura - 1; i++)
                {
                    Console.Write("-");
                }
                Console.Write("\\");
            }
            else if (alto == altura - 1)
            {
                Console.Write("\\");
                for (int i = 1; i < anchura - 1; i++)
                {
                    Console.Write("-");
                }
                Console.Write("/");
            }
            else
            {
                Console.Write("|");
                for (int i = 1; i < anchura - 1; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("|");
            }
            Console.WriteLine();
        }
    }

    static string MayusculasCorrectas(string cadena)
    {
        string[] trozosMayus = cadena.ToUpper().Split();
        string[] trozosMinus = cadena.ToLower().Split();
        string cadenaTemporal = "";

        for (int i = 0; i < trozosMayus.Length; i++)
        {
            cadenaTemporal += trozosMayus[i][0] +
                trozosMinus[i].Substring(1) + " ";
        }

        trozosMayus = cadenaTemporal.ToUpper().Split('.');
        string[] trozos = cadenaTemporal.Split('.');
        string cadenaFinal = "";

        for (int i = 0; i < trozosMayus.Length; i++)
        {
            cadenaFinal += trozosMayus[i][0] +
                trozos[i].Substring(1) + ".";
        }

        return cadenaFinal;
    }

    static byte ObtenerMayorDigitoR(long numero)
    {
        if (numero == 0)
        {
            return 0;
        }
        else if (numero % 10 > ObtenerMayorDigitoR(numero / 10))
        {
            return Convert.ToByte(numero % 10);
        }
        else
        {
            return ObtenerMayorDigitoR(numero / 10);
        }
    }

    static void ContarLd(string cadena, out int letras, out int digitos)
    {
        letras = 0;
        digitos = 0;
        foreach (char caracter in cadena)
        {
            if (caracter >= 'a' && caracter <= 'z' ||
                caracter >= 'A' && caracter <= 'Z')
            {
                letras++;
            }
            else if (caracter >= '0' && caracter <= '9')
            {
                digitos++;
            }
        }
    }
}
