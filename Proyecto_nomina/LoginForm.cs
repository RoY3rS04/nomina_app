using Newtonsoft.Json;
using NominaAPI.Http.Responses;
using SharedModels.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_nomina
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string uri = ConfigurationManager.AppSettings["ApiBaseUrl"];
                var http = new HttpClient { BaseAddress = new Uri(uri) };

                LoginUserDto loginDto = new LoginUserDto
                {
                    Email = txtEmail.Text,
                    Password = txtPassword.Text
                };

                var json = JsonConvert.SerializeObject(loginDto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");


                var response = await http.PostAsync("Auth", content);

                var dataString = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<TokenResponse>(dataString);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        $"Error al iniciar session {data.Message}",
                        "error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                MenuForm menu = new MenuForm(data.Token);

                MessageBox.Show(
                    "Usuario authenticado correctamente!",
                    "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                txtEmail.Text = "";
                txtPassword.Text = "";

               menu.Show();
            } catch(Exception ex)
            {
                MessageBox.Show(
                    $"Hubo un error al loggearse {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
