namespace Programa.Tipos
{
    using Programa.Interfaces;

    public class TipoInt : Tipo
    {
        public override string Nombre => Lenguaje.NombreTipoEntero;

        public override string ValorPorDefecto => "0";

        public TipoInt(ILenguaje lenguaje)
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