// Rocio (...), retoques por Nacho

/*
71. Contabilidad doméstica (fragmento del examen del tema 4, grupo presencial, de 2013-2014)

Crea un programa en C# que pueda almacenar hasta 10000 gastos e ingresos, para
crear un pequeño sistema de contabilidad doméstica. Para cada gasto (o
ingreso), debe permitir guardar los siguientes datos:

- Fecha (8 caracteres: formato AAAAMMDD)
- Descripción del gasto o ingreso (por ejemplo, "Ampliación de RAM para el ordenador")
- Categoría (por ejemplo, "estudios")
- Importe (positivo si es un ingreso, negativo si es un gasto)

El programa debe permitir al usuario realizar las siguientes operaciones:

1- Añadir un nuevo gasto (o ingreso; la fecha debe "parecer correcta": día de
01 a 31, mes de 01 a 12, año entre 1000 y 3000, y se volverá a pedir si no es
así). La descripción no debe estar vacía. No hace falta validar los demás
datos.

2- Mostrar todos los gastos (o ingresos) de una cierta categoría (por ejemplo,
"estudios"). Al final de todos los datos se mostrará el importe total de los
datos mostrados. Se mostrarán todos los datos de cada gasto, en una misma
línea.

3- Buscar gastos (o ingresos) cuya descripción sea la que introduzca el
usuario.

4- Modificar una ficha (pedirá el número de ficha al usuario; se mostrará el
valor anterior de cada campo y se podrá pulsar Intro para no modificar alguno
de los datos). Se debe avisar (pero no volver a pedir) si el usuario introduce
un número de ficha incorrecto. No hace falta validar ningún dato.

5- Borrar un cierto dato, a partir del número de registro que indique el
usuario. Se debe avisar (pero no volver a pedir) si introduce un número
incorrecto. Se debe mostrar la ficha que se va a borrar y pedir confirmación
antes de proceder al borrado.

T- Terminar el uso de la aplicación (como no sabemos almacenar la información,
los datos se perderán)

*/

using System;

struct tipoFecha
{
    public int anyo;
    public int mes;
    public int dia;
}

struct tipoGasto
{
    public tipoFecha fecha;
    public string descripcion;
    public string categoria;
    public int importe;
}

enum menu { ANYADIR = '1', MOSTRAR, BUSCAR, MODIFICAR, BORRAR,
    TERMINAR = 't', TERMINAR2 = 'T'}

class contabilidad71
{
    static void Main()
    {
        const int MAXIMO = 10000;
        tipoGasto[] gastos = new tipoGasto[MAXIMO];
        int contador = 0;
        int sumaMostrar = 0, ficha = 0;
        string buscar;
        char seleccion;
        bool terminado = false;

        do
        {
            Console.WriteLine((char) menu.ANYADIR + ". Añadir un nuevo gasto o "
               + "ingreso");
            Console.WriteLine((char) menu.MOSTRAR + ". Mostrar todos los gastos "
                + "(o ingresos) de una cierta categoría");
            Console.WriteLine((char) menu.BUSCAR + ". Buscar gastos (o ingresos)");
            Console.WriteLine((char) menu.MODIFICAR + ". Modificar una ficha");
            Console.WriteLine((char) menu.BORRAR + ". Borrar un cierto dato");
            Console.WriteLine((char) menu.TERMINAR + ". Terminar");

            Console.Write("Escoja una opción: ");
            seleccion = Convert.ToChar(Console.ReadLine());

            switch (seleccion)
            {
                case (char) menu.ANYADIR:

                    do
                    {
                        Console.Write("Introduzca el año: ");
                        gastos[contador].fecha.anyo =
                            Convert.ToInt32(Console.ReadLine());
                        if (gastos[contador].fecha.anyo < 1000 ||
                            gastos[contador].fecha.anyo > 3000)
                        {
                            Console.WriteLine("Año no valido, vuelva a " +
                                "introducir el año.");
                        }

                    } while (gastos[contador].fecha.anyo < 1000 ||
                    gastos[contador].fecha.anyo > 3000);

                    do
                    {
                        Console.Write("Introduzca el mes: ");
                        gastos[contador].fecha.mes =
                            Convert.ToInt32(Console.ReadLine());
                        if (gastos[contador].fecha.mes < 1 ||
                            gastos[contador].fecha.mes > 12)
                        {
                            Console.Write("Mes no valido, vuelva a " +
                                "introducir el mes.");
                        }
                    } while (gastos[contador].fecha.mes < 1 ||
                    gastos[contador].fecha.mes > 12);

                    do
                    {
                        Console.Write("Introduzca el dia: ");
                        gastos[contador].fecha.dia =
                            Convert.ToInt32(Console.ReadLine());
                        if (gastos[contador].fecha.dia < 1 ||
                            gastos[contador].fecha.dia > 31)
                        {
                            Console.WriteLine("Día no valido, vuelva a " +
                                "introducir el dia.");
                        }
                    } while (gastos[contador].fecha.dia < 1 ||
                    gastos[contador].fecha.dia > 32);

                    do
                    {
                        Console.Write("Introduzca la descripción del " +
                            "gasto/ingreso: ");
                        gastos[contador].descripcion = Console.ReadLine();
                        if (gastos[contador].descripcion == "")
                        {
                            Console.WriteLine("No debe estar vacía, vuelva a " +
                                "introducir la descripción.");
                        }
                    } while (gastos[contador].descripcion == "");

                    Console.Write("Introduzca la categoria del gasto/ingreso: ");
                    gastos[contador].categoria = Console.ReadLine();

                    Console.Write("Introduzca el importe del gasto/ingreso: ");
                    gastos[contador].importe = Convert.ToInt32(Console.ReadLine());

                    contador++;
                    Console.WriteLine();
                    break;

                case (char) menu.MOSTRAR:
                    Console.Write("De que categoria quiere ver el " +
                        "gasto/ingreso?");
                    buscar = Console.ReadLine();
                    for (int i = 0; i < contador; i++)
                    {
                        if (buscar == gastos[i].categoria)
                        {
                            Console.WriteLine("{0}. fecha: {1}/{2}/{3}, " +
                                "descripción: {4}, categoria: {5}, importe:" +
                                " {6} euros",
                                i + 1,
                                gastos[i].fecha.anyo.ToString("00"),
                                gastos[i].fecha.mes.ToString("00"),
                                gastos[i].fecha.dia.ToString("00"),
                                gastos[i].descripcion, gastos[i].categoria,
                                gastos[i].importe);
                            sumaMostrar += gastos[i].importe;
                        }
                    }
                    Console.WriteLine("Total: {0} euros", sumaMostrar);
                    Console.WriteLine();
                    break;

                case (char) menu.BUSCAR:
                    Console.Write("De que descripción quiere buscar?");
                    buscar = Console.ReadLine();
                    for (int i = 0; i < contador; i++)
                    {
                        if (buscar == gastos[i].descripcion)
                        {
                            Console.WriteLine("{0}. fecha: {1}/{2}/{3}, " +
                                "descripción: {4}, categoria: {5}, importe:" +
                                " {6} euros",
                                i + 1,
                                gastos[i].fecha.anyo.ToString("00"),
                                gastos[i].fecha.mes.ToString("00"),
                                gastos[i].fecha.dia.ToString("00"),
                                gastos[i].descripcion, gastos[i].categoria,
                                gastos[i].importe);
                        }
                    }
                    Console.WriteLine();
                    break;

                case (char) menu.MODIFICAR:

                    Console.WriteLine("Introduzca el numero de ficha:");
                    ficha = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Posicion {0}", ficha);
                    ficha = ficha - 1;

                    Console.WriteLine("fecha:{0}/{1}/{2} ", gastos[ficha]
                        .fecha.anyo, gastos[ficha].fecha.mes,
                        gastos[ficha].fecha.dia);

                    Console.WriteLine("Introduzca el año: ");
                    string nuevoyear = Console.ReadLine();
                    if (nuevoyear != "")
                    {
                        gastos[ficha].fecha.anyo =
                            Convert.ToInt32(nuevoyear);
                    }

                    Console.WriteLine("Introduzca el mes");
                    string nuevomes = Console.ReadLine();
                    if (nuevomes != "")
                    {
                        gastos[ficha].fecha.mes =
                            Convert.ToInt32(nuevomes);
                    }

                    Console.WriteLine("Introduzca el dia: ");
                    string nuevodia = Console.ReadLine();
                    if (nuevodia != "")
                    {
                        gastos[ficha].fecha.dia =
                            Convert.ToInt32(nuevodia);

                    }

                    Console.WriteLine("Descripción del gasto: "
                        + gastos[ficha].descripcion);
                    Console.WriteLine("Introduzca la descripción del " +
                        "gasto/ingreso: ");
                    string nuevaDescripcion = Console.ReadLine();
                    if (nuevaDescripcion != "")
                    {
                        gastos[ficha].descripcion = nuevaDescripcion;
                    }

                    Console.WriteLine("Categoria: " + gastos[ficha].categoria);
                    Console.WriteLine("Introduzca la categoria del gasto/ingreso: ");
                    string nuevaCategoria = Console.ReadLine();
                    if (nuevaCategoria != "")
                    {
                        gastos[ficha].categoria = nuevaCategoria;
                    }

                    Console.WriteLine("Importe: {0} euros ",
                        gastos[ficha].importe);
                    Console.WriteLine("Introduzca el importe del gasto/ingreso: ");
                    string nuevoImporte = Console.ReadLine();
                    if (nuevoImporte != "")
                    {
                        gastos[ficha].importe = Convert.ToInt32(nuevoImporte);
                    }
                    Console.WriteLine();
                    break;

                case (char) menu.BORRAR:
                    Console.Write("Posicion del fichero que desea borrar:");
                    ficha = Convert.ToInt32(Console.ReadLine()) - 1;
                    if ((ficha < 0) || (ficha >= contador))
                    {
                        Console.WriteLine("Dato no valido");
                    }
                    else
                    {

                        Console.WriteLine("numero de ficha:" + ficha);
                        Console.WriteLine("fecha: {0}/{1}/{2}, descpipción:"
                                   + " {3}, categoria: {4}, importe: {5} euros",
                                    gastos[ficha].fecha.anyo.ToString("00"),
                                    gastos[ficha].fecha.mes.ToString("00"),
                                    gastos[ficha].fecha.dia.ToString("00"),
                                    gastos[ficha].descripcion,
                                    gastos[ficha].categoria,
                                    gastos[ficha].importe);
                        Console.Write("Desea borrarlo definitivamente? si/no ");
                        string respuesta = Console.ReadLine();
                        if (respuesta == "si")
                        {
                            for (int i = ficha; i < contador-1; i++)
                            {
                                gastos[i] = gastos[i + 1];
                            }
                            contador--;
                            Console.WriteLine("Se ha borrado los datos"); ;
                        }
                    }

                    break;

                case (char) menu.TERMINAR:
                case (char) menu.TERMINAR2:
                    terminado = true;

                    break;

                default:
                    Console.WriteLine("Opción incorrecta");
                    break;
            }

        } while (! terminado);
        Console.WriteLine("Hasta otra!");

    }
}
