namespace Interprete.Procesadores
{
    using Core;
    using Interfaces;
    using Programa.Core;
    using Programa.Instrucciones;
    using System.Text.RegularExpressions;

    public class ProcesadorDeRetornoDeValor : ProcesadorSucesible
    {
        const string
            NOMBRE_GRUPO_VALOR_DE_RETORNO = "valorDeRetorno";

        readonly string
            EXPRESION = $"return{SEPARADORES}(?<{NOMBRE_GRUPO_VALOR_DE_RETORNO}>{FORMATO_VALIDO_VALOR_DE_RETORNO})";

        protected override string Expresión => EXPRESION;

        public ProcesadorDeRetornoDeValor(IRepositorioDeProcesadores repositorio)
            : base(repositorio)
        {
        }

        protected override void ProcesarCadena(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            //Aqui tengo que enlazarlo de alguna forma con un evaluador externo para ver que los tipos coinciden
            var evaluador = new ProcesadorDeEvaluación(Repositorio);
            var valorDeRetorno = coincidencias[0].Groups[NOMBRE_GRUPO_VALOR_DE_RETORNO].Value;
            evaluador.Procesar(valorDeRetorno, declaración, desplazamiento + coincidencias[0].Groups[NOMBRE_GRUPO_VALOR_DE_RETORNO].Index);
        }
    }
}