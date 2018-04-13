using Programa.Interfaces;

namespace Programa.Core
{
    public class Función : DeclaraciónDeContexto
    {
        public override string Tipo => "Función";

        public int InicioEnElCódigo { get; set; }

        public int LongitudDeDeclaración { get; set; }

        public ITipo TipoDeRetorno { get; set; }

        public ListaDeParámetros Parámetros { get; set; }

        public Función(ILenguaje lenguaje)
            : base(lenguaje)
        {
            Parámetros = new ListaDeParámetros();
        }

        public override void CrearParámetro(Parámetro parámetro)
        {
            parámetro.Visitar(this);
        }

        public virtual Función Clonar()
        {
            var resultado = new Función(Lenguaje)
            {
                Nombre = Nombre,
                InicioEnElCódigo = InicioEnElCódigo,
                LongitudDeDeclaración = LongitudDeDeclaración,
                Funciones = Funciones,
                FuncionesNativas = FuncionesNativas,
                Parámetros = Parámetros
            };

            foreach(var instrucción in Instrucciones)
            {
                resultado.Instrucciones.Enqueue(instrucción.Clonar());
            }

            return resultado;
        }
    }
}