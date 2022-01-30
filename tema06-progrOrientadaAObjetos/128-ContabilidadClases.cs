// 128: Contabilidad + clases

/*
128. Crea una nueva versión del ejercicio 100 (Contabilidad doméstica), usando 
clases en vez de "struct". Los campos se deben convertir en propiedades en 
formato breve (desde Visual Studio, puedes renombrar cada una de ellas con 
Ctrl+RR, para que su nombre pase a comenzar con mayúsculas).

Recuerda que, al contrario que en los "struct", necesitarás inicializar cada 
objeto individual con "new" antes de acceder a sus componentes, en este caso en 
la función "AnyadirFicha".
*/

// Javier (...), retoques por Nacho

using System;

class ContabilidadDomestica
{
    class tipoMovimiento
    {
        public string Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public double Importe { get; set; }
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
            Console.WriteLine("4. Modificar una ficha");
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

        movs[cont].Fecha = anyo.ToString("0000") +
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
            movs[cont].Descripcion = Console.ReadLine();
            if (movs[cont].Descripcion != "")
                correcto = true;
            else
                Console.WriteLine("Debe introducir una descripción");
        }
        while (!correcto);
    }

    static void AnyadirCategoria(ref tipoMovimiento[] movs, int cont)
    {
        Console.Write("Introduce la categoría: ");
        movs[cont].Categoria = Console.ReadLine();
    }

    static void AnyadirImporte(ref tipoMovimiento[] movs, int cont)
    {
        Console.Write("Introduce el importe: ");
        movs[cont].Importe =
            Convert.ToDouble(Console.ReadLine());
    }

    static void AnyadirFicha(int MAX, tipoMovimiento[] movs, ref int cont)
    {
        if (cont < MAX)
        {
            movs[cont] = new tipoMovimiento();
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
            movs[ficha].Fecha = Console.ReadLine();
        }
        while (movs[ficha].Fecha.Length != 8);
    }

    static void MostrarFichas(string NO_MOVS, tipoMovimiento[] movs, int cont)
    {
        bool encontrado = false;
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
                if (movs[i].Categoria == cat &&
                    movs[i].Fecha.CompareTo(fechaInicial) >= 0 &&
                    movs[i].Fecha.CompareTo(fechaFinal) <= 0)
                {
                    encontrado = true;
                    fecha = UnirFecha(movs, i);
                    Console.WriteLine("{0}-{1}-{2}-({3})-({4})",
                        i + 1, fecha, movs[i].Descripcion,
                        movs[i].Categoria,
                        movs[i].Importe.ToString("N2"));

                    importeTotal += movs[i].Importe;
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
        string fecha = movs[i].Fecha;
        return fecha.Substring(0, 4) + "/" + fecha.Substring(4, 2) + "/" +
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
                if (movs[i].Descripcion.ToUpper().Contains(texto)
                    || movs[i].Categoria.ToUpper().Contains(texto))
                {
                    fecha = UnirFecha(movs, i);

                    string des = movs[i].Descripcion;
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

                Console.WriteLine("Descripción: " + movs[ficha].Descripcion);
                Console.Write("Nueva descripción: ");
                string des = Console.ReadLine();
                if (des != "")
                    movs[ficha].Descripcion = des;

                Console.WriteLine("Categoría: " + movs[ficha].Categoria);
                Console.Write("Nueva categoría: ");
                string cat = Console.ReadLine();
                if (cat != "")
                    movs[ficha].Categoria = cat;

                Console.WriteLine("Importe: " + movs[ficha].Importe);
                Console.Write("Nuevo importe: ");
                string imp = Console.ReadLine();
                if (imp != "")
                    movs[ficha].Importe = Convert.ToDouble(imp);
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
                fecha1 = movs[i].Fecha;
                for (int j = i + 1; j < cont; j++)
                {
                    fecha2 = movs[j].Fecha;
                    if ((String.Compare(fecha1, fecha2, true) > 0) ||
                        ((String.Compare(fecha1, fecha2, true) == 0)
                        && (String.Compare(movs[i].Descripcion,
                        movs[j].Descripcion, true) > 0)))
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
                movs[i].Descripcion.Trim();
                string des = movs[i].Descripcion;
                if (des == des.ToUpper())
                {
                    des = des.Substring(0, 1).ToUpper() +
                        des.Substring(1).ToLower();
                }

                while (des.Contains("  "))
                    des = des.Replace("  ", " ");

                movs[i].Descripcion = des;
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
