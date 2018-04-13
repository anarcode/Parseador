namespace Interprete.Lenguajes
{
    using Programa.Interfaces;

    public class LenguajeBase : ILenguaje
    {
        public string NombreTipoVoid => "void";

        public string NombreTipoBool => "bool";

        public string NombreTipoEntero => "int";

        public string NombreTipoCadena => "string";

        public string OperadorDeAsignación => "=";
    }
}