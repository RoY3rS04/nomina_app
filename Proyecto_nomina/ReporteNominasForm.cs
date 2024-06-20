using NominaAPI.Http.Responses;
using SharedModels.DTOs.Empleado;
using SharedModels.DTOs.Nomina;
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
    public partial class ReporteNominasForm : Form
    {
        private ApiClient _apiClient;

        public ReporteNominasForm(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }

        private async void ReporteNominasForm_Load(object sender, EventArgs e)
        {
            await LoadNominasAsync();

            try
            {
                var response = await _apiClient.Empleados.GetAllAsync();

                cmbEmpleado.DataSource = response.Data;
                cmbEmpleado.ValueMember = "Id";
                cmbEmpleado.DisplayMember = "PrimerNombre";
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

        private async Task LoadNominasAsync()
        {
            try
            {
                var response = await _apiClient.Nominas.GetAllAsync();

                dgvReporteNominas.DataSource = response.Data;

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Hubo un error al obtener las nominas: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void cmbEmpleado_Format(object sender, ListControlConvertEventArgs e)
        {
            string firstName = ((EmpleadoDto)e.ListItem).PrimerNombre;
            string lastName = ((EmpleadoDto)e.ListItem).PrimerApellido;

            e.Value = firstName + " " + lastName;
        }

        private void checkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTodos.Checked)
            {
                cmbEmpleado.Enabled = false;
                return;
            }

            cmbEmpleado.Enabled = true;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            Response<IEnumerable<NominaDto>> response;

            try
            {
                if (checkTodos.Checked)
                {
                    string queryParams = $"empleadoId={null}&fechaRealizacion={(dtpFecha.Checked ? dtpFecha.Value : null)}";
                    response = await _apiClient.Nominas.GetAllAsync(queryParams);
                }
                else
                {
                    string queryParams = $"empleadoId={cmbEmpleado.SelectedValue}&fechaRealizacion={(dtpFecha.Checked ? dtpFecha.Value : null)}";
                    response = await _apiClient.Nominas.GetAllAsync(queryParams);
                }

                dgvReporteNominas.DataSource = response.Data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Hubo un error al obtener las nominas: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
