namespace Interprete.Procesadores
{
    using Core;
    using Interfaces;
    using Programa.Core;
    using Programa.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ProcesadorDeDeclaraciónDeVariable : ProcesadorSucesible
    {
        const string
            ERROR_DE_DECLARACION = "Declaración incorrecta de variable";

        readonly string EXPRESION;

        ManejadorDeDeclaradorDeVariables _manejador;

        protected override string Expresión => EXPRESION;

        public ProcesadorDeDeclaraciónDeVariable(ILenguaje lenguaje, IRepositorioDeProcesadores repositorio)
            : base(repositorio)
        {
            _manejador = new ManejadorDeDeclaradorDeVariables(repositorio);

            var tiposVálidos = string.Join("|", new List<string> { lenguaje.NombreTipoBool, lenguaje.NombreTipoCadena, lenguaje.NombreTipoEntero });
            EXPRESION = $@"({tiposVálidos}){{1}}{SEPARADORES_OBLIGATORIOS}{FORMATO_VALIDO_NOMBRE_DE_VARIABLE}{SEPARADORES}(={SEPARADORES}("")*[{LETRAS_PERMITIDAS}{CARACTERES_VALOR_DE_INT},\s\{{\}}\(\)""]*("")*{SEPARADORES})?{SEPARADORES}";
        }

        protected override void ProcesarCadena(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            try
            {
                foreach(Match coincidencia in coincidencias)
                {
                    if(!_manejador.Procesar(coincidencia.Value, declaración, desplazamiento))
                    {
                        //Variable rara
                        declaración.Correcto = false;
                        declaración.Error = new ErrorDeDeclaración(coincidencia.Value, ERROR_DE_DECLARACION, coincidencia.Index + desplazamiento, coincidencia.Length);
                    }
                }
            }
            catch (InvalidOperationException)
            {
                //Aqui estoy jodido porque no sé que coño de variable han definido
            }
        }
    }
}