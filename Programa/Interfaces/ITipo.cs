namespace Programa.Interfaces
{
    public interface ITipo
    {
        string Nombre { get; }

        string ValorPorDefecto { get; }

        bool ComprobarValor(string cadena);
    }
}