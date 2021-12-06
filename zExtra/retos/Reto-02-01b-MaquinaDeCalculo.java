/* Reto 2.01: Máquina de cálculo
 * Máquina de cálculo
 * ProgramaMe Regional Online Valencia 2017-2018 - CEEDCV (Valencia)-Problema A
 * Curiosiencio está fascinado por el mundo de la informática y se ha puesto a
 * investigar sobre cómo comenzó todo. Esto le lleva a encontrar información
 * sobre una de las pioneras, Ada Lovelace.
 * Ada Lovelace, fue una matemática y escritora británica. Ada realizó
 * muchísimas aportaciones a la ciencia. Entre ellas destaca el trabajo
 * realizado sobre la "máquina analítica" de Charles Babbage,
 * una primitiva computadora mecánica.
 * Entre sus notas sobre dicha máquina se encuentra lo que se reconoce hoy como
 * el primer algoritmo destinado a ser procesado por una máquina. Por esto se
 * le considera la primera programadora de la historia.
 * Entre otros logros, dedujo y previó la capacidad de los ordenadores para ir
 * más allá de los simples cálculos de números, pensando en ello como máquinas
 * de propósito general.
 * Tras leer esta historia, Curiosiencio, que sólo conoce los ordenadores
 * actuales, trata de imaginarse cómo sería una máquina tan simple. Para
 * ayudarle, implementaremos una máquina de cálculo sencilla.
 * 
 * Entrada
 * En primer lugar, un número N indicando cuántos casos de prueba habrá.
 * 1 <= N <= 1000
 * Habrá una línea por cada caso de prueba. Cada una de esas líneas constará
 * de:
 * Un primer número entero A que indicará el primer operando de la operación.
 * Separado por un espacio se encontrará un símbolo que indicará la operación
 * a realizar. Este podrá ser "+", "-", "*" y "/". Tras ello, separado con un
 * espacio un número entero B, que será el segundo operado.
 * -10000 <= A <= 10000
 * -10000 <= B <= 10000
 * 
 * Salida
 * Se mostrarán N líneas, una por cada caso de prueba, donde se indicará el
 * resultado de la operación aritmética. En caso de división por cero
 * se indicará ERROR.
 * Se garantiza que el resultado siempre será un número entero y que las
 * divisiones proporcionadas siempre tendrán resto 0.
 * 
 * Ejemplo de entrada
 * 5
 * 5 + -13
 * 10 / 2
 * 7 * 3
 * 3 / 0
 * 5 - 13
 * 
 * Ejemplo de salida
 * -8
 * 5
 * 21
 * ERROR
 * -8  */

import java.util.*;

public class MaquinaDeCalculo {
    public static void main(String[] args){
        Scanner entrada = new Scanner(System.in);
        int nCasos = entrada.nextInt();

        for(int i = 0; i < nCasos; i++) {

            short num1 = entrada.nextShort();
            char operador = entrada.next().charAt(0);
            short num2 = entrada.nextShort();

            switch (operador) {

                case '+':
                    System.out.println(num1 + num2);
                    break;

                case '-':
                    System.out.println(num1 - num2);
                    break;

                case '*':
                    System.out.println(num1 * num2);
                    break;

                case '/':
                    if (num2 != 0)
                        System.out.println(num1 / num2);
                    else
                        System.out.println("ERROR");
                    break;
            }
        }
    }
}
