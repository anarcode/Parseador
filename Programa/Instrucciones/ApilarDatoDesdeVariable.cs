namespace Programa.Instrucciones
{
    using Programa.Core;
    using System.Linq;

    public class ApilarDatoDesdeVariable : Instrucción
    {
        string _nombreDeVariable;

        public ApilarDatoDesdeVariable(string nombreDeVariable, string cadena) : base(cadena)
        {
            _nombreDeVariable = nombreDeVariable;
        }

        public override void Ejecutar(ContextoDePrograma contexto)
        {
            var variable = contexto.Variables.Where(v => v.Nombre == _nombreDeVariable).First();
            if(variable != null)
            {
                contexto.ApilarDato(variable.Valor.ToString());
            }
        }

        protected override Instrucción Clonar(string valor)
        {
            return new ApilarDatoDesdeVariable(_nombreDeVariable, valor)
            {
                Inicio = Inicio
            };
        }
    }
}