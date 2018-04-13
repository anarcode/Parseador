namespace Programa.Nativo.Funciones
{
    using Programa.Core;
    using Programa.Interfaces;
    using Programa.Nativo.Instrucciones;

    public class readln : Función
    {
        public static string NOMBRE = "readln";

        public readln(ILenguaje lenguaje)
            : base(lenguaje)
        {
            Nombre = NOMBRE;
            Instrucciones.Enqueue(new PedirPorConsola());
        }
    }
}