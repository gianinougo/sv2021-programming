// Jose Ismael (...)
/* Ejerc 041: Escribe un programa que pida a un usuario: edad, año nacimiento
 * estatura en cm, € ahorrados sin centimos, poblacion de su ciudad
 * y poblacion estimada del mundo */


using System;

class DatosEnteros
{
    static void Main()
    {
        Console.WriteLine ("dime tu edad");
        byte edad = Convert.ToByte(Console.ReadLine());
        
        Console.WriteLine ("dime tu año de nacimiento");
        ushort nacimiento = Convert.ToUInt16 (Console.ReadLine());
        
        Console.WriteLine ("dime tu estatura en cm");
        ushort estatura = Convert.ToUInt16(Console.ReadLine());
        
        Console.WriteLine ("dime cuantos euros has ahorrado este mes");
        int ahorro = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine ("dime la poblacion de tu ciudad");
        uint poblacionciudad = Convert.ToUInt32 (Console.ReadLine());
        
        Console.WriteLine ("dime la poblacion del mundo");
        ulong poblacionmundial = Convert.ToUInt64 (Console.ReadLine());
    }
}
