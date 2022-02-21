// Ejercicio recomendado 150
// Javier (...)

class Fantasma : Sprite
{
}

// ----

class Galleta : Sprite
{

}

// ----

class GalletaPoder : Galleta
{
}
﻿
// ----

class JuegoPrincipalPacMan
{
    public static void Main()
    {
        Partida p = new Partida();
        p.Lanzar();
    }
}

// ----

class Laberinto
{
    protected string nombre;
    protected Pared[] muros;
    protected Galleta[] galletas;
    protected GalletaPoder[] galletasPoder;

    public Laberinto() { }
    public int GetNombre() { }
    public void SetNombre(string nombre) { }
    public void Dibujar() { }
}

// ----

class Pac_Man : Sprite
{
    private bool efectoGalletaPoder;

    public Pac_Man() { }

    public bool GetEfectoGalletaPoder() { }
    public void SetEfectoGalletaPoder(bool efectoGP) { }
    public override void Mover()
    {
        base.Mover();
    }
    public override void MoverA(int x, int y)
    {
        base.MoverA(x, y);
    }

    public override void Dibujar()
    {
        base.Dibujar();
    }

    public bool ComerGalletaPoder() { }
    public void ComerGalleta() { }

}

// ----

class Pared : Sprite
{
    private int tamanyo;

    public Pared() { }
    public int GetTamanyo() { }
    public void SetTamanyo(int tamanyo) { }
}

// ----

class Partida
{
    private Laberinto[] laberintos;
    private Fantasma[] fantasmas;
    private JuegoPrincipalPacMan pacman;

    public Partida() { }
    public void Lanzar() { }
}
// ----

class Sprite
{
    protected int x;
    protected int y;
    protected int velocidadX;
    protected int velocidadY;
    protected int alto;
    protected int ancho;
    protected bool activo;
    protected byte direccion;

    public Sprite() { }

    public int GetX() { }
    public int GetY() { }
    public int GetDireccion() { }
    public int GetVelocidadX() { }
    public int GetVelocidadY() { }
    public bool GetActivo() { }

    public void SetX(int x) { }
    public void SetY(int y) { }
    public void SetDireccion(int direccion) { }
    public void SetVelocidadX(int vX) { }
    public void SetVelocidadY(int vY) { }
    public void SetActivo(bool activo) { }


    public virtual void MoverA(int x, int y) { }
    public virtual void Mover() { }
    public void SetVelocidad(int velocidadX, int velocidadY) { }
    public void CambiarDireccion(byte direccion) { }
    public virtual void Dibujar() { }
    public void Desaparecer() { }
    public bool ColisionarCon(Sprite otro) { }
    
}

