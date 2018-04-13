namespace Editor.Convertidores
{
    using Editor.Core;
    using Editor.Visualizadores;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class ConvertidorDeVisualizador : ExpandableObjectConverter
    {
        readonly List<Type> _tiposPermitidos = new List<Type>
        {
            typeof(VisualizadorDeVariables),
            typeof(VisualizadorDePilaDeLlamadas),
            typeof(ContextoDeProgramaVisualizable)
        };

        public override object ConvertTo(ITypeDescriptorContext context,
                             System.Globalization.CultureInfo culture,
                             object value, Type destType)
        {
            if (destType == typeof(string) && _tiposPermitidos.Contains(value.GetType()))
            {
                var nombreDeInterface = typeof(RetornadorDeTipo).Name;
                if(value.GetType().GetInterface(nombreDeInterface) != null)
                {
                    return (value as RetornadorDeTipo).Tipo;
                }
                return string.Empty;
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }
}