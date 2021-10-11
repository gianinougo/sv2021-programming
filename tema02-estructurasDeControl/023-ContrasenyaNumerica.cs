//JOSE (...)
/* 23. Escribe un programa en C# que pida al usuario una contraseña numérica. 
 * Se le dirá "Acceso concedido" cuando acierte la contraseña correcta, 1111. 
 * Si no la acierta, se le volverá a pedir tantas veces como sea necesario. 
 * Hazlo primero con "do-while" y luego con "while".
 */
using System;

class ejer_02_23
{
    static void Main()
    {
        int numero;
        int contrasenya = 1111;

        // Versión con do-while
        do
        {
            Console.Write("Introduce la contraseña de 4 cifras: ");
            numero = Convert.ToInt32(Console.ReadLine());
            
            if (numero != contrasenya)
            {
                Console.Write("Contraseña errónea, vuelve a intentarlo. ");
            }
        } while (numero != contrasenya);
        Console.WriteLine("Acceso concedido.");
        
        
        Console.WriteLine();
        
        // Versión con while
        Console.Write("Introduce la contraseña de 4 cifras: ");
        numero = Convert.ToInt32(Console.ReadLine());
        while (numero != contrasenya)
        {
            Console.Write("Contraseña errónea, vuelve a intentarlo. ");
            Console.Write("Introduce la contraseña de 4 cifras: ");
            numero = Convert.ToInt32(Console.ReadLine());
        }
        Console.WriteLine("Acceso concedido.");
    }
}

