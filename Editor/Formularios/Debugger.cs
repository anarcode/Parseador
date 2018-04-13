namespace Editor.Formularios
{
    using Editor.Visualizadores;
    using ElConstructor;
    using Programa.Core;
    using Programa.Interfaces;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class Debugger : Form
    {
        Constructor _constructor;
        ContextoDePrograma _programa;
        VisualizadorDeContextoDePrograma _visualizador;

        public Debugger(ILenguaje lenguaje)
        {
            InitializeComponent();

            _constructor = new Constructor(lenguaje);
        }

        private void Debugger_Load(object sender, System.EventArgs e)
        {
            Código.Text = Programas.Primero;
        }

        private void BotónEmpezar_Click(object sender, System.EventArgs e)
        {
            _programa = _constructor.Construir(Código.Text);

            if (!_programa.Declaración.Correcto)
            {
                Código.Select(_programa.Declaración.Error.InicioDeInstrucción, _programa.Declaración.Error.LongitudDeInstrucción);
                Código.ScrollToCaret();
                Código.SelectionBackColor = Color.Red;

                Estado.Text = _programa.Declaración.Error.Mensaje;
                return;
            }

            var siguienteInstrucción = _programa.SiguienteInstrucción;
            if (siguienteInstrucción != null)
            {
                Estado.Text = "En depurando";
                btnSiguiente.Enabled = true;
                _visualizador = new VisualizadorDeContextoDePrograma(_programa);
                VisualizadorDeContextoDeEjecución.SelectedObject = _visualizador;

                Código.Select(siguienteInstrucción.Inicio, siguienteInstrucción.Longitud);
                Código.ScrollToCaret();
                Código.SelectionBackColor = Color.Yellow;
            }
        }

        private void BotónSiguiente_Click(object sender, System.EventArgs e)
        {
            _programa.ContextoActual.EjecutarSiguienteInstrucción();
            Código.SelectionBackColor = Color.White;

            if (_programa.SiguienteInstrucción != null)
            {
                VisualizadorDeContextoDeEjecución.SelectedObject = _visualizador;
                Código.Select(_programa.SiguienteInstrucción.Inicio, _programa.SiguienteInstrucción.Longitud);
                Código.ScrollToCaret();
                Código.SelectionBackColor = Color.Yellow;
            }
            else
            {
                VisualizadorDeContextoDeEjecución.SelectedObject = null;
                btnSiguiente.Enabled = false;
                Código.Select(0, 0);
                Estado.Text = string.Empty;
            }
        }

        private void Código_GotFocus(object sender, System.EventArgs e)
        {
            //Si está en eejecución no
            Código.SelectionBackColor = Color.White;
            Código.Select(0, 0);
        }
    }
}