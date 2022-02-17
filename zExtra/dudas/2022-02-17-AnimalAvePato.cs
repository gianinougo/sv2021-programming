using System;

abstract class Animal
{
    string nombre;
    public Animal(string nombre)
    {
        this.nombre = nombre;
    }
    
    public virtual void Hablar()
    {
        Console.WriteLine("Estoy hablando...");
    }
}

// ----------------

abstract class Ave : Animal
{
    public Ave(string nombre) : base (nombre)
    {
    }
    
    public abstract void Volar();
}

// ----------------

class Pato : Ave
{
    public Pato(string nombre) : base (nombre)
    {
    }
    
    public override void Hablar()
    {
        Console.WriteLine("Cuac Cuac!");
    }
    
    public override void Volar()
    {
        Console.WriteLine("Estoy volando");
    }
}

// ----------------

class Perro : Animal
{
    public Perro(string nombre) : base (nombre)
    {
    }
    
    public override void Hablar()
    {
        Console.WriteLine("Guau!");
    }
}

// ----------------

class PruebaAnimales
{
    static void Main()
    {
        Animal[] animales = new Animal[5];
        animales[0] = new Perro("Bobby");
        animales[1] = new Pato("Donald");
        animales[0].Hablar();
        animales[1].Hablar();
        
        // La siguiente líena dará error de compilación:
        // No todos los animales pueden volar
        // animales[1].Volar();   
        
        // Alternativa: forzado de tipos
        ((Ave) animales[1]).Volar();
        
        // Alternativa más segura
        if (animales[1] is Ave)
            ((Ave) animales[1]).Volar();
            
        // La siguiente línea lanzaría una excepción en tiempo de ejecución:
        // Un perro no se puede tomar como "Ave"
        // ((Ave) animales[0]).Volar();
            
        // Esta alternativa sí es válida
        if (animales[0] is Ave)
            ((Ave) animales[0]).Volar();
    }

}
