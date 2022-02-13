using System;

class R04  // Máximo de un array
{
    static void Main()
    {
        int[] datos1 = {1, 2, 3, 4, 5};
        Console.WriteLine("Máx. Iterativo 1: " + MaximoIterativo(datos1, 0 ,4));
        Console.WriteLine("Máx. Recursivo 1: " + MaximoRecursivo(datos1, 0 ,4));
        
        int[] datos2 = {5, 4, 3, 2, 1};
        Console.WriteLine("Máx. Iterativo 2: " + MaximoIterativo(datos2, 0 ,4));
        Console.WriteLine("Máx. Recursivo 2: " + MaximoRecursivo(datos2, 0 ,4));
        
        int[] datos3 = {1, 2, 5, 4, 4};
        Console.WriteLine("Máx. Iterativo 3: " + MaximoIterativo(datos3, 0 ,4));
        Console.WriteLine("Máx. Recursivo 3: " + MaximoRecursivo(datos3, 0 ,4));
    }
    
    static int Maximo(int n1, int n2)
    {
        if (n1 >= n2)
            return n1;
        else
            return n2;
    }
        
    static int MaximoIterativo(int[] array, int desde, int hasta)
    {
        int mayor = array[desde];

        for (int i = desde + 1; i <= hasta; i++)
        {
            if (mayor < array[i])
                mayor = array[i];
        }
        return mayor;
    }

    static int MaximoRecursivo(int[] array, int desde, int hasta)
    {
        if (desde == hasta)
            return array[desde];
        else
            return Maximo(
                array[desde], 
                MaximoRecursivo(array, desde +1, hasta));
    }
}
