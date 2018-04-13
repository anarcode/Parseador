namespace Programa.Core
{
    using System.Collections.Generic;

    public partial class ContextoDePrograma
    {
        static Stack<string> PilaDeDatos = new Stack<string>();

        static Stack<ContextoDePrograma> PilaDeEjecución = new Stack<ContextoDePrograma>();

        public DeclaraciónDeContexto Declaración { get; private set; }

        public static List<ContextoDePrograma> PilaDeLlamadas //Cuidao con dar el contexto que la puedo liar
        {
            get
            {
                var resultado = new List<ContextoDePrograma>();
                foreach(var contexto in PilaDeEjecución)
                {
                    resultado.Add(contexto);
                }
                return resultado;
            }
        }

        public List<Variable> Variables { get; private set; }

        public object ValorDeRetorno { get; set; }

        internal Consola Consola { get; private set; }

        public ContextoDePrograma ContextoActual
        {
            get
            {
                if(PilaDeEjecución.Count > 0)
                {
                    return PilaDeEjecución.Peek();
                }
                return null;
            }
        }

        public Instrucción SiguienteInstrucción
        {
            get
            {
                if(ContextoActual == null || ContextoActual.Declaración.Instrucciones.Count == 0)
                {
                    return null;
                }

                return ContextoActual.Declaración.Instrucciones.Peek();
            }
        }

        public ContextoDePrograma(DeclaraciónDeContexto declaración, bool inicializarPila)
        {
            if (inicializarPila)
            {
                PilaDeDatos.Clear();
                PilaDeEjecución.Clear();
            }
            
            Declaración = declaración;
            
            Variables = new List<Variable>();
            if(PilaDeEjecución.Count == 0)
            {
                PilaDeEjecución.Push(this);
            }

            Consola = new Consola();
        }

        public ContextoDePrograma(DeclaraciónDeContexto declaración)
            : this(declaración, false)
        {
        }

        public void EjecutarSiguienteInstrucción() //El retorno de valor parece que no desapila contexto después de apilar el retorno
        {
            if(SiguienteInstrucción != null)
            {
                var instrucción = ContextoActual.Declaración.Instrucciones.Dequeue();
                instrucción.Ejecutar(ContextoActual);

                while(ContextoActual.Declaración.Instrucciones.Count == 0)
                {
                    DesapilarContexto();
                }
            }
        }

        public void ApilarContexto(ContextoDePrograma subcontexto)
        {
            PilaDeEjecución.Push(subcontexto);
        }

        public void DesapilarContexto()
        {
            if(PilaDeEjecución.Count > 0)
            {
                PilaDeEjecución.Pop();
            }
            //Si no, se acobó el pograma
        }

        public void DesapilarContexto(object valorDeRetorno)
        {
            DesapilarContexto();
            PilaDeEjecución.Peek().ValorDeRetorno = valorDeRetorno; // Esto no peta si al final hay un return???
        }

        public void ApilarDato(string dato)
        {
            PilaDeDatos.Push(dato);
        }

        public string DesapilarDato()
        {
            if(PilaDeDatos.Count > 0)
            {
                return PilaDeDatos.Pop();
            }
            return null;
        }
    }
}