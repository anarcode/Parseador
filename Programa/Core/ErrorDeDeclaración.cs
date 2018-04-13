namespace Programa.Core
{
    public class ErrorDeDeclaración
    {
        public string Instrucción { get; }

        public string Mensaje { get; }

        public int InicioDeInstrucción { get; }

        public int LongitudDeInstrucción { get; }

        public ErrorDeDeclaración(string instrucción, string mensaje, int inicio, int longitud)
        {
            Instrucción = instrucción;
            Mensaje = mensaje;
            InicioDeInstrucción = inicio;
            LongitudDeInstrucción = longitud;
        }
    }
}