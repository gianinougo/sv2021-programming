//Author: Franco (...)
/*
78. Crea una función llamada "MediaDeArray", que devolverá la media 
de los elementos de un array de reales de simple precisión que 
se pasará como parámetro. Si el array está vacío, devolverá 0. 
Pruébala con un array prefijado. La función deberá aparecer 
antes de "Main".
*/

using System;

class FuncionMediaDeArray 
{

    static float MediaDeArray(float[] datos)
    {
        float media=0;
        if (datos.Length != 0) 
        {
            for (int i=0; i < datos.Length; i++)
                media += datos[i];
            media /= datos.Length;
        }
        return media;
    }

    static void Main() 
    {
        float[] datos = {2.5f, 5.0f, 7.5f};
        float[] datosVacio = {};
        float media;
        float mediaCero;

        media = MediaDeArray(datos);
        mediaCero = MediaDeArray(datosVacio);

        Console.WriteLine("{0}", media);
        Console.WriteLine("{0}", mediaCero);
    }
}
