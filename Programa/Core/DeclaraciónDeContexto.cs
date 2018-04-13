namespace Programa.Core
{
    using Programa.Interfaces;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class DeclaraciónDeContexto
    {
        protected ILenguaje Lenguaje { get; private set; }

        public string Nombre { get; set; }

        public virtual string Tipo => "Programa";

        public ColecciónDeFunciones FuncionesNativas { get; set; }

        public ColecciónDeFunciones Funciones { get; set; }

        public List<Variable> VariablesDeclaradas { get; set; }

        public Queue<Instrucción> Instrucciones { get; set; }

        public bool Correcto { get; set; }

        public ErrorDeDeclaración Error { get; set; }

        [DebuggerStepThrough]
        public DeclaraciónDeContexto(ILenguaje lenguaje)
        {
            Lenguaje = lenguaje;

            Instrucciones = new Queue<Instrucción>();
            FuncionesNativas = new ColecciónDeFunciones();
            Funciones = new ColecciónDeFunciones();
            VariablesDeclaradas = new List<Variable>();
            Correcto = true;
        }

        public virtual void CrearParámetro(Parámetro parámetro)
        {
            parámetro.Visitar(this);
        }
    }
}