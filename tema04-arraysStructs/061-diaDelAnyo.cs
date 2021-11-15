// Ejercicio recomendado 61
// Javier (...)
// Solicita un día y un mes y muestra su equivalencia en el año

using System;

class DiadelAnyo
{
    static void Main()
    {
        int[] meses = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        string[] mesesCadena = {"Enero", "Febrero", "Marzo", "Abril", "Mayo",
            "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre",
            "Diciembre"};
        int diaDelAnyo, diaDelMes, mes;

        Console.Write("Introduce el mes: ");
        mes = Convert.ToInt32(Console.ReadLine());
        Console.Write("Introduce el día: ");
        diaDelMes = Convert.ToInt32(Console.ReadLine());
        diaDelAnyo = diaDelMes;
        
        for (int i=0; i<mes-1; i++)
        {
            diaDelAnyo += meses[i];
        }
        Console.Write("El {0} de {1} es el día {2} del año", 
            diaDelMes, mesesCadena[mes-1], diaDelAnyo);
    }
}
