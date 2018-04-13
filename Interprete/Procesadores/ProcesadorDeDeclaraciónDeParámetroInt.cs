namespace Interprete.Procesadores
{
    using Interfaces;
    using Programa.Core;
    using Programa.Instrucciones;
    using Programa.Interfaces;

    public class ProcesadorDeDeclaraciónDeParámetroInt : ProcesadorDeDeclaraciónDeInt
    {
        public ProcesadorDeDeclaraciónDeParámetroInt(ILenguaje lenguaje, IRepositorioDeProcesadores repositorio)
            : base(lenguaje, repositorio)
        {
        }

        protected override void CrearComportamiento(string cadena, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            var parámetro = new Parámetro
            {
                Tipo = TipoDeVariable,
                Nombre = NombreDeVariable
            };

            declaración.CrearParámetro(parámetro);

            base.CrearComportamiento(cadena, declaración, desplazamiento);

            var cargarDatoDeParámetro = new CargarDatoEnVariable(NombreDeVariable, cadena)
            {
                Inicio = desplazamiento
            };
            declaración.Instrucciones.Enqueue(cargarDatoDeParámetro);
        }
    }
}