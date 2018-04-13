namespace Programa.Core
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    public class Consola
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        StreamWriter _flujoDeSalida;
        StreamReader _flujoDeEntrada;

        public Consola()
        {
            AllocConsole();

            _flujoDeSalida = new StreamWriter(Console.OpenStandardOutput());
            _flujoDeEntrada = new StreamReader(Console.OpenStandardInput());
            _flujoDeSalida.AutoFlush = true;
            Console.SetOut(_flujoDeSalida);
        }

        public void Escribir(string valor)
        {
            _flujoDeSalida.WriteLine(valor);
        }

        public string Leer()
        {
            return _flujoDeEntrada.ReadLine();
        }
    }
}