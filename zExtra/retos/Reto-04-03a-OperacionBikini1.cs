// Reto 4.03
// Javier (...)

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

class OperacionBikini
{

    static int[] RecogerDatos()
    {
        string dentradaDatos = Console.ReadLine();
        string[] datosTexto = dentradaDatos.Split();
        int[] datos = new int[2];

        for (int i = 0; i < 2; i++)
            datos[i] = Convert.ToInt32(datosTexto[i]);

        return datos;
    }

    static void OrdenarDatos(int[][] datos)
    {
        for (int i=0; i<datos.Length - 1; i++)
        {
            for (int j=i+1; j<datos.Length; j++)
            {
                if ((datos[i][0] < datos[j][0]) ||
                    (datos[i][0] == datos[j][0] &&
                    datos[i][1] > datos[j][1]))
                {
                    int[] aux = datos[i];
                    datos[i] = datos[j];
                    datos[j]= aux;
                }
            }
        }
    }

    static void Main()
    {
        int p = Convert.ToInt32(Console.ReadLine());
        int[][] datos = new int[p][];

        for (int i=0; i<p; i++)
        {            
            datos[i] = RecogerDatos();            
        }
        OrdenarDatos(datos);

        Console.WriteLine();
        foreach(int[] d1 in datos)
        {
            foreach (int d2 in d1)
                Console.Write(d2 + " ");

            Console.WriteLine();
        }
    }
}
