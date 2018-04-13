namespace Programa.Instrucciones
{
    using Programa.Core;

    public class LlamadaAFunción : Instrucción
    {
        string _nombre;

        public LlamadaAFunción(string nombreDeFunción, string valor) : base(valor)
        {
            _nombre = nombreDeFunción;
        }

        public override void Ejecutar(ContextoDePrograma contexto)
        {
            var función = contexto.Declaración.Funciones[_nombre];
            var contextoDeFunción = new ContextoDePrograma(función.Clonar());
            contexto.ApilarContexto(contextoDeFunción);
        }

        protected override Instrucción Clonar(string valor)
        {
            return new LlamadaAFunción(_nombre, valor)
            {
                Inicio = Inicio
            };
        }
    }
}