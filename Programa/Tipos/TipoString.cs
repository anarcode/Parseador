namespace Programa.Tipos
{
    using Programa.Interfaces;

    public class TipoString : Tipo
    {
        public override string Nombre => Lenguaje.NombreTipoCadena;

        public override string ValorPorDefecto => @"""""";

        public TipoString(ILenguaje lenguaje)
            : base(lenguaje)
        {
        }

        public override bool ComprobarValor(string cadena)
        {
            //Y los valores válidos de dentro de momento me los paso por el forro
            return cadena.StartsWith(@"""") && cadena.EndsWith(@"""");
        }
    }
}