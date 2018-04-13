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
    public class ProcesadorDeEvaluaciónTest
    {
        [TestMethod]
        public void ProcesadorDeEvaluaciónLeeBienLosNumerosLiterales()
        {
            ILenguaje lenguaje = new LenguajeBase();
            IRepositorioDeProcesadores repositorio = new RepositorioDeProcesadores(lenguaje);
            var procesador = new ProcesadorDeEvaluación(repositorio);
            var declaración = new DeclaraciónDeContexto(lenguaje);
            bool resultado = procesador.Procesar(@"2", declaración, 0);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void ProcesadorDeEvaluaciónLeeBienLasCadenasLiterales()
        {
            ILenguaje lenguaje = new LenguajeBase();
            IRepositorioDeProcesadores repositorio = new RepositorioDeProcesadores(lenguaje);
            var procesador = new ProcesadorDeEvaluación(repositorio);
            var declaración = new DeclaraciónDeContexto(lenguaje);
            bool resultado = procesador.Procesar(@"""pa""mplinas""", declaración, 0);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void ProcesadorDeEvaluaciónLeeBienLosPosiblesNombreDeVariables()
        {
            ILenguaje lenguaje = new LenguajeBase();
            IRepositorioDeProcesadores repositorio = new RepositorioDeProcesadores(lenguaje);
            var procesador = new ProcesadorDeEvaluación(repositorio);
            var declaración = new DeclaraciónDeContexto(lenguaje);
            bool resultado = procesador.Procesar(@"NombreDeVariable23", declaración, 0);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void ProcesadorDeEvaluaciónLeeBienLasPosiblesLlamadasAFuncionesSinParámetros()
        {
            ILenguaje lenguaje = new LenguajeBase();
            IRepositorioDeProcesadores repositorio = new RepositorioDeProcesadores(lenguaje);
            var procesador = new ProcesadorDeEvaluación(repositorio);
            var declaración = new DeclaraciónDeContexto(lenguaje);
            bool resultado = procesador.Procesar(@"NombreDeFuncion()", declaración, 0);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void ProcesadorDeEvaluaciónLeeBienLasPosiblesLlamadasAFuncionesConParámetros()
        {
            ILenguaje lenguaje = new LenguajeBase();
            IRepositorioDeProcesadores repositorio = new RepositorioDeProcesadores(lenguaje);
            var procesador = new ProcesadorDeEvaluación(repositorio);
            var declaración = new DeclaraciónDeContexto(lenguaje);
            bool resultado = procesador.Procesar(@"NombreDeFuncion(string paramtero1, int parametro2)", declaración, 0);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void ProcesadorDeEvaluaciónNoSeFumaLosValoresInválidos()
        {
            ILenguaje lenguaje = new LenguajeBase();
            IRepositorioDeProcesadores repositorio = new RepositorioDeProcesadores(lenguaje);
            var procesador = new ProcesadorDeEvaluación(repositorio);
            var declaración = new DeclaraciónDeContexto(lenguaje);
            bool resultado = procesador.Procesar(@"2Pamplinas", declaración, 0);

            Assert.IsFalse(resultado);
        }
    }
}