namespace Programa.Tipos
{
    using Programa.Interfaces;
    using System.Collections.Generic;

    public class TipoBool : Tipo
    {
        readonly List<string> _valoresVálidos = new List<string>
        {
            "false",
            "true"
        };

        public override string Nombre => Lenguaje.NombreTipoBool;

        public override string ValorPorDefecto => _valoresVálidos[0];

        public TipoBool(ILenguaje lenguaje)
            : base(lenguaje)
        {
        }

        public override bool ComprobarValor(string cadena)
        {
            //De momento soy un cutre
            return _valoresVálidos.Contains(cadena);
        }
    }
}