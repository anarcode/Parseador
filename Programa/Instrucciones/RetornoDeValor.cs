namespace Programa.Instrucciones
{
    using Programa.Core;

    public class RetornoDeValor : Instrucción
    {
        object _valorDeRetorno;

        public RetornoDeValor(object valorDeRetorno, string valor) : base(valor)
        {
            _valorDeRetorno = valorDeRetorno;
        }

        public override void Ejecutar(ContextoDePrograma contexto)
        {
            contexto.DesapilarContexto(_valorDeRetorno); //contextoActual??
        }

        protected override Instrucción Clonar(string valor)
        {
            return new RetornoDeValor(_valorDeRetorno, valor)
            {
                Inicio = Inicio
            };
        }
    }
}