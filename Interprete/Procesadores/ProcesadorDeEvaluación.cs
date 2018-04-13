namespace Interprete.Procesadores
{
    using Core;
    using Interfaces;
    using Programa.Core;
    using Programa.Interfaces;
    using System.Text.RegularExpressions;

    public class ProcesadorDeEvaluación : Procesador, IEvaluador
    {
        readonly string
            EXPRESION = $@"({FORMATO_VALIDO_VALOR_DE_INT}|{FORMATO_VALIDO_VALOR_DE_STRING}|{FORMATO_VALIDO_NOMBRE_DE_VARIABLE}\([{CARACTERES_PASO_DE_PARAMETROS}]*\)|{FORMATO_VALIDO_NOMBRE_DE_VARIABLE}){{1}}";

        protected override string Expresión => EXPRESION;

        IProcesador _manejador;

        public ITipo TipoDeSalida { get; set; }

        public ProcesadorDeEvaluación(IRepositorioDeProcesadores repositorio)
            : base(repositorio)
        {
            _manejador = new ManejadorDeEvaluación(Repositorio, this);
        }

        protected override bool ComprobaciónAdicional(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            return coincidencias.Count == 1 && coincidencias[0].Index == 0 && coincidencias[0].Length == cadena.Length;
        }

        protected override void ProcesarCadena(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            //Tengo que pasarle this como evaluador para que le ponga el tipo de salida
            //aunque si la funcion tiene tipo devuelto debería ser ese
            _manejador.Procesar(cadena, declaración, desplazamiento);
            //Revisar que el contexto no venga con Correcto a false porque ha petado algo.
        }
    }
}