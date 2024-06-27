namespace Proyecto_nomina
{
    partial class RegistroNominaForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btnGuardar = new Button();
            btnEliminar = new Button();
            btnActualizar = new Button();
            btnNvo = new Button();
            panel2 = new Panel();
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            txtPrestamos = new TextBox();
            label11 = new Label();
            txtAnticipos = new TextBox();
            label10 = new Label();
            groupBox2 = new GroupBox();
            ckRiesgoLaboral = new CheckBox();
            ckNocturnidad = new CheckBox();
            txtBonos = new TextBox();
            txtComisiones = new TextBox();
            label5 = new Label();
            label8 = new Label();
            txtDepreciacion = new TextBox();
            txtViaticos = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtDiasExtras = new TextBox();
            txtHorasExtras = new TextBox();
            label7 = new Label();
            label6 = new Label();
            txtSalarioOrdinario = new TextBox();
            label2 = new Label();
            cboCodigoEmpleado = new ComboBox();
            label1 = new Label();
            dgvRegistroNomina = new DataGridView();
            cboEstado = new ComboBox();
            dtpFechaTerminacion = new DateTimePicker();
            dtpFechaContratacion = new DateTimePicker();
            rdbMasculino = new RadioButton();
            dtpFechaNacimiento = new DateTimePicker();
            cboEstadoCivil = new ComboBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegistroNomina).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(29, 34, 39);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(btnEliminar);
            panel1.Controls.Add(btnActualizar);
            panel1.Controls.Add(btnNvo);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(95, 492);
            panel1.TabIndex = 1;
            // 
            // btnGuardar
            // 
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnGuardar.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 12F);
            btnGuardar.ForeColor = Color.Silver;
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(3, 56);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(93, 50);
            btnGuardar.TabIndex = 35;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnNuevo_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnEliminar.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 12F);
            btnEliminar.ForeColor = Color.Silver;
            btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEliminar.Location = new Point(2, 167);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(93, 50);
            btnEliminar.TabIndex = 34;
            btnEliminar.Text = "Eliminar";
            btnEliminar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnActualizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 12F);
            btnActualizar.ForeColor = Color.Silver;
            btnActualizar.ImageAlign = ContentAlignment.MiddleLeft;
            btnActualizar.Location = new Point(2, 112);
            btnActualizar.Margin = new Padding(3, 2, 3, 2);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(93, 50);
            btnActualizar.TabIndex = 33;
            btnActualizar.Text = "Actualizar";
            btnActualizar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnNvo
            // 
            btnNvo.Cursor = Cursors.Hand;
            btnNvo.FlatAppearance.BorderSize = 0;
            btnNvo.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnNvo.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnNvo.FlatStyle = FlatStyle.Flat;
            btnNvo.Font = new Font("Segoe UI", 12F);
            btnNvo.ForeColor = Color.Silver;
            btnNvo.ImageAlign = ContentAlignment.MiddleLeft;
            btnNvo.Location = new Point(3, 5);
            btnNvo.Margin = new Padding(3, 2, 3, 2);
            btnNvo.Name = "btnNvo";
            btnNvo.Size = new Size(93, 50);
            btnNvo.TabIndex = 32;
            btnNvo.Text = "Nuevo";
            btnNvo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNvo.UseVisualStyleBackColor = true;
            btnNvo.Click += btnNvo_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(95, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(756, 492);
            panel2.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(dgvRegistroNomina);
            groupBox1.Controls.Add(cboEstado);
            groupBox1.Controls.Add(dtpFechaTerminacion);
            groupBox1.Controls.Add(dtpFechaContratacion);
            groupBox1.Controls.Add(rdbMasculino);
            groupBox1.Controls.Add(dtpFechaNacimiento);
            groupBox1.Controls.Add(cboEstadoCivil);
            groupBox1.ForeColor = SystemColors.Control;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(756, 489);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "-";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtPrestamos);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(txtAnticipos);
            groupBox3.Controls.Add(label10);
            groupBox3.Location = new Point(6, 219);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(744, 72);
            groupBox3.TabIndex = 115;
            groupBox3.TabStop = false;
            groupBox3.Text = "Deducciones";
            // 
            // txtPrestamos
            // 
            txtPrestamos.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtPrestamos.Location = new Point(121, 30);
            txtPrestamos.Name = "txtPrestamos";
            txtPrestamos.Size = new Size(126, 22);
            txtPrestamos.TabIndex = 109;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 9.75F);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(261, 33);
            label11.Name = "label11";
            label11.Size = new Size(65, 16);
            label11.TabIndex = 106;
            label11.Text = "Anticipos:";
            // 
            // txtAnticipos
            // 
            txtAnticipos.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtAnticipos.Location = new Point(358, 25);
            txtAnticipos.Name = "txtAnticipos";
            txtAnticipos.Size = new Size(126, 22);
            txtAnticipos.TabIndex = 107;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 9.75F);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(16, 33);
            label10.Name = "label10";
            label10.Size = new Size(75, 16);
            label10.TabIndex = 103;
            label10.Text = "Préstamos:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ckRiesgoLaboral);
            groupBox2.Controls.Add(ckNocturnidad);
            groupBox2.Controls.Add(txtBonos);
            groupBox2.Controls.Add(txtComisiones);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(txtDepreciacion);
            groupBox2.Controls.Add(txtViaticos);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtDiasExtras);
            groupBox2.Controls.Add(txtHorasExtras);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtSalarioOrdinario);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(cboCodigoEmpleado);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(6, 10);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(744, 208);
            groupBox2.TabIndex = 114;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ingresos";
            // 
            // ckRiesgoLaboral
            // 
            ckRiesgoLaboral.AutoSize = true;
            ckRiesgoLaboral.ForeColor = SystemColors.ActiveCaptionText;
            ckRiesgoLaboral.Location = new Point(261, 164);
            ckRiesgoLaboral.Name = "ckRiesgoLaboral";
            ckRiesgoLaboral.Size = new Size(103, 19);
            ckRiesgoLaboral.TabIndex = 113;
            ckRiesgoLaboral.Text = "Riesgo Laboral";
            ckRiesgoLaboral.UseVisualStyleBackColor = true;
            // 
            // ckNocturnidad
            // 
            ckNocturnidad.AutoSize = true;
            ckNocturnidad.ForeColor = SystemColors.ActiveCaptionText;
            ckNocturnidad.Location = new Point(16, 164);
            ckNocturnidad.Name = "ckNocturnidad";
            ckNocturnidad.Size = new Size(93, 19);
            ckNocturnidad.TabIndex = 112;
            ckNocturnidad.Text = "Nocturnidad";
            ckNocturnidad.UseVisualStyleBackColor = true;
            // 
            // txtBonos
            // 
            txtBonos.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtBonos.Location = new Point(367, 122);
            txtBonos.Name = "txtBonos";
            txtBonos.Size = new Size(126, 22);
            txtBonos.TabIndex = 102;
            // 
            // txtComisiones
            // 
            txtComisiones.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtComisiones.Location = new Point(367, 78);
            txtComisiones.Name = "txtComisiones";
            txtComisiones.Size = new Size(126, 22);
            txtComisiones.TabIndex = 101;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9.75F);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(261, 124);
            label5.Name = "label5";
            label5.Size = new Size(49, 16);
            label5.TabIndex = 100;
            label5.Text = "Bonos:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 9.75F);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(261, 78);
            label8.Name = "label8";
            label8.Size = new Size(81, 16);
            label8.TabIndex = 99;
            label8.Text = "Comisiones:";
            // 
            // txtDepreciacion
            // 
            txtDepreciacion.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtDepreciacion.Location = new Point(367, 33);
            txtDepreciacion.Name = "txtDepreciacion";
            txtDepreciacion.Size = new Size(126, 22);
            txtDepreciacion.TabIndex = 98;
            // 
            // txtViaticos
            // 
            txtViaticos.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtViaticos.Location = new Point(121, 122);
            txtViaticos.Name = "txtViaticos";
            txtViaticos.Size = new Size(126, 22);
            txtViaticos.TabIndex = 97;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9.75F);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(261, 35);
            label3.Name = "label3";
            label3.Size = new Size(91, 16);
            label3.TabIndex = 96;
            label3.Text = "Depreciación:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9.75F);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(16, 126);
            label4.Name = "label4";
            label4.Size = new Size(58, 16);
            label4.TabIndex = 95;
            label4.Text = "Viáticos:";
            // 
            // txtDiasExtras
            // 
            txtDiasExtras.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtDiasExtras.Location = new Point(597, 77);
            txtDiasExtras.Name = "txtDiasExtras";
            txtDiasExtras.Size = new Size(126, 22);
            txtDiasExtras.TabIndex = 94;
            // 
            // txtHorasExtras
            // 
            txtHorasExtras.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtHorasExtras.Location = new Point(597, 31);
            txtHorasExtras.Name = "txtHorasExtras";
            txtHorasExtras.Size = new Size(126, 22);
            txtHorasExtras.TabIndex = 93;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 9.75F);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(508, 79);
            label7.Name = "label7";
            label7.Size = new Size(78, 16);
            label7.TabIndex = 92;
            label7.Text = "Días Extras:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9.75F);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(508, 35);
            label6.Name = "label6";
            label6.Size = new Size(87, 16);
            label6.TabIndex = 91;
            label6.Text = "Horas Extras:";
            // 
            // txtSalarioOrdinario
            // 
            txtSalarioOrdinario.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtSalarioOrdinario.Location = new Point(121, 78);
            txtSalarioOrdinario.Name = "txtSalarioOrdinario";
            txtSalarioOrdinario.Size = new Size(126, 22);
            txtSalarioOrdinario.TabIndex = 90;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9.75F);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(16, 70);
            label2.Name = "label2";
            label2.Size = new Size(65, 32);
            label2.TabIndex = 76;
            label2.Text = "Salario \r\nOrdinario:";
            // 
            // cboCodigoEmpleado
            // 
            cboCodigoEmpleado.Font = new Font("Microsoft Sans Serif", 9.75F);
            cboCodigoEmpleado.FormattingEnabled = true;
            cboCodigoEmpleado.Location = new Point(121, 33);
            cboCodigoEmpleado.Name = "cboCodigoEmpleado";
            cboCodigoEmpleado.Size = new Size(126, 24);
            cboCodigoEmpleado.TabIndex = 75;
            cboCodigoEmpleado.Format += cboCodigoEmpleado_Format;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9.75F);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(16, 36);
            label1.Name = "label1";
            label1.Size = new Size(91, 16);
            label1.TabIndex = 74;
            label1.Text = "Nº Empleado:";
            // 
            // dgvRegistroNomina
            // 
            dgvRegistroNomina.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvRegistroNomina.DefaultCellStyle = dataGridViewCellStyle1;
            dgvRegistroNomina.Location = new Point(8, 297);
            dgvRegistroNomina.Name = "dgvRegistroNomina";
            dgvRegistroNomina.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegistroNomina.Size = new Size(738, 188);
            dgvRegistroNomina.TabIndex = 113;
            dgvRegistroNomina.CellClick += dgvRegistroNomina_CellClick;
            // 
            // cboEstado
            // 
            cboEstado.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.FormattingEnabled = true;
            cboEstado.Items.AddRange(new object[] { "Activo/a", "Inactivo/a" });
            cboEstado.Location = new Point(1176, 168);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(100, 23);
            cboEstado.TabIndex = 112;
            // 
            // dtpFechaTerminacion
            // 
            dtpFechaTerminacion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFechaTerminacion.Format = DateTimePickerFormat.Short;
            dtpFechaTerminacion.Location = new Point(1176, 83);
            dtpFechaTerminacion.Name = "dtpFechaTerminacion";
            dtpFechaTerminacion.Size = new Size(100, 23);
            dtpFechaTerminacion.TabIndex = 111;
            // 
            // dtpFechaContratacion
            // 
            dtpFechaContratacion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFechaContratacion.Format = DateTimePickerFormat.Short;
            dtpFechaContratacion.Location = new Point(1176, 36);
            dtpFechaContratacion.Name = "dtpFechaContratacion";
            dtpFechaContratacion.Size = new Size(100, 23);
            dtpFechaContratacion.TabIndex = 110;
            // 
            // rdbMasculino
            // 
            rdbMasculino.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rdbMasculino.AutoSize = true;
            rdbMasculino.ForeColor = Color.Black;
            rdbMasculino.Location = new Point(922, 72);
            rdbMasculino.Name = "rdbMasculino";
            rdbMasculino.Size = new Size(80, 19);
            rdbMasculino.TabIndex = 108;
            rdbMasculino.TabStop = true;
            rdbMasculino.Text = "Masculino";
            rdbMasculino.UseVisualStyleBackColor = true;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(922, 34);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(100, 23);
            dtpFechaNacimiento.TabIndex = 107;
            // 
            // cboEstadoCivil
            // 
            cboEstadoCivil.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboEstadoCivil.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstadoCivil.FormattingEnabled = true;
            cboEstadoCivil.Items.AddRange(new object[] { "Soltero/a", "Casado/o", "Divorciado/a", "Viudo/a" });
            cboEstadoCivil.Location = new Point(922, 134);
            cboEstadoCivil.Name = "cboEstadoCivil";
            cboEstadoCivil.Size = new Size(100, 23);
            cboEstadoCivil.TabIndex = 106;
            // 
            // RegistroNominaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(851, 492);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "RegistroNominaForm";
            Text = "RegistroNominaForm";
            Load += RegistroNominaForm_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegistroNomina).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnActualizar;
        private Button btnNvo;
        private Panel panel2;
        private GroupBox groupBox1;
        private DataGridView dgvRegistroNomina;
        private ComboBox cboEstado;
        private DateTimePicker dtpFechaTerminacion;
        private DateTimePicker dtpFechaContratacion;
        private RadioButton rdbMasculino;
        private DateTimePicker dtpFechaNacimiento;
        private ComboBox cboEstadoCivil;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label1;
        private ComboBox cboCodigoEmpleado;
        private Label label2;
        private TextBox txtSalarioOrdinario;
        private TextBox txtBonos;
        private TextBox txtComisiones;
        private Label label5;
        private Label label8;
        private TextBox txtDepreciacion;
        private TextBox txtViaticos;
        private Label label3;
        private Label label4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label label9;
        private Label label10;
        private TextBox txtDiasExtras;
        private TextBox txtHorasExtras;
        private Label label7;
        private Label label6;
        private Label label11;
        private TextBox txtAnticipos;
        private TextBox txtPrestamos;
        private CheckBox ckRiesgoLaboral;
        private CheckBox ckNocturnidad;
    }
}