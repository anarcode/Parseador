namespace Programa.Tipos
{
    using Programa.Interfaces;

    public abstract class Tipo : ITipo
    {
        protected ILenguaje Lenguaje { get; private set; }

        protected Tipo(ILenguaje lenguaje)
        {
            Lenguaje = lenguaje;
        }

        public abstract string Nombre { get; }

        public abstract string ValorPorDefecto { get; }

        public abstract bool ComprobarValor(string cadena);
    }
}