using Newtonsoft.Json;
using NominaAPI.Http.Responses;
using SharedModels.DTOs.Empleado;
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
    public partial class RegistroEmpleadoForm : Form
    {

        private readonly ApiClient _apiClient;

        public RegistroEmpleadoForm()
        {
            InitializeComponent();
            _apiClient = new ApiClient();
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            EmpleadoCreateDto dto = GetValues();

            try
            {
                await _apiClient.Empleados.CreateAsync(dto);

                MessageBox.Show(
                    "Empleado creado correctamente",
                    "Exito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ClearInputs();

                await LoadEmpleadosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Hubo un error al crear el empleados: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ClearInputs()
        {
            foreach(Control control in this.Controls)
            {
                if(control.GetType() == typeof(TextBox))
                {
                    control.Text = "";
                } else if(control.GetType() == typeof(DateTimePicker))
                {
                    (control as DateTimePicker).Value = DateTimePicker.MinimumDateTime;
                } else if(control.GetType() == typeof(RadioButton))
                {
                    (control as RadioButton).Checked = false;
                } else if(control.GetType() == typeof(ComboBox))
                {
                    (control as ComboBox).SelectedIndex = -1;
                }
            }
        }

        private async Task LoadEmpleadosAsync()
        {
            try
            {
                var response = await _apiClient.Empleados.GetAllAsync();

                dgvRegistroEmpleado.DataSource = response.Data;

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

        private EmpleadoCreateDto GetValues()
        {
            MessageBox.Show(cboEstadoCivil.SelectedText);
            return new EmpleadoCreateDto
            {
                Cargo = txtCargo.Text.Trim(),
                Cedula = txtCedula.Text.Trim(),
                Celular = ntxtCelular.Text.Trim(),
                CodigoEmpleado = txtCodigoEmpleado.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Estado = !(Convert.ToBoolean(cboEstado.SelectedIndex)),
                EstadoCivil = cboEstadoCivil.SelectedText,
                FechaContratacion = dtpFechaContratacion.Value,
                Nacimento = dtpFechaNacimiento.Value,
                NumeroINSS = txtINSS.Text.Trim(),
                NumeroRUC = txtRUC.Text.Trim(),
                PrimerApellido = txtApellido.Text.Trim(),
                PrimerNombre = txtNombre.Text.Trim(),
                Sexo = rdbMasculino.Checked ? rdbMasculino.Text : rdbFemenino.Text,
                Telefono = mtxtTelefono.Text.Trim(),
            };
        }

        private async void RegistroEmpleadoForm_Load(object sender, EventArgs e)
        {
            await LoadEmpleadosAsync();
        }                                                                    
    }
}
