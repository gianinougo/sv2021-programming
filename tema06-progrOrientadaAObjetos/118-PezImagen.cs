/*
 * 118. Crea una nueva versión de la clase "Pez" (ejercicio 105), que incluya 
 * un constructor que prefije su nombre y su especie. También tendrá dos 
 * atributos x e y, que indiquen su posición en pantalla, para los cuales 
 * habrá getters y setters, y que se podrán fijar también desde un segundo 
 * constructor que dé valor a todos los atributos. Al tratarse de un simulador
 * en modo texto, los atributos x e y serán de tipo "byte", si bien su 
 * "getter" devolverá un número entero, y su "setter" recibirá un número 
 * entero (y lo mismo ocurrirá con el constructor). El método Nadar 
 * dibujará un supuesto pez en pantalla (por ejemplo, "><=>", en esas 
 * coordenadas x e y, y luego incrementará su x. Añade un destructor 
 * que escriba "Aquí acabó la vida del pez". El programa de prueba creará 
 * un pez en las coordenadas 15, 15, y lo hará nadar cada vez que se pulse 
 * una tecla, terminando la ejecución cuando esa tecla sea ESC, para lo que 
 * puedes ayudarte del siguiente fragmento de programa:

    ConsoleKeyInfo tecla = Console.ReadKey();

    if (tecla.Key == ConsoleKey.Escape)
       salir = true;
 */
 
// Ezequiel + Ugo, retoques por Nacho

using System;

class Pez
{
    protected string nombre;
    protected string especie;
    protected byte x;
    protected byte y;


    public Pez(string nuevoNombre, string nuevaEspecie)
    {
        nombre = nuevoNombre;
        especie = nuevaEspecie;
        x = 40;
        y = 10;
    }
    
    public Pez(string nuevoNombre, string nuevaEspecie,
        int nuevoX, int nuevoY)
    {
        nombre = nuevoNombre;
        especie = nuevaEspecie;
        x = (byte) nuevoX;
        y = (byte) nuevoY;
    }

    ~Pez()
    {
        Console.WriteLine("Aquí acaba la vida del pez");
    }

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

    public int GetX() { return x; }
    public void SetX(int nuevoX) { x = (byte)nuevoX; }
    
    public int GetY() { return y; }
    public void SetY(int nuevoY) { y = (byte)nuevoY; }


    public void Nadar()
    {
        Console.SetCursorPosition(x, y);
        Console.Write("><=>");
        
        x++;
    }
}


class SimuladorDePecera
{
    static void Main()
    {
        bool salir = false;
        Pez dorada = new Pez("goldeen", "dorada", 15, 15);
        dorada.Nadar();
        
        while (!salir)
        {
            ConsoleKeyInfo tecla = Console.ReadKey();
            Console.Clear();
            if (tecla.Key == ConsoleKey.Escape)
                salir = true;
            dorada.Nadar();
        }
    }
}
