/*
 * VIRGINIA (...)
 * 
 * 62. Crea un array de números reales de simple precisión, con espacio para 
 * TAMANYO datos. Pide al usuario esos TAMANYO datos y luego muestra un menú que le 
 * permita: Ver todos los datos en el orden en que se habían introducido, 
 * calcular y mostrar el máximo de los datos, calcular y mostrar el mínimo 
 * de los datos, ver si aparece un cierto dato, salir. La opción de Buscar 
 * preguntará el dato que se quiere localizar y responderá si era parte de 
 * los TAMANYO datos iniciales o no lo era.
 */

using System;

class Ejercicio62
{
    static void Main()
    {
        const int TAMANYO = 10;
        float[] datos = new float[TAMANYO];
        float maximo, minimo, datoBuscar;
        bool salir = false, encontrado = false;
        byte opcion;

        for (int i = 0; i < TAMANYO; i++)
        {
            Console.Write("Dato {0}: ", i + 1);
            datos[i] = Convert.ToSingle(Console.ReadLine());
        }

        while (! salir)
        {
            Console.WriteLine();
            Console.WriteLine("1. Ver todos los datos.");
            Console.WriteLine("2. Calcular el máximo.");
            Console.WriteLine("3. Calcular el mínimo.");
            Console.WriteLine("4. Buscar dato.");
            Console.WriteLine("5. Salir.");
            Console.WriteLine();

            Console.Write("Introduce una opción: ");
            opcion = Convert.ToByte(Console.ReadLine());

            switch(opcion)
            {
                case 1:
                    foreach (int dato in datos)
                    {
                        Console.WriteLine(dato);
                    }
                    break;
                    
                case 2:
                    maximo = datos[0];
                    for (int i=1; i<TAMANYO; i++)
                    {
                        if(maximo < datos[i])
                        {
                            maximo = datos[i];
                        }
                    }
                    Console.WriteLine("Máximo = {0}", maximo);
                    break;
                    
                case 3:
                    minimo = datos[0];
                    for (int i = 0; i < TAMANYO; i++)
                    {
                        if (minimo > datos[i])
                        {
                            minimo = datos[i];
                        }
                    }
                    Console.WriteLine("Mínimo = {0}", minimo);
                    break;
                
                case 4:
                    encontrado = false;
                    Console.Write("Dime un dato: ");
                    datoBuscar = Convert.ToSingle(Console.ReadLine());

                    for(int i=0; i<TAMANYO; i++)
                    {
                        if (datoBuscar == datos[i])
                        {
                            encontrado = true;
                        }
                    }
                    if (encontrado == true)
                    {
                        Console.WriteLine("Se ha encontrado el dato.");
                    }
                    else
                    {
                        Console.WriteLine("No se ha encontrado el dato.");
                    }
                    break;

                case 5:
                    Console.WriteLine("Hasta pronto!");
                    salir = true;
                    break;
            }
        }     
    }
}
