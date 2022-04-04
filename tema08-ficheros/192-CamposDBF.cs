// Author: Franco (...), retoques por Nacho
/*
 * [Tiempo máximo recomendado: 40 minutos] 
 * 
 * 192. 
 * El formato DBF es el usado por el antiguo gestor de bases de datos dBase, 
 * y soportado como formato de exportación por muchas herramientas actuales, 
 * como Excel o Access. 
 * 
 * Debes crear un programa que muestre la lista 
 * de los campos que hay almacenados en un fichero DBF.
 * 
 * Los archivos DBF se dividen en dos partes: 
 * una cabecera que almacena información sobre la estructura del archivo 
 * y una zona de datos.
 * 
 * La zona de cabecera se separa de la zona de datos con el carácter CR 
 * (avance de carro, número 13 del código ASCII). 
 * 
 * A su vez la cabecera se divide en dos partes: 
 * la primera ocupa 32 bytes y contiene información general sobre el archivo, 
 * mientras que la segunda contiene información sobre cada campo 
 * y está formada por tantos bloques de 32 bytes como campos tenga la tabla.
 * 
 * La cabecera general del archivo es:
 * Posicion     Tamaño (bytes)   Descripcion
 * 1                  1          Nro. que identifica el producto con el fue creada la tabla
 * 2                  3          Fecha ultima actualizacion año/mes/dia
 * 5                  4          Nro.total de registros de la tabla (en orden inverso)
 * 9                  2          Longitud total de la cabecera incluido CR
 * 11                 2          Longitud del registro (incluye el caracter de marca de borrado)
 * 13                 2          Reservados
 * 15                 1          Flag de Transaccion activa
 * 16                 1          Flag de encriptacion
 * 17                 12         Indicadores para el uso en red de area local
 * 29                 1          Flag de fichero de indica .MDX
 * 30                 3          Reservados
 * 
 * La cabecera de cada campo es:
 * Posicion     Tamaño (bytes)   Descripcion
 * 1                  11         Nombre de Campo
 * 12                 1          Tipo de campo (C,D,F,L,M,N)
 * 13                 4          Reservados
 * 17                 1          Longitud de campo
 * 18                 1          Numero de decimales si el campo numerico, 
 *                               tambien usado para campos de caracteres de gran tamaño
 * 19                 2          Reservados
 * 21                 1          Flag de area de trabajo
 * 22                 10         Reservados
 * 32                 1          Flag de inclusion en el indice .MDX
 * 
 * (Se puede observar que la cantidad de campos no se indica en la cabecera, 
 * pero se puede deducir, 
 * sabiendo la longitud de la cabecera, 
 * que está en las posiciones 9 y 10, 
 * y el tamaño de cada bloque de cabecera, 
 * que es de 32 bytes).
 */

using System;
using System.IO;

class ej192 
{ 
    static void Main() 
    {
        //Console.WriteLine("¿Nombre del fichero?");
        //string nombreFichero = Console.ReadLine();
        string nombreFichero = "ficherosEjemplo\\CUSTOMER.DBF";

        if (!File.Exists(nombreFichero))
        {
            Console.WriteLine("El fichero no existe.");
        }
        else 
        {

            try
            {
                FileStream fichero = File.OpenRead(nombreFichero);
                fichero.Seek(8, SeekOrigin.Begin);
                int posicionDatos = fichero.ReadByte();  // Válido para max 7 campos
                int cantidadCampos = posicionDatos / 32;
                byte[] datos = new byte[32];
                fichero.Seek(32, SeekOrigin.Begin);

                for (int i = 0; i < cantidadCampos - 1; i++) 
                {
                    fichero.Read(datos, 0, 32);
                    for (int j = 0; j < 11; j++)
                    {
                        char letra = Convert.ToChar((byte)datos[j]);
                        Console.Write(letra);
                    }  
                    Console.WriteLine();
                }
                fichero.Close();

            }
            catch (PathTooLongException ptee)
            {
                Console.WriteLine("Error en el nombre: " + ptee.Message);
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Error de lectura/escritura, " + ioe.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }
    }
}
