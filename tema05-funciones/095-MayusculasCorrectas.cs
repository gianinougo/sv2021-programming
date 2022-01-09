// Ejercicio recomendado 95
// Javier (...)

/*
Crea una función llamada "MayusculasCorrectas", que recibirá una cadena como 
parámetro y la devolverá en minúsculas excepto por la primera letra y las que 
están precedidas por un punto (y quizá algún espacio en blanco). Por ejemplo, 
para el texto "hOLa.que . tal" debería devolver "Hola.Que . Tal".
*/

using System;

class RevisarTexto
{
    static void Main()
    {
        Console.WriteLine("Introduce un texto:");
        string texto = Console.ReadLine();

        string textoEditado = MayusculasCorrectas(texto);
        Console.WriteLine(textoEditado);
    }

    static string MayusculasCorrectas(string texto)
    {
        string textoEditado;
        texto = texto.Trim();
        string mays = texto.ToUpper();
        string mins = texto.ToLower();

        textoEditado = mays[0] + mins.Substring(1);

        int pos=1;

        while (pos > 0 && pos < textoEditado.Length-1)
        {
            pos = textoEditado.IndexOf(".", pos);

            if (pos > 0 && pos < textoEditado.Length-1)
            {
                do
                {
                    pos++;
                }
                while (textoEditado[pos] == ' ');

                textoEditado = textoEditado.Substring(0, pos);
                textoEditado += mays[pos];
                textoEditado += mins.Substring(pos + 1);
            }
        }

        return textoEditado;
    }
}
