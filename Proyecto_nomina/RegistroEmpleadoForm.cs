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

        public RegistroEmpleadoForm(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            EmpleadoDto dto = GetValues();

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
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    control.Text = "";
                }
                else if (control.GetType() == typeof(DateTimePicker))
                {
                    (control as DateTimePicker).Value = DateTimePicker.MinimumDateTime;
                }
                else if (control.GetType() == typeof(RadioButton))
                {
                    (control as RadioButton).Checked = false;
                }
                else if (control.GetType() == typeof(ComboBox))
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

        private EmpleadoDto GetValues()
        {
            return new EmpleadoDto
            {
                Cargo = txtCargo.Text.Trim(),
                Cedula = txtCedula.Text.Trim(),
                Celular = ntxtCelular.Text.Trim(),
                CodigoEmpleado = txtCodigoEmpleado.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Estado = !(Convert.ToBoolean(cboEstado.SelectedIndex)),
                EstadoCivil = cboEstadoCivil.GetItemText(cboEstadoCivil.SelectedItem),
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

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvRegistroEmpleado.SelectedRows.Count > 0)
            {
                var selectedEmpleado = (EmpleadoDto)dgvRegistroEmpleado.SelectedRows[0].DataBoundItem;

                var updateEmpleado = GetValues();
                updateEmpleado.Id = selectedEmpleado.Id;
                updateEmpleado.FechaTerminacion = dtpFechaTerminacion.Value;

                try
                {
                    var response = await _apiClient.Empleados.UpdateAsync(selectedEmpleado.Id, updateEmpleado);

                    if (!response)
                    {
                        MessageBox.Show(
                            "Ocurrio un error al actualizar el empleado",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                        return;
                    }

                    MessageBox.Show(
                        "Empleado actualizado correctamente",
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
                        $"Ocurrio un error al actualizar el empleado {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            else
            {
                MessageBox.Show(
                    "Seleccione un empleado para actualizar",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void dgvRegistroEmpleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedEmpleado = (EmpleadoDto)dgvRegistroEmpleado.SelectedRows[0].DataBoundItem;
                SetValues(selectedEmpleado);
            }
        }

        private void SetValues(EmpleadoDto dto)
        {
            txtCargo.Text = dto.Cargo;
            txtCedula.Text = dto.Cedula;
            ntxtCelular.Text = dto.Celular;
            txtCodigoEmpleado.Text = dto.CodigoEmpleado;
            txtDireccion.Text = dto.Direccion;
            cboEstado.SelectedIndex = dto.Estado ? 0 : 1;
            cboEstadoCivil.SelectedIndex = dto.EstadoCivil == "Soltero/a" ? 0 : 1;
            dtpFechaContratacion.Value = dto.FechaContratacion;
            dtpFechaNacimiento.Value = dto.Nacimento;
            txtINSS.Text = dto.NumeroINSS;
            txtRUC.Text = dto.NumeroRUC;
            txtApellido.Text = dto.PrimerApellido;
            txtNombre.Text = dto.PrimerNombre;
            rdbMasculino.Checked = dto.Sexo == "Masculino" ? true : false;
            rdbFemenino.Checked = dto.Sexo == "Femenino" ? true : false;
            mtxtTelefono.Text = dto.Telefono;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRegistroEmpleado.SelectedRows.Count > 0)
            {
                var selectedEmpleado = (EmpleadoDto)dgvRegistroEmpleado.SelectedRows[0].DataBoundItem;

                var result = MessageBox.Show(
                    $"Esta seguro que quiere eliminar al empleado {selectedEmpleado.PrimerNombre} {selectedEmpleado.PrimerApellido}?",
                    "Confirmacion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var response = await _apiClient.Empleados.DeleteAsync(selectedEmpleado.Id);

                        if (!response)
                        {
                            MessageBox.Show(
                                "Hubo un error al eliminar el empleado",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );

                            return;
                        }

                        MessageBox.Show(
                            "Empleado eliminado correctamente",
                            "Exito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        await LoadEmpleadosAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Error al eliminar empleado {ex.Message}",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    "Seleccione un empleado para eliminar",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnNvo_Click(object sender, EventArgs e)
        {
            txtCodigoEmpleado.Text = "";
            txtCedula.Text = "";
            txtINSS.Text = "";
            txtRUC.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            dtpFechaContratacion.Value = DateTime.Now;
            rdbFemenino.Checked = false;
            rdbMasculino.Checked = false;
            cboEstadoCivil.TabIndex = 0;
            txtDireccion.Text = "";
            dtpFechaContratacion.Value = DateTime.Now;
            dtpFechaTerminacion.Value = DateTime.Now;
            txtCargo.Text = "";
            cboEstado.TabIndex = 0;
            mtxtTelefono.Text = string.Empty;
            ntxtCelular.Text = string.Empty;
            foreach (DataGridViewRow row in dgvRegistroEmpleado.Rows)
            {
                row.Selected = false;
            }
        }
    }
}
