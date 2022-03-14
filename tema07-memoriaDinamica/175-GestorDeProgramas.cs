// Ejercicio recomendado 175
// Javier (...), retoques por Nacho

/*
175. Crea un programa en C# que pueda almacenar fichas de programas de 
ordenador. Para cada programa, esta primera versión debe guardar los siguientes 
datos:

- Nombre
- Descripción
- Versión (es un conjunto de 2 datos: el mes de lanzamiento –byte- y el año 
  de lanzamiento –entero corto sin signo-)
- Ubicación del backup

El programa debe permitir al usuario las siguientes operaciones:

1- Añadir datos de un nuevo programa al final de los existentes. 

2- Insertar un nuevo programa en una cierta posición (desplazando los ya 
existentes).

3- Mostrar los nombres de todos los programas almacenados. Cada nombre debe 
aparecer en una línea distinta, precedido por el número de programa (empezando 
a contar desde 1). Si hay más de 20 programas, se deberá hacer una pausa tras 
mostrar cada bloque de 20 programas, y esperar a que el usuario pulse Intro 
antes de seguir. Se deberá avisar si no hay datos.

4- Ver todos los datos de un cierto programa (a partir de su número de 
registro, contando desde 1). Se deberá avisar (pero no volver a pedir) si el 
número no es válido.

5- Modificar una ficha (se pedirá el número y se volverá a introducir el valor 
de todos los campos. Se debe avisar (pero no volver a pedir) si introduce un 
número de ficha incorrecto.

6- Borrar un cierto dato, en la posición que indique el usuario. Se debe avisar 
(pero no volver a pedir) si introduce un número incorrecto.

T- Terminar.
*/

using System;
using System.Collections.Generic;

class ProgamasPC
{
    public static void Main()
    {
        GestorDeProgramas gestor = new GestorDeProgramas();
        gestor.Ejecutar();
    }
}

// -------------

struct TipoVersion
{
    public byte mes;
    public ushort anyo;
}
class Programa
{
    protected string nombre;
    protected string descripcion;
    protected TipoVersion version;
    protected string ubicacion;  // almacena la ubicación del backup

    public Programa(string nombre, string descripcion,
        TipoVersion version, string ubicacion)
    {
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.version = version;
        this.ubicacion = ubicacion;
    }

    public string GetNombre() { return nombre; }
    public string GetDescripcion() { return descripcion; }
    public TipoVersion GetVersion() { return version; }
    public string GetUbicacion() { return ubicacion; }

    public void SetNombre(string nombre) { this.nombre = nombre; }
    public void SetDescripcion(string descripcion)
    {
        this.descripcion = descripcion;
    }
    public void SetVersion(TipoVersion version)
    {
        this.version = version;
    }
    public void SetUbicacion(string ubicacion) { this.ubicacion = ubicacion; }

    public override string ToString()
    {
        return nombre + ", " + descripcion + " (" + version.anyo + ", " +
            version.mes + ")" + " - " + ubicacion;
    }
}


// -------------

class GestorDeProgramas
{
    public void Ejecutar()
    {
        bool terminar = false;
        List<Programa> programas = new List<Programa>();

        do
        {
            MostrarOperaciones();
            string opcion = RecogerOpcion();
            terminar = RealizarOperacion(opcion, programas);

        }
        while (!terminar);
    }

    private void MostrarOperaciones()
    {
        Console.WriteLine();
        Console.WriteLine("1. Añadir nuevo programa al final");
        Console.WriteLine("2. Insertar nuevo programa por posición");
        Console.WriteLine("3. Mostrar nombre de todos los programas");
        Console.WriteLine("4. Ver datos de un programa");
        Console.WriteLine("5. Modificar una ficha");
        Console.WriteLine("6. Borrar una ficha");
        Console.WriteLine("T. Terminar");
    }

    private bool RealizarOperacion(string opcion, List<Programa> programas)
    {
        bool terminar = false;

        switch (opcion)
        {
            case "1": Anyadir(programas); break;
            case "2": Insertar(programas); break;
            case "3": MostrarProgramas(programas); break;
            case "4": VerDatosPrograma(programas); break;
            case "5": ModificarFicha(programas); break;
            case "6": BorrarFicha(programas); break;
            case "T": terminar = Terminar(); break;
            default: MostrarOperacionIncorrecta(); break;
        }
        return terminar;
    }

    private void BorrarFicha(List<Programa> programas)
    {
        if (programas.Count > 0)
        {
            int registro = PedirNumRegistro();
            if (VerificarRegistro(programas, registro))
            {
                programas.RemoveAt(registro);
            }
            else
                MostrarRegistroIncorrecto();
        }
        else
            MostrarListaVacia();
    }

    private void ModificarFicha(List<Programa> programas)
    {
        if (programas.Count > 0)
        {
            int registro = PedirNumRegistro();
            if (VerificarRegistro(programas, registro))
            {
                Console.WriteLine(programas[registro]);
                string nombre = ModificarDato("nombre", programas[registro].GetNombre());
                string descripcion = ModificarDato("descripcion", programas[registro].GetDescripcion());

                TipoVersion version;
                version.mes = Convert.ToByte(
                    ModificarDato("mes", programas[registro].GetVersion().mes.ToString()));
                version.anyo = Convert.ToByte(
                    ModificarDato("año", programas[registro].GetVersion().anyo.ToString()));

                string ubicacion = ModificarDato("ubicacion", programas[registro].GetUbicacion());

                Programa p =
                    new Programa(nombre, descripcion, version, ubicacion);
                programas[registro] = p;
            }
            else
                MostrarRegistroIncorrecto();
        }
        else
            MostrarListaVacia();
    }

    private void VerDatosPrograma(List<Programa> programas)
    {
        if (programas.Count > 0)
        {
            int registro = PedirNumRegistro();
            if (VerificarRegistro(programas, registro))
                Console.WriteLine((registro + 1) + ". " + programas[registro]);
            else
                MostrarRegistroIncorrecto();
        }
        else
            MostrarListaVacia();
    }

    private void MostrarProgramas(List<Programa> programas)
    {
        if (programas.Count > 0)
        {
            byte lineas = 0;
            for (int i = 0; i < programas.Count; i++)
            {
                if (lineas == 19)
                {
                    lineas = 0;
                    Console.WriteLine("Pulse enter para continuar");
                    Console.ReadLine();
                }
                Console.WriteLine((i + 1) + ". " + programas[i].GetNombre());
            }
        }
        else
            MostrarListaVacia();
    }


    private void Insertar(List<Programa> programas)
    {
        if (programas.Count > 0)
        {
            string nombre, descripcion, ubicacion;
            TipoVersion version;
            int posicion =
                Convert.ToInt32(PedirDatoNoVacio("posición para insertar")) - 1;
            if (VerificarRegistro(programas, posicion))
            {
                PedirPrograma(out nombre, out descripcion, out version, out ubicacion);
                programas.Insert(posicion,
                    new Programa(nombre, descripcion, version, ubicacion));
            }
            else
                MostrarRegistroIncorrecto();
        }
        else
            MostrarListaVacia();
    }

    private void Anyadir(List<Programa> programas)
    {
        string nombre, descripcion, ubicacion;
        TipoVersion version;
        PedirPrograma(out nombre, out descripcion, out version, out ubicacion);
        programas.Add(new Programa(nombre, descripcion, version, ubicacion));
    }

    private int PedirNumRegistro()
    {
        return Convert.ToInt32(PedirDatoNoVacio("registro a visualizar")) - 1;
    }

    private void PedirPrograma(out string nombre, out string descripcion,
        out TipoVersion version, out string ubicacion)
    {
        nombre = PedirDatoNoVacio("nombre");
        descripcion = PedirDatoNoVacio("descripcion");
        version.mes = Convert.ToByte(PedirDatoNoVacio("mes"));
        version.anyo = Convert.ToUInt16(PedirDatoNoVacio("año"));
        ubicacion = PedirDatoNoVacio("ubicacion de backup");
    }

    private string PedirDatoNoVacio(string aviso)
    {
        string dato;
        do
        {
            Console.Write("Introduce " + aviso + ": ");
            dato = Console.ReadLine();
            if (dato == "")
                Console.WriteLine("Debes introducir un dato");
        }
        while (dato == "");

        return dato;
    }

    private string ModificarDato(string aviso, string valorAnterior)
    {
        string dato;
        Console.Write("Introduce nuevo valor para " + aviso + 
            " (era " + valorAnterior + "): ");
        dato = Console.ReadLine();
        if (dato == "")
            return valorAnterior;
        else
            return dato;
    }

    private bool Terminar()
    {
        Console.WriteLine("Hasta la próxima!");
        return true;
    }

    private void MostrarOperacionIncorrecta()
    {
        Console.WriteLine("Operación incorrecta");
    }

    private void MostrarListaVacia()
    {
        Console.WriteLine("Error: no hay datos");
    }

    private void MostrarRegistroIncorrecto()
    {
        Console.WriteLine("Número de registro incorrecto");
    }

    private string RecogerOpcion()
    {
        return Console.ReadLine().ToUpper();
    }

    private bool VerificarRegistro(List<Programa> programas, int registro)
    {
        return registro >= 0 && registro < programas.Count;
    }
}

