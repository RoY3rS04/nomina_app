namespace Proyecto_nomina
{
    partial class RegistroEmpleadoForm
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
            btnNuevo = new Button();
            btnEliminar = new Button();
            btnActualizar = new Button();
            btnGuardar = new Button();
            panel2 = new Panel();
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            label17 = new Label();
            dgvRegistroEmpleado = new DataGridView();
            cboEstado = new ComboBox();
            dtpFechaTerminacion = new DateTimePicker();
            dtpFechaContratacion = new DateTimePicker();
            rdbFemenino = new RadioButton();
            rdbMasculino = new RadioButton();
            dtpFechaNacimiento = new DateTimePicker();
            cboEstadoCivil = new ComboBox();
            txtSalarioOrdinario = new TextBox();
            ntxtCelular = new MaskedTextBox();
            txtDireccion = new TextBox();
            mtxtTelefono = new MaskedTextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            txtRUC = new TextBox();
            txtINSS = new TextBox();
            txtCedula = new TextBox();
            txtCodigoEmpleado = new TextBox();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegistroEmpleado).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(29, 34, 39);
            panel1.Controls.Add(btnNuevo);
            panel1.Controls.Add(btnEliminar);
            panel1.Controls.Add(btnActualizar);
            panel1.Controls.Add(btnGuardar);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(95, 492);
            panel1.TabIndex = 0;
            // 
            // btnNuevo
            // 
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnNuevo.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 12F);
            btnNuevo.ForeColor = Color.Silver;
            btnNuevo.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevo.Location = new Point(2, 11);
            btnNuevo.Margin = new Padding(3, 2, 3, 2);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(93, 50);
            btnNuevo.TabIndex = 35;
            btnNuevo.Text = "Nuevo";
            btnNuevo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNuevo.UseVisualStyleBackColor = true;
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
            btnEliminar.Location = new Point(2, 168);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(93, 50);
            btnEliminar.TabIndex = 34;
            btnEliminar.Text = "Eliminar";
            btnEliminar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEliminar.UseVisualStyleBackColor = true;
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
            btnActualizar.Location = new Point(2, 114);
            btnActualizar.Margin = new Padding(3, 2, 3, 2);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(93, 50);
            btnActualizar.TabIndex = 33;
            btnActualizar.Text = "Actualizar";
            btnActualizar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnActualizar.UseVisualStyleBackColor = true;
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
            btnGuardar.Location = new Point(2, 60);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(93, 50);
            btnGuardar.TabIndex = 32;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(95, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(756, 492);
            panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label17);
            groupBox1.Controls.Add(dgvRegistroEmpleado);
            groupBox1.Controls.Add(cboEstado);
            groupBox1.Controls.Add(dtpFechaTerminacion);
            groupBox1.Controls.Add(dtpFechaContratacion);
            groupBox1.Controls.Add(rdbFemenino);
            groupBox1.Controls.Add(rdbMasculino);
            groupBox1.Controls.Add(dtpFechaNacimiento);
            groupBox1.Controls.Add(cboEstadoCivil);
            groupBox1.Controls.Add(txtSalarioOrdinario);
            groupBox1.Controls.Add(ntxtCelular);
            groupBox1.Controls.Add(txtDireccion);
            groupBox1.Controls.Add(mtxtTelefono);
            groupBox1.Controls.Add(txtApellido);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(txtRUC);
            groupBox1.Controls.Add(txtINSS);
            groupBox1.Controls.Add(txtCedula);
            groupBox1.Controls.Add(txtCodigoEmpleado);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.Black;
            groupBox1.Location = new Point(0, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(756, 486);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Registro";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 9.75F);
            textBox1.Location = new Point(620, 170);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 25);
            textBox1.TabIndex = 115;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9.75F);
            label17.ForeColor = Color.Black;
            label17.Location = new Point(508, 173);
            label17.Name = "label17";
            label17.Size = new Size(47, 17);
            label17.TabIndex = 114;
            label17.Text = "Cargo:";
            // 
            // dgvRegistroEmpleado
            // 
            dgvRegistroEmpleado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegistroEmpleado.Location = new Point(7, 285);
            dgvRegistroEmpleado.Name = "dgvRegistroEmpleado";
            dgvRegistroEmpleado.Size = new Size(738, 190);
            dgvRegistroEmpleado.TabIndex = 113;
            // 
            // cboEstado
            // 
            cboEstado.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.Font = new Font("Segoe UI", 9.75F);
            cboEstado.FormattingEnabled = true;
            cboEstado.Items.AddRange(new object[] { "Activo/a", "Inactivo/a" });
            cboEstado.Location = new Point(620, 210);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(100, 25);
            cboEstado.TabIndex = 112;
            // 
            // dtpFechaTerminacion
            // 
            dtpFechaTerminacion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFechaTerminacion.Font = new Font("Segoe UI", 9.75F);
            dtpFechaTerminacion.Format = DateTimePickerFormat.Short;
            dtpFechaTerminacion.Location = new Point(620, 83);
            dtpFechaTerminacion.Name = "dtpFechaTerminacion";
            dtpFechaTerminacion.Size = new Size(100, 25);
            dtpFechaTerminacion.TabIndex = 111;
            // 
            // dtpFechaContratacion
            // 
            dtpFechaContratacion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFechaContratacion.Font = new Font("Segoe UI", 9.75F);
            dtpFechaContratacion.Format = DateTimePickerFormat.Short;
            dtpFechaContratacion.Location = new Point(620, 36);
            dtpFechaContratacion.Name = "dtpFechaContratacion";
            dtpFechaContratacion.Size = new Size(100, 25);
            dtpFechaContratacion.TabIndex = 110;
            // 
            // rdbFemenino
            // 
            rdbFemenino.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rdbFemenino.AutoSize = true;
            rdbFemenino.Font = new Font("Segoe UI", 9.75F);
            rdbFemenino.ForeColor = Color.Black;
            rdbFemenino.Location = new Point(362, 97);
            rdbFemenino.Name = "rdbFemenino";
            rdbFemenino.Size = new Size(82, 21);
            rdbFemenino.TabIndex = 109;
            rdbFemenino.TabStop = true;
            rdbFemenino.Text = "Femenino";
            rdbFemenino.UseVisualStyleBackColor = true;
            // 
            // rdbMasculino
            // 
            rdbMasculino.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rdbMasculino.AutoSize = true;
            rdbMasculino.Font = new Font("Segoe UI", 9.75F);
            rdbMasculino.ForeColor = Color.Black;
            rdbMasculino.Location = new Point(361, 72);
            rdbMasculino.Name = "rdbMasculino";
            rdbMasculino.Size = new Size(85, 21);
            rdbMasculino.TabIndex = 108;
            rdbMasculino.TabStop = true;
            rdbMasculino.Text = "Masculino";
            rdbMasculino.UseVisualStyleBackColor = true;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFechaNacimiento.Font = new Font("Segoe UI", 9.75F);
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(366, 34);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(100, 25);
            dtpFechaNacimiento.TabIndex = 107;
            // 
            // cboEstadoCivil
            // 
            cboEstadoCivil.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboEstadoCivil.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstadoCivil.Font = new Font("Segoe UI", 9.75F);
            cboEstadoCivil.FormattingEnabled = true;
            cboEstadoCivil.Items.AddRange(new object[] { "Soltero/a", "Casado/a" });
            cboEstadoCivil.Location = new Point(366, 134);
            cboEstadoCivil.Name = "cboEstadoCivil";
            cboEstadoCivil.Size = new Size(100, 25);
            cboEstadoCivil.TabIndex = 106;
            // 
            // txtSalarioOrdinario
            // 
            txtSalarioOrdinario.Font = new Font("Segoe UI", 9.75F);
            txtSalarioOrdinario.Location = new Point(620, 130);
            txtSalarioOrdinario.Name = "txtSalarioOrdinario";
            txtSalarioOrdinario.Size = new Size(100, 25);
            txtSalarioOrdinario.TabIndex = 104;
            // 
            // ntxtCelular
            // 
            ntxtCelular.Font = new Font("Segoe UI", 9.75F);
            ntxtCelular.Location = new Point(366, 242);
            ntxtCelular.Mask = "(505)-0000-0000";
            ntxtCelular.Name = "ntxtCelular";
            ntxtCelular.Size = new Size(100, 25);
            ntxtCelular.TabIndex = 101;
            // 
            // txtDireccion
            // 
            txtDireccion.Font = new Font("Segoe UI", 9.75F);
            txtDireccion.Location = new Point(366, 170);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(100, 25);
            txtDireccion.TabIndex = 100;
            // 
            // mtxtTelefono
            // 
            mtxtTelefono.Font = new Font("Segoe UI", 9.75F);
            mtxtTelefono.Location = new Point(366, 205);
            mtxtTelefono.Mask = "(505)-0000-0000";
            mtxtTelefono.Name = "mtxtTelefono";
            mtxtTelefono.Size = new Size(100, 25);
            mtxtTelefono.TabIndex = 95;
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Segoe UI", 9.75F);
            txtApellido.Location = new Point(117, 239);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(111, 25);
            txtApellido.TabIndex = 94;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 9.75F);
            txtNombre.Location = new Point(117, 202);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(111, 25);
            txtNombre.TabIndex = 93;
            // 
            // txtRUC
            // 
            txtRUC.Font = new Font("Segoe UI", 9.75F);
            txtRUC.Location = new Point(117, 159);
            txtRUC.Name = "txtRUC";
            txtRUC.Size = new Size(111, 25);
            txtRUC.TabIndex = 92;
            // 
            // txtINSS
            // 
            txtINSS.Font = new Font("Segoe UI", 9.75F);
            txtINSS.Location = new Point(117, 120);
            txtINSS.Name = "txtINSS";
            txtINSS.Size = new Size(111, 25);
            txtINSS.TabIndex = 91;
            // 
            // txtCedula
            // 
            txtCedula.Font = new Font("Segoe UI", 9.75F);
            txtCedula.Location = new Point(117, 76);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(111, 25);
            txtCedula.TabIndex = 90;
            // 
            // txtCodigoEmpleado
            // 
            txtCodigoEmpleado.Font = new Font("Segoe UI", 9.75F);
            txtCodigoEmpleado.Location = new Point(117, 39);
            txtCodigoEmpleado.Name = "txtCodigoEmpleado";
            txtCodigoEmpleado.Size = new Size(111, 25);
            txtCodigoEmpleado.TabIndex = 89;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9.75F);
            label16.ForeColor = Color.Black;
            label16.Location = new Point(508, 210);
            label16.Name = "label16";
            label16.Size = new Size(51, 17);
            label16.TabIndex = 88;
            label16.Text = "Estado:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9.75F);
            label15.ForeColor = Color.Black;
            label15.Location = new Point(508, 134);
            label15.Name = "label15";
            label15.Size = new Size(111, 17);
            label15.TabIndex = 87;
            label15.Text = "Salario Ordinario:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9.75F);
            label14.ForeColor = Color.Black;
            label14.Location = new Point(508, 76);
            label14.Name = "label14";
            label14.Size = new Size(81, 34);
            label14.TabIndex = 86;
            label14.Text = "Fecha de \r\nTerminación:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9.75F);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(508, 36);
            label13.Name = "label13";
            label13.Size = new Size(85, 34);
            label13.TabIndex = 85;
            label13.Text = "Fecha de \r\nContratación:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9.75F);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(258, 245);
            label12.Name = "label12";
            label12.Size = new Size(51, 17);
            label12.TabIndex = 84;
            label12.Text = "Celular:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.75F);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(258, 210);
            label11.Name = "label11";
            label11.Size = new Size(61, 17);
            label11.TabIndex = 83;
            label11.Text = "Teléfono:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9.75F);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(258, 173);
            label10.Name = "label10";
            label10.Size = new Size(65, 17);
            label10.TabIndex = 82;
            label10.Text = "Dirección:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(258, 139);
            label9.Name = "label9";
            label9.Size = new Size(78, 17);
            label9.TabIndex = 81;
            label9.Text = "Estado Civil:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(258, 84);
            label8.Name = "label8";
            label8.Size = new Size(39, 17);
            label8.TabIndex = 80;
            label8.Text = "Sexo:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(257, 32);
            label7.Name = "label7";
            label7.Size = new Size(77, 34);
            label7.TabIndex = 79;
            label7.Text = "Fecha de\r\nNacimiento:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(24, 83);
            label6.Name = "label6";
            label6.Size = new Size(71, 17);
            label6.TabIndex = 78;
            label6.Text = "Nº Cédula:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(24, 242);
            label5.Name = "label5";
            label5.Size = new Size(59, 17);
            label5.TabIndex = 77;
            label5.Text = "Apellido:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(24, 205);
            label4.Name = "label4";
            label4.Size = new Size(60, 17);
            label4.TabIndex = 76;
            label4.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(24, 165);
            label3.Name = "label3";
            label3.Size = new Size(56, 17);
            label3.TabIndex = 75;
            label3.Text = "Nº RUC:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(24, 123);
            label2.Name = "label2";
            label2.Size = new Size(62, 17);
            label2.TabIndex = 74;
            label2.Text = "Nº  INSS:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(21, 41);
            label1.Name = "label1";
            label1.Size = new Size(90, 17);
            label1.TabIndex = 73;
            label1.Text = "Nº Empleado:";
            // 
            // RegistroEmpleadoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(851, 492);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "RegistroEmpleadoForm";
            Text = "RegistroEmpleadoForm";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegistroEmpleado).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnEliminar;
        private Button btnActualizar;
        private Button btnGuardar;
        private Panel panel2;
        private Button btnNuevo;
        private GroupBox groupBox1;
        private TextBox txtSalarioOrdinario;
        private MaskedTextBox ntxtCelular;
        private TextBox txtDireccion;
        private MaskedTextBox mtxtTelefono;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private TextBox txtRUC;
        private TextBox txtINSS;
        private TextBox txtCedula;
        private TextBox txtCodigoEmpleado;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cboEstadoCivil;
        private RadioButton rdbFemenino;
        private RadioButton rdbMasculino;
        private DateTimePicker dtpFechaNacimiento;
        private DateTimePicker dtpFechaTerminacion;
        private DateTimePicker dtpFechaContratacion;
        private ComboBox cboEstado;
        private DataGridView dgvRegistroEmpleado;
        private TextBox textBox1;
        private Label label17;
    }
}