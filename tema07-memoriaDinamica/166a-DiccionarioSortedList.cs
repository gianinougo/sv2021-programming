// Author: Franco (...)

 /* 166. Crea un diccionario simple de castellano a valenciano: 
 * el programa deberá contener al menos 15 palabras prefijadas. 
 * Mostrará un menú que permita añadir una nueva palabra 
 * (pedirá tanto la palabra en castellano como su traducción a valenciano), 
 * buscar la traducción de una palabra, 
 * ver la lista de todas las palabras almacenadas o salir. 
 * Puedes usar una SortedList, 
 * una tabla Hash o un Dictionary<string,string> 
 * (se compartirán las tres soluciones, para que puedas comparar).
 */

// Versión a: SortedList, sin Generics

using System;
using System.Collections;

namespace ej166
{
    class Program
    {
        static void Main()
        {
            string opcion;
            SortedList miDiccio = new SortedList();
            bool salir = false;

            miDiccio.Add("perro", "gos");
            miDiccio.Add("gato", "gat");
            miDiccio.Add("uno", "un");
            miDiccio.Add("cuatro", "quatre");
            miDiccio.Add("cinco", "cinc");
            miDiccio.Add("seis", "sis");
            miDiccio.Add("siete", "set");
            miDiccio.Add("ocho", "huit");
            miDiccio.Add("nueve", "nou");
            miDiccio.Add("diez", "deu");
            miDiccio.Add("once", "onze");
            miDiccio.Add("doce", "dotze");
            miDiccio.Add("trece", "tretze");
            miDiccio.Add("catorce", "catorze");
            miDiccio.Add("quince", "quinze");

            do
            {
                Console.WriteLine();
                Console.WriteLine("1 - Añadir palabra.");
                Console.WriteLine("2 - Buscar traducción.");
                Console.WriteLine("3 - Ver palabras almacenadas.");
                Console.WriteLine("S - Salir.");
                Console.WriteLine();

                Console.Write(" > ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Palabra en castellano: ");
                        string palabraCastellano = Console.ReadLine();
                        if (! miDiccio.ContainsKey(palabraCastellano))
                        {
                            Console.Write("Palabra en valenciano: ");
                            string palabraValenciano = Console.ReadLine();
                            miDiccio.Add(palabraCastellano, palabraValenciano);
                        }
                        else
                            Console.WriteLine("(Ya está el diccionario)");
                        break;

                    case "2":
                        Console.Write("Introduzca la palabra a traducir: ");
                        string palabraATraducir = Console.ReadLine();
                        if (miDiccio.ContainsKey(palabraATraducir))
                            Console.WriteLine(miDiccio[palabraATraducir]);
                        else
                            Console.WriteLine("(No existe en el diccionario)");
                        break;

                    case "3":
                        for (int i = 0; i < miDiccio.Count; i++)
                            Console.WriteLine("{0} = {1}",
                                miDiccio.GetKey(i), 
                                miDiccio[ miDiccio.GetKey(i) ]);
                        break;

                    case "S":
                    case "s":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción no valida.");
                        break;
                }

            } while (!salir);
            Console.WriteLine("Gracias por usar nuestro traductor");
        }
    }
}
