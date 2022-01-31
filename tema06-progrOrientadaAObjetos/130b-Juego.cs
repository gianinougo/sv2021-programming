
namespace JuegoSDL
{
    class Juego
    {
        static void Main(string[] args)
        {
            const int NUM_ENEMIGOS = 4;
            Sprite personaje;
            Sprite[] enemigos;
            Fuente fuente18;
            int x = 800, y = 500;
            int velocidad = 5;

            // Inicializo modo grafico 1280x720 puntos, 24 bits de color
            Hardware.Inicializar(1280, 720, 24);

            // Cargo imagenes y tipos de letra
            personaje = new Sprite("datos/personaje.png");
            enemigos = new Sprite[NUM_ENEMIGOS];
            for (int i = 0; i < NUM_ENEMIGOS; i++)
            {
                enemigos[i] = new Sprite("datos/enemigo.png");
            }
            fuente18 = new Fuente("datos/FreeSansBold.ttf", 18);

            // Bucle de juego
            bool terminado = false;
            do
            {
                // Actualizar pantalla
                Hardware.BorrarPantallaOculta();

                personaje.MoverA(x, y);
                personaje.Dibujar();

                for (int i = 0; i < NUM_ENEMIGOS; i++)
                {
                    enemigos[i].MoverA(100 + i * 200, 80);
                    enemigos[i].Dibujar();
                }

                Hardware.EscribirTextoOculta(
                    "Pulsa ESC para salir",
                    300, 500,  // Coordenadas
                    0xAA, 0xAA, 0xAA, // Color: gris claro
                    fuente18); // Tipo de letra

                Hardware.VisualizarOculta();

                // Comprobar acciones del usuario
                if (Hardware.TeclaPulsada(Hardware.TECLA_IZQ))
                    x -= velocidad;
                if (Hardware.TeclaPulsada(Hardware.TECLA_DER))
                    x += velocidad;
                if (Hardware.TeclaPulsada(Hardware.TECLA_ARR))
                    y -= velocidad;
                if (Hardware.TeclaPulsada(Hardware.TECLA_ABA))
                    y += velocidad;

                if (Hardware.TeclaPulsada(Hardware.TECLA_ESC))
                    terminado = true;

                //Mover enemigos, fondo, etc 
                // TO DO

                // Comprobar colisiones y aplicar la lógica de juego
                for (int i = 0; i < NUM_ENEMIGOS; i++)
                {
                    if (personaje.ColisionaCon(enemigos[i]))
                        terminado = true;
                }

                // Pausa (20 ms = 50 fps)
                Hardware.Pausa(20);
            }
            while (!terminado);

        }
    }
}
