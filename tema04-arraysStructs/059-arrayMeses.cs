// Joaquin (...)

/*
59. Crea un array que contenga los nombres de los meses, prefijando sus datos 
entre llaves. Muestra todos los meses en pantalla, desde el primero (enero) 
hasta el último (diciembre), en una misma línea y separados por espacios. En la 
siguiente línea, muéstralos en orden inverso (de diciembre a enero). 
Finalmente, pide al usuario un número de mes (por ejemplo, el 3) y muestra su 
nombre (el 3 sería marzo).
*/

using System;

class mesesAnyo
{ 
    static void Main()
    {
        string [] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", 
            "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", 
            "Diciembre" };

        // Del primero al último
        for ( int i = 0 ; i < meses.Length ; i++ )
        {
            Console.Write("{0} ", meses[i]);
        }
        Console.WriteLine();
        
        // En orden inverso
        for (int i = meses.Length - 1 ; i >= 0 ; i-- )
        {
            Console.Write("{0} ", meses[i]);
        }
        Console.WriteLine();
        
        // Elegido por el usuario
        Console.WriteLine("Introduce el numero de mes: ");
        byte mes = Convert.ToByte( Console.ReadLine() );
        Console.WriteLine("Ese mes se llama {0}", meses[mes-1]);
    }
}
