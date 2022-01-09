//JOSE (...)
/* 94. Crea una función "MostrarRecuadroRedondeado", que mostrará un (supuesto) 
 * recuadro redondeado con una cierta anchura y altura, como en este ejemplo:

MostrarRecuadroRedondeado(8,3);
/------\
|      |
\------/
 */
using System;
class Ejer_05_94
{
    static void Main()
    {
        MostrarRecuadroRedondeado(8, 3);
    }

    static void MostrarRecuadroRedondeado(int ancho, int alto)
    {
        string primeraYUltima = new String('-', ancho - 2);
        string relleno = new String(' ', ancho-2);

        Console.WriteLine("/"+primeraYUltima+"\\");
        for (int i = 0; i < alto-2; i++)
        {
            Console.WriteLine("|"+relleno+"|");
        }
        Console.WriteLine("\\"+primeraYUltima+"/");
    }
}
