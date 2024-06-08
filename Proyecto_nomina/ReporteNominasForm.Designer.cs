namespace Proyecto_nomina
{
    partial class ReporteNominasForm
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
            dgvReporteNominas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvReporteNominas).BeginInit();
            SuspendLayout();
            // 
            // dgvReporteNominas
            // 
            dgvReporteNominas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporteNominas.Location = new Point(30, 140);
            dgvReporteNominas.Name = "dgvReporteNominas";
            dgvReporteNominas.Size = new Size(699, 186);
            dgvReporteNominas.TabIndex = 2;
            // 
            // ReporteNominasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 453);
            Controls.Add(dgvReporteNominas);
            Name = "ReporteNominasForm";
            Text = "ReporteNominasForm";
            ((System.ComponentModel.ISupportInitialize)dgvReporteNominas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvReporteNominas;
    }
}