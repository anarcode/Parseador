namespace Editor
{
    using Editor.Formularios;
    using Interprete.Lenguajes;
    using Programa.Interfaces;
    using System;
    using System.Windows.Forms;

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ILenguaje lenguaje = new LenguajeBase();
            Application.Run(new Debugger(lenguaje));
        }
    }
}