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
    public class ProcesadorDeDeclaraciónDeDeclaraciónStringTest
    {
        [TestMethod]
        public void ProcesadorDeDeclaraciónDeDeclaraciónStringFunciona()
        {
            ILenguaje lenguaje = new LenguajeBase();
            IRepositorioDeProcesadores repositorio = new RepositorioDeProcesadores(lenguaje);
            var procesador = new ProcesadorDeDeclaraciónDeString(lenguaje, repositorio);
            procesador.Procesar("string cadena = \"tex}to\";", new DeclaraciónDeContexto(lenguaje), 0);
        }
    }
}