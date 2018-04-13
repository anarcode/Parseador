namespace Interprete.Procesadores
{
    using Core;
    using Interfaces;
    using Programa.Core;
    using Programa.Interfaces;
    using System.Text.RegularExpressions;

    public class PlantillaProcesador : Procesador
    {
        const string EXPRESION = @"";

        protected override string Expresión => EXPRESION;

        public PlantillaProcesador(ILenguaje lenguaje, IRepositorioDeProcesadores repositorio)
            : base(repositorio)
        {
        }

        protected override void ProcesarCadena(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
        }
    }
}