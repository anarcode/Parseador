namespace Programa.Nativo.Instrucciones
{
    using Programa.Core;
    using System.Linq;

    public class MostrarPorConsola : InstrucciónNativa
    {
        string _nombreDeVariable;

        public MostrarPorConsola(string nombreDeVariable)
             : base("__println")
        {
            _nombreDeVariable = nombreDeVariable;
        }

        public override void Ejecutar(ContextoDePrograma contexto)
        {
            contexto.Consola.Escribir(contexto.Variables.Where(v => v.Nombre == _nombreDeVariable).FirstOrDefault().Valor.ToString());
        }

        protected override Instrucción Clonar(string valor)
        {
            return new MostrarPorConsola(_nombreDeVariable);
        }
    }
}