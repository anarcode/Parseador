namespace Interprete.Core
{
    using Interprete.Interfaces;
    using Programa.Core;
    using Programa.Interfaces;

    public class ManejadorDeTipoDeRetorno : IProcesador, IEvaluador
    {
        IProcesadorSucesible _inicial;

        public ITipo TipoDeSalida { get; set; }

        public ManejadorDeTipoDeRetorno(IRepositorioDeProcesadores repositorioDeProcesadores)
        {
            IProcesadorSucesible procesadorDeRetornoInt = repositorioDeProcesadores.ObtenerProcesadorDeTipoDeRetornoInt(this),
                procesadorDeRetornoString = repositorioDeProcesadores.ObtenerProcesadorDeTipoDeRetornoString(this),
                procesadorDeRetornoBool = repositorioDeProcesadores.ObtenerProcesadorDeTipoDeRetornoBool(this);

            _inicial = procesadorDeRetornoInt;
            procesadorDeRetornoInt.EstablecerSucesor(procesadorDeRetornoString);
            procesadorDeRetornoString.EstablecerSucesor(procesadorDeRetornoBool);
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