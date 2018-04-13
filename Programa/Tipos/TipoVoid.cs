namespace Programa.Tipos
{
    using Programa.Interfaces;

    public class TipoVoid : Tipo
    {
        public override string Nombre => Lenguaje.NombreTipoVoid;

        public override string ValorPorDefecto => "";

        public TipoVoid(ILenguaje lenguaje)
            : base(lenguaje)
        {
        }

        public override bool ComprobarValor(string cadena)
        {
            //De momento soy un cutre
            return int.TryParse(cadena, out int variableQueTengoQueDeclarar);
        }
    }
}