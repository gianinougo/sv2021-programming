// Ejercicio recomendado 100
// Javier (...), retoques por Nacho

/*

Ejercicio 75:

Crea una nueva versión del ejercicio 75 (Contabilidad doméstica), en el que 
cada opción del menú principal se haya extraído a una función. Por lo general, 
cada una de estas funciones deberá recibir como parámetros el array con los 
datos y el contador de cuántos datos hay almacenados (quizá como parámetro 
"ref"), de modo que no existan variables locales, sino variables locales y 
datos pasados como parámetros.

Ejercicio 100:

Contabilidad doméstica (examen del tema 4, grupo presencial, de 2013-2014, 
versión completa)

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

using System;

class ContabilidadDomestica
{
    struct tipoMovimiento
    {
        public string fecha;
        public string descripcion;
        public string categoria;
        public double importe;
    }
    static void Main()
    {
        const int MAX = 10000;
        const string NO_MOVS = "No hay movimientos";
        tipoMovimiento[] movs = new tipoMovimiento[MAX];
        bool salir = false;
        int cont = 0;

        do
        {
            Console.WriteLine();
            Console.WriteLine("1. Añadir nueva ficha");
            Console.WriteLine("2. Mostrar todas las fichas entre 2 fechas");
            Console.WriteLine("3. Buscar fichas");
            Console.WriteLine("4. Modidicar una ficha");
            Console.WriteLine("5. Borrar una ficha");
            Console.WriteLine("6. Ordenar los datos");
            Console.WriteLine("7. Normalizar descripciones");
            Console.WriteLine("T. Salir");
            Console.WriteLine();
            string opcion = Console.ReadLine().ToUpper();

            switch (opcion)
            {
                case "1": AnyadirFicha(MAX, movs, ref cont); break;
                case "2": MostrarFichas(NO_MOVS, movs, cont); break;
                case "3": BuscarFicha(NO_MOVS, movs, cont); break;
                case "4": Modificar(NO_MOVS, ref movs, cont); break;
                case "5": Borrar(NO_MOVS, ref movs, ref cont); break;
                case "6": Ordenar(NO_MOVS, ref movs, cont); break;
                case "7": Normalizar(NO_MOVS, ref movs, cont); break;
                case "T": salir = Salir(); break;
                default: Console.WriteLine("Opción no válida"); break;
            }
        }
        while (!salir);
    }

    static void AnyadirFecha(ref tipoMovimiento[] movs, int cont)
    {
        Console.WriteLine("Introduce la fecha (DD / MM / AAAA):");
        byte dia = AnyadirDia();
        byte mes = AnyadirMes();
        ushort anyo = AnyadirAnyo();

        movs[cont].fecha = anyo.ToString("0000") +
            mes.ToString("00") + dia.ToString("00");
    }
    static byte AnyadirDia()
    {
        bool correcto = false;
        byte dia;

        do
        {
            Console.Write("Día (DD): ");
            dia = Convert.ToByte(Console.ReadLine());
            if (dia > 0 && dia <= 31)
                correcto = true;
            else
                Console.WriteLine("Día no válido");
        }
        while (!correcto);

        return dia;
    }

    static byte AnyadirMes()
    {
        byte mes;
        bool correcto = false;

        do
        {
            Console.Write("Mes (MM): ");
            mes = Convert.ToByte(Console.ReadLine());
            if (mes > 0 && mes <= 12)
                correcto = true;
            else
                Console.WriteLine("Mes no válido");
        }
        while (!correcto);

        return mes;
    }

    static ushort AnyadirAnyo()
    {
        ushort anyo;
        bool correcto = false;

        do
        {
            Console.Write("Año (AAAA): ");
            anyo = Convert.ToUInt16(Console.ReadLine());
            if (anyo >= 1000 && anyo <= 3000)
                correcto = true;
            else
                Console.WriteLine("Anyo no válido");
        }
        while (!correcto);

        return anyo;
    }

    static void AnyadirDescripcion(ref tipoMovimiento[] movs, int cont)
    {
        bool correcto = false;

        do
        {
            Console.WriteLine("Introduce la descripción:");
            movs[cont].descripcion = Console.ReadLine();
            if (movs[cont].descripcion != "")
                correcto = true;
            else
                Console.WriteLine("Debe introducir una descripción");
        }
        while (!correcto);
    }

    static void AnyadirCategoria(ref tipoMovimiento[] movs, int cont)
    {
        Console.Write("Introduce la categoría: ");
        movs[cont].categoria = Console.ReadLine();
    }

    static void AnyadirImporte(ref tipoMovimiento[] movs, int cont)
    {
        Console.Write("Introduce el importe: ");
        movs[cont].importe =
            Convert.ToDouble(Console.ReadLine());
    }

    static void AnyadirFicha(int MAX, tipoMovimiento[] movs, ref int cont)
    {
        if (cont < MAX)
        {
            AnyadirFecha(ref movs, cont);
            AnyadirDescripcion(ref movs, cont);
            AnyadirCategoria(ref movs, cont);
            AnyadirImporte(ref movs, cont);
            cont++;
        }
        else
        {
            Console.WriteLine("No caben más movimientos");
        }
    }

    static void PedirFechaNoVacia(string aviso, ref tipoMovimiento[] movs,
        int ficha)
    {
        Console.Write("Fecha (AAAAMMDD): ");
        do
        {
            movs[ficha].fecha = Console.ReadLine();
        }
        while (movs[ficha].fecha.Length != 8);
    }
    static void MostrarFichas(string NO_MOVS, tipoMovimiento[] movs, int cont)
    {
        bool encontrado = false;
        byte dia, mes, diaFinal, mesFinal;
        ushort anyo, anyoFinal;
        string fecha;

        if (cont > 0)
        {
            double importeTotal = 0;

            Console.WriteLine("Introduce los datos de búsqueda");
            Console.Write("Categoría: ");
            string cat = Console.ReadLine();

            Console.WriteLine("Fecha inicial (AAAAMMDD): ");
            string fechaInicial = Console.ReadLine();

            Console.WriteLine("Fecha final (AAAAMMDD): ");
            string fechaFinal = Console.ReadLine();

            for (int i = 0; i < cont; i++)
            {
                if (movs[i].categoria == cat &&
                    movs[i].fecha.CompareTo(fechaInicial) >= 0 &&
                    movs[i].fecha.CompareTo(fechaFinal) <= 0)
                {
                    encontrado = true;
                    fecha = UnirFecha(movs, i);
                    Console.WriteLine("{0}-{1}-{2}-({3})-({4})",
                        i + 1, fecha, movs[i].descripcion,
                        movs[i].categoria,
                        movs[i].importe.ToString("N2"));

                    importeTotal += movs[i].importe;
                }
            }
            if (encontrado)
            {
                encontrado = false;
                Console.WriteLine("Importe total: " + importeTotal);
            }
            else
                Console.WriteLine("No se han encontrado movimientos con " +
                    "los datos introducidos");
        }
        else
            Console.WriteLine(NO_MOVS);
    }

    static string UnirFecha(tipoMovimiento[] movs, int i)
    {
        string fecha = movs[i].fecha;
        return fecha.Substring(0,4)+"/"+ fecha.Substring(4,2) + "/" +
            fecha.Substring(6, 2);
    }
    static void BuscarFicha(string NO_MOVS, tipoMovimiento[] movs, int cont)
    {
        string fecha;

        if (cont > 0)
        {
            Console.Write("Introduce el texto: ");
            string texto = Console.ReadLine().ToUpper();
            for (int i = 0; i < cont; i++)
            {
                if (movs[i].descripcion.ToUpper().Contains(texto)
                    || movs[i].categoria.ToUpper().Contains(texto))
                {
                    fecha = UnirFecha(movs, i);

                    string des = movs[i].descripcion;
                    int espacios = 0, pos = 0;

                    while (pos >= 0 && espacios < 6 && pos < des.Length)
                    {
                        pos = des.IndexOf(" ", pos);
                        if (pos >= 0)
                        {
                            espacios++;
                            pos++;
                        }
                        if (espacios == 6)
                            des = des.Remove(pos, des.Length);
                    }
                    Console.WriteLine("{0}-{1}-{2}", i + 1, fecha,
                        des);
                }
            }
        }
        else
            Console.WriteLine(NO_MOVS);
    }
    static void Modificar(string NO_MOVS, ref tipoMovimiento[] movs, int cont)
    {
        int ficha;

        if (cont > 0)
        {
            Console.Write("Número de ficha a modificar: ");
            ficha = Convert.ToInt32(Console.ReadLine()) - 1;
            if (ficha >= 0 && ficha < cont)
            {
                string fecha = UnirFecha(movs, ficha);
                Console.WriteLine(fecha);
                PedirFechaNoVacia("Nueva fecha (AAAAMMDD): ", ref movs, ficha);

                Console.WriteLine("Descripción: " + movs[ficha].descripcion);
                Console.Write("Nueva descripción: ");
                string des = Console.ReadLine();
                if (des != "")
                    movs[ficha].descripcion = des;

                Console.WriteLine("Categoría: " + movs[ficha].categoria);
                Console.Write("Nueva categoría: ");
                string cat = Console.ReadLine();
                if (cat != "")
                    movs[ficha].categoria = cat;

                Console.WriteLine("Importe: " + movs[ficha].importe);
                Console.Write("Nuevo importe: ");
                string imp = Console.ReadLine();
                if (imp != "")
                    movs[ficha].importe = Convert.ToDouble(imp);
            }
            else
                Console.WriteLine("Número de ficha erróneo");
        }
        else
            Console.WriteLine(NO_MOVS);
    }

    static void Borrar(string NO_MOVS, ref tipoMovimiento[] movs, ref int cont)
    {
        if (cont > 0)
        {
            Console.Write("Número de ficha a borrar: ");
            int ficha = Convert.ToInt32(Console.ReadLine()) - 1;
            if (ficha >= 0 && ficha < cont)
            {
                for (int i = ficha; i < cont; i++)
                    movs[i] = movs[i + 1];

                cont--;
            }
            else
                Console.WriteLine("Número de ficha erróneo");
        }
        else
            Console.WriteLine(NO_MOVS);
    }

    static void Ordenar(string NO_MOVS, ref tipoMovimiento[] movs, int cont)
    {
        if (cont > 0)
        {
            string fecha1, fecha2;
            for (int i = 0; i < cont - 1; i++)
            {
                fecha1 = movs[i].fecha;
                for (int j = i + 1; j < cont; j++)
                {
                    fecha2 = movs[j].fecha;
                    if ((String.Compare(fecha1, fecha2, true) > 0) ||
                        ((String.Compare(fecha1, fecha2, true) == 0)
                        && (String.Compare(movs[i].descripcion,
                        movs[j].descripcion, true) > 0)))
                    {
                        tipoMovimiento aux = movs[i];
                        movs[i] = movs[j];
                        movs[j] = aux;
                    }
                }
            }
            Console.WriteLine("Datos ordenados");
        }
        else
            Console.WriteLine(NO_MOVS);
    }

    static void Normalizar(string NO_MOVS, ref tipoMovimiento[] movs, int cont)
    {
        if (cont > 0)
        {
            for (int i = 0; i < cont; i++)
            {
                movs[i].descripcion.Trim();
                string des = movs[i].descripcion;
                if (des == des.ToUpper())
                {
                    des = des.Substring(0, 1).ToUpper() +
                        des.Substring(1).ToLower();
                }

                while (des.Contains("  "))
                    des = des.Replace("  ", " ");

                movs[i].descripcion = des;
            }
        }
        else
            Console.WriteLine(NO_MOVS);
    }

    static bool Salir()
    {
        bool salir = true;

        Console.WriteLine("Los datos no pueden ser almacenados " +
        "y se perderán. Hasta la próxima!");

        return salir;
    }
}
