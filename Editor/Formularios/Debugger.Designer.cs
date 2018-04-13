namespace Editor.Formularios
{
    partial class Debugger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelHerramientas = new System.Windows.Forms.Panel();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnEmpezar = new System.Windows.Forms.Button();
            this.PanelContenedor = new System.Windows.Forms.SplitContainer();
            this.BarraDeEstado = new System.Windows.Forms.StatusStrip();
            this.Estado = new System.Windows.Forms.ToolStripStatusLabel();
            this.Código = new System.Windows.Forms.RichTextBox();
            this.PanelDePuntosDeInterrupción = new System.Windows.Forms.Panel();
            this.VisualizadorDeContextoDeEjecución = new System.Windows.Forms.PropertyGrid();
            this.PanelHerramientas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelContenedor)).BeginInit();
            this.PanelContenedor.Panel1.SuspendLayout();
            this.PanelContenedor.Panel2.SuspendLayout();
            this.PanelContenedor.SuspendLayout();
            this.BarraDeEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelHerramientas
            // 
            this.PanelHerramientas.Controls.Add(this.btnSiguiente);
            this.PanelHerramientas.Controls.Add(this.btnEmpezar);
            this.PanelHerramientas.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelHerramientas.Location = new System.Drawing.Point(0, 0);
            this.PanelHerramientas.Name = "PanelHerramientas";
            this.PanelHerramientas.Size = new System.Drawing.Size(813, 37);
            this.PanelHerramientas.TabIndex = 0;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Enabled = false;
            this.btnSiguiente.Location = new System.Drawing.Point(82, 7);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(64, 23);
            this.btnSiguiente.TabIndex = 1;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.BotónSiguiente_Click);
            // 
            // btnEmpezar
            // 
            this.btnEmpezar.Location = new System.Drawing.Point(12, 7);
            this.btnEmpezar.Name = "btnEmpezar";
            this.btnEmpezar.Size = new System.Drawing.Size(64, 23);
            this.btnEmpezar.TabIndex = 0;
            this.btnEmpezar.Text = "Empezar";
            this.btnEmpezar.UseVisualStyleBackColor = true;
            this.btnEmpezar.Click += new System.EventHandler(this.BotónEmpezar_Click);
            // 
            // PanelContenedor
            // 
            this.PanelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContenedor.Location = new System.Drawing.Point(0, 37);
            this.PanelContenedor.Name = "PanelContenedor";
            // 
            // PanelContenedor.Panel1
            // 
            this.PanelContenedor.Panel1.Controls.Add(this.BarraDeEstado);
            this.PanelContenedor.Panel1.Controls.Add(this.Código);
            this.PanelContenedor.Panel1.Controls.Add(this.PanelDePuntosDeInterrupción);
            // 
            // PanelContenedor.Panel2
            // 
            this.PanelContenedor.Panel2.Controls.Add(this.VisualizadorDeContextoDeEjecución);
            this.PanelContenedor.Size = new System.Drawing.Size(813, 327);
            this.PanelContenedor.SplitterDistance = 562;
            this.PanelContenedor.TabIndex = 1;
            // 
            // BarraDeEstado
            // 
            this.BarraDeEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Estado});
            this.BarraDeEstado.Location = new System.Drawing.Point(16, 305);
            this.BarraDeEstado.Name = "BarraDeEstado";
            this.BarraDeEstado.Size = new System.Drawing.Size(546, 22);
            this.BarraDeEstado.SizingGrip = false;
            this.BarraDeEstado.TabIndex = 4;
            // 
            // Estado
            // 
            this.Estado.Name = "Estado";
            this.Estado.Size = new System.Drawing.Size(0, 17);
            // 
            // Código
            // 
            this.Código.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Código.Location = new System.Drawing.Point(16, 0);
            this.Código.Name = "Código";
            this.Código.Size = new System.Drawing.Size(546, 327);
            this.Código.TabIndex = 3;
            this.Código.Text = "";
            this.Código.GotFocus += new System.EventHandler(this.Código_GotFocus);
            // 
            // PanelDePuntosDeInterrupción
            // 
            this.PanelDePuntosDeInterrupción.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PanelDePuntosDeInterrupción.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelDePuntosDeInterrupción.Location = new System.Drawing.Point(0, 0);
            this.PanelDePuntosDeInterrupción.Name = "PanelDePuntosDeInterrupción";
            this.PanelDePuntosDeInterrupción.Size = new System.Drawing.Size(16, 327);
            this.PanelDePuntosDeInterrupción.TabIndex = 2;
            // 
            // VisualizadorDeContextoDeEjecución
            // 
            this.VisualizadorDeContextoDeEjecución.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisualizadorDeContextoDeEjecución.LineColor = System.Drawing.SystemColors.ControlDark;
            this.VisualizadorDeContextoDeEjecución.Location = new System.Drawing.Point(0, 0);
            this.VisualizadorDeContextoDeEjecución.Name = "VisualizadorDeContextoDeEjecución";
            this.VisualizadorDeContextoDeEjecución.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.VisualizadorDeContextoDeEjecución.Size = new System.Drawing.Size(247, 327);
            this.VisualizadorDeContextoDeEjecución.TabIndex = 0;
            // 
            // Debugger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 364);
            this.Controls.Add(this.PanelContenedor);
            this.Controls.Add(this.PanelHerramientas);
            this.Name = "Debugger";
            this.Text = "Te miro y te interpreto";
            this.Load += new System.EventHandler(this.Debugger_Load);
            this.PanelHerramientas.ResumeLayout(false);
            this.PanelContenedor.Panel1.ResumeLayout(false);
            this.PanelContenedor.Panel1.PerformLayout();
            this.PanelContenedor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelContenedor)).EndInit();
            this.PanelContenedor.ResumeLayout(false);
            this.BarraDeEstado.ResumeLayout(false);
            this.BarraDeEstado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelHerramientas;
        private System.Windows.Forms.SplitContainer PanelContenedor;
        private System.Windows.Forms.RichTextBox Código;
        private System.Windows.Forms.Panel PanelDePuntosDeInterrupción;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnEmpezar;
        private System.Windows.Forms.PropertyGrid VisualizadorDeContextoDeEjecución;
        private System.Windows.Forms.StatusStrip BarraDeEstado;
        private System.Windows.Forms.ToolStripStatusLabel Estado;
    }
}