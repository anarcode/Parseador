namespace Programa.Core
{
    using Programa.Interfaces;

    public class Parámetro
    {
        public ITipo Tipo { get; set; }

        public string Nombre { get; set; }

        public void Visitar(DeclaraciónDeContexto función)
        {
        }

        public void Visitar(Función función)
        {
            función.Parámetros.Añadir(this);
        }
    }
}