namespace Editor.Visualizadores
{
    using Editor.Convertidores;
    using Programa.Core;
    using System.ComponentModel;

    public class VisualizadorDeContextoDePrograma
    {
        ContextoDePrograma _contexto;
        VisualizadorDePilaDeLlamadas _visualizadorDePilaDeLlamadas;

        public string Contexto => _contexto.ContextoActual == null ? string.Empty : _contexto.ContextoActual.Declaración.Nombre;

        [TypeConverter(typeof(ConvertidorDeVisualizador))]
        public VisualizadorDePilaDeLlamadas PilaDeLlamadas => _visualizadorDePilaDeLlamadas;

        [TypeConverter(typeof(ConvertidorDeVisualizador))]
        public VisualizadorDeVariables Variables => new VisualizadorDeVariables(_contexto.ContextoActual.Variables);

        public VisualizadorDeContextoDePrograma(ContextoDePrograma contexto)
        {
            _contexto = contexto;
            _visualizadorDePilaDeLlamadas = new VisualizadorDePilaDeLlamadas();
        }
    }
}