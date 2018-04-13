namespace ElConstructor
{
    using Interprete.Core;
    using Interprete.Interfaces;
    using Interprete.Procesadores;
    using Programa.Core;
    using Programa.Interfaces;

    public class Constructor
    {
        IProcesador _procesadorDePrograma;
        ILenguaje _lenguaje;

        public Constructor(ILenguaje lenguaje)
        {
            _lenguaje = lenguaje;
            IRepositorioDeProcesadores repositorio = new RepositorioDeProcesadores(lenguaje);
            _procesadorDePrograma = new ProcesadorDePrograma(repositorio);
        }

        public ContextoDePrograma Construir(string código)
        {
            var declaración = new DeclaraciónDeContextoConFuncionesNativas(_lenguaje);
            _procesadorDePrograma.Procesar(código, declaración);
            return new ContextoDePrograma(declaración, true);
        }
    }
}