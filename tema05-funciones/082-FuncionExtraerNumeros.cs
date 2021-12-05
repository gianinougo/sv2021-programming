/* Juan Manuel (...) */

/* Ejercicio82.Crea una función llamada "ExtraerNumeros", que reciba
 * una cadena formada por números enteros y espacios, como "23 45 67 89 " y
 * devuelva un array con enteros largos, los que aparezcan como parte de esa
 * cadena, que en este caso serían {23, 45, 67, 89}. Ten en cuenta que la
 * cadena inicial puede contener espacios iniciales, finales o redundantes,
 * que deberás filtrar.*/


using System;


class Ejercicio82
{

    static long[] ExtraerNumeros(string cadenaNumeros)
    {
        //Console.WriteLine("|" + cadenaNumeros + "|");
        cadenaNumeros = cadenaNumeros.Trim();
        do
        {
            cadenaNumeros = cadenaNumeros.Replace("  ", " ");
        }
        while (cadenaNumeros.Contains("  "));

        string[] separado = cadenaNumeros.Split(' ');
        long[] arrayAux = new long[separado.Length];

        for (int i = 0; i < separado.Length; i++)
        {
            arrayAux[i] = Convert.ToInt64(separado[i]);
            //Console.WriteLine("|" + Convert.ToString(arrayAux[i]) + "|");
        }
        return (arrayAux);
    }
    
    static void Main()
    {
        long[] resultado = ExtraerNumeros("   23  45  67   89  28   152   ");
        foreach(long n in resultado)
            Console.Write(n + " ");
    }
}

