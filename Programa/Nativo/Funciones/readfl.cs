namespace Programa.Nativo.Funciones
{
    using Programa.Core;
    using Programa.Interfaces;
    using Programa.Nativo.Instrucciones;
    using Programa.Tipos;

    public class readfl : Función
    {
        public static string NOMBRE = "readfl";

        public readfl(ILenguaje lenguaje)
            : base(lenguaje)
        {
            Nombre = NOMBRE;

            Parámetros.Añadir(new Parámetro
            {
                Tipo = new TipoString(Lenguaje),
                Nombre = "texto"
            });

            Instrucciones.Enqueue(new LeerFichero("texto"));
        }
    }
}