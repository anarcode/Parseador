namespace Interprete.Procesadores
{
    using Core;
    using Interfaces;
    using Programa.Core;
    using Programa.Interfaces;
    using System.Text.RegularExpressions;

    public class ProcesadorDeDeclaraciónDeParámetros : Procesador
    {
        const string
            NOMBRE_GRUPO_NOMBRE_DE_PARAMETRO = "nombreDeParametro";

        readonly string
            EXPRESION_UN_PARAMETRO,
            EXPRESION;

        IProcesador _procesadorDeDeclaraciónDeParámetros;

        protected override string Expresión => EXPRESION;

        public ProcesadorDeDeclaraciónDeParámetros(ILenguaje lenguaje, IRepositorioDeProcesadores repositorio)
            : base(repositorio)
        {
            EXPRESION_UN_PARAMETRO = $@"({lenguaje.NombreTipoCadena}|{lenguaje.NombreTipoEntero}){{1}}{SEPARADORES}(?<{NOMBRE_GRUPO_NOMBRE_DE_PARAMETRO}>{FORMATO_VALIDO_NOMBRE_DE_VARIABLE})?{SEPARADORES}";
            EXPRESION = $@"{EXPRESION_UN_PARAMETRO}(?({SEPARADORES},{SEPARADORES}){EXPRESION_UN_PARAMETRO})*";

            _procesadorDeDeclaraciónDeParámetros = new ManejadorDeDeclaradorDeParámetros(Repositorio);
        }

        protected override void ProcesarCadena(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            foreach (Match coincidencia in coincidencias)
            {
                _procesadorDeDeclaraciónDeParámetros.Procesar(coincidencia.Value, declaración, desplazamiento + coincidencia.Index);
            }
        }
    }
}