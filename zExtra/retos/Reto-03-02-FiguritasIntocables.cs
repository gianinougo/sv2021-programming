/*
 * VIRGINIA (...)
  
Reto 3.02: Figuritas intocables
 
Nuestro amigo Maniatiquez tiene una extraña afición. Resulta que tiene un 
patio de baldosas cuadradas de N (Ancho) por M (largo) baldosas. En cada una 
de esas baldosas él puede o no poner una figura decorativa de animales. Pero 
nuestro amigo impone una serie de restricciones para poner dichas figuras. Las 
figuras no pueden estar tocando ninguno de los bordes de su patio. Además, las
figuras no pueden tener una figura en alguna baldosa contigua en cualquiera de
las 8 direcciones posibles (Vertical, horizontal y diagonal). Tampoco será 
válida una configuración que no tenga ninguna figura.

Nuestra tarea es realizar un programa que indique si una propuesta de 
colocación de figuras es válida para nuestro amigo Maniatiquez.

Entrada

En la primera línea un entero C indicando el número de casos de prueba. Cada 
caso de prueba tendrá una línea que indicará las dimensiones del patio de N 
por M.
1 <= C <= 100
3 <= N <= 15
3 <= M <= 15
En las restantes M lineas, se representará el estado del patio. Cada baldosa 
vacía se representará por una letra X. Cada figura colocada, se representará 
mediante una letra F.

Salida

Por cada juego de prueba, se escribirá VALIDA si la configuración es válida, 
o INVALIDA en caso contrario.

Ejemplo de entrada

5
4 4
XXXX
XXXX
XXXX
XXXX
3 3
XXX
XFX
XXX
3 3
XXX
FXX
XXX
4 3
XXXX
FXFX
XXXX
6 6
XXXXXX
XFXXFX
XXXXXX
XFXFXX
XXXXXX
XXXXXX

Ejemplo de salida
INVALIDA
VALIDA
INVALIDA
INVALIDA
VALIDA
*/

using System;

class Reto3_02
{
    static void Main()
    {
        byte numeroCasos = Convert.ToByte(Console.ReadLine());

        for (int caso=0; caso<numeroCasos; caso++)
        {
            string entrada = Console.ReadLine();
            string[] filasColumnas = entrada.Split();
            int numeroColumnas = Convert.ToInt32(filasColumnas[0]);
            int numeroFilas = Convert.ToInt32(filasColumnas[1]);
            string[] patio = new string[numeroFilas];
            bool valida = true;
            int cantidadFiguritas = 0;

            //Construcción del patio:
            for (int i=0; i<numeroFilas; i++)
            {
                patio[i] = Console.ReadLine();
                
                for (int j=0; j<numeroColumnas; j++)
                {                  
                    if (patio[i][j] == 'F')
                        cantidadFiguritas++;
                }
            }

            //Comprobación de su validez.
            //1-Comprobamos si el patio esta vacío:
            if (cantidadFiguritas == 0)
                valida = false;
            else
            {
                for (int i = 0; i < numeroFilas; i++)
                {
                    for (int j = 0; j < numeroColumnas; j++)
                    {
                        //2-Comprobamos si hay figuritas en los bordes:
                        if (i == 0 || i == numeroFilas - 1 ||
                            j == 0 || j == numeroColumnas - 1)
                        {
                            if (patio[i][j] == 'F')
                                valida = false;
                        }
                        //3-comprobamos si una figurita del interior tiene 
                        //figuritas en las proximidades:
                        else if (patio[i][j] == 'F')
                        {
                            if (patio[i-1][j-1] == 'F' || 
                                patio[i-1][j] == 'F' ||
                                patio[i-1][j+1] == 'F' ||
                                patio[i][j-1] == 'F' ||
                                patio[i][j+1] == 'F' ||
                                patio[i+1][j-1] == 'F' ||
                                patio[i+1][j] == 'F' ||
                                patio[i+1][j+1] == 'F')
                            {
                                valida = false;
                            }
                        }
                    }
                }
            }
            if (valida == true)
                Console.WriteLine("VALIDA");
            else
                Console.WriteLine("INVALIDA");
        }
    }
}
