// JOSE (...)
/* 165. Puedes volcar el contenido de un array de strings a un fichero de texto 
 * con "File.WriteAllLines("nombre.ext", miArray);" y, el de una lista con 
 * "File.WriteAllLines("nombre.ext", miLista.ToArray());". Utiliza esa 
 * estructura, junto con File.ReadAllLines, para crear un programa que lea un 
 * fichero "datos.txt" a una lista, ordene las líneas alfabéticamente, elimine 
 * las líneas duplicadas y finalmente vuelque el resultado a un fichero llamado 
 * "datos2.txt".
 */
using System.Collections.Generic;
using System.IO;


class Ejercicio165
{
    static void Main()
    {
        string[] frases = File.ReadAllLines("datos.txt");
        List<string> listaFrases = new List<string>(frases);

        listaFrases.Sort();

        for (int i = 0; i < listaFrases.Count-1; i++) // Hasta penúltima
        {
            if (listaFrases[i] == listaFrases[i+1])
            {
                listaFrases.RemoveAt(i);
                i--;  // Y probamos la misma, por si se repite varias veces
            }
        }

        File.WriteAllLines("datos2.txt", listaFrases.ToArray());
    }
}

