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
            lblCodigoEmpleado = new Label();
            lblCedulaEmpleado = new Label();
            txtCodigoEmpleado = new TextBox();
            txtCedulaEmpleado = new TextBox();
            btnSearch = new Button();
            btnExport = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReporteEmpleados).BeginInit();
            SuspendLayout();
            // 
            // dgvReporteEmpleados
            // 
            dgvReporteEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporteEmpleados.Location = new Point(30, 158);
            dgvReporteEmpleados.Name = "dgvReporteEmpleados";
            dgvReporteEmpleados.Size = new Size(699, 216);
            dgvReporteEmpleados.TabIndex = 1;
            // 
            // lblCodigoEmpleado
            // 
            lblCodigoEmpleado.AutoSize = true;
            lblCodigoEmpleado.Location = new Point(30, 40);
            lblCodigoEmpleado.Name = "lblCodigoEmpleado";
            lblCodigoEmpleado.Size = new Size(105, 15);
            lblCodigoEmpleado.TabIndex = 2;
            lblCodigoEmpleado.Text = "Codigo Empleado:";
            // 
            // lblCedulaEmpleado
            // 
            lblCedulaEmpleado.AutoSize = true;
            lblCedulaEmpleado.Location = new Point(387, 40);
            lblCedulaEmpleado.Name = "lblCedulaEmpleado";
            lblCedulaEmpleado.Size = new Size(103, 15);
            lblCedulaEmpleado.TabIndex = 3;
            lblCedulaEmpleado.Text = "Cedula Empleado:";
            // 
            // txtCodigoEmpleado
            // 
            txtCodigoEmpleado.Location = new Point(141, 37);
            txtCodigoEmpleado.Name = "txtCodigoEmpleado";
            txtCodigoEmpleado.Size = new Size(200, 23);
            txtCodigoEmpleado.TabIndex = 4;
            // 
            // txtCedulaEmpleado
            // 
            txtCedulaEmpleado.Location = new Point(517, 37);
            txtCedulaEmpleado.Name = "txtCedulaEmpleado";
            txtCedulaEmpleado.Size = new Size(212, 23);
            txtCedulaEmpleado.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(30, 89);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(699, 43);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Buscar Empleado";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(30, 394);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(699, 34);
            btnExport.TabIndex = 7;
            btnExport.Text = "Exportar";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // ReporteEmpleadosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 453);
            Controls.Add(btnExport);
            Controls.Add(btnSearch);
            Controls.Add(txtCedulaEmpleado);
            Controls.Add(txtCodigoEmpleado);
            Controls.Add(lblCedulaEmpleado);
            Controls.Add(lblCodigoEmpleado);
            Controls.Add(dgvReporteEmpleados);
            Name = "ReporteEmpleadosForm";
            Text = "ReporteEmpleadosForm";
            Load += ReporteEmpleadosForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReporteEmpleados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvReporteEmpleados;
        private Label lblCodigoEmpleado;
        private Label lblCedulaEmpleado;
        private TextBox txtCodigoEmpleado;
        private TextBox txtCedulaEmpleado;
        private Button btnSearch;
        private Button btnExport;
    }
}