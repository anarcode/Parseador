namespace Ejecutor
{
    using ElConstructor;
    using Interprete.Lenguajes;
    using Programa.Core;
    using System;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0 && File.Exists(args[0]))
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                Constructor constructor = new Constructor(new LenguajeBase());
                var código = File.ReadAllText(args[0]);
                ContextoDePrograma programa = constructor.Construir(código);

                if (programa.Declaración.Correcto)
                {
                    while (programa.SiguienteInstrucción != null)
                    {
                        programa.EjecutarSiguienteInstrucción();
                    }
                }
                else
                {
                    int línea = código.Take(programa.Declaración.Error.InicioDeInstrucción).Count(c => c == '\n') + 1;
                    string instrucciónErronea = programa.Declaración.Error.Instrucción,
                           mensaje = programa.Declaración.Error.Mensaje;

                    Console.WriteLine($"Error en línea {línea}: {instrucciónErronea} => {mensaje}");
                }
            }
        }
    }
}