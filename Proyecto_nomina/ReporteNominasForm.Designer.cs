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
            lblEmpleado = new Label();
            lblFecha = new Label();
            cmbEmpleado = new ComboBox();
            dtpFecha = new DateTimePicker();
            btnSearch = new Button();
            checkTodos = new CheckBox();
            btnExport = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReporteNominas).BeginInit();
            SuspendLayout();
            // 
            // dgvReporteNominas
            // 
            dgvReporteNominas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporteNominas.Location = new Point(30, 140);
            dgvReporteNominas.Name = "dgvReporteNominas";
            dgvReporteNominas.Size = new Size(699, 242);
            dgvReporteNominas.TabIndex = 2;
            // 
            // lblEmpleado
            // 
            lblEmpleado.AutoSize = true;
            lblEmpleado.Location = new Point(30, 35);
            lblEmpleado.Name = "lblEmpleado";
            lblEmpleado.Size = new Size(63, 15);
            lblEmpleado.TabIndex = 3;
            lblEmpleado.Text = "Empleado:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(240, 35);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(103, 15);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "Fecha Realizacion:";
            // 
            // cmbEmpleado
            // 
            cmbEmpleado.FormattingEnabled = true;
            cmbEmpleado.Location = new Point(112, 32);
            cmbEmpleado.Name = "cmbEmpleado";
            cmbEmpleado.Size = new Size(108, 23);
            cmbEmpleado.TabIndex = 5;
            cmbEmpleado.Format += cmbEmpleado_Format;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(358, 32);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.ShowCheckBox = true;
            dtpFecha.Size = new Size(181, 23);
            dtpFecha.TabIndex = 6;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(30, 76);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(699, 41);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Buscar Nominas";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // checkTodos
            // 
            checkTodos.AutoSize = true;
            checkTodos.Location = new Point(593, 36);
            checkTodos.Name = "checkTodos";
            checkTodos.Size = new Size(136, 19);
            checkTodos.TabIndex = 8;
            checkTodos.Text = "Todos los empleados";
            checkTodos.UseVisualStyleBackColor = true;
            checkTodos.CheckedChanged += checkTodos_CheckedChanged;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(30, 400);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(699, 33);
            btnExport.TabIndex = 9;
            btnExport.Text = "Exportar Nominas";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // ReporteNominasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 453);
            Controls.Add(btnExport);
            Controls.Add(checkTodos);
            Controls.Add(btnSearch);
            Controls.Add(dtpFecha);
            Controls.Add(cmbEmpleado);
            Controls.Add(lblFecha);
            Controls.Add(lblEmpleado);
            Controls.Add(dgvReporteNominas);
            Name = "ReporteNominasForm";
            Text = "ReporteNominasForm";
            Load += ReporteNominasForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReporteNominas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvReporteNominas;
        private Label lblEmpleado;
        private Label lblFecha;
        private ComboBox cmbEmpleado;
        private DateTimePicker dtpFecha;
        private Button btnSearch;
        private CheckBox checkTodos;
        private Button btnExport;
    }
}