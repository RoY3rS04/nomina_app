﻿namespace Proyecto_nomina
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            panel3 = new Panel();
            btnCerrar = new Button();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.Controls.Add(btnCerrar);
            panel3.Controls.Add(panel2);
            panel3.Controls.Add(btnLogin);
            panel3.Controls.Add(txtPassword);
            panel3.Controls.Add(txtEmail);
            panel3.Location = new Point(32, 21);
            panel3.Name = "panel3";
            panel3.Size = new Size(349, 337);
            panel3.TabIndex = 3;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.ForeColor = Color.Blue;
            btnCerrar.Location = new Point(0, 313);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(349, 24);
            btnCerrar.TabIndex = 37;
            btnCerrar.Text = "salir";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(29, 34, 39);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(349, 123);
            panel2.TabIndex = 36;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(120, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(108, 107);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(64, 69, 76);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 69, 76);
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 45, 53);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F);
            btnLogin.ForeColor = SystemColors.Control;
            btnLogin.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogin.Location = new Point(77, 243);
            btnLogin.Margin = new Padding(3, 2, 3, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(188, 42);
            btnLogin.TabIndex = 35;
            btnLogin.Text = "Login";
            btnLogin.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.Control;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = SystemColors.WindowFrame;
            txtPassword.Location = new Point(77, 191);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(188, 27);
            txtPassword.TabIndex = 1;
            txtPassword.Text = "Password";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = SystemColors.Control;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = SystemColors.WindowFrame;
            txtEmail.Location = new Point(77, 152);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(188, 27);
            txtEmail.TabIndex = 0;
            txtEmail.Text = "Email";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 34, 39);
            ClientSize = new Size(412, 386);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            Opacity = 0.99D;
            Text = "LoginForm";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private Button btnLogin;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Button btnCerrar;
    }
}