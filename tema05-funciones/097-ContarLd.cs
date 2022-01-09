//Author: Franco (...)
/*
97. Crea una función "ContarLd", que permita saber 
la cantidad de letras (sólo del alfabeto inglés) y 
de dígitos que hay en la cadena que se pasa como parámetro. 
Se usaría de manera parecida a:

    ContarLd("Este es 1 Texto", letras, digitos);
    Console.WriteLine ("Letras: " + letras + ", dígitos: " + digitos);
    // Mostraría "Letras: 11, dígitos: 1"
*/

using System;

class Ejercicio97 {

    static void ContarLd (string texto, out int letras, out int digitos) {

        letras = digitos = 0;

        texto = texto.ToLower();

        for (int i=0; i < texto.Length; i++) {
            
            if (texto[i] >= 'a' && texto[i] <= 'z')
                letras++;

            if (texto[i] >= '0' && texto[i] <= '9')
                digitos++;
            
        }

    }
    

    static void Main () {

        int letras, digitos;

        ContarLd("Este es 1 Texto", out letras, out digitos);
        Console.WriteLine ("Letras: " + letras + ", dígitos: " + digitos);

    }

}
