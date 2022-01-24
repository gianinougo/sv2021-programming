/*
VIRGINIA (...)
Siguiente ronda

"El concursante que obtenga una puntuación igual o superior al puntuación del 
k-ésimo puesto avanzará a la siguiente ronda, siempre y cuando obtenga una 
puntuación positiva ..."" - es un extracto de las reglas de un concurso.

Un total de n participantes participan en el concurso (n ≥ k), y ya se conocen 
sus puntuaciones. Se debe calcular cuántos participantes avanzarán a la 
siguiente ronda.

Entrada

La primera línea de la entrada contiene dos enteros n y k (1 ≤ k ≤ n ≤ 50) 
separados por un solo espacio.

La segunda línea contiene n enteros separados por espacios a1, a2, ..., an 
(0 ≤ ai ≤ 100), donde ai es la puntuación obtenida por el participante del 
lugar i-ésimo. La secuencia dada no es creciente (es decir, para todo i de 1 
a n - 1 se cumple la siguiente condición: ai ≥ ai + 1).

Salida

Se debe mostrar la cantidad de participantes que avanzan a la siguiente ronda.

Ejemplos

entrada 1

8 5
10 9 8 7 7 7 5 5
salida 1

6
entrada 2

4 2
0 0 0 0
salida 2
0

-----------------

Datos de prueba adicionales

entrada 3
10 5
10 9 8 7 7 7 7 7 5 5
salida 3
8

entrada 4
8 5
10 9 0 0 0 0 0 0
salida 1
2
* 
*/

using System;

class Reto4_01
{
    static void Main()
    {
        string entrada = Console.ReadLine();
        int participantes = Convert.ToInt32(entrada.Split()[0]);
        int participanteK = Convert.ToInt32(entrada.Split()[1]);

        entrada = Console.ReadLine();
        int[] puntuaciones = new int[participantes];

        for (int i=0; i<participantes; i++)
        {
            puntuaciones[i] = Convert.ToInt32(entrada.Split()[i]);         
        }

        int clasificados = 0;

        for (int i=0; i<participantes; i++)
        {
            if (puntuaciones[i] >= puntuaciones[participanteK] &&
                puntuaciones[i] >= 5)
                clasificados++;
        }

        Console.WriteLine(clasificados);
    }
}
