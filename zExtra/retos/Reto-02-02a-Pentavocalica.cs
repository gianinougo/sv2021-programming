﻿// Reto 2.02
// Javier (...)

/*
Palabras pentavocálicas (Acepta el reto 300)

Los estudiosos de la lengua no se ponen de acuerdo en cuáles son las palabras 
pentavocálicas, también conocidas como panvocálicas. Todos coinciden en que son 
palabras que contienen las cinco vocales (el prefijo penta-, de origen griego, 
significa cinco; y el prefijo pan-, también de origen griego, significa todos). 
Por ejemplo: "cuestionar", "secundario" o "hipotenusa".

Sin embargo, hay controversia en los detalles. Algunos añaden la condición de 
que las vocales no se pueden repetir, por lo que excluirían, por ejemplo, 
"aceitunero" por contener dos veces la vocal e. Otros añaden una condición 
fonética por la cual las cinco vocales deben sonar al pronunciar la palabra, 
por lo que excluirían, por ejemplo, "arquitecto", porque le falta el sonido de 
la vocal u. Nosotros somos más flexibles y admitimos como pentavocálicas todas 
aquellas palabras que simplemente contienen las cinco vocales.

Hay muchísimas palabras pentavocálicas en español; hay quien ha recopilado más 
de 42.000. Curiosamente, no existen palabras con las vocales en el orden aeiou, 
salvo que admitamos repeticiones, como en "cuadragesimoquinta". En orden 
inverso sí hay unas cuantas, como por ejemplo, "sudorienta".

Entrada

La entrada comienza con un número que indica la cantidad de casos de prueba que 
vienen a continuación. Cada caso consiste en una palabra de no más de 30 letras 
de la a a la z (todas minúsculas, sin tilde y excluida la letra ñ).

Salida

Para cada caso de prueba, el programa escribirá SI si la palabra es 
pentavocálica y NO en caso contrario.

Entrada de ejemplo
4
albaricoque
seculariza
peliagudo
abracadabra

Salida de ejemplo
SI
NO
SI
NO
*/

using System;

class Pentavocalicas
{
    static void Main()
    {
        int casos = Convert.ToInt32(Console.ReadLine());
        
        for (int i=0; i<casos; i++)
        {
            string palabra = Console.ReadLine();
        
            if (EsPanvocalica(palabra))
                Console.WriteLine("SI");
            else
                Console.WriteLine("NO");
        }
    }

    static bool EsPanvocalica(string palabra)
    {
        bool esPanVocal = false;

        if (palabra.Contains("a") && palabra.Contains("e") &&
            palabra.Contains("i") && palabra.Contains("o") &&
            palabra.Contains("u"))
            esPanVocal = true;        

        return esPanVocal;
    }
}
