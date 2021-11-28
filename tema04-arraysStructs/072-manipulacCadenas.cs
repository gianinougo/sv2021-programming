//Author: Franco (...)
/*
    72. Crea un programa que solicite al usuario una cadena y:
        - La convierta a mayúsculas (almacenando el resultado en una nueva
          cadena, que mostrará)

        - La convierta a minúsculas (almacenando el resultado en una nueva
          cadena, que mostrará)

        - Elimine la segunda letra y la tercera letra (almacenando el resultado
          en una nueva cadena, que mostrará)

        - Inserte "yo" después de la segunda letra (almacenando el resultado
          en una nueva cadena, que mostrará)

        - Reemplace todos los espacios por guiones bajos (almacenando el
          resultado en una nueva cadena, que mostrará)

        - Elimine los espacios iniciales y finales (almacenando el
          resultado en otra cadena, que mostrará)

        - Divida el texto en un array de strings, usando los espacios
          como separadores, y muestre las subcadenas resultantes, cada
          una en una línea.

        - Reemplace todos los espacios por guiones bajos, con la ayuda
          de un StringBuilder (almacenando el resultado en una nueva cadena,
          que mostrará)

*/

using System;
using System.Text;

class jugandoConCadenas {
    static void Main() {

        string cadena,
               cadenaMayus,
               cadenaMinus,
               cadenaDosTres,
               cadenaYo,
               cadena_bajo,
               cadenaSinEspacios;

        Console.Write("Introduce una cadena: ");
        cadena = Console.ReadLine();
        Console.WriteLine();

        cadenaMayus = cadena.ToUpper();
        Console.WriteLine(cadenaMayus);

        cadenaMinus = cadena.ToLower();
        Console.WriteLine(cadenaMinus);

        cadenaDosTres = cadena.Remove(1, 2);
        Console.WriteLine(cadenaDosTres);

        cadenaYo = cadena.Insert(2, "yo");
        Console.WriteLine(cadenaYo);

        cadena_bajo = cadena.Replace(" ","_");
        Console.WriteLine(cadena_bajo);

        cadenaSinEspacios = cadena.Replace(" ","");
        Console.WriteLine(cadenaSinEspacios);

        Console.WriteLine();
        string[] arrayDeCadenas = cadena.Split();
        for (int i = 0; i < arrayDeCadenas.Length; i++)
            Console.WriteLine(arrayDeCadenas[i]);
        Console.WriteLine();

        StringBuilder cadena_bajoStrBui = new StringBuilder(cadena);
        for (int i=0; i < cadena_bajoStrBui.Length; i++)
            if (cadena_bajoStrBui[i] == ' ')
                cadena_bajoStrBui[i] = '_';
        Console.WriteLine(cadena_bajoStrBui);
    }
}
