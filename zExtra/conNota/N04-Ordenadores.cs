/*
Cuarto ejercicio con nota (tema 5)

Propuesta desarrollada por Javier (...), retoques mínimos por Nacho

Crea un programa en C# que permita almacenar hasta 500 fichas de ordenadores
clásicos. Para cada ordenador, debes guardar los siguientes datos:

Marca (por ejemplo, Amstrad)
Modelo (p.ej. CPC664)
Año (p.ej. 1984)
RAM (conjunto de 2 datos: la unidad de medida, por ejemplo, Kb, y el tamaño,
    por ejemplo, 64)
Comentarios


El programa debe permitir al usuario las siguientes operaciones:

1 - Añadir un ordenador. La marca no debe estar vacía. El modelo no debe ocupar
más de 50 letras, y se debe volver a pedir en caso de que no se cumpla este
requisito. Si el año es anterior a 1900, debe ser almacenado como 0, para
indicar que no es válido).

2 - Mostrar todas las marcas y modelos de ordenadores almacenados. Cada
ordenador (marca y modelo) debe aparecer en una línea, separada por un guion
(por ejemplo, "Amstrad - CPC664"). El programa debe hacer una pausa después de
mostrar cada bloque de 24 ordenadores, mostrar el mensaje "Pulse Intro para
continuar" y esperar hasta que el usuario pulse Intro. Se debe avisar al
usuario si no hay datos.

3 - Buscar ordenadores que contengan un determinado texto (como parte de su
marca, modelo o comentarios, sin distinción de mayúsculas y minúsculas). Si el
año es 0, se deberá mostrar: "Año: desconocido". Los datos se deben mostrar en
líneas separadas, con una línea en blanco adicional después de cada ordenador.
Se debe avisar al usuario si no se encuentra ninguno.

4 - Modificar un registro (el programa solicitará el número, mostrará el valor
anterior de cada campo y el usuario podrá pulsar Intro para no modificar alguno
de los datos). Se debe advertir al usuario (pero no volver a preguntarle) si
introduce un número de registro incorrecto. No es necesario validar ninguno de
los campos.

5 - Eliminar un registro, en la posición indicada por el usuario. Se le debe
avisar (pero no volver a preguntarle) si introduce un número de registro
incorrecto. Se debe mostrar el dato que se va a borrar y pedir confirmación.

6 - Ordenar los datos alfabéticamente por marca + modelo.

7 - Eliminar espacios sobrantes (espacios iniciales, finales y duplicados en
todas las marcas, modelos y comentarios. Por ejemplo, un comentario como "
Datos   de prueba  " se convertirá en "Datos de prueba".

S - Salir (como no almacenamos la información, se perderá).

-------------

Cada opción del menú principal debe estar extraída a una función. Por lo
general, cada una de estas funciones deberá recibir como parámetros el array
con los datos y el contador de cuántos datos hay almacenados (quizá como
parámetro "ref"), de modo que no existan variables locales, sino variables
locales y datos pasados como parámetros.

Además de las funciones que consideres adecuadas para descomponer el problema,
DEBES crear las siguientes funciones:

// Para simplificar el "Añadir"; será un WriteLine seguido de un ReadLine
string Pedir(string aviso)
// Para simplificar el "Añadir" en el caso de datos que no deban estar vacíos
// Se encargará de pedir tantas veces como sea necesario
string PedirNoVacio(string aviso)
// Para simplificar el "Modificar"
string Modificar(string nombreCampo, string valorAnterior)
// Para simplificar la opción de buscar y la de borrar
void MostrarUnDato(Ordenador[] datos, int pos)

También puedes crear las funciones adicionales que consideres convenientes,
donde veas que tienes tareas repetitivas (por ejemplo, puede ser útil una
que elimine los espacios sobrantes de una cadena).

*/

using System;

class OrdenadoresClasicos
{
    struct tipoRam
    {
        public string tipo;
        public int tamanyo;
    }

    struct tipoOrdenador
    {
        public string marca;
        public string modelo;
        public ushort anyo;
        public tipoRam ram;
        public string comentarios;
    }

    static void Main()
    {
        const int MAX = 500;
        tipoOrdenador[] pcs = new tipoOrdenador[MAX];
        string opcion;
        bool terminado = false;
        int cont = 0;

        do
        {
            Console.WriteLine();
            Console.WriteLine("1. Añadir un ordenador");
            Console.WriteLine("2. Mostrar marca y modelo de los ordenadores");
            Console.WriteLine("3. Buscar ordenadores por texto");
            Console.WriteLine("4. Modificar un registro");
            Console.WriteLine("5. Eliminar un registro");
            Console.WriteLine("6. Ordenar los datos (marca + modelo)");
            Console.WriteLine("7. Eliminar espacios sobrantes");
            Console.WriteLine("S. Salir");
            Console.WriteLine();
            opcion = Console.ReadLine().ToUpper();

            switch (opcion)
            {
                case "1": Anyadir(ref pcs, ref cont, MAX); break;
                case "2": Mostrar(pcs, cont); break;
                case "3": Buscar(pcs, cont); break;
                case "4": ModificarRegistro(ref pcs, cont); break;
                case "5": Eliminar(ref pcs, ref cont); break;
                case "6": Ordenar(ref pcs, cont); break;
                case "7": EliminarEspacios(ref pcs, cont); break;
                case "S": terminado = true; break;
                default: Console.WriteLine("Opción incorrecta"); break;
            }
        }
        while (!terminado);

        Console.WriteLine("No se puede almancenar la información y se " +
            "perderán los datos. Hasta la próxima!");
    }


    /* --- Funciones para descomponer el problema --- */

    static void Anyadir(ref tipoOrdenador[] pcs, ref int cont, int MAX)
    {
        if (cont < MAX)
        {
            Console.WriteLine("Introduce los datos del ordenador");
            pcs[cont].marca = PedirNoVacio("marca");
            pcs[cont].modelo = PedirTamanyoMaximo("modelo", 50);
            pcs[cont].anyo = PedirAnyoCorrecto("anyo");
            pcs[cont].ram = PedirRam("ram");
            pcs[cont].comentarios = Pedir("comentarios");
            cont++;
        }
        else
            Console.WriteLine("No caben más datos");
    }


    static void Mostrar(tipoOrdenador[] pcs, int cont)
    {
        if (cont > 0)
        {
            for (int i = 0; i < cont; i++)
            {
                Console.WriteLine((i + 1) + ". " + pcs[i].marca + " - " +
                    pcs[i].modelo);

                if (i % 24 == 23)
                {
                    Console.WriteLine("Pulse Intro para continuar");
                    Console.ReadLine();
                }
            }
        }
        else
            Console.WriteLine("No hay datos para mostrar");
    }


    static void Buscar(tipoOrdenador[] pcs, int cont)
    {
        if (cont > 0)
        {
            string texto = Pedir("texto a buscar").ToUpper();

            for (int i = 0; i < cont; i++)
            {
                if (pcs[i].marca.ToUpper().Contains(texto) ||
                        pcs[i].modelo.ToUpper().Contains(texto) ||
                        pcs[i].comentarios.ToUpper().Contains(texto))
                    MostrarUnDato(pcs, i);
            }
        }
        else
            Console.WriteLine("No hay datos para buscar");
    }


    static void ModificarRegistro(ref tipoOrdenador[] pcs, int cont)
    {
        if (cont > 0)
        {
            int pos = PedirNumeroRegistro();

            if (pos < 0 || pos > cont)
                Console.WriteLine("Número de registro no existe");
            else
            {
                pcs[pos].marca = Modificar("marca", pcs[pos].marca);
                pcs[pos].modelo = Modificar("modelo", pcs[pos].modelo);
                pcs[pos].anyo = Convert.ToUInt16(Modificar("anyo",
                    pcs[pos].anyo.ToString()));
                pcs[pos].ram.tipo = Modificar("tipo RAM", pcs[pos].ram.tipo);
                pcs[pos].ram.tamanyo = Convert.ToInt32(Modificar("tamaño RAM",
                    pcs[pos].ram.tamanyo.ToString()));
                pcs[pos].comentarios = Modificar("comentarios",
                    pcs[pos].comentarios);
            }
        }
        else
            Console.WriteLine("No hay datos almacenados");
    }


    static void Eliminar(ref tipoOrdenador[] pcs, ref int cont)
    {
        if (cont > 0)
        {
            int pos = PedirNumeroRegistro();

            if (pos < 0 || pos > cont)
                Console.WriteLine("Ese número de registro no existe");
            else
            {
                MostrarUnDato(pcs, pos);
                Console.Write("Pulse 's' para confirmar: ");
                string confirmar = Console.ReadLine().ToLower();

                if (confirmar == "s")
                {
                    for (int i = pos; i < cont; i++)
                        pcs[i] = pcs[i + 1];

                    cont--;
                    Console.WriteLine("Registro eliminado");
                }
            }
        }
        else
            Console.WriteLine("No hay datos para eliminar");
    }


    static void Ordenar(ref tipoOrdenador[] pcs, int cont)
    {
        if (cont > 0)
        {
            for (int i = 0; i < cont - 1; i++)
            {
                for (int j = i + 1; j < cont; j++)
                {
                    if ((String.Compare(pcs[i].marca, pcs[j].marca, true) > 0)
                        || ((String.Compare(pcs[i].marca, pcs[j].marca, true) == 0)
                            && (String.Compare(pcs[i].modelo,pcs[j].modelo, true) > 0)))
                    {
                        tipoOrdenador aux = pcs[i];
                        pcs[i] = pcs[j];
                        pcs[j] = aux;
                    }
                }
            }
            Console.WriteLine("Datos ordenados");
        }
        else
            Console.WriteLine("No hay datos almacenados");
    }


    static void EliminarEspacios(ref tipoOrdenador[] pcs, int cont)
    {
        if (cont > 0)
        {
            for (int i = 0; i < cont; i++)
            {
                pcs[i].marca = QuitarEspaciosSobrantes(pcs[i].marca);
                pcs[i].modelo = QuitarEspaciosSobrantes(pcs[i].modelo);
                pcs[i].comentarios = QuitarEspaciosSobrantes(pcs[i].comentarios);
            }
            Console.WriteLine("Espacios sobrantes eliminados");
        }
        else
            Console.WriteLine("No hay datos almacenados");
    }


    /* --- Funciones auxiliares obligatorias --- */

    static string Pedir(string aviso)
    {
        Console.Write("Introduce " + aviso + ": ");
        string texto = Console.ReadLine();

        return texto;
    }


    static string PedirNoVacio(string aviso)
    {
        string texto;

        do
        {
            texto = Pedir(aviso);
        }
        while (texto == "");

        return texto;
    }


    static string Modificar(string nombreCampo, string valorAnterior)
    {
        string mensaje = "Introduce nuevo valor para " + nombreCampo +
            "(era " + valorAnterior + "): ";
        string texto = Pedir(mensaje);

        if (texto != "")
            return texto;
        else
            return valorAnterior;
    }


    static void MostrarUnDato(tipoOrdenador[] pcs, int pos)
    {
        Console.WriteLine("Marca: " + pcs[pos].marca);
        Console.WriteLine("Modelo: " + pcs[pos].modelo);
        Console.Write("Año: ");
        if (pcs[pos].anyo == 0)
            Console.WriteLine("desconocido");
        else
            Console.WriteLine(pcs[pos].anyo);

        Console.WriteLine("RAM: " + pcs[pos].ram.tamanyo + " " +
            pcs[pos].ram.tipo);
        Console.WriteLine("Comentarios: " + pcs[pos].comentarios);
        Console.WriteLine();
    }


    /* --- Funciones auxiliares recomendadas --- */

    static string QuitarEspaciosSobrantes(string texto)
    {
        texto = texto.Trim();
        while (texto.Contains("  "))
            texto = texto.Replace("  ", " ");

        return texto;
    }


    /* --- Funciones auxiliares propias --- */

    static string PedirTamanyoMaximo(string aviso, int tamanyoMax)
    {
        bool correcto = false;
        string texto;

        do
        {
            texto = Pedir(aviso);

            if (texto.Length <= tamanyoMax)
                correcto = true;
            else
                Console.WriteLine("El tamaño no puede ser superior a " +
                    + tamanyoMax +
                    "caracteres");
        }
        while (!correcto);

        return texto;
    }


    static ushort PedirAnyoCorrecto(string aviso)
    {
        ushort anyo = 0;

        string texto = Pedir(aviso);

        if (Convert.ToUInt16(texto) >= 1900)
            anyo = Convert.ToUInt16(texto);

        return anyo;
    }


    static tipoRam PedirRam(string aviso)
    {
        tipoRam ram;

        Console.WriteLine("Introduce los datos de la memoria RAM");
        ram.tipo = Pedir("tipo");
        ram.tamanyo = Convert.ToInt32(Pedir("tamaño"));

        return ram;
    }


    static int PedirNumeroRegistro()
    {
        Console.Write("Introduce el número de registro: ");
        int pos = Convert.ToInt32(Console.ReadLine()) - 1;

        return pos;
    }
}

