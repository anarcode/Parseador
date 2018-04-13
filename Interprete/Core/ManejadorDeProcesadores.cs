namespace Interprete.Core
{
    using Interprete.Interfaces;
    using Programa.Core;

    public class ManejadorDeProcesadores : IProcesador
    {
        IRepositorioDeProcesadores _repositorioDeProcesadores;
        IProcesadorSucesible _inicial;

        public ManejadorDeProcesadores(IRepositorioDeProcesadores repositorioDeProcesadores, IEvaluador evaluador)
        {
            _repositorioDeProcesadores = repositorioDeProcesadores;

            var procesadorDeBucleFor = _repositorioDeProcesadores.ObtenerProcesadorDeBucleFor();
            _inicial = procesadorDeBucleFor;

            var procesadorDeVariables = _repositorioDeProcesadores.ObtenerProcesadorDeDeclaraciónDeVariable();
            var procesadorDeDeclaraciónDeFunción = repositorioDeProcesadores.ObtenerProcesadorDeDeclaraciónDeFunción();
            var procesadorDeAsignación = _repositorioDeProcesadores.ObtenerProcesadorDeAsignación();
            var procesadorDeLlamadaFunción = _repositorioDeProcesadores.ObtenerProcesadorDeLlamadaFunción(evaluador);
            var procesadorDeRetornoDeValor = _repositorioDeProcesadores.ObtenerProcesadorDeRetornoDeValor();

            procesadorDeBucleFor.EstablecerSucesor(procesadorDeDeclaraciónDeFunción);
            procesadorDeDeclaraciónDeFunción.EstablecerSucesor(procesadorDeLlamadaFunción);
            procesadorDeLlamadaFunción.EstablecerSucesor(procesadorDeVariables);
            procesadorDeVariables.EstablecerSucesor(procesadorDeAsignación);
            procesadorDeAsignación.EstablecerSucesor(procesadorDeRetornoDeValor);
        }

        public bool Procesar(string cadena, DeclaraciónDeContexto contexto, int desplazamiento)
        {
            return _inicial.Procesar(cadena, contexto, desplazamiento);
        }

        public bool Procesar(string cadena, DeclaraciónDeContexto contexto)
        {
            return Procesar(cadena, contexto, 0);
        }
    }
}