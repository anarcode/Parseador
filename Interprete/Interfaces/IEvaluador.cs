namespace Interprete.Interfaces
{
    using Programa.Interfaces;

    public interface IEvaluador : IProcesador
    {
        ITipo TipoDeSalida { get; set; }
    }
}