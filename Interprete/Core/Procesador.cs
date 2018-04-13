namespace Interprete.Core
{
    using Interprete.Interfaces;
    using Programa.Core;
    using System.Text.RegularExpressions;

    public abstract class Procesador : IProcesador
    {
        protected const char
            SEPARADOR_DE_PARAMETROS = ',';

        protected static readonly string
            LETRAS_PERMITIDAS = $@"a-zA-ZñÑ",
            CARACTERES_OPERADORES = $@"\+\=",
            CARACTERES_VALOR_DE_INT = $@"0-9",
            FORMATO_OPERADOR_VALIDO = $@"(\=|\+){1}",
            CARACTERES_SEPARADORES = $@"\s\r\n\t",
            LLAVES = $@"\{{\}}",
            PARENTESIS = $@"\(\)",
            SEPARADORES = $@"[{CARACTERES_SEPARADORES}]*",
            SEPARADORES_OBLIGATORIOS = $@"[{CARACTERES_SEPARADORES}]+",
            CARACTERES_NOMBRE_DE_PROGRAMA = $@"{LETRAS_PERMITIDAS}{CARACTERES_VALOR_DE_INT}_",
            CARACTERES_CUERPO_DE_PROGRAMA = $@"{CARACTERES_NOMBRE_DE_PROGRAMA},\.;""{CARACTERES_OPERADORES}{CARACTERES_SEPARADORES}{LLAVES}{PARENTESIS}",
            CARACTERES_DECLARACION_DE_FUNCION = $@"[{CARACTERES_CUERPO_DE_PROGRAMA}{CARACTERES_SEPARADORES}{LLAVES}{PARENTESIS}]+",
            CARACTERES_DECLARACION_DE_PARAMETROS = $@"[{CARACTERES_SEPARADORES}{LETRAS_PERMITIDAS}{CARACTERES_VALOR_DE_INT},]+",
            CARACTERES_VALOR_DE_RETORNO = $@"{LETRAS_PERMITIDAS}{CARACTERES_VALOR_DE_INT}",
            CARACTERES_EXPRESION = $@"{LETRAS_PERMITIDAS}{CARACTERES_VALOR_DE_INT}""{CARACTERES_OPERADORES}{CARACTERES_SEPARADORES}{PARENTESIS}\,\.\{{\}}",
            CARACTERES_GRUPO_DE_EXPRESIONES = $@"{CARACTERES_EXPRESION};",
            CARACTERES_PASO_DE_PARAMETROS = $@"""\{SEPARADOR_DE_PARAMETROS}\.{CARACTERES_SEPARADORES}{LETRAS_PERMITIDAS}{CARACTERES_VALOR_DE_INT}",
            FORMATO_VALIDO_NOMBRE_DE_VARIABLE = $@"[{LETRAS_PERMITIDAS}]{{1}}[{CARACTERES_NOMBRE_DE_PROGRAMA}]*",
            FORMATO_VALIDO_VALOR_DE_INT = $@"[{CARACTERES_VALOR_DE_INT}]+",
            FORMATO_VALIDO_VALOR_DE_STRING = $@"""[{LETRAS_PERMITIDAS}{CARACTERES_VALOR_DE_INT}\s\{{\}}""{2}]*""",
            FORMATO_VALIDO_VALOR_DE_BOOL = $@"(true|false)?",
            FORMATO_VALIDO_VALOR_DE_RETORNO = $@"[{CARACTERES_EXPRESION}]*";

        //Regex _expresión;
        //protected ILenguaje Configuración { get; private set; }

        protected IRepositorioDeProcesadores Repositorio { get; private set; }

        protected abstract string Expresión { get; }

        protected Procesador(IRepositorioDeProcesadores repositorio)
        {
            Repositorio = repositorio;
        }

        protected abstract void ProcesarCadena(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento);

        protected virtual (bool, string) ComprobaciónAntesDeDelegar()
        {
            return (true, string.Empty);
        }

        public virtual bool Procesar(string cadena, DeclaraciónDeContexto contexto)
        {
            return Procesar(cadena, contexto, 0);
        }

        protected virtual bool ComprobaciónAdicional(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            return true;
        }

        public virtual bool Procesar(string cadena, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            var expresión = new Regex(Expresión);
            var coincidencias = expresión.Matches(cadena);
            if (coincidencias.Count > 0 && ComprobaciónAdicional(cadena, coincidencias, declaración, desplazamiento))
            {
                ProcesarCadena(cadena, coincidencias, declaración, desplazamiento);
                return declaración.Correcto;
            }

            return false;
        }
    }
}