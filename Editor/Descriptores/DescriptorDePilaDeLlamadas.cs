namespace Editor.Descriptores
{
    using Editor.Core;
    using Editor.Visualizadores;
    using System;
    using System.ComponentModel;

    public class DescriptorDePilaDeLlamadas : PropertyDescriptor
    {
        VisualizadorDePilaDeLlamadas _pilaDeLlamadas;
        int _índice;

        public override Type ComponentType => _pilaDeLlamadas.Contenido.GetType();

        public override AttributeCollection Attributes => new AttributeCollection(null);

        public override bool IsReadOnly => true;

        public override Type PropertyType => typeof(ContextoDeProgramaVisualizable);

        public DescriptorDePilaDeLlamadas(VisualizadorDePilaDeLlamadas pilaDeLlamadas, int id)
            : base(id.ToString(), null)
        {
            _pilaDeLlamadas = pilaDeLlamadas;
            _índice = id;
        }

        public override string DisplayName => _pilaDeLlamadas.Contenido[_índice].Declaración.Nombre;

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override object GetValue(object component)
        {
            return new ContextoDeProgramaVisualizable(_pilaDeLlamadas.Contenido[_índice]);
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