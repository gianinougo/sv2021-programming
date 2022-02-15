// Ejercicio recomendado 148, variante B, compartiendo variables
// Carlos (...)

/*
148. Consulta

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

class Consulta
{
    const int MAXIMO = 500;
    int contadorPacientes = 2;
    int contadorVisitas = 2;
    int contadorMedicos = 2;

    Paciente[] pacientes = new Paciente[MAXIMO];
    Visita[] visitas = new Visita[MAXIMO];
    Medico[] medicos = new Medico[MAXIMO];

    private static void Main(string[] args)
    {
        Consulta consulta = new Consulta();
        consulta.Ejecutar();
    }

    private void Ejecutar()
    {
        bool salir = false;
        medicos[0] = new Medico("Buades, Fernando", 1);
        medicos[1] = new Medico("Perez, Juan", 2, "Geriatria");
        pacientes[0] = new Paciente("a, a", 1);
        pacientes[1] = new Paciente("b, b", 2);
        visitas[0] = new Planificada(pacientes[0], medicos[0], 
            DateTime.Now, "dolor", "muerte");
        visitas[1] = new Urgencia(pacientes[1], medicos[1], 
            DateTime.Now, "lados", "muertefresca", true);
        Enfermero enfermero1 = new Enfermero("Martinez, Antonio", 2);

        do
        {
            MostrarMenu();
            string opcion = PedirDato("Elige una opcion de las indicadas arriba");
            switch (opcion)
            {
                case "1": AnyadirPaciente(); break;
                case "2": BuscarPaciente(); break;
                case "3": AnyadirVisita(); break;
                case "4": VerVisitas(); break;
                case "6": MostrarPacientes(); break;
                case "s":
                case "S": salir = true; break;

            }
        } while (salir == false);
    }

    private void MostrarMenu()
    {
        Console.WriteLine("1-Añadir un paciente");
        Console.WriteLine("2-Buscar pacientes");
        Console.WriteLine("3-Añadir una visita");
        Console.WriteLine("4-Ver todas las visitas.");
        Console.WriteLine("S-salir");
        Console.WriteLine();
    }

    private string PedirDato(string frase)
    {
        Console.WriteLine(frase);
        string dato = Console.ReadLine();
        return dato;
    }

    private void AnyadirPaciente()
    {
        string nombre = PedirDato("Nombre?");
        string apellido = PedirDato("Apellido?");
        int codigo = Convert.ToInt32(PedirDato("Codigo?"));

        pacientes[contadorPacientes] = new Paciente(apellido
           +", " + nombre, codigo);
        contadorPacientes++;
    }

    private void MostrarPacientes()
    {
        for (int i = 0; i < contadorPacientes; i++)
        {
            Console.WriteLine(pacientes[i]);
            Console.WriteLine(pacientes[i].Nombre);
        }
    }

    private void BuscarPaciente()
    {
        string texto = PedirDato("Nombre o apellido");
        for (int i = 0; i < contadorPacientes; i++)
        {
            if (pacientes[i].Nombre.Contains(texto))
            {
                Console.WriteLine(pacientes[i].ToString());
            }
        }
    }

    private Paciente BuscarPacienteCodigo(int codigo)
    {
        Paciente pacienteEncontrado = null;
        for (int i = 0; i < contadorPacientes; i++)
        {
            if (codigo == pacientes[i].Codigo)
            {
                pacienteEncontrado = pacientes[i];
            }
        }
        return pacienteEncontrado;
    }

    private Medico BuscarMedicoCodigo(int codigo)
    {
        Medico medicoEncontrado = null;
        for (int i = 0; i < contadorMedicos; i++)
        {
            if (codigo == medicos[i].Codigo)
            {
                medicoEncontrado = medicos[i];
            }
        }
        return medicoEncontrado;
    }

    private void AnyadirVisita()
    {
        string tipoVisita = PedirDato("Elija el tipo de visita " +
            "(U)urgencia (P)Planificada");
        if (tipoVisita == "P")
        {
            int codigoMedico = Convert.ToInt32(PedirDato("Codigo medico?"));
            Medico medico = BuscarMedicoCodigo(codigoMedico);
            int codigoPaciente = Convert.ToInt32(PedirDato("Codigo paciente?"));
            Paciente paciente = BuscarPacienteCodigo(codigoPaciente);

            string motivo = PedirDato("Motivo?");
            string diagnostico = PedirDato("Diagnostico?");
            visitas[contadorVisitas] = new Planificada(paciente, medico,
                  DateTime.Now, motivo, diagnostico);
            Console.WriteLine("Prevista");

        }
        else if (tipoVisita == "U")
        {
            int codigoMedico = Convert.ToInt32(PedirDato("Codigo medico?"));
            Medico medico = BuscarMedicoCodigo(codigoMedico);
            int codigoPaciente = Convert.ToInt32(PedirDato("Codigo paciente?"));
            Paciente paciente = BuscarPacienteCodigo(codigoPaciente);
            bool revision = Convert.ToBoolean(PedirDato("Revision true/false?"));

            string motivo = PedirDato("Motivo?");
            string diagnostico = PedirDato("Diagnostico?");
            visitas[contadorVisitas] = new Urgencia(paciente, medico,
                  DateTime.Now, motivo, diagnostico, revision);

            Console.WriteLine("Urgencia");

        }
        else
        {
            Console.WriteLine("Faltan datos");
        }
        Console.WriteLine("Visita añadida!!");
        contadorVisitas++;
    }

    private void VerVisitas()
    {
        for (int i = 0; i <= contadorVisitas; i++)
        {
            Console.WriteLine(visitas[i]);
        }
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
