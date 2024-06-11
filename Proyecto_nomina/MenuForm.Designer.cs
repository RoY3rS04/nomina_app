namespace Proyecto_nomina
{
    partial class MenuForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            pnlContenedor = new Panel();
            pnlContenedorForm = new Panel();
            pnlMenu = new Panel();
            btnRegistroUsuarioForm = new Button();
            btnAyuda = new Button();
            btnReportes = new Button();
            btnRegistroNominaForm = new Button();
            btnRegistroEmpleadoForm = new Button();
            btnMenu = new Button();
            panel3 = new Panel();
            btnMaximizar = new Button();
            btnCerrar = new Button();
            btnNormal = new Button();
            btnMinimizar = new Button();
            tmExpandirMenu = new System.Windows.Forms.Timer(components);
            tmContraerMenu = new System.Windows.Forms.Timer(components);
            pnlContenedor.SuspendLayout();
            pnlMenu.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContenedor
            // 
            pnlContenedor.BackColor = Color.FromArgb(64, 69, 76);
            pnlContenedor.Controls.Add(pnlContenedorForm);
            pnlContenedor.Controls.Add(pnlMenu);
            pnlContenedor.Controls.Add(panel3);
            pnlContenedor.Dock = DockStyle.Fill;
            pnlContenedor.Location = new Point(0, 0);
            pnlContenedor.Name = "pnlContenedor";
            pnlContenedor.Size = new Size(1097, 554);
            pnlContenedor.TabIndex = 0;
            // 
            // pnlContenedorForm
            // 
            pnlContenedorForm.BackColor = Color.FromArgb(64, 69, 76);
            pnlContenedorForm.Dock = DockStyle.Fill;
            pnlContenedorForm.Location = new Point(230, 55);
            pnlContenedorForm.Name = "pnlContenedorForm";
            pnlContenedorForm.Size = new Size(867, 499);
            pnlContenedorForm.TabIndex = 5;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(29, 34, 39);
            pnlMenu.Controls.Add(btnRegistroUsuarioForm);
            pnlMenu.Controls.Add(btnAyuda);
            pnlMenu.Controls.Add(btnReportes);
            pnlMenu.Controls.Add(btnRegistroNominaForm);
            pnlMenu.Controls.Add(btnRegistroEmpleadoForm);
            pnlMenu.Controls.Add(btnMenu);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 55);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(230, 499);
            pnlMenu.TabIndex = 3;
            // 
            // btnRegistroUsuarioForm
            // 
            btnRegistroUsuarioForm.Cursor = Cursors.Hand;
            btnRegistroUsuarioForm.FlatAppearance.BorderSize = 0;
            btnRegistroUsuarioForm.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnRegistroUsuarioForm.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnRegistroUsuarioForm.FlatStyle = FlatStyle.Flat;
            btnRegistroUsuarioForm.Font = new Font("Segoe UI", 12F);
            btnRegistroUsuarioForm.ForeColor = Color.Silver;
            btnRegistroUsuarioForm.Image = (Image)resources.GetObject("btnRegistroUsuarioForm.Image");
            btnRegistroUsuarioForm.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegistroUsuarioForm.Location = new Point(-6, 61);
            btnRegistroUsuarioForm.Margin = new Padding(3, 2, 3, 2);
            btnRegistroUsuarioForm.Name = "btnRegistroUsuarioForm";
            btnRegistroUsuarioForm.Size = new Size(238, 57);
            btnRegistroUsuarioForm.TabIndex = 7;
            btnRegistroUsuarioForm.Text = "   Registro de Usuario";
            btnRegistroUsuarioForm.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistroUsuarioForm.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRegistroUsuarioForm.UseVisualStyleBackColor = true;
            btnRegistroUsuarioForm.Click += btnRegistroUsuarioForm_Click;
            // 
            // btnAyuda
            // 
            btnAyuda.Cursor = Cursors.Hand;
            btnAyuda.FlatAppearance.BorderSize = 0;
            btnAyuda.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnAyuda.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnAyuda.FlatStyle = FlatStyle.Flat;
            btnAyuda.Font = new Font("Segoe UI", 12F);
            btnAyuda.ForeColor = Color.Silver;
            btnAyuda.Image = (Image)resources.GetObject("btnAyuda.Image");
            btnAyuda.ImageAlign = ContentAlignment.MiddleLeft;
            btnAyuda.Location = new Point(1, 438);
            btnAyuda.Margin = new Padding(3, 2, 3, 2);
            btnAyuda.Name = "btnAyuda";
            btnAyuda.Size = new Size(229, 58);
            btnAyuda.TabIndex = 6;
            btnAyuda.Text = "      Ayuda";
            btnAyuda.TextAlign = ContentAlignment.MiddleLeft;
            btnAyuda.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAyuda.UseVisualStyleBackColor = true;
            // 
            // btnReportes
            // 
            btnReportes.Cursor = Cursors.Hand;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnReportes.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Segoe UI", 12F);
            btnReportes.ForeColor = Color.Silver;
            btnReportes.Image = (Image)resources.GetObject("btnReportes.Image");
            btnReportes.ImageAlign = ContentAlignment.MiddleLeft;
            btnReportes.Location = new Point(-6, 245);
            btnReportes.Margin = new Padding(3, 2, 3, 2);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(235, 58);
            btnReportes.TabIndex = 5;
            btnReportes.Text = "  Reportes";
            btnReportes.TextAlign = ContentAlignment.MiddleLeft;
            btnReportes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnRegistroNominaForm
            // 
            btnRegistroNominaForm.Cursor = Cursors.Hand;
            btnRegistroNominaForm.FlatAppearance.BorderSize = 0;
            btnRegistroNominaForm.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnRegistroNominaForm.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnRegistroNominaForm.FlatStyle = FlatStyle.Flat;
            btnRegistroNominaForm.Font = new Font("Segoe UI", 12F);
            btnRegistroNominaForm.ForeColor = Color.Silver;
            btnRegistroNominaForm.Image = (Image)resources.GetObject("btnRegistroNominaForm.Image");
            btnRegistroNominaForm.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegistroNominaForm.Location = new Point(-5, 183);
            btnRegistroNominaForm.Margin = new Padding(3, 2, 3, 2);
            btnRegistroNominaForm.Name = "btnRegistroNominaForm";
            btnRegistroNominaForm.Size = new Size(235, 58);
            btnRegistroNominaForm.TabIndex = 4;
            btnRegistroNominaForm.Text = "  Registro de Nómina";
            btnRegistroNominaForm.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistroNominaForm.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRegistroNominaForm.UseVisualStyleBackColor = true;
            btnRegistroNominaForm.Click += btnRegistroNominaForm_Click;
            // 
            // btnRegistroEmpleadoForm
            // 
            btnRegistroEmpleadoForm.Cursor = Cursors.Hand;
            btnRegistroEmpleadoForm.FlatAppearance.BorderSize = 0;
            btnRegistroEmpleadoForm.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnRegistroEmpleadoForm.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnRegistroEmpleadoForm.FlatStyle = FlatStyle.Flat;
            btnRegistroEmpleadoForm.Font = new Font("Segoe UI", 12F);
            btnRegistroEmpleadoForm.ForeColor = Color.Silver;
            btnRegistroEmpleadoForm.Image = (Image)resources.GetObject("btnRegistroEmpleadoForm.Image");
            btnRegistroEmpleadoForm.ImageAlign = ContentAlignment.MiddleRight;
            btnRegistroEmpleadoForm.Location = new Point(1, 122);
            btnRegistroEmpleadoForm.Margin = new Padding(3, 2, 3, 2);
            btnRegistroEmpleadoForm.Name = "btnRegistroEmpleadoForm";
            btnRegistroEmpleadoForm.Size = new Size(229, 57);
            btnRegistroEmpleadoForm.TabIndex = 3;
            btnRegistroEmpleadoForm.Text = "     Registro de Empleado";
            btnRegistroEmpleadoForm.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistroEmpleadoForm.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRegistroEmpleadoForm.UseVisualStyleBackColor = true;
            btnRegistroEmpleadoForm.Click += btnRegistroEmpleadoForm_Click;
            // 
            // btnMenu
            // 
            btnMenu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMenu.Cursor = Cursors.Hand;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Image = (Image)resources.GetObject("btnMenu.Image");
            btnMenu.Location = new Point(171, 0);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(64, 56);
            btnMenu.TabIndex = 2;
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += btnMenu_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LawnGreen;
            panel3.Controls.Add(btnMaximizar);
            panel3.Controls.Add(btnCerrar);
            panel3.Controls.Add(btnNormal);
            panel3.Controls.Add(btnMinimizar);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1097, 55);
            panel3.TabIndex = 2;
            // 
            // btnMaximizar
            // 
            btnMaximizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMaximizar.FlatAppearance.BorderSize = 0;
            btnMaximizar.FlatStyle = FlatStyle.Flat;
            btnMaximizar.Image = (Image)resources.GetObject("btnMaximizar.Image");
            btnMaximizar.Location = new Point(967, 0);
            btnMaximizar.Name = "btnMaximizar";
            btnMaximizar.Size = new Size(57, 53);
            btnMaximizar.TabIndex = 2;
            btnMaximizar.UseVisualStyleBackColor = true;
            btnMaximizar.Click += btnMaximizar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Image = (Image)resources.GetObject("btnCerrar.Image");
            btnCerrar.Location = new Point(1040, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(57, 53);
            btnCerrar.TabIndex = 5;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnNormal
            // 
            btnNormal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNormal.FlatAppearance.BorderSize = 0;
            btnNormal.FlatStyle = FlatStyle.Flat;
            btnNormal.Image = (Image)resources.GetObject("btnNormal.Image");
            btnNormal.Location = new Point(967, 0);
            btnNormal.Name = "btnNormal";
            btnNormal.Size = new Size(57, 53);
            btnNormal.TabIndex = 4;
            btnNormal.UseVisualStyleBackColor = true;
            btnNormal.Click += btnNormal_Click;
            // 
            // btnMinimizar
            // 
            btnMinimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimizar.BackColor = Color.LawnGreen;
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.FlatStyle = FlatStyle.Flat;
            btnMinimizar.Image = (Image)resources.GetObject("btnMinimizar.Image");
            btnMinimizar.Location = new Point(892, 0);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(57, 53);
            btnMinimizar.TabIndex = 1;
            btnMinimizar.UseVisualStyleBackColor = false;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // tmExpandirMenu
            // 
            tmExpandirMenu.Tick += tmExpandirMenu_Tick;
            // 
            // tmContraerMenu
            // 
            tmContraerMenu.Tick += tmContraerMenu_Tick;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1097, 554);
            Controls.Add(pnlContenedor);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MenuForm";
            Text = "MenuForm";
            pnlContenedor.ResumeLayout(false);
            pnlMenu.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContenedor;
        private Panel pnlMenu;
        private Panel panel3;
        private Panel pnlContenedorForm;
        private Button btnMaximizar;
        private Button btnMinimizar;
        private Button btnNormal;
        private Button btnMenu;
        private System.Windows.Forms.Timer tmExpandirMenu;
        private System.Windows.Forms.Timer tmContraerMenu;
        private Button btnCerrar;
        private Button btnRegistroEmpleadoForm;
        private Button btnRegistroNominaForm;
        private Button btnReportes;
        private Button btnAyuda;
        private Button btnRegistroUsuarioForm;
    }
}