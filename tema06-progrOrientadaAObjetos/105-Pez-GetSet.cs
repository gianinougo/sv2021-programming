//Recomendado 105, por Ezequiel (...) 1º DAM
/*Crea una nueva versión de la clase "Pez". Sus atributos serán privados y 
 * tendrá "getters" y "setters" que permitan cambiar el valor de éstos. 
 * Modifica el programa y "Main" según sea necesario.*/
 
using System;

class Pez
{
    private string nombre;
    private string especie;
    
        
    public string GetNombre()
    {
        return nombre;
    }
    public void SetNombre(string cadenaTexto)
    {
        nombre = cadenaTexto;
    }
    
    public string GetEspecie()
    {
        return especie;
    }
    public void SetEspecie(string cadenaTexto)
    {
        especie = cadenaTexto;
    }
    
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
        
        dorada.SetNombre("goldeen");
        dorada.SetEspecie("dorada");
        
        dorada.Nadar();
    }
}
