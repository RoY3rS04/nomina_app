namespace Proyecto_nomina
{
    partial class ReportesForm
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
            panel1 = new Panel();
            btnReporteEmpleadosFrom = new Button();
            btnReporteNominasForm = new Button();
            pnlContenedorForm = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(29, 34, 39);
            panel1.Controls.Add(btnReporteEmpleadosFrom);
            panel1.Controls.Add(btnReporteNominasForm);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(112, 492);
            panel1.TabIndex = 1;
            // 
            // btnReporteEmpleadosFrom
            // 
            btnReporteEmpleadosFrom.Cursor = Cursors.Hand;
            btnReporteEmpleadosFrom.FlatAppearance.BorderSize = 0;
            btnReporteEmpleadosFrom.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnReporteEmpleadosFrom.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnReporteEmpleadosFrom.FlatStyle = FlatStyle.Flat;
            btnReporteEmpleadosFrom.Font = new Font("Segoe UI", 12F);
            btnReporteEmpleadosFrom.ForeColor = Color.Silver;
            btnReporteEmpleadosFrom.Location = new Point(0, 30);
            btnReporteEmpleadosFrom.Margin = new Padding(3, 2, 3, 2);
            btnReporteEmpleadosFrom.Name = "btnReporteEmpleadosFrom";
            btnReporteEmpleadosFrom.Size = new Size(110, 50);
            btnReporteEmpleadosFrom.TabIndex = 36;
            btnReporteEmpleadosFrom.Text = "Empleados";
            btnReporteEmpleadosFrom.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReporteEmpleadosFrom.UseVisualStyleBackColor = true;
            btnReporteEmpleadosFrom.Click += btnReporteEmpleadosFrom_Click;
            // 
            // btnReporteNominasForm
            // 
            btnReporteNominasForm.Cursor = Cursors.Hand;
            btnReporteNominasForm.FlatAppearance.BorderSize = 0;
            btnReporteNominasForm.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnReporteNominasForm.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnReporteNominasForm.FlatStyle = FlatStyle.Flat;
            btnReporteNominasForm.Font = new Font("Segoe UI", 12F);
            btnReporteNominasForm.ForeColor = Color.Silver;
            btnReporteNominasForm.Location = new Point(0, 95);
            btnReporteNominasForm.Margin = new Padding(3, 2, 3, 2);
            btnReporteNominasForm.Name = "btnReporteNominasForm";
            btnReporteNominasForm.Size = new Size(112, 50);
            btnReporteNominasForm.TabIndex = 35;
            btnReporteNominasForm.Text = "Nominas";
            btnReporteNominasForm.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReporteNominasForm.UseVisualStyleBackColor = true;
            btnReporteNominasForm.Click += btnReporteNominasForm_Click;
            // 
            // pnlContenedorForm
            // 
            pnlContenedorForm.Dock = DockStyle.Fill;
            pnlContenedorForm.Location = new Point(112, 0);
            pnlContenedorForm.Name = "pnlContenedorForm";
            pnlContenedorForm.Size = new Size(739, 492);
            pnlContenedorForm.TabIndex = 2;
            // 
            // ReportesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(851, 492);
            Controls.Add(pnlContenedorForm);
            Controls.Add(panel1);
            Name = "ReportesForm";
            Text = "ReportesForm";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnReporteEmpleadosFrom;
        private Button btnReporteNominasForm;
        private Panel pnlContenedorForm;
    }
}