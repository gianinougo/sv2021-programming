/* Carlos (...)
 * 
 * Programa que calcula la longitud de la circunferencia 
 * a partir del radio introducido
 * 
 * Debe usar {0} en vez de "Write". No se puede utilizar "using System;".
 * 
 * Debe contener un único comentario de múltiples líneas, que detalle
 * tu nombre y el cometido del programa
 */
 
public class Ejercicio_7
{
    public static void Main ()
    {
        int radio;
        System.Console.Write("Escribe el radio de tu circunferencia: ");
        radio = System.Convert.ToInt32( System.Console.ReadLine() );
        System.Console.WriteLine(
            "La longitud de tu circunferencia de radio {0} m es: {1} metros.",
            radio,  2 * 3.1416 * radio );
    }
}
