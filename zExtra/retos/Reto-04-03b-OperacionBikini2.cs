// Reto 4.03
// VIRGINIA (...)

/*
Se acerca el verano y comienzan los nervios y desesperación por mantener una 
línea adecuada. Para ello muchas personas quieren ponerse en forma y se ponen 
en manos del experto nutricionista Dr Ácula.

El Dr Ácula es un doctor muy solicitado y debe ordenar la lista de pacientes 
en función de quien tiene que atender antes. Este aconsejará a los pacientes 
según mayor urgencia tengan. Para ello los ordenará por mayor peso y en caso 
de empate lo hará según una menor altura.

Entrada

En la primera línea un entero P indicando el número de pacientes.
1 <= C <= 10000
Las siguientes P líneas indicarán de cada paciente el peso w y la altura h.
1 <= h <= 100000
1 <= w <= 100000

Salida

Se nos mostrará los pacientes ordenados de mayor a menor, en base a su peso y 
altura según la urgencia de atención.

Ejemplo de entrada
5
90 150
100 120
100 110
77 170
110 161

Ejemplo de salida
110 161
100 110
100 120
90 150
77 170
*/

using System;

class Reto4_03
{
    struct datos
    {
        public int peso;
        public int altura;
    }

    static void Main()
    {
        ushort casos = Convert.ToUInt16(Console.ReadLine());

        datos[] pacientes = new datos[casos];

        for (int i=0; i<casos; i++)
        {
            string entrada = Console.ReadLine();
            pacientes[i].peso = Convert.ToInt32(entrada.Split()[0]);
            pacientes[i].altura = Convert.ToInt32(entrada.Split()[1]); 
        }

        for (int i=0; i<casos-1; i++)
        {
            int mayor = i;

            for (int j=i+1; j<casos; j++)
            {
                if (pacientes[mayor].peso < pacientes[j].peso)
                {
                    mayor = j;
                }
                else if (pacientes[mayor].peso == pacientes[j].peso)
                {
                    if (pacientes[mayor].altura > pacientes[j].altura)
                    {
                        mayor = j;
                    }
                }
            }

            if (mayor != i)
            {
                datos temporal = pacientes[i];
                pacientes[i] = pacientes[mayor];
                pacientes[mayor] = temporal;
            }         
        }

        for (int i=0; i<casos; i++)
        {
            Console.WriteLine(pacientes[i].peso + " " + pacientes[i].altura);
        }
    }
}
