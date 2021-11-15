//Author: Franco (...)
/*
    60. Pide al usuario 10 enteros cortos sin signo y guárdalos en un array. 
    Luego pide uno más y dile si estaba entre esos 10 datos iniciales, de 2 
    formas distintas: primero usando un booleano y luego usando un contador, 
    para, en la segunda ocasión, responderle cuántas veces aparecía (ambas 
    respuestas serán parte del mismo programa, no dos programas independientes).
*/

using System;

class BuscarDatoArray {
    static void Main() {

        const int CANTIDAD = 10;
        int datoABuscar;
        ushort[] enteros = new ushort[CANTIDAD];

        //Solicitar datos al usuario
        for (int i = 0; i < CANTIDAD; i++) {
            Console.Write("Dato {0}: ", i+1);
            enteros[i] = Convert.ToUInt16(Console.ReadLine());
        }

        Console.WriteLine();      
        Console.Write("Introduce el entero a buscar: ");
        datoABuscar = Convert.ToInt32(Console.ReadLine());

        // Búsqueda con booleano
        bool encontrado = false;
        for (int i = 0; i < CANTIDAD; i++) {
            if (datoABuscar == enteros[i]) {
                encontrado = true;
            }
        }

        if (encontrado == true) {
            Console.WriteLine("Encontrado");
        }
        
        // Búsqueda con contador
        int apariciones = 0;
        for (int i = 0; i < CANTIDAD; i++) {
            if (datoABuscar == enteros[i]) {
                apariciones += 1;
            }
        }

        Console.WriteLine("Apariciones: {0}", apariciones);
    }
}
