namespace Interprete.Procesadores
{
    using Interfaces;
    using Programa.Core;
    using Programa.Instrucciones;
    using Programa.Interfaces;
    using Programa.Tipos;

    public class ProcesadorDeDeclaraciónDeInt : ProcesadorDeDeclaración
    {
        readonly string EXPRESION;

        protected override string Expresión => EXPRESION;

        public ProcesadorDeDeclaraciónDeInt(ILenguaje lenguaje, IRepositorioDeProcesadores repositorio)
            : base(lenguaje, repositorio)
        {
            EXPRESION = $@"({SEPARADORES}|\()?{lenguaje.NombreTipoEntero}{SEPARADORES_OBLIGATORIOS}(?<{NOMBRE_GRUPO_NOMBRE_DE_VARIABLE}>{FORMATO_VALIDO_NOMBRE_DE_VARIABLE}){SEPARADORES}(={SEPARADORES}(?<{NOMBRE_GRUPO_VALOR_DE_VARIABLE}>{FORMATO_VALIDO_VALOR_DE_INT}|{FORMATO_VALIDO_NOMBRE_DE_VARIABLE})?)?{SEPARADORES}";
        }

        protected override ITipo CrearTipo()
        {
            return new TipoInt(Lenguaje);
        }

        protected override void CrearComportamiento(string cadena, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            var variable = new Variable
            {
                Tipo = TipoDeVariable,
                Nombre = NombreDeVariable
                //Valor = string.IsNullOrEmpty(ValorDeVariable) ? TipoDeVariable.ValorPorDefecto : ValorDeVariable
            };

            var instrucción = new DeclaraciónDeVariable(variable, cadena)
            {
                Inicio = desplazamiento
            };
            declaración.Instrucciones.Enqueue(instrucción);
            declaración.VariablesDeclaradas.Add(variable);
        }
    }
}