//Author: Franco (...)
/*
81. Crea una función llamada "DibujarRectanguloHueco", que 
mostrará un rectángulo hueco con el ancho, el alto y el 
carácter que se indiquen como parámetros. Añade un 
"Main" de prueba.
*/

using System;

class FuncionDibujarRectanguloHueco {

    static void DibujarRectanguloHueco(int ancho, int alto, char simbolo) 
    {
        string lineaTopes = new string(simbolo, ancho);
        string lineaCentral = simbolo + new string(' ', ancho-2) + simbolo;

        Console.WriteLine(lineaTopes);
        for (int i=0; i < alto-2; i++) 
            Console.WriteLine(lineaCentral);
        Console.WriteLine(lineaTopes);
    }

    static void Main() 
    {

        int ancho, alto;
        char simbolo;

        Console.Write("Ancho: ");
        ancho = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Alto: ");
        alto = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Simbolo: ");
        simbolo = Convert.ToChar(Console.ReadLine());

        DibujarRectanguloHueco(ancho, alto, simbolo);

    }
}
