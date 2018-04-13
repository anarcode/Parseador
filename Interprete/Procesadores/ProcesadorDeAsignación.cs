namespace Interprete.Procesadores
{
    using Core;
    using Interfaces;
    using Programa.Core;
    using System.Text.RegularExpressions;

    public class ProcesadorDeAsignación : ProcesadorSucesible
    {
        const string
            NOMBRE_GRUPO_NOMBRE_DE_VARIABLE = "nombreDeVariable",
            NOMBRE_GRUPO_VALOR_DE_VARIABLE = "valorDeVariable";

        readonly string
            EXPRESION = $"(?<{NOMBRE_GRUPO_NOMBRE_DE_VARIABLE}>{FORMATO_VALIDO_NOMBRE_DE_VARIABLE}){{1}}{SEPARADORES}={SEPARADORES}(?<primerValor>({FORMATO_VALIDO_NOMBRE_DE_VARIABLE}|{FORMATO_VALIDO_VALOR_DE_INT})){SEPARADORES}(?<operador>{FORMATO_OPERADOR_VALIDO}){SEPARADORES}(?<segundoValor>({FORMATO_VALIDO_NOMBRE_DE_VARIABLE}|[{FORMATO_VALIDO_VALOR_DE_INT}]+)){SEPARADORES}";

        protected override string Expresión => EXPRESION;

        public ProcesadorDeAsignación(IRepositorioDeProcesadores repositorio)
            : base(repositorio)
        {
        }

        protected override void ProcesarCadena(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            string nombre = coincidencias[0].Groups[NOMBRE_GRUPO_NOMBRE_DE_VARIABLE].Value,
                valor = coincidencias[0].Groups[NOMBRE_GRUPO_VALOR_DE_VARIABLE].Value;
        }
    }
}