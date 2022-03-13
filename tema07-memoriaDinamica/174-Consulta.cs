// Ejercicio recomendado 174
// Javier (...)

/*
Consulta - Versión con listas

Se desea crear un esqueleto para un sistema informático para una pequeña 
consulta médica.

Para ello, se creará una clase "Consulta", que englobará a todas las demás. El 
sistema estará previsto para controlar:

Médicos, enfermeros y pacientes. Para todos ellos se anotará el nombre y los 
apellidos (en un único campo, con el formato "Apellidos, Nombre"), además de un 
código numérico. Tendrán un constructor que permita indicar esos dos 
parámetros, además de Getters y Setters (o propiedades) para cada uno de ellos. 
En el caso de los médicos, existirá además una "especialidad" (por ejemplo, 
"Oftalmología", junto con su Get y su Set, y un constructor adicional que 
permita indicar la especialidad además de los otros 2 datos (en el caso del 
constructor general, que no indica especialidad, se asumirá que ésta es 
"Medicina general"). Para todos ellos se deberá crear un método ToString, que 
muestre código, nombre y apellidos y (en el caso de los médicos) especialidad, 
separados por comas.

Visitas, que a su vez pueden ser Planificadas o Urgencias. Para cada visita se 
deberá anotar el paciente que se ha atendido y el médico que lo ha hecho (como 
no siempre se precisará un enfermero, este detalle se dejará para la versión 
2.0). También será preciso anotar la fecha y hora (como DateTime.Now), el 
motivo de la visita y el diagnóstico. Además, para las urgencias se anotará un 
dato booleano que indique si es necesaria una visita posterior o no. Todos 
estos datos se deberán poder indicar en el constructor, y existirán Getters y 
Setters para ellos (o propiedades). El método ToString de una visita devolverá 
el nombre del cliente, nombre del médico, fecha, motivo y diagnóstico, 
separados por " - ". En caso de que sea planificada, esta información será 
precedida por "Planificada - ", y en el caso de una urgencia, estará precedida 
por "Urgencia - ". El método ToString de una urgencia que tenga programada una 
visita posterior deberá terminar con " (P)".

El cuerpo del programa estará en el método Ejecutar de la clase Consulta. Este 
cuerpo creará dos médicos y un enfermero prefijados y un array de pacientes 
inicialmente vacío. Mostrará cinco opciones:

- Añadir un paciente (pidiendo sus datos por consola)

- Buscar pacientes, a partir de parte de su nombre o apellidos.

- Añadir una visita (pidiendo el tipo de visita, el código del paciente, el 
código del médico, el motivo de la visita y el diagnóstico -la fecha no se 
pedirá, sino que se tomará el instante actual-; si es urgencia, se preguntará 
también si se ha planificado una visita posterior).

- Ver todas las visitas.

- Salir

Esta misma clase Consulta será la que también contenga Main.

Como no sabemos manejar ficheros, esta primera versión provisional perderá la 
información cada vez que termine una sesión.

Recuerda evitar código repetitivo tanto como sea posible, reutilizando 
constructores o métodos cuando corresponda.
*/

using System;
using System.Collections.Generic;

class Consulta
{
    private static void Ejecutar()
    {
        Medico m1 = new Medico("Perez García, Manuel", 1, "Neurología");
        Medico m2 = new Medico("Gómez Jurado, Ramón", 2, "Traumatología");
        List<Paciente> pacientes = new List<Paciente>();
        List<Medico> medicos = new List<Medico>();
        medicos.Add(m1);
        medicos.Add(m2);

        Enfermero e1 = new Enfermero("Corona Lara, Beatriz", 3);

        List<Visita> visitas = new List<Visita>();

        string opcion;
        bool salir = false;

        do
        {
            MostrarMenu();
            opcion = Console.ReadLine().ToUpper();

            switch (opcion)
            {
                case "1": AnyadirPaciente(pacientes); break;
                case "2": BuscarPacientes(pacientes); break;
                case "3": AnyadirVisita(visitas, pacientes, medicos); break;
                case "4": VerVisitas(visitas); break;
                case "S":
                    Console.WriteLine("No se pueden guardar los datos y se " +
                        "perderán. Hasta la próxima!");
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción incorrecta");
                    break;
            }
        }
        while (!salir);
    }

    private static void VerVisitas(List<Visita> visitas)
    {
        if (visitas.Count > 0)
        {
            for (int i = 0; i < visitas.Count; i++)
                Console.WriteLine(visitas[i]);
        }
        else
            Console.WriteLine("No hay visitas");
    }

    private static int ExistePaciente(List<Paciente> pacientes, int codigoPersona)
    {
        bool pacienteCorrecto = false;
        int persona = -1;

        if (pacientes.Count > 0)
        {
            int i = 0;

            while (!pacienteCorrecto && i < pacientes.Count)
            {
                if (pacientes[i].Codigo == codigoPersona)
                {
                    pacienteCorrecto = true;
                    persona = i;
                }

                i++;
            }
        }

        return persona;
    }

    private static int ExisteMedico(List<Medico> medicos, int codigoPersona)
    {
        bool medicoCorrecto = false;
        int persona = -1;

        if (medicos.Count > 0)
        {
            int i = 0;

            while (!medicoCorrecto && i < medicos.Count)
            {
                if (medicos[i].Codigo == codigoPersona)
                {
                    medicoCorrecto = true;
                    persona = i;
                }

                i++;
            }
        }

        return persona;
    }

    private static void AnyadirVisita(List<Visita> visitas,
        List<Paciente> pacientes, List<Medico> medicos)
    {

        string tipoVisita = PedirDato("Tipo visita: (1) Urgencia - " +
            "(2) Planificada");
        int codigoPaciente = Convert.ToInt32(PedirDato("Código del paciente"));
        int codigoMedico = Convert.ToInt32(PedirDato("Código del médico"));
        string motivoVisita = PedirDato("Motivo de la visita");
        string diagnostico = PedirDato("Diagnóstico");

        int numPaciente = ExistePaciente( pacientes, codigoPaciente);
        int numMedico = ExisteMedico(medicos, codigoMedico);

        if (numPaciente >= 0 && numMedico >= 0)
        {
            if (tipoVisita == "1")
            {
                string visitaPosterior = PedirDato("Necesita visita posterior? " +
                    "(1) Sí - (2) No");
                bool necesitaVisitaPosterior = visitaPosterior == "1";

                visitas.Add(new Urgencia(pacientes[numPaciente],
                    medicos[numMedico], DateTime.Now, motivoVisita,
                    diagnostico, necesitaVisitaPosterior));
            }
            else
                visitas.Add(new Planificada(pacientes[numPaciente],
                    medicos[numMedico], DateTime.Now, motivoVisita,
                    diagnostico));
        }
        else
        {
            Console.WriteLine("El código de paciente o médico " +
                "introducidos no existe");
        }
    }

    private static void BuscarPacientes(List<Paciente> pacientes)
    {
        if (pacientes.Count > 0)
        {
            bool encontrado = false;

            Console.WriteLine("Introduce el texto de búsqueda de pacientes:");
            string busqueda = PedirDato("Texto de la búsqueda").ToLower();

            for (int i = 0; i < pacientes.Count; i++)
            {
                if (pacientes[i] is Paciente &&
                    pacientes[i].ToString().ToLower().Contains(busqueda))
                {
                    Console.WriteLine(pacientes[i]);
                    encontrado = true;
                }
            }

            if (!encontrado)
                Console.WriteLine("No se han encontrado pacientes con los " +
                    "datos de búsqueda introducidos");
        }
        else
            Console.WriteLine("No hay pacientes");
    }

    private static void AnyadirPaciente(List<Paciente> pacientes)
    {
        Console.WriteLine("Introduce los datos del paciente:");
        string apellidos = PedirDato("Apellidos");
        string nombre = PedirDato("Nombre");
        apellidos += ", " + nombre;

        int codigo = Convert.ToInt32(PedirDato("Código"));

        if (ExistePaciente(pacientes, codigo) < 0)
        {
            pacientes.Add(new Paciente(apellidos, codigo));
        }
        else
            Console.WriteLine("Error: el código de paciente ya existe");

    }

    private static string PedirDato(string aviso)
    {
        Console.Write(aviso + ": ");
        return Console.ReadLine();
    }

    private static void MostrarMenu()
    {
        Console.WriteLine();
        Console.WriteLine("1. Añadir paciente");
        Console.WriteLine("2. Buscar pacientes");
        Console.WriteLine("3. Añadir visita");
        Console.WriteLine("4. Ver todas las visitas");
        Console.WriteLine("S. Salir");
        Console.WriteLine();
    }

    public static void Main()
    {
        Ejecutar();
    }
}

// ---------------------------------

abstract class Persona
{
    public string Nombre { get; set; }
    public int Codigo { get; set; }

    public Persona(string nombre, int codigo)
    {
        Nombre = nombre;
        Codigo = codigo;
    }

    public override string ToString()
    {
        return Codigo + ", " + Nombre;
    }
}

// ---------------------------------

class Paciente : Persona
{
    public Paciente(string nombre, int codigo)
        : base(nombre, codigo)
    {
    }
}

// ---------------------------------

class Medico : Persona
{
    public string Especialidad { get; set; }

    public Medico(string nombre, int codigo)
        : base(nombre, codigo)
    {
        Especialidad = "Medicina general";
    }

    public Medico(string nombre, int codigo, string especialidad)
        : base(nombre, codigo)
    {
        Especialidad = especialidad;
    }

    public override string ToString()
    {
        return base.ToString() + ", " + Especialidad;
    }
}

// ---------------------------------

class Enfermero : Persona
{
    public Enfermero(string nombre, int codigo)
        : base(nombre, codigo)
    {
    }
}

// ---------------------------------

abstract class Visita
{
    public Paciente P { get; set; }
    public Medico M { get; set; }

    // Nota: la siguiente orden dara error desde Geany,
    // si se usa el compilador de C# 5
    // y habría que crear una propiedad en formato largo,
    // con un atributo por debajo
    public DateTime FechaVisita { get; }
    public string MotivoVisita { get; set; }
    public string Diagnostico { get; set; }

    public Visita(Paciente paciente, Medico medico, DateTime fechaVisita,
        string motivoVisita, string diagnostico)
    {
        P = paciente;
        M = medico;
        FechaVisita = fechaVisita;
        MotivoVisita = motivoVisita;
        Diagnostico = diagnostico;
    }

    public override string ToString()
    {
        return P.Nombre + " - " + M.Nombre + " - " +
            FechaVisita + " - " + MotivoVisita + " - " + Diagnostico;
    }
}

// ---------------------------------

class Planificada : Visita
{
    public Planificada(Paciente paciente, Medico medico, DateTime fechaVisita,
        string motivoVisita, string diagnostico)
        : base(paciente, medico, fechaVisita, motivoVisita, diagnostico)
    {
    }

    public override string ToString()
    {
        return "Planificada - " + base.ToString();
    }
}

// ---------------------------------

class Urgencia : Visita
{
    public bool NecesitaVisitaPosterior { get; set; }

    public Urgencia(Paciente paciente, Medico medico, DateTime fechaVisita,
        string motivoVisita, string diagnostico, bool necesitaVisitaPosterior)
        : base(paciente, medico, fechaVisita, motivoVisita, diagnostico)
    {
        NecesitaVisitaPosterior = necesitaVisitaPosterior;
    }

    public override string ToString()
    {
        string texto = "Urgencia - " + base.ToString();
        if (NecesitaVisitaPosterior)
            texto += " (P)";

        return texto;
    }
}
