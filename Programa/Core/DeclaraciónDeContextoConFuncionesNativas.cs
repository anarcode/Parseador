namespace Programa.Core
{
    using Programa.Interfaces;
    using Programa.Nativo.Funciones;

    public class DeclaraciónDeContextoConFuncionesNativas : DeclaraciónDeContexto
    {
        public DeclaraciónDeContextoConFuncionesNativas(ILenguaje lenguaje)
            : base(lenguaje)
        {
            //Aqui aprovecho y meto las funciones base de mi api
            Función Println = new println(Lenguaje),
                    Readln = new readln(Lenguaje),
                    Readfl = new readfl(Lenguaje);

            FuncionesNativas.Añadir(Println);
            FuncionesNativas.Añadir(Readln);
            FuncionesNativas.Añadir(Readfl);
        }
    }
}