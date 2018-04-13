namespace Interprete.Procesadores
{
    using Core;
    using Interfaces;
    using Programa.Core;
    using Programa.Interfaces;
    using Programa.Tipos;
    using System.Text.RegularExpressions;

    public class ProcesadorDeTipoDeRetornoString : ProcesadorSucesible
    {
        ILenguaje _lenguaje;
        IEvaluador _evaluador;

        readonly string EXPRESION;

        protected override string Expresión => EXPRESION;

        public ProcesadorDeTipoDeRetornoString(ILenguaje lenguaje, IRepositorioDeProcesadores repositorio, IEvaluador evaluador)
            : base(repositorio)
        {
            //RepositorioDeTipos YA!!
            _lenguaje = lenguaje;
            _evaluador = evaluador;
            EXPRESION = $@"{_lenguaje.NombreTipoCadena}";
        }

        protected override bool ComprobaciónAdicional(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            return coincidencias[0].Index == 0;
        }

        protected override void ProcesarCadena(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            _evaluador.TipoDeSalida = new TipoString(_lenguaje);
        }
    }
}