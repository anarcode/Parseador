namespace Interprete.Procesadores
{
    using Core;
    using Interfaces;
    using Programa.Core;
    using Programa.Instrucciones;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ProcesadorDeLlamadaFunción : ProcesadorSucesible
    {
        const string
            ERROR_FUNCION_NO_ENCONTRADA = "Para llamar a una función primero hay que declararla",
            ERROR_VALOR_DE_PARAMETRO_INVALIDO = "El valor no es válido para un {0}, zoquete!!",
            NOMBRE_GRUPO_NOMBRE_DE_FUNCION = "nombreDeFuncion",
            NOMBRE_GRUPO_PARAMETROS = "parametros";

        readonly string
            EXPRESION = $@"(?<{NOMBRE_GRUPO_NOMBRE_DE_FUNCION}>{FORMATO_VALIDO_NOMBRE_DE_VARIABLE})\((?<{NOMBRE_GRUPO_PARAMETROS}>[{CARACTERES_PASO_DE_PARAMETROS}]*)?\)";

        IEvaluador _evaluador;

        protected override string Expresión => EXPRESION;

        public ProcesadorDeLlamadaFunción(IRepositorioDeProcesadores repositorio, IEvaluador evaluador)
            : base(repositorio)
        {
            _evaluador = evaluador;
        }

        void GenerarExcepción(string cadena, string mensaje,int inicio, int longitud)
        {
            throw new ErrorDeCompilación(new ErrorDeDeclaración(
                cadena,
                mensaje,
                inicio,
                longitud));
        }

        protected override bool ComprobaciónAdicional(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            return coincidencias[0].Index == 0; //No está al principio, asi que pasa algo raro
        }

        protected override void ProcesarCadena(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            //_evaluador = new ProcesadorDeEvaluación(Repositorio);
            var nombreDeFunción = coincidencias[0].Groups[NOMBRE_GRUPO_NOMBRE_DE_FUNCION].Value;
            bool esNativa = true;
            var función = declaración.FuncionesNativas[nombreDeFunción];

            if (función == null)
            {
                función = declaración.Funciones[nombreDeFunción];
                esNativa = false;
            }

            if (función == null)
            {
                GenerarExcepción(cadena, ERROR_FUNCION_NO_ENCONTRADA, coincidencias[0].Index + desplazamiento, cadena.Length);
            }

            //Esto queda cerdo que no veas
            if(_evaluador == null)
            {
                _evaluador = new ProcesadorDeEvaluación(Repositorio);
            }

            int índice = función.Parámetros.Total - 1;
            string subexpresion = $@"{SEPARADORES}(?<valor>{FORMATO_VALIDO_VALOR_DE_INT}|{FORMATO_VALIDO_VALOR_DE_STRING}|{FORMATO_VALIDO_NOMBRE_DE_VARIABLE}){SEPARADORES}";
            Regex separadorDeValores = new Regex($@"{SEPARADOR_DE_PARAMETROS}{subexpresion}");
            MatchCollection valoresEncontrados = separadorDeValores.Matches(SEPARADOR_DE_PARAMETROS + coincidencias[0].Groups[NOMBRE_GRUPO_PARAMETROS].Value);
            Stack<Match> pilaDeValores = new Stack<Match>();

            foreach(Match valorEncontrado in valoresEncontrados)
            {
                pilaDeValores.Push(valorEncontrado);
            }

            while(pilaDeValores.Count > 0)
            {
                Match coincidencia = pilaDeValores.Pop();
                var valor = coincidencia.Groups["valor"].Value;
                _evaluador.Procesar(valor, declaración, desplazamiento + coincidencias[0].Groups[NOMBRE_GRUPO_PARAMETROS].Index + coincidencia.Groups["valor"].Index - 1);
                var declaraciónDeParámetro = función.Parámetros[índice];
                if(declaraciónDeParámetro == null)
                {
                    GenerarExcepción(
                        valor,
                        "Parámetro no declarado",
                        coincidencias[0].Groups[NOMBRE_GRUPO_PARAMETROS].Index + desplazamiento + coincidencia.Groups["valor"].Index,
                        valor.Length);
                }
                else if (declaraciónDeParámetro.Tipo.Nombre != _evaluador.TipoDeSalida.Nombre)
                {
                    GenerarExcepción(
                        valor,
                        string.Format(ERROR_VALOR_DE_PARAMETRO_INVALIDO, declaraciónDeParámetro.Tipo.Nombre),
                        coincidencias[0].Groups[NOMBRE_GRUPO_PARAMETROS].Index + desplazamiento + coincidencia.Groups["valor"].Index,
                        valor.Length);
                }
                índice--;
            }

            _evaluador.TipoDeSalida = función.TipoDeRetorno;

            if (esNativa)
            {
                Instrucción instrucción = new LlamadaAFunciónNativa(nombreDeFunción, cadena)
                {
                    Inicio = desplazamiento
                };
                declaración.Instrucciones.Enqueue(instrucción);
            }
            else
            {
                Instrucción instrucción = new LlamadaAFunción(nombreDeFunción, cadena)
                {
                    Inicio = desplazamiento
                };
                declaración.Instrucciones.Enqueue(instrucción);
            }
        }
    }
}