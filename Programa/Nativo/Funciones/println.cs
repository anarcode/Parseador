namespace Programa.Nativo.Funciones
{
    using Programa.Core;
    using Programa.Interfaces;
    using Programa.Nativo.Instrucciones;
    using Programa.Tipos;

    public class println : Función
    {
        public static string NOMBRE = "println";

        public println(ILenguaje lenguaje)
            : base(lenguaje)
        {
            Nombre = NOMBRE;

            Parámetros.Añadir(new Parámetro
            {
                Tipo = new TipoString(Lenguaje),
                Nombre = "texto"
            });

            Instrucciones.Enqueue(new MostrarPorConsola("texto"));
        }
    }
}