namespace Programa.Instrucciones
{
    using Programa.Core;

    public class DeclaraciónDeVariable : Instrucción
    {
        Variable _variable;

        public DeclaraciónDeVariable(Variable variable, string cadena) : base(cadena)
        {
            _variable = variable;
        }

        public override void Ejecutar(ContextoDePrograma contexto)
        {
            //_variable.Valor = contexto.DesapilarDato();
            contexto.Variables.Add(_variable);
        }

        protected override Instrucción Clonar(string cadena)
        {
            return new DeclaraciónDeVariable(_variable, cadena)
            {
                Inicio = Inicio
            };
        }
    }
}