namespace Interprete.Interfaces
{
    public interface IRepositorioDeProcesadores
    {
        IProcesador ObtenerProcesadorDeCuerpoDeExpresiones();

        IProcesadorSucesible ObtenerProcesadorDeDeclaraciónDeVariable();

        IProcesadorSucesible ObtenerProcesadorDeDeclaraciónDeFunción();

        IProcesador ObtenerProcesadorDeDeclaraciónDeParámetros();

        IProcesadorSucesible ObtenerProcesadorDeAsignación();

        IEvaluador ObtenerProcesadorDeEvaluación();

        IProcesadorSucesible ObtenerProcesadorDeLiteralInt(IEvaluador evaluador);

        IProcesadorSucesible ObtenerProcesadorDeLiteralString(IEvaluador evaluador);

        IProcesadorSucesible ObtenerProcesadorDeLiteralBool(IEvaluador evaluador);

        IProcesadorSucesible ObtenerProcesadorDeApilaciónDeVariable(IEvaluador evaluador);

        IProcesadorSucesible ObtenerProcesadorDeBucleFor();

        IProcesadorSucesible ObtenerProcesadorDeDeclaraciónDeVariableTipada(string tipo);

        IProcesadorSucesible ObtenerProcesadorDeDeclaraciónDeString();

        IProcesadorSucesible ObtenerProcesadorDeDeclaraciónDeParámetroString();

        IProcesadorSucesible ObtenerProcesadorDeDeclaraciónDeInt();

        IProcesadorSucesible ObtenerProcesadorDeDeclaraciónDeParámetroInt();

        IProcesadorSucesible ObtenerProcesadorDeDeclaraciónDeBool();

        IProcesadorSucesible ObtenerProcesadorDeDeclaraciónDeParámetroBool();

        IProcesadorSucesible ObtenerProcesadorDeLlamadaFunción(IEvaluador evaluador);

        IProcesadorSucesible ObtenerProcesadorDeRetornoDeValor();

        IProcesadorSucesible ObtenerProcesadorDeTipoDeRetornoInt(IEvaluador evaluador);

        IProcesadorSucesible ObtenerProcesadorDeTipoDeRetornoString(IEvaluador evaluador);

        IProcesadorSucesible ObtenerProcesadorDeTipoDeRetornoBool(IEvaluador evaluador);
    }
}