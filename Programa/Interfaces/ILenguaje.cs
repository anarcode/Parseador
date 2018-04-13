namespace Programa.Interfaces
{
    public interface ILenguaje
    {
        string NombreTipoVoid { get; }

        string NombreTipoBool { get; }

        string NombreTipoEntero { get; }

        string NombreTipoCadena { get; }

        string OperadorDeAsignación { get; }
    }
}