// Tema 2 Semana 4 recomendado 37 
// Ezequiel (...)

/*Pide al usuario el número de un mes y el número de un día, y muestre de qué
 número de día dentro del año se trata, en un año no bisiesto.*/

using System;
class T2s4r37
{
    static void Main()
    {
        int mes, totalDias;
    
        Console.Write("Dime un mes (1-12) ");
        mes = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Dime un número de dia (1-31) ");
        totalDias = Convert.ToInt32(Console.ReadLine());       
       
        for(int i = 1;i < mes;i++)
        {
            if(i==4||i==6||i==9||i==11) totalDias += 30;
            if(i==1||i==3||i==5||i==7||i==8||i==10||i==12) totalDias += 31;
            if(i== 2) totalDias +=28;
            
            /*switch (i)
            {
                case 1: goto case 12;
                case 2: { totalDias +=28; break; }
                case 3: goto case 12;
                case 4: goto case 11;
                case 5: goto case 12;
                case 6: goto case 11;
                case 7: goto case 12;
                case 8: goto case 12;
                case 9: goto case 11;
                case 10: goto case 12;
                case 11:{ totalDias += 30; break; }
                case 12:{ totalDias += 31; break; }
            }*/
    
        }
       
        Console.WriteLine(totalDias);
    }
}

