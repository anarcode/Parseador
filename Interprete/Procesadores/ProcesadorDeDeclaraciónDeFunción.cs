namespace Interprete.Procesadores
{
    using Core;
    using Interfaces;
    using Programa.Core;
    using Programa.Interfaces;
    using Programa.Tipos;
    using System.Text.RegularExpressions;

    public class ProcesadorDeDeclaraciónDeFunción : ProcesadorSucesible
    {
        const string
            NOMBRE_GRUPO_TIPO_DE_RETORNO = "tipoDeRetorno",
            NOMBRE_GRUPO_NOMBRE_DE_FUNCION = "nombreDeFuncion",
            NOMBRE_GRUPO_PARAMETROS = "parametros",
            NOMBRE_GRUPO_CUERPO_DE_FUNCION = "cuerpoDeFuncion";

        internal static readonly string
            EXPRESION = $"{SEPARADORES}function{SEPARADORES}(?<{NOMBRE_GRUPO_TIPO_DE_RETORNO}>|int|string|bool){{1}}{SEPARADORES}(?<{NOMBRE_GRUPO_NOMBRE_DE_FUNCION}>({FORMATO_VALIDO_NOMBRE_DE_VARIABLE})){SEPARADORES}\\((?<{NOMBRE_GRUPO_PARAMETROS}>[{CARACTERES_DECLARACION_DE_PARAMETROS}]*)?\\){SEPARADORES}\\{{{SEPARADORES}(?<{NOMBRE_GRUPO_CUERPO_DE_FUNCION}>[^\\}}]*){SEPARADORES}\\}}"; //Esto deja de valer en cuanto haya llaves dentro, cojona!!!
        //EXPRESION = $"{SEPARADORES}function{SEPARADORES}(?<{NOMBRE_GRUPO_TIPO_DE_RETORNO}>|int|string|bool){{1}}{SEPARADORES}(?<{NOMBRE_GRUPO_NOMBRE_DE_FUNCION}>({FORMATO_VALIDO_NOMBRE_DE_VARIABLE})){SEPARADORES}\\((?<{NOMBRE_GRUPO_PARAMETROS}>[{CARACTERES_DECLARACION_DE_PARAMETROS}]*)?\\){SEPARADORES}\\{{{SEPARADORES}(?<{NOMBRE_GRUPO_CUERPO_DE_FUNCION}>[{CARACTERES_GRUPO_DE_EXPRESIONES}]*){SEPARADORES}\\}}";

        ILenguaje _lenguaje;
        IProcesador _procesadorDeParámetros, _procesadorDeCuerpo;

        protected override string Expresión => EXPRESION;

        public ProcesadorDeDeclaraciónDeFunción(IRepositorioDeProcesadores repositorio, ILenguaje lenguaje)
            : base(repositorio)
        {
            _lenguaje = lenguaje;
            _procesadorDeParámetros = Repositorio.ObtenerProcesadorDeDeclaraciónDeParámetros();
        }

        protected override void ProcesarCadena(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            foreach(Match coincidencia in coincidencias)
            {
                var resultado = new Función(_lenguaje)
                {
                    TipoDeRetorno = new TipoVoid(_lenguaje),
                    Nombre = coincidencia.Groups[NOMBRE_GRUPO_NOMBRE_DE_FUNCION].Value,
                    InicioEnElCódigo = coincidencia.Index,
                    LongitudDeDeclaración = coincidencia.Value.Length,
                    FuncionesNativas = declaración.FuncionesNativas,
                    Funciones = declaración.Funciones
                };

                if (!string.IsNullOrEmpty(coincidencia.Groups[NOMBRE_GRUPO_TIPO_DE_RETORNO].Value))
                {
                    //Si el manejador no tiene tipo es que no existe!!
                    var manejador = new ManejadorDeTipoDeRetorno(Repositorio);
                    manejador.Procesar(coincidencia.Groups[NOMBRE_GRUPO_TIPO_DE_RETORNO].Value, declaración, desplazamiento + coincidencia.Groups[NOMBRE_GRUPO_TIPO_DE_RETORNO].Index);
                    resultado.TipoDeRetorno = manejador.TipoDeSalida;
                }

                //En lugar de crear variables voy a crear un stack de Parámetro y al procesar la llamada creo las variables ya con los valores
                if (!string.IsNullOrEmpty(coincidencia.Groups[NOMBRE_GRUPO_PARAMETROS].Value))
                {
                    //Este debería ser de variables
                    _procesadorDeParámetros.Procesar(coincidencia.Groups[NOMBRE_GRUPO_PARAMETROS].Value, resultado, desplazamiento + coincidencia.Groups[NOMBRE_GRUPO_PARAMETROS].Index);
                }

                //Comprobar que hay un return. Puede ser que este sea evaluador y los procesadores le asignen
                //si al final es void y el tipo definido es otro la liamos (ya, y cuando lleguen los ifs me descojono)

                //Compruebo si hay funciones declaradas dentro
                Procesar(coincidencia.Groups[NOMBRE_GRUPO_CUERPO_DE_FUNCION].Value, resultado, desplazamiento);

                //Por problemas tecnicos, si hago esto en el ctor se mete en un bucle infinito
                _procesadorDeCuerpo = Repositorio.ObtenerProcesadorDeCuerpoDeExpresiones();
                _procesadorDeCuerpo.Procesar(coincidencia.Groups[NOMBRE_GRUPO_CUERPO_DE_FUNCION].Value, resultado, desplazamiento + coincidencia.Groups[NOMBRE_GRUPO_CUERPO_DE_FUNCION].Index);

                declaración.Funciones.Añadir(resultado);
            }
        }
    }
}