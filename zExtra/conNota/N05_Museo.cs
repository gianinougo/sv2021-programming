using System;
using System.Collections.Generic;

/* Por una parte, habrá una clase genérica Obra, para representar las 
obras de arte que el museo tiene expuestas. En concreto, en esta 
primera versión distinguiremos entre Pinturas y Esculturas. En ambos 
casos querremos saber el autor, el título y el año, pero en las 
pinturas detallaremos también la técnica y en las esculturas el 
material. El constructor de la clase Pintura recibirá autor, título, 
año y técnica, en ese orden, y el de Escultura recibirá autor, título, 
año y material, en ese orden. Para cada uno de los campos, crearemos 
getters y setters "convencionales". Además, habrá un ToString, que 
devolverá los campos en el mismo orden en que aparecen en el 
constructor, separados por " – ". También habrá un método 
"MostrarDatos", que mostrará en pantalla esa misma información (campos 
separados por guiones), seguida de "(Pintura)" o "(Escultura)", según 
el caso. */

class Obra
{
    protected string autor, titulo;
    protected int anyo;

    public Obra(string autor, string titulo, int anyo)
    {
        this.autor = autor;
        this.titulo = titulo;
        this.anyo = anyo;
    }

    public string GetAutor() { return autor; }

    public void SetAutor(string nuevoAutor)
    {
        autor = nuevoAutor;
    }

    public string GetTitulo() { return titulo; }

    public void SetTitulo(string nuevoTitulo)
    {
        titulo = nuevoTitulo;
    }

    public int GetAnyo() { return anyo; }

    public void SetAnyo(int nuevoAnyo)
    {
        anyo = nuevoAnyo;
    }

    public override string ToString()
    {
        return autor + " - " + titulo + " - " + anyo;
    }
    
    public virtual void MostrarDatos()
    {
        Console.Write(ToString());
    }
}

// ---------------------------------


class Pintura: Obra
{
    protected string tecnica;

    public Pintura(string autor, string titulo, int anyo, string tecnica)
        : base (autor, titulo, anyo)
    {
        this.tecnica = tecnica;
    }

    public string GetTecnica() { return tecnica; }

    public void SetTecnica(string nuevaTecnica)
    {
        tecnica = nuevaTecnica;
    }

    public override string ToString()
    {
        return base.ToString() + " - " + tecnica;
    }
    
    public override void MostrarDatos()
    {
        base.MostrarDatos();
        Console.Write(" (Pintura)");
    }
}

// ---------------------------------

class Escultura : Obra
{
    protected string material;

    public Escultura(string autor, string titulo, int anyo, string material)
        : base(autor, titulo, anyo)
    {
        this.material = material;
    }

    public string GetMaterial() { return material; }

    public void SetMaterial(string nuevoMaterial)
    {
        material = nuevoMaterial;
    }

    public override string ToString()
    {
        return base.ToString() + " - " + material;
    }
    
    public override void MostrarDatos()
    {
        base.MostrarDatos();
        Console.Write(" (Escultura)");
    }
}


// =================================

/*

También nos han pedido llevar cuenta de los empleados que tienen 
trabajando para ellos y de los que desean trabajar con ellos cuando 
haya nuevas ofertas. De hecho, quieren distinguir entre Empleados en 
plantilla (de los que guardarán código, nombre, sector y dirección) e 
Interesados (de los que guardarán nombre, sector y fecha de último 
contacto). Para cada clase habrá un constructor que reciba todos esos 
datos en ese orden, además de propiedades en formato compacto, con la 
peculiaridad de que no queremos que se pueda modificar el código de un 
empleado en plantilla. El ToString de cada empleado mostrará nombre y 
sector, separados por " | ", y seguido por " (P)" o por " (I)", según 
esté en plantilla o sea un aspirante interesado en trabajar con 
nosotros.
*/

class Empleado
{
    public string Nombre { get; set; }
    public string Sector { get; set; }
    public string Email { get; set; }

    public Empleado(string Nombre, string Sector, string Email)
    {
        this.Nombre = Nombre;
        this.Sector = Sector;
        this.Email = Email;
    }

    public override string ToString()    {
        return Nombre + " | " + Sector + " | " + Email;
    }
}

// ---------------------------------

class EnPlantilla: Empleado
{
    // Nota: la siguiente línea funciona en versiones recientes de C#
    // public string Codigo { get; }
    
    // Y esta es la alternativa para C# 5 y anteriores (compilar desde Geany):
    private string codigo;
    public string Codigo { get {return codigo;} }
    
    public string Direccion { get; set; }

    public EnPlantilla(string codigo, string Nombre, string Sector, 
            string direccion, string Email)
        :base (Nombre, Sector, Email)
    {
        this.codigo = codigo;
        Direccion = direccion;
    }

    public override string ToString()
    {
        return base.ToString() + " (P)";
    }
}

// ---------------------------------

class Interesado : Empleado
{
    public string Fecha { get; set; }

    public Interesado(string Nombre, string Sector, string Email, string Fecha)
        : base(Nombre, Sector, Email)
    {
        this.Fecha = Fecha;
    }

    public override string ToString()
    {
        return base.ToString() + " (I)";
    }
}

// =================================

/*
La clase principal se llamará "Museo" y contendrá como atributos una lista de 
obras y una lista de empleados.

El cuerpo del programa estará en el método Ejecutar de la clase Museo. Este 
cuerpo creará dos empleados en plantilla prefijados y y dos obras prefijadas, 
una de las cuales será un pintura y otra una escultura. Mostrará además las 
siguientes opciones:

 - Añadir un empleado en plantilla (pidiendo sus datos por consola)
 - Añadir un interesado en trabajar en el museo (ídem).
 - Buscar empleados, a partir de parte de su descripción (su "ToString").
 - Añadir una obra (preguntando el tipo de obra y todos sus datos).
 - Buscar en las obras, a partir de su descripción (su "ToString").
 - Salir

Esta misma clase Museo será la que también contenga Main. 
*/

class Museo
{
    const int MAX_OBRAS = 1000;
    const int MAX_EMPLEADOS = 200;
    int contadorEmpleados = 0;
    int contadorObras = 0;
    
    Obra[] obras = new Obra[MAX_OBRAS];
    Empleado[] empleados = new Empleado[MAX_EMPLEADOS];
    
    public void Ejecutar()
    {
        bool terminado = false;

        Empleado e1 = new EnPlantilla("0001", "Roy Batty", "Informática",
            "Calle Stratton, 1982", "roy@elmuseo.com");
        Empleado e2 = new EnPlantilla("0002", "Rick Deckard", "Seguridad",
            "Calle Gaff, 1968", "rick@elmuseo.com");
        empleados[0] = e1; contadorEmpleados++;
        empleados[1] = e2; contadorEmpleados++;

        Obra o1 = new Pintura("Leonardo", "La Gioconda", 1519, "Óleo");
        Obra o2 = new Escultura("Miguel Angel", "David", 1504, "Mármol");
        obras[0] = o1; contadorObras++;
        obras[1] = o2; contadorObras++;

        do
        {
            MostrarMenu();
            Console.Write("Seleccione una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1: AnyadirEmpleado(); break;
                case 2: AnyadirInteresado(); break;
                case 3: BuscarEmpleado(); break;
                case 4: AnyadirObra(); break;
                case 5: BuscarObra(); break;
                case 6: terminado = true; break;
                default: Console.WriteLine("Opción no válida."); break;
            }
        }
        while (!terminado);
    }

    private void MostrarMenu()
    {
        Console.WriteLine("1.- Añadir nuevo empleado.");
        Console.WriteLine("2.- Añadir nuevo interesado");
        Console.WriteLine("3.- Buscar empleados por texto.");
        Console.WriteLine("4.- Añadir obra de arte");
        Console.WriteLine("5.- Buscar obra de arte");
        Console.WriteLine("6.- Salir.");
        Console.WriteLine();
    }

    private static string Pedir(string aviso)
    {
        Console.Write(aviso + ": ");
        string respuesta = Console.ReadLine();

        return respuesta;
    }

    private void AnyadirEmpleado()
    {
        if (contadorEmpleados < MAX_EMPLEADOS)
        {
            string codigo = Pedir("Codigo");
            string nombre = Pedir("Nombre");
            string sector = Pedir("Sector");
            string direccion = Pedir("Direccion");
            string email = Pedir("Email");
            
            empleados[contadorEmpleados] = 
                new EnPlantilla(codigo, nombre, sector, direccion, email);
            contadorEmpleados++;
        }
        else
        {
            Console.WriteLine("Base de datos llena");
        }
    }
    
    
    private void AnyadirInteresado()
    {
        if (contadorEmpleados < MAX_EMPLEADOS)
        {
            string nombre = Pedir("Nombre");
            string sector = Pedir("Sector");
            string email = Pedir("Email");
            string fecha = Pedir("Fecha");

            empleados[contadorEmpleados] = 
                new Interesado(nombre, sector, email, fecha);
            contadorEmpleados++;
        }
        else
        {
            Console.WriteLine("Base de datos llena");
        }
    }

    private void AnyadirObra()
    {
        if (contadorEmpleados < MAX_EMPLEADOS)
        {
            string autor, titulo, tecnica, material;
            int anyo;

            Console.WriteLine("Tipo de Obra : 1 Pintura - 2 Escultura");
            int tipoObra = Convert.ToInt32(Console.ReadLine());
            autor = Pedir("Autor");
            titulo = Pedir("Titulo");
            anyo = Convert.ToInt32(Pedir("Año"));

            if (tipoObra == 1)
            {
                tecnica = Pedir("Técnica");
                obras[contadorObras] = 
                    new Pintura(autor, titulo, anyo, tecnica);
                contadorObras++;
            }
            else if (tipoObra == 2)
            {
                material = Pedir("Material");
                obras[contadorObras] = 
                    new Escultura(autor, titulo, anyo, material);
                contadorObras++;
            }
        }
        else
        {
            Console.WriteLine("Base de datos llena");
        }
    }

    private void BuscarEmpleado()
    {
        if (contadorEmpleados == 0)
        {
            Console.WriteLine("No hay ningún empleado para mostrar");
        }
        else
        {
            string textoABuscar = Pedir("Introduce el texto a buscar en empleados");
            bool encontrado = false;

            for (int i = 0; i < contadorEmpleados; i++)
            {
                if (empleados[i].ToString().ToUpper().
                    Contains(textoABuscar.ToUpper()))
                {
                    Console.WriteLine(empleados[i]);
                    encontrado = true;
                }
            }
            if ( ! encontrado)
            {
                Console.WriteLine("No se ha encontrado");
            }
        }
        
    }

    private void BuscarObra()
    {
        if (contadorObras == 0)
        {
            Console.WriteLine("No hay ninguna obra para mostrar");
        }
        else
        {
            string textoABuscar = Pedir("Introduce el texto a buscar en obras");
            bool encontrado = false;

            for (int i = 0; i < contadorObras; i++)
            {
                if (obras[i].ToString().ToUpper().
                    Contains(textoABuscar.ToUpper()))
                {
                    Console.WriteLine(obras[i]);
                    encontrado = true;
                }
            }
            
            if ( ! encontrado)
            {
                Console.WriteLine("No se ha encontrado");
            }
        }
    }

    static void Main()
    {
        Museo m = new Museo();
        m.Ejecutar();
    }
}
