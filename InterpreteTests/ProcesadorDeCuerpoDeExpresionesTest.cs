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
    public class ProcesadorDeCuerpoDeExpresionesTest
    {
        [TestMethod]
        public void ProcesadorDeDeclaraciónDeParámetrosFunciona()
        {
            ILenguaje lenguaje = new LenguajeBase();
            IRepositorioDeProcesadores repositorio = new RepositorioDeProcesadores(lenguaje);
            var manejador = new ManejadorDeProcesadores(repositorio, null);
            var procesador = new ProcesadorDeCuerpoDeExpresiones(manejador);
            var declaración = new DeclaraciónDeContexto(lenguaje);
            procesador.Procesar(@"int entero = 0;string cadena = ""texto"";", declaración, 0);
        }
    }
}