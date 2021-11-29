/*
Contabilidad doméstica

Crea un programa en C# que pueda almacenar hasta 10000 gastos e ingresos, para 
crear un pequeño sistema de contabilidad doméstica. Para cada gasto (o 
ingreso), debe permitir guardar los siguientes datos:

- Fecha (8 caracteres: formato AAAAMMDD)

- Descripción del gasto o ingreso

- Categoría

- Importe (positivo si es un ingreso, negativo si es un gasto)

El programa debe permitir al usuario realizar las siguientes operaciones:

1- Añadir un nuevo gasto (la fecha debe "parecer correcta": día de 01 a 31, mes 
de 01 a 12, año entre 1000 y 3000, y se volverá a pedir si no es así). La 
descripción no debe estar vacía. No hace falta validar los demás datos.

2- Mostrar todos los gastos de una cierta categoría (por ejemplo, "estudios") 
entre dos ciertas fechas (por ejemplo entre "20110101" y "20111231"). Se 
mostrará número, fecha (en formato DD/MM/AAAA), descripción, categoría entre 
paréntesis, e importe con dos decimales, todo ello en la misma línea, separado 
por guiones. Al final de todos los datos se mostrará el importe total de los 
datos mostrados.

3- Buscar gastos que contengan un cierto texto (en la descripción o en la 
categoría, sin distinguir mayúsculas ni minúsculas). Se mostrará número, fecha 
y descripción (la descripción se mostrará truncada en el sexto espacio en 
blanco, en caso de existir seis espacios o más).

4- Modificar una ficha (pedirá el número de ficha al usuario; se mostrará el 
valor anterior de cada campo y se podrá pulsar Intro para no modificar alguno 
de los datos). Se debe avisar (pero no volver a pedir) si el usuario introduce 
un número de ficha incorrecto. No hace falta validar ningún dato.

5- Borrar un cierto dato, a partir del número que indique el usuario. Se debe 
avisar (pero no volver a pedir) si introduce un número incorrecto. Se debe 
mostrar la ficha que se va a borrar y pedir confirmación antes de proceder al 
borrado.

6- Ordenar los datos alfabéticamente, según fecha y (en caso de coincidir) 
descripción.

7- Normalizar descripciones: eliminar espacios finales, espacios iniciales y 
espacios duplicados. Si alguna descripción está totalmente en mayúsculas, se 
convertirá a minúsculas (excepto la primera letra, que se conservará en 
mayúsculas).

T- Terminar el uso de la aplicación (como no sabemos almacenar la información, 
los datos se perderán)

*/

// Por Virginia, retoques por Nacho

using System;
using System.Text;

class ContabilidadV2
{
    struct tipoGasto
    {
        public string fecha;
        public string descripcion;
        public string categoria;
        public float importe;
    }

    static void Main()
    {
        const int MAXIMO = 10000;
        tipoGasto[] gastos = new tipoGasto[MAXIMO];
        tipoGasto temporal;
        int contador = 0;
        int numFicha;
        string respuesta;
        bool salir = false;
        string opcion;
        StringBuilder cadenaMod;

        do
        {
            Console.WriteLine();
            Console.WriteLine("-------------------MENÚ----------------------");
            Console.WriteLine("1. Añadir un nuevo gasto");
            Console.WriteLine("2. Mostrar todos los gastos de una cierta categoría");
            Console.WriteLine("3. Buscar gastos que contengan un cierto texto");
            Console.WriteLine("4. Modificar una ficha ");
            Console.WriteLine("5. Borrar un cierto dato");
            Console.WriteLine("6. Ordenar los datos");
            Console.WriteLine("7. Normalizar descripciones");
            Console.WriteLine("T. Terminar");

            Console.WriteLine("Escoja una opción: ");
            opcion = Console.ReadLine().ToUpper();

            switch (opcion)
            {
                case "1": //Añadir
                
                    if (contador < MAXIMO)
                    {

                        int anyoTemporal;
                        byte mesTemporal, diaTemporal;

                        do
                        {
                            Console.Write("Año del gasto/ingreso: ");
                            anyoTemporal = Convert.ToInt32(Console.ReadLine());

                            if (anyoTemporal < 1000 || anyoTemporal > 3000)
                            {
                                Console.WriteLine("Año no válido.");
                            }
                        }
                        while (anyoTemporal < 1000 || anyoTemporal > 3000);

                        do
                        {
                            Console.Write("Mes del gasto/ingreso: ");
                            mesTemporal = Convert.ToByte(Console.ReadLine());

                            if (mesTemporal > 12 || mesTemporal < 1)
                            {
                                Console.WriteLine("Mes no válido.");
                            }
                        }
                        while (mesTemporal > 12 || mesTemporal < 1);

                        do
                        {
                            Console.Write("Día del gasto/ingreso: ");
                            diaTemporal = Convert.ToByte(Console.ReadLine());

                            if (diaTemporal > 31 || diaTemporal < 1)
                            {
                                Console.WriteLine("Día no válido.");
                            }
                        }
                        while (diaTemporal > 31 || diaTemporal < 1);
                        gastos[contador].fecha = anyoTemporal.ToString() +
                            mesTemporal.ToString("00") +
                            diaTemporal.ToString("00");

                        do
                        {
                            Console.Write("Descripción del gasto/ingreso: ");
                            respuesta = Console.ReadLine();

                            if (respuesta == "")
                            {
                                Console.WriteLine("El campo \"descripción\" no" +
                                    "puede quedar vacío.");
                            }
                        }
                        while (respuesta == "");
                        gastos[contador].descripcion = respuesta;

                        Console.Write("Categoría del gasto/ingreso: ");
                        gastos[contador].categoria = Console.ReadLine();

                        Console.Write("Importe del gasto/ingreso: ");
                        gastos[contador].importe =
                            Convert.ToSingle(Console.ReadLine());
                        contador++;
                    }
                    else
                    {
                        Console.WriteLine("No caben más datos");
                    }
                    break;

                case "2": // Mostrar
                    Console.Write("Categoría de los datos a mostrar: ");
                    string categoria = Console.ReadLine();
                    Console.WriteLine("Mostrar datos desde la fecha (AAAAMMDD): ");
                    string fechaInferior = Console.ReadLine();
                    Console.WriteLine("Hasta la fecha (AAAAMMDD): ");
                    string fechaSuperior = Console.ReadLine();

                    float sumaImportes = 0;
                    for (int i = 0; i < contador; i++)
                    {
                        if (gastos[i].categoria == categoria &&
                            gastos[i].fecha.CompareTo(fechaInferior) >= 0 &&
                            gastos[i].fecha.CompareTo(fechaSuperior) <= 0)
                        {
                            string fechaMostrar =
                                gastos[i].fecha.Substring(6, 2) + "/" +
                                gastos[i].fecha.Substring(4, 2) + "/" +
                                gastos[i].fecha.Substring(0, 4);
                            Console.WriteLine("{0} - {1} - {2} - " +
                                "({3}) - {4}",
                                i + 1,
                                fechaMostrar,
                                gastos[i].descripcion,
                                gastos[i].categoria,
                                gastos[i].importe.ToString("N2"));

                            sumaImportes += gastos[i].importe;
                        }
                    }
                    Console.WriteLine("Importe total de los datos mostrados: " +
                        sumaImportes.ToString("N2"));
                    break;

                case "3": // Buscar
                    Console.Write("Texto a buscar: ");
                    respuesta = Console.ReadLine().ToLower();

                    for (int i = 0; i < contador; i++)
                    {
                        if (gastos[i].descripcion.ToLower().Contains(respuesta) ||
                            gastos[i].categoria.ToLower().Contains(respuesta))
                        {
                            cadenaMod =
                                new StringBuilder(gastos[i].descripcion);
                            int espacios = 0;
                            int posicion = 0;
                            string descripTruncada;

                            do
                            {
                                if (cadenaMod[posicion] == ' ')
                                {
                                    espacios++;
                                }
                                posicion++;
                            } 
                            while (espacios < 6 && posicion < cadenaMod.Length);

                            if (espacios < 6)
                            {
                                descripTruncada = gastos[i].descripcion;
                            }
                            else
                            {
                                descripTruncada = gastos[i].descripcion.
                                    Substring(0, posicion - 2);
                            }

                            Console.WriteLine("{0} - {1} - {2}",
                                i + 1,
                                gastos[i].fecha,
                                descripTruncada);
                        }
                    }
                    break;

                case "4": // Modificar
                    Console.Write("Número de ficha a modificar: ");
                    numFicha = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (numFicha < 0 || numFicha >= contador)
                    {
                        Console.WriteLine("Número de ficha no válido.");
                    }
                    else
                    {
                        Console.WriteLine("---Fecha anterior: {0}",
                            gastos[numFicha].fecha);
                        Console.WriteLine("---Nueva fecha: ");
                        respuesta = Console.ReadLine();

                        if (respuesta != "")
                        {
                            gastos[numFicha].fecha = respuesta;
                        }

                        Console.WriteLine("---Descripción anterior: {0}",
                            gastos[numFicha].descripcion);
                        Console.WriteLine("---Nueva descripción: ");
                        respuesta = Console.ReadLine();

                        if (respuesta != "")
                        {
                            gastos[numFicha].descripcion = respuesta;
                        }

                        Console.WriteLine("---Categoría anterior: {0}",
                            gastos[numFicha].categoria);
                        Console.WriteLine("---Nueva categoría: ");
                        respuesta = Console.ReadLine();

                        if (respuesta != "")
                        {
                            gastos[numFicha].categoria = respuesta;
                        }

                        Console.WriteLine("---Importe anterior: {0}",
                            gastos[numFicha].descripcion);
                        Console.WriteLine("---Nuevo importe: ");
                        respuesta = Console.ReadLine();

                        if (respuesta != "")
                        {
                            gastos[numFicha].importe =
                                Convert.ToInt32(respuesta);
                        }
                    }
                    break;

                case "5": // Borrar
                    Console.Write("Número de ficha a borrar: ");
                    numFicha = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (numFicha < 0 || numFicha >= contador)
                    {
                        Console.WriteLine("Número de ficha no válido.");
                    }
                    else
                    {
                        Console.WriteLine("Ficha que se va a borrar: ");
                        Console.WriteLine("Fecha: " + gastos[numFicha].fecha);
                        Console.WriteLine("Descripción: " +
                            gastos[numFicha].descripcion);
                        Console.WriteLine("Categoría: " +
                            gastos[numFicha].categoria);
                        Console.WriteLine("Importe: " +
                            gastos[numFicha].importe.ToString("N2"));

                        Console.WriteLine();
                        Console.WriteLine("¿Desea borrarlo definitivamente? " +
                            "S/N");
                        respuesta = Console.ReadLine();

                        if (respuesta.ToLower() == "s")
                        {
                            for (int i = numFicha; i < contador - 1; i++)
                            {
                                gastos[i] = gastos[i + 1];
                            }
                            contador--;
                        }
                        else
                        {
                            Console.WriteLine("No se ha borrado el registro.");
                        }
                    }
                    break;

                case "6": // Ordenar
                    for (int i = 0; i < contador - 1; i++)
                    {
                        int menor = Convert.ToInt32(gastos[i].fecha);
                        for (int j = i + 1; j < contador; j++)
                        {
                            int fechaEntero = Convert.ToInt32(gastos[j].fecha);
                            if (fechaEntero < menor)
                            {
                                temporal = gastos[i];
                                gastos[i] = gastos[j];
                                gastos[j] = temporal;
                            }
                            else if (fechaEntero == menor)
                            {
                                if (string.Compare(gastos[j].descripcion,
                                    gastos[i].descripcion, true) < 0)
                                {
                                    temporal = gastos[i];
                                    gastos[i] = gastos[j];
                                    gastos[j] = temporal;
                                }
                            }
                        }
                    }
                    Console.WriteLine("Datos ordenados!");
                    break;

                case "7": // Normalizar
                    for (int i = 0; i < contador; i++)
                    {
                        // Espacios iniciales y finales
                        gastos[i].descripcion = gastos[i].descripcion.Trim();

                        // Espacios intermedios
                        do
                        {
                            gastos[i].descripcion.Replace("  ", " ");
                        } 
                        while (gastos[i].descripcion.Contains("  "));

                        // Todo en mayúsculas?
                        if (gastos[i].descripcion.ToUpper() == gastos[i].descripcion)
                        {
                            string textoAnterior = gastos[i].descripcion;
                            gastos[i].descripcion = textoAnterior[0] +
                                textoAnterior.ToLower().Substring(1);
                        }
                        Console.WriteLine("Normalizado!");
                    }
                    break;

                case "T":  // Terminar
                    salir = true;
                    break;
            }
        } while (!salir);
        Console.WriteLine("Hasta otra!");
    }
}
