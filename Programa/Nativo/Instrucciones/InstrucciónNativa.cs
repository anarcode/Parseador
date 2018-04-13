namespace Programa.Nativo.Instrucciones
{
    using Programa.Core;

    public abstract class InstrucciónNativa : Instrucción
    {
        protected InstrucciónNativa(string valor)
            : base(valor)
        {
            //Instrucciones = new CuerpoAtómicoDeInstrucciones();
        }

        //public override void Ejecutar(ContextoDePrograma contexto)
        //{
        //    Instrucciones.Ejecutar(contexto);
        //}
    }
}