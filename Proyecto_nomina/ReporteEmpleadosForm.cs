using System;
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
    public partial class ReporteEmpleadosForm : Form
    {
        private ApiClient _apiClient;

        public ReporteEmpleadosForm(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }

        private async void ReporteEmpleadosForm_Load(object sender, EventArgs e)
        {
            await LoadEmpleadosAsync();
        }

        private async Task LoadEmpleadosAsync()
        {
            try
            {
                var response = await _apiClient.Empleados.GetAllAsync();

                dgvReporteEmpleados.DataSource = response.Data;

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Hubo un error al obtener los empleados: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {

            if(
                String.IsNullOrEmpty(txtCedulaEmpleado.Text.Trim())
                && String.IsNullOrEmpty(txtCodigoEmpleado.Text.Trim())
            )
            {
                await LoadEmpleadosAsync();
                return;
            }

            try
            {

                string queryParams = $"codigoEmp={txtCodigoEmpleado.Text}&cedulaEmp={txtCedulaEmpleado.Text}";

                var response = await _apiClient.Empleados.GetAllAsync(queryParams);

                dgvReporteEmpleados.DataSource = response.Data;
            } catch (Exception ex)
            {
                MessageBox.Show(
                    $"Hubo un error al obtener el empleado: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
