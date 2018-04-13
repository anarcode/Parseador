namespace Interprete.Procesadores
{
    using Interfaces;
    using Programa.Core;
    using Programa.Instrucciones;
    using Programa.Interfaces;
    using Programa.Tipos;

    public class ProcesadorDeDeclaraciónDeString : ProcesadorDeDeclaración
    {
        readonly string EXPRESION;

        protected override string Expresión => EXPRESION;

        public ProcesadorDeDeclaraciónDeString(ILenguaje lenguaje, IRepositorioDeProcesadores repositorio)
            : base(lenguaje, repositorio)
        {
            EXPRESION = $@"{lenguaje.NombreTipoCadena}{SEPARADORES_OBLIGATORIOS}(?<{NOMBRE_GRUPO_NOMBRE_DE_VARIABLE}>{FORMATO_VALIDO_NOMBRE_DE_VARIABLE}){SEPARADORES}(={SEPARADORES}(?<{NOMBRE_GRUPO_VALOR_DE_VARIABLE}>{FORMATO_VALIDO_VALOR_DE_STRING}|{FORMATO_VALIDO_NOMBRE_DE_VARIABLE}\([{CARACTERES_PASO_DE_PARAMETROS}]*\)|{FORMATO_VALIDO_NOMBRE_DE_VARIABLE}))?{SEPARADORES}(;|\))?";
            //EXPRESION = $@"{lenguaje.NombreTipoCadena}{SEPARADORES}(?<{NOMBRE_GRUPO_NOMBRE_DE_VARIABLE}>{FORMATO_VALIDO_NOMBRE_DE_VARIABLE}){SEPARADORES}(={SEPARADORES}(?<{NOMBRE_GRUPO_VALOR_DE_VARIABLE}>""[{LETRAS_PERMITIDAS}{CARACTERES_VALOR_DE_INT}\s\\{{\\}}""]*""))?{SEPARADORES}";
        }

        protected override ITipo CrearTipo()
        {
            return new TipoString(Lenguaje);
        }

        protected override void CrearComportamiento(string cadena, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            var variable = new Variable
            {
                Tipo = TipoDeVariable,
                Nombre = NombreDeVariable
                //El valor en lugar de pasárselo, tengo que construir instrucciones para obtenerlo
                //Valor = string.IsNullOrEmpty(ValorDeVariable) ? TipoDeVariable.ValorPorDefecto : ValorDeVariable
            };

            //Igual un CrearVariable y uego un AsignarValorDeVariable
            var instrucción = new DeclaraciónDeVariable(variable, cadena) //Este puede que simplemente haga un pop de algun sitio y coja el valor
            {
                Inicio = desplazamiento
            };
            declaración.Instrucciones.Enqueue(instrucción);
            declaración.VariablesDeclaradas.Add(variable);
        }
    }
}