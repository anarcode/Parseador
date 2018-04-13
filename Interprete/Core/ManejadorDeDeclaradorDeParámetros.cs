namespace Interprete.Core
{
    using Interprete.Interfaces;
    using Programa.Core;

    public class ManejadorDeDeclaradorDeParámetros : IProcesador
    {
        IProcesadorSucesible _inicial;

        public ManejadorDeDeclaradorDeParámetros(IRepositorioDeProcesadores repositorioDeProcesadores)
        {
            IProcesadorSucesible
                procesadorDeDeclaraciónDeParámetroString = repositorioDeProcesadores.ObtenerProcesadorDeDeclaraciónDeParámetroString(),
                procesadorDeDeclaraciónDeParámetroInt = repositorioDeProcesadores.ObtenerProcesadorDeDeclaraciónDeParámetroInt(),
                procesadorDeDeclaraciónDeParámetroBool = repositorioDeProcesadores.ObtenerProcesadorDeDeclaraciónDeParámetroBool();

            _inicial = procesadorDeDeclaraciónDeParámetroString;

            procesadorDeDeclaraciónDeParámetroString.EstablecerSucesor(procesadorDeDeclaraciónDeParámetroInt);
            procesadorDeDeclaraciónDeParámetroInt.EstablecerSucesor(procesadorDeDeclaraciónDeParámetroBool);
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