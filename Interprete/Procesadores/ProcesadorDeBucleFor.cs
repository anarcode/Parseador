namespace Interprete.Procesadores
{
    using Core;
    using Interfaces;
    using Programa.Core;
    using System.Text.RegularExpressions;

    public class ProcesadorDeBucleFor : ProcesadorSucesible
    {
        const string
            NOMBRE_GRUPO_DECLARACION = "declaracion",
            NOMBRE_GRUPO_COMPROBACION = "comprobacion",
            NOMBRE_GRUPO_ACCION_FINAL = "accionFinal",
            NOMBRE_GRUPO_CUERPO = "cuerpo";

        readonly string
            EXPRESION = $"for{SEPARADORES}\\({SEPARADORES}(?<{NOMBRE_GRUPO_DECLARACION}>[{CARACTERES_GRUPO_DE_EXPRESIONES}]*){SEPARADORES};{SEPARADORES}(?<{NOMBRE_GRUPO_COMPROBACION}>[{CARACTERES_GRUPO_DE_EXPRESIONES}]*){SEPARADORES};{SEPARADORES}(?<{NOMBRE_GRUPO_ACCION_FINAL}>[{CARACTERES_GRUPO_DE_EXPRESIONES}]*){SEPARADORES}\\){SEPARADORES}{{{SEPARADORES}(?<{NOMBRE_GRUPO_CUERPO}>{CARACTERES_GRUPO_DE_EXPRESIONES}*){SEPARADORES}}}{SEPARADORES}";

        protected override string Expresión => EXPRESION;

        IProcesador _procesadorDeclaraciónDeVariables;

        public ProcesadorDeBucleFor(IProcesador procesadorDeclaraciónDeVariables)
            : base(null)
        {
            _procesadorDeclaraciónDeVariables = procesadorDeclaraciónDeVariables;
        }

        protected override void ProcesarCadena(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            string declaracion = coincidencias[0].Groups[NOMBRE_GRUPO_DECLARACION].Value,
                comprobacion = coincidencias[0].Groups[NOMBRE_GRUPO_COMPROBACION].Value,
                accionFinal = coincidencias[0].Groups[NOMBRE_GRUPO_ACCION_FINAL].Value,
                cuerpo = coincidencias[0].Groups[NOMBRE_GRUPO_CUERPO].Value;

            //Aqui me interesa un repo en lugar de un chain porque tengo que discriminar según el tipo, que ya me sepo
            //IProcesador procesador = Repositorio.ObtenerProcesadorDeDeclaraciónDeVariables();
            _procesadorDeclaraciónDeVariables.Procesar(declaracion, declaración, desplazamiento);
        }
    }
}