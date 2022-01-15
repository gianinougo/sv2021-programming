/* Juan Manuel (...), retoques por Nacho */

/*
 Ejercicio 101.Crea una clase llamada "SpriteTexto", que representará una
 supuesta imagen de un juego en modo de consola. Sus atributos (públicos)
 serán las coordenadas x e y (números enteros) y el carácter que represente
 esa supuesta imagen. Tendrá un método (void) llamado "Dibujar", que mostrará
 ese carácter en la pantalla, en las coordenadas indicadas por sus atributos
 (puedes ayudarte de Console.SetCursorPosition para conseguir que el texto
 aparezca realmente en esas coordenadas). Crea una clase "PruebaDeSprite"
 (en el mismo fichero fuente), que tendrá un "Main" para probar la clase
 "SpriteTexto", creando ua supuesta nave espacial formada por el carácter
 "A", en las coordenadas (40, 12) y que habrá de mostrarse.
 Deberás entregar sólo el fichero .cs. */




using System;
class SpriteTexto
{
    public int X, Y;
    public char Caracter;

    public void Dibujar()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(Caracter);
    }

}


class PruebaDeSprite
{
    static void Main()
    {
        SpriteTexto s = new SpriteTexto();
        s.X = 40;
        s.Y = 12;
        s.Caracter = 'A';
        s.Dibujar();
        
    }
}

