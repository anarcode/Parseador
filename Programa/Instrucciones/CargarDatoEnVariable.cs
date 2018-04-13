namespace Programa.Instrucciones
{
    using Programa.Core;
    using System.Linq;

    public class CargarDatoEnVariable : Instrucción
    {
        string _nombreDeVariable;

        public CargarDatoEnVariable(string nombreDeVariable, string cadena) : base(cadena)
        {
            _nombreDeVariable = nombreDeVariable;
        }

        public override void Ejecutar(ContextoDePrograma contexto)
        {
            var valor = contexto.DesapilarDato();
            contexto.Variables.Where(v => v.Nombre == _nombreDeVariable).First().Valor = valor;
        }

        protected override Instrucción Clonar(string valor)
        {
            return new CargarDatoEnVariable(_nombreDeVariable, valor)
            {
                Inicio = Inicio
            };
        }
    }
}