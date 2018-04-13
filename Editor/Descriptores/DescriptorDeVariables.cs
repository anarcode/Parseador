namespace Editor.Descriptores
{
    using Editor.Core;
    using Editor.Visualizadores;
    using Programa.Core;
    using System;
    using System.ComponentModel;

    public class DescriptorDeVariables : PropertyDescriptor
    {
        VisualizadorDeVariables _variables;
        int _índice;

        public override Type ComponentType => _variables.Contenido.GetType();

        public override AttributeCollection Attributes => new AttributeCollection(null);

        public override bool IsReadOnly => true;

        public override Type PropertyType => typeof(Variable);

        public DescriptorDeVariables(VisualizadorDeVariables variables, int id)
            : base(id.ToString(), null)
        {
            _variables = variables;
            _índice = id;
        }

        public override string DisplayName => _variables.Contenido[_índice].Tipo.Nombre + " " + _variables.Contenido[_índice].Nombre;

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override object GetValue(object component)
        {
            return _variables.Contenido[_índice].Valor;
        }

        public override void ResetValue(object component)
        {
        }

        public override void SetValue(object component, object value)
        {
        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }
    }
}