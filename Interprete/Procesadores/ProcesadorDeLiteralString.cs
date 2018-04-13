namespace Interprete.Procesadores
{
    using Core;
    using Interfaces;
    using Programa.Core;
    using Programa.Instrucciones;
    using Programa.Interfaces;
    using Programa.Tipos;
    using System.Text.RegularExpressions;

    public class ProcesadorDeLiteralString : ProcesadorSucesible
    {
        const string NOMBRE_GRUPO_VALOR_SIN_COMILLAS = "valorSinComillas";

        readonly string EXPRESION = $@"(?<{NOMBRE_GRUPO_VALOR_SIN_COMILLAS}>{FORMATO_VALIDO_VALOR_DE_STRING})";

        ILenguaje _lenguaje;
        IEvaluador _evaluador;

        protected override string Expresión => EXPRESION;

        public ProcesadorDeLiteralString(ILenguaje lenguaje, IRepositorioDeProcesadores repositorio, IEvaluador evaluador)
            : base(repositorio)
        {
            _lenguaje = lenguaje;
            _evaluador = evaluador;
        }

        protected override bool ComprobaciónAdicional(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            return coincidencias[0].Index == 0;
        }

        protected override void ProcesarCadena(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            _evaluador.TipoDeSalida = new TipoString(_lenguaje);
            var dato = coincidencias[0].Value;
            if (_evaluador.TipoDeSalida.ComprobarValor(dato))
            {
                var instrucción = new ApilarDato(coincidencias[0].Groups[NOMBRE_GRUPO_VALOR_SIN_COMILLAS].Value, cadena)
                {
                    Inicio = desplazamiento
                };
                declaración.Instrucciones.Enqueue(instrucción);
            }
            else
            {
                //EXCEPCION: Tipo inválido
            }
        }
    }
}