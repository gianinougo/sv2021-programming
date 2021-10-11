// Crea una versión mejorada del ejercicio de la contraseña numérica, en la que el 
// usuario sólo tenga 3 intentos. Si al cabo de 3 intentos no ha indicado el 
// usuario y la contraseña correctos, se le responderá con "Acceso denegado" y 
// terminará el programa. Si introduce ambos datos de forma correcta en 3 intentos 
// o menos, se le dirá "Acceso concedido" y terminará el programa. Esta versión 
// hazla sólo una vez, empleando "while" o "do-while", como consideres más 
// razonable.

// Rocio (...)

using System;
class ContrasenyaaTresIntentos24
{
    static void Main()
    {
        int clave;
        int ok = 1111;
        int intento = 0;

        do
        {
            Console.WriteLine("introduce constraseña");
            clave = Convert.ToInt32(Console.ReadLine());
            intento++;
            if ((clave != ok) && (intento < 3))
            {
                Console.WriteLine("Clave incorrecta vuelva a intentarlo");
            }
        }
        while ((clave != ok) && (intento < 3));
        
        if (clave != ok)
        {
            Console.WriteLine("Acceso denegado");
        }
        else
        {
            Console.WriteLine("Acceso concedido");
        }
    }
}
