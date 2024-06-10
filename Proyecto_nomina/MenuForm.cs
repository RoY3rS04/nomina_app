﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_nomina
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();

            tmExpandirMenu.Interval = 15;
            tmExpandirMenu.Tick += new EventHandler(tmExpandirMenu_Tick);

            tmContraerMenu.Interval = 15;
            tmContraerMenu.Tick += new EventHandler(tmContraerMenu_Tick);
        }

        int lx, ly;
        int sw, sh;

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnMaximizar.Visible = false;
            btnNormal.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnNormal.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (pnlMenu.Width == 230)
                tmContraerMenu.Start();
            else if (pnlMenu.Width == 55)
                tmExpandirMenu.Start();
        }

        private void tmExpandirMenu_Tick(object sender, EventArgs e)
        {
            if (pnlMenu.Width >= 230)
                tmExpandirMenu.Stop();
            else
                pnlMenu.Width += 5;
        }

        private void tmContraerMenu_Tick(object sender, EventArgs e)
        {
            if (pnlMenu.Width <= 55)
                tmContraerMenu.Stop();
            else
                pnlMenu.Width -= 5;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegistroEmpleadoForm_Click(object sender, EventArgs e)
        {
            RegistroEmpleadoForm frm = new RegistroEmpleadoForm();
            AbrirFormEnPanel(frm);
        }

        private void AbrirFormEnPanel(RegistroEmpleadoForm frm)
        {
            if (pnlContenedorForm.Controls.Count > 0)
                pnlContenedorForm.Controls.RemoveAt(0);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlContenedorForm.Controls.Add(frm);
            pnlContenedorForm.Tag = frm;
            frm.Show();
        }

        private void btnRegistroNominaForm_Click(object sender, EventArgs e)
        {
            RegistroNominaForm frm = new RegistroNominaForm();
            AbrirFormEnPanel2(frm);
        }

        private void AbrirFormEnPanel2(RegistroNominaForm frm)
        {
            if (pnlContenedorForm.Controls.Count > 0)
                pnlContenedorForm.Controls.RemoveAt(0);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlContenedorForm.Controls.Add(frm);
            pnlContenedorForm.Tag = frm;
            frm.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ReportesForm frm = new ReportesForm();
            AbrirFormEnPanel3(frm);
        }

        private void AbrirFormEnPanel3(ReportesForm frm)
        {
            if (pnlContenedorForm.Controls.Count > 0)
                pnlContenedorForm.Controls.RemoveAt(0);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlContenedorForm.Controls.Add(frm);
            pnlContenedorForm.Tag = frm;
            frm.Show();
        }
    }
}