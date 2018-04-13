namespace Programa.Core
{
    public abstract class Instrucción
    {
        string _cadena;

        public string Código => _cadena;

        public int Inicio { get; set; }

        public int Longitud { get; set; }

        protected Instrucción(string cadena)
        {
            _cadena = cadena;
            Longitud = _cadena.Length;
        }

        public abstract void Ejecutar(ContextoDePrograma contexto);

        protected abstract Instrucción Clonar(string cadena);

        public Instrucción Clonar()
        {
            return Clonar(_cadena);
        }

        //public static implicit operator Instrucción(string valor)
        //{
        //    return new Instrucción(valor);
        //}

        //public static implicit operator string(Instrucción instrucción)
        //{
        //    return instrucción._valor;
        //}
    }
}