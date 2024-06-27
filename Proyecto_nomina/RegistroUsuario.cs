using Microsoft.AspNetCore.Http;
using NominaAPI.Services;
using SharedModels;
using SharedModels.DTOs.Empleado;
using SharedModels.DTOs.User;
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
    public partial class RegistroUsuario : Form
    {
        private ApiClient _apiClient;

        public RegistroUsuario(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            UserDto dto = GetValues();
            try
            {
                await _apiClient.Users.CreateAsync(dto);
                MessageBox.Show(
                    "Usuario creado correctamente",
                    "Exito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearInputs();
                await LoadUsersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Hubo un error al crear el usuario: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private UserDto GetValues()
        {
            return new UserDto
            {
                Name = txtNombre.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Password = txtContraseña.Text.Trim(),
                IsAdmin = ckAdmin.Checked
            };
        }

        private async Task LoadUsersAsync()
        {
            try
            {
                var response = await _apiClient.Users.GetAllAsync();
                dgvRegistroUsuario.DataSource = response.Data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Hubo un error al obtener los usuarios: {ex.Message}",
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
                ckAdmin.Checked = false;
            }
        }

        private async void RegistroUsuario_Load(object sender, EventArgs e)
        {
            await LoadUsersAsync();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvRegistroUsuario.SelectedRows.Count > 0)
            {
                var selectedUser = (UserDto)dgvRegistroUsuario.SelectedRows[0].DataBoundItem;

                var updateUserDto = new UserUpdateDto
                {
                    Name = txtNombre.Text,
                    Email = txtEmail.Text,
                    IsAdmin = ckAdmin.Checked,
                    NewPassword = txtContraseña.Text
                };

                try
                {
                    var response = await _apiClient.Users.UpdateAsync(selectedUser.Id, updateUserDto);

                    //if (response == StatusCodes.Status200OK)
                    //{
                    //    MessageBox.Show("Usuario actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //    ClearInputs();
                    //    await LoadUsersAsync();
                    //}
                    //else
                    //{
                    //    MessageBox.Show($"Ocurrió un error al actualizar el usuario: {response.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al actualizar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para actualizar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void dgvRegistroUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedUsuario = (UserDto)dgvRegistroUsuario.SelectedRows[0].DataBoundItem;
                SetValues(selectedUsuario);
            }
        }

        private void SetValues(UserDto dto)
        {
            txtNombre.Text = dto.Name;
            txtEmail.Text = dto.Email;
            txtContraseña.Text = dto.Password;
            ckAdmin.Checked = dto.IsAdmin;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRegistroUsuario.SelectedRows.Count > 0)
            {
                var selectedUsuario = (UserDto)dgvRegistroUsuario.SelectedRows[0].DataBoundItem;

                var result = MessageBox.Show(
                    $"Esta seguro que quiere eliminar al usuario {selectedUsuario.Name} ?",
                    "Confirmacion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var response = await _apiClient.Users.DeleteAsync(selectedUsuario.Id);

                        if (!response)
                        {
                            MessageBox.Show(
                                "Hubo un error al eliminar el usuario",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );

                            return;
                        }

                        MessageBox.Show(
                            "Usuario eliminado correctamente",
                            "Exito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        await LoadUsersAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Error al eliminar usuario {ex.Message}",
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
                    "Seleccione un usuario para eliminar",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvRegistroUsuario.Rows)
            {
                row.Selected = false;
            }
            txtContraseña.Text = "";
            txtEmail.Text = "";
            txtNombre.Text = "";
            ckAdmin.Checked = false;
        }
    }
}
