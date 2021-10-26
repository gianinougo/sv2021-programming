/*
Reto 1.01: Hola mundo (AceptaElReto.com, 116)

Entrada de ejemplo
3

Salida de ejemplo
Hola mundo.
Hola mundo.
Hola mundo.
*/

import java.util.*;

public class HolaMundo{
    public static void main(String[] args){
        Scanner entrada = new Scanner(System.in);
        int n = entrada.nextInt();
        
        for(int i = 1; i <= n; i++)
            System.out.println("Hola mundo.");
    }
}
