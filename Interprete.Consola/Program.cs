namespace Expresiones.Consola
{
    using Expresiones.Core;
    using Expresiones.Interfaces;
    using Expresiones.Procesadores;
    using Programa.Core;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            IRepositorioDeProcesadores repositorio = new RepositorioDeProcesadores();
            IProcesador programa = new ProcesadorDePrograma(repositorio);
            var código = File.ReadAllText(Directory.GetCurrentDirectory() + "\\" + args[0]);

            var contexto = new DeclaraciónDePrograma();
            programa.Procesar(código, contexto);

            //manejador.Procesar(@"for(string cadena1=""hey"";;) { string cadena = ""pamplinas""; } ");
            ////manejador.Procesar(@"for(string cadena1=""hey"";string cadena2 = """";string cadena="""") { string cadena = ""pamplinas""; } ");

            ////manejador.Procesar(@"for  ( string cadena1 = ""valor""; )     ");
            //manejador.Procesar(@"for (   string cadena=""""; string cadena= ""hey"" ;string hola=""hh"" ) { cuerpo  } ");
        }
    }
}