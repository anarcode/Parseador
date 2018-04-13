namespace Interprete.Core
{
    using Interprete.Interfaces;
    using Programa.Core;

    public class ManejadorDeDeclaradorDeVariables : IProcesador
    {
        IProcesadorSucesible _inicial;

        public ManejadorDeDeclaradorDeVariables(IRepositorioDeProcesadores repositorioDeProcesadores)
        {
            IProcesadorSucesible procesadorDeDeclaraciónDeString = repositorioDeProcesadores.ObtenerProcesadorDeDeclaraciónDeString(),
                procesadorDeDeclaraciónDeInt = repositorioDeProcesadores.ObtenerProcesadorDeDeclaraciónDeInt(),
                procesadorDeDeclaraciónDeBool = repositorioDeProcesadores.ObtenerProcesadorDeDeclaraciónDeBool();

            _inicial = procesadorDeDeclaraciónDeString;
            procesadorDeDeclaraciónDeString.EstablecerSucesor(procesadorDeDeclaraciónDeInt);
            procesadorDeDeclaraciónDeInt.EstablecerSucesor(procesadorDeDeclaraciónDeBool);
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