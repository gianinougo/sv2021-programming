// Reto 1.02 - Contando en la arena (acepta 369)

/*
Contar en base 1

Ejemplo de entrada
1
4
6
0

Salida para esa entrada
1
1111
111111
*/


import java.util.*;

public class Base1
{
    public static void main(String[] args)
    {
        int n;
        
        Scanner entrada = new Scanner(System.in);
        
        do
        {
            n = entrada.nextInt();

            if (n != 0)
            {
                for(int i = 0; i < n; i++)
                    System.out.print(1);
                System.out.println();
            }
        } while(n != 0);
    }
}
