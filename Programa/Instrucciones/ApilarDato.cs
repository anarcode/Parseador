namespace Programa.Instrucciones
{
    using Programa.Core;

    public class ApilarDato : Instrucción
    {
        string _dato;

        public ApilarDato(string dato, string cadena) : base(cadena)
        {
            _dato = dato;
        }

        public override void Ejecutar(ContextoDePrograma contexto)
        {
            contexto.ApilarDato(_dato);
        }

        protected override Instrucción Clonar(string valor)
        {
            return new ApilarDato(_dato, valor)
            {
                Inicio = Inicio
            };
        }
    }
}