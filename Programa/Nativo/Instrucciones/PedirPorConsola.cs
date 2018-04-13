namespace Programa.Nativo.Instrucciones
{
    using Programa.Core;

    public class PedirPorConsola : InstrucciónNativa
    {
        public PedirPorConsola()
             : base("__readln")
        {
        }

        public override void Ejecutar(ContextoDePrograma contexto)
        {
            //Aqui leo y dejo el resultado en ...
            contexto.ValorDeRetorno = contexto.Consola.Leer();
        }

        protected override Instrucción Clonar(string valor)
        {
            return new PedirPorConsola();
        }
    }
}