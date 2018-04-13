namespace Interprete.Procesadores
{
    using Core;
    using Interfaces;
    using Programa.Core;
    using Programa.Instrucciones;
    using Programa.Interfaces;
    using Programa.Tipos;
    using System.Text.RegularExpressions;

    public class ProcesadorDeLiteralInt : ProcesadorSucesible
    {
        ILenguaje _lenguaje;
        IEvaluador _evaluador;

        readonly string EXPRESION = $@"{FORMATO_VALIDO_VALOR_DE_INT}";

        protected override string Expresión => EXPRESION;

        public ProcesadorDeLiteralInt(ILenguaje lenguaje, IRepositorioDeProcesadores repositorio, IEvaluador evaluador)
            : base(repositorio)
        {
            //RepositorioDeTipos YA!!
            _lenguaje = lenguaje;
            _evaluador = evaluador;
        }

        protected override bool ComprobaciónAdicional(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            return coincidencias[0].Index == 0;
        }

        protected override void ProcesarCadena(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            _evaluador.TipoDeSalida = new TipoInt(_lenguaje);
            var dato = coincidencias[0].Value;
            if (_evaluador.TipoDeSalida.ComprobarValor(dato))
            {
                var instrucción = new ApilarDato(dato, cadena)
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