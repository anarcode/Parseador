namespace Programa.Core
{
    using Programa.Interfaces;
    using System.Diagnostics;

    [DebuggerDisplay("{Tipo} {Nombre} = {Valor}")]
    public class Variable
    {
        public ITipo Tipo { get; set; }

        public string Nombre { get; set; }

        public object Valor { get; set; }
    }
}