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
    public class ProcesadorDeDeclaraciónDeParámetroTest
    {
        [TestMethod]
        public void ProcesadorDeDeclaraciónDeParámetrosFunciona()
        {
            ILenguaje lenguaje = new LenguajeBase();
            IRepositorioDeProcesadores repositorio = new RepositorioDeProcesadores(lenguaje);
            var procesador = new ProcesadorDeDeclaraciónDeParámetros(lenguaje, repositorio);
            procesador.Procesar("int entero, string cadena", new DeclaraciónDeContexto(lenguaje), 0);
        }
    }
}