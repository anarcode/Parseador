namespace Interprete.Core
{
    using Interprete.Interfaces;
    using Programa.Core;

    public class ManejadorDeEvaluación : IProcesador
    {
        IProcesadorSucesible _inicial;

        public ManejadorDeEvaluación(IRepositorioDeProcesadores repositorioDeProcesadores, IEvaluador evaluador)
        {
            IProcesadorSucesible procesadorDeLiteralInt = repositorioDeProcesadores.ObtenerProcesadorDeLiteralInt(evaluador),
                procesadorDeLiteralString = repositorioDeProcesadores.ObtenerProcesadorDeLiteralString(evaluador),
                procesadorDeLiteralBool = repositorioDeProcesadores.ObtenerProcesadorDeLiteralBool(evaluador),
                procesadorDeValorDeVariable = repositorioDeProcesadores.ObtenerProcesadorDeApilaciónDeVariable(evaluador),
                procesadorDeLlamadaAFunción = repositorioDeProcesadores.ObtenerProcesadorDeLlamadaFunción(evaluador);

            _inicial = procesadorDeLiteralInt;
            procesadorDeLiteralInt.EstablecerSucesor(procesadorDeLiteralString);
            procesadorDeLiteralString.EstablecerSucesor(procesadorDeLiteralBool);
            procesadorDeLiteralBool.EstablecerSucesor(procesadorDeValorDeVariable);
            procesadorDeValorDeVariable.EstablecerSucesor(procesadorDeLlamadaAFunción);
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