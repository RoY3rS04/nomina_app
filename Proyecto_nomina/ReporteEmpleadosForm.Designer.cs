namespace Proyecto_nomina
{
    partial class ReporteEmpleadosForm
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
            dgvReporteEmpleados = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvReporteEmpleados).BeginInit();
            SuspendLayout();
            // 
            // dgvReporteEmpleados
            // 
            dgvReporteEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporteEmpleados.Location = new Point(30, 140);
            dgvReporteEmpleados.Name = "dgvReporteEmpleados";
            dgvReporteEmpleados.Size = new Size(699, 186);
            dgvReporteEmpleados.TabIndex = 1;
            // 
            // ReporteEmpleadosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 453);
            Controls.Add(dgvReporteEmpleados);
            Name = "ReporteEmpleadosForm";
            Text = "ReporteEmpleadosForm";
            ((System.ComponentModel.ISupportInitialize)dgvReporteEmpleados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvReporteEmpleados;
    }
}