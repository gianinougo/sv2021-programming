//Recomendado 104, por Ezequiel (...) 1º DAM

/*Crea una clase llamada "Pez", que representará supuestamente uno de tantos 
componentes que aparecerán en un simulador de una pecera que vamos a 
desarrollar. Sus atributos (públicos) serán el nombre (una cadena de texto) y 
la especie (otra cadena de texto). Tendrá un método llamado "Nadar", que por 
ahora simplemente escribirá en pantalla "Soy un pez de la especie XXX, llamado 
YYY y estoy nadando". Crea una clase "SimuladorDePecera" (en el mismo fichero 
fuente), que tendrá un "Main" para probarlo */

using System;

class Pez
{
    public string nombre;
    public string especie;
    
    public void Nadar()
    {
        Console.WriteLine("Soy un pez de la especie {0}, llamado {1} y " +
                            "estoy nadando.", especie, nombre);
    }
}

class SimuladorDePecera
{
    static void Main()
    {
        Pez dorada = new Pez();
        
        dorada.especie = "dorada";
        dorada.nombre = "goldeen";
        dorada.Nadar();
        
    }
}
