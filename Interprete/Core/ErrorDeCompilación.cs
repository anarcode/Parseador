namespace Interprete.Core
{
    using Programa.Core;
    using System;

    public class ErrorDeCompilación : Exception
    {
        public ErrorDeDeclaración ErrorDeDeclaración { get; }

        public ErrorDeCompilación(ErrorDeDeclaración error) : base(error.Mensaje)
        {
            ErrorDeDeclaración = error;
        }
    }
}