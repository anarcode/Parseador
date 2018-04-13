namespace Editor.Core
{
    using Editor.Convertidores;
    using Editor.Visualizadores;
    using Programa.Core;
    using System.ComponentModel;

    [TypeConverter(typeof(ConvertidorDeVisualizador))]
    public class ContextoDeProgramaVisualizable : RetornadorDeTipo
    {
        ContextoDePrograma _contexto;

        public string Tipo => _contexto.Declaración.Tipo;

        public int Variables => _contexto.Variables.Count;

        public string Siguiente
        {
            get
            {
                if(_contexto.Declaración.Instrucciones.Count > 0)
                {
                    return _contexto.Declaración.Instrucciones.Peek().Código;
                }
                return "No hay más";
            }
        }

        public ContextoDeProgramaVisualizable(ContextoDePrograma contexto)
        {
            _contexto = contexto;
        }
    }
}