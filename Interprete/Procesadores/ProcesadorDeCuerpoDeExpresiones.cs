namespace Interprete.Procesadores
{
    using Core;
    using Interfaces;
    using Programa.Core;
    using System.Text.RegularExpressions;

    public class ProcesadorDeCuerpoDeExpresiones : Procesador
    {
        const string
            NOMBRE_GRUPO_EXPRESION = "expresion",
            NOMBRE_GRUPO_EXPRESION_CON_SEPARADORES = "expresionConSeparadores";

        readonly string
            EXPRESION = $@"(?<{NOMBRE_GRUPO_EXPRESION_CON_SEPARADORES}>{SEPARADORES}(?<{NOMBRE_GRUPO_EXPRESION}>[{CARACTERES_EXPRESION}]*){SEPARADORES};){{1}}";

        IProcesador _manejador;

        protected override string Expresión => EXPRESION;

        public ProcesadorDeCuerpoDeExpresiones(IProcesador manejador)
            : base(null)
        {
            _manejador = manejador;
        }

        protected override void ProcesarCadena(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            foreach (Match coincidencia in coincidencias)
            {
                string expresión = coincidencia.Groups[NOMBRE_GRUPO_EXPRESION].Value;
                if (!string.IsNullOrEmpty(expresión))
                {
                    if(!_manejador.Procesar(expresión, declaración, coincidencia.Groups[NOMBRE_GRUPO_EXPRESION].Index + desplazamiento))
                    {
                        //Algo que no se qué es
                    }
                }
            }
        }
    }
}