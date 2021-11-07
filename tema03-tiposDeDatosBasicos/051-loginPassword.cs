/* Juan Manuel (...) */

/*Ejercicio51.Realiza una nueva versión del programa de la contraseña
 *de acceso con 3 intentos, pero esta vez pidiendo un login (que será
 *una cadena de texto) y también una clave (otra cadena de texto).*/

using System;

class Ejercicio51
{
    static void Main()
    {

        string login, clave;
        bool accesoPermitido = false;
        const string claveAcceso = "The Boss";
        const string loginAcceso = "El Jefe";
        int intentos = 0;
        
        do
        {
            intentos++;
            Console.Write("Deme su login :");
            login = Console.ReadLine();

            Console.Write("Deme su clave se acceso :");
            clave = Console.ReadLine();
            if (login == loginAcceso && clave == claveAcceso)
            {
                accesoPermitido = true;
            }
        }
        while (intentos < 3 && ! accesoPermitido);

        if (accesoPermitido)
        {
            Console.WriteLine("Acceso concedido.");
        }
        else
        {
            Console.WriteLine("Acceso denegado.");
        }
    }
}
