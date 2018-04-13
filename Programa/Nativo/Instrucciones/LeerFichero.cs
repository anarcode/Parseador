namespace Programa.Nativo.Instrucciones
{
    using Programa.Core;
    using System.IO;
    using System.Linq;

    public class LeerFichero : InstrucciónNativa
    {
        string _nombreDeVariable;

        public LeerFichero(string nombreDeVariable)
             : base("__println")
        {
            _nombreDeVariable = nombreDeVariable;
        }

        public override void Ejecutar(ContextoDePrograma contexto)
        {
            string nombreDeFichero = contexto.Variables.Where(v => v.Nombre == _nombreDeVariable).FirstOrDefault().Valor.ToString();
            if (!File.Exists(nombreDeFichero))
            {
                //Lanzo mi propia excepción o como hago?? En contexto un Errores a lo Lezana??
            }
            contexto.ValorDeRetorno = File.ReadAllText(nombreDeFichero);
        }

        protected override Instrucción Clonar(string valor)
        {
            return new LeerFichero(_nombreDeVariable);
        }
    }
}