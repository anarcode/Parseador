namespace Interprete.Interfaces
{
    using Programa.Core;

    public interface IProcesador
    {
        bool Procesar(string cadena, DeclaraciónDeContexto declaración);

        bool Procesar(string cadena, DeclaraciónDeContexto declaración, int desplazamiento);
    }
}