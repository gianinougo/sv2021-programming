//Author: Franco (...=
/*
    53. Escribe un programa que pida un ancho y un carácter, y muestre un 
    triángulo creciente alineado a la derecha, como éste:

    Introduzca el ancho deseado: 5
    Introduzca el carácter: *
        *
       **
      ***
     ****
    *****
*/

using System;

class TrianguloCrecienteDerecha {
    static void Main() {

        byte ancho;
        char caracter;

        Console.Write("Introduzca el ancho deseado: ");
        ancho = Convert.ToByte(Console.ReadLine());

        Console.Write("Introduzca el carácter: ");
        caracter = Convert.ToChar(Console.ReadLine());

        for (int i = 0; i < ancho; i++) { //Numero filas

            for (int k = ancho-1; k > i; k--) { //Espacios a izquierda
                Console.Write(" ");
            }

            for(int j = 0; j <= i; j++) { //Caracteres
                Console.Write(caracter);
            }

            Console.WriteLine(); //Salto de linea
        }

    }
}
