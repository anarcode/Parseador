namespace Editor.Visualizadores
{
    using Editor.Descriptores;
    using Programa.Core;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public interface RetornadorDeTipo
    {
        string Tipo { get; }
    }

    //https://www.codeproject.com/Articles/4448/Customized-display-of-collection-data-in-a-Propert
    public class VisualizadorDeVariables : ICustomTypeDescriptor, RetornadorDeTipo
    {
        List<Variable> _variables;

        public List<Variable> Contenido
        {
            get { return _variables; }
        }

        public string Tipo => string.Empty;

        public VisualizadorDeVariables(List<Variable> variables)
        {
            _variables = variables;
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public PropertyDescriptorCollection GetProperties()
        {
            var descriptores = new PropertyDescriptorCollection(null);

            for (int i = 0; i < Contenido.Count; i++)
            {
                descriptores.Add(new DescriptorDeVariables(this, i));
            }
            return descriptores;
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return GetProperties();
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
    }
}