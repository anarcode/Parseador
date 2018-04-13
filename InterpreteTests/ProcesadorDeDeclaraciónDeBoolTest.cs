namespace ExpresionesTests
{
    using Interprete.Core;
    using Interprete.Interfaces;
    using Interprete.Lenguajes;
    using Interprete.Procesadores;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Programa.Core;
    using Programa.Interfaces;

    [TestClass]
    public class ProcesadorDeDeclaraciónDeBoolTest
    {
        [TestMethod]
        public void ProcesadorDeDeclaraciónDeBoolDeclaraSinValor()
        {
            ILenguaje lenguaje = new LenguajeBase();
            IRepositorioDeProcesadores repositorio = new RepositorioDeProcesadores(lenguaje);
            var procesador = new ProcesadorDeDeclaraciónDeBool(lenguaje, repositorio);
            var declaración = new DeclaraciónDeContexto(lenguaje);
            procesador.Procesar(@"bool a", declaración, 0);
        }
    }
}