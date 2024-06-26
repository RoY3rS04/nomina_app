﻿using AutoMapper;
using NominaAPI.Http.Responses;
using SharedModels;
using SharedModels.DTOs.Deducciones;
using SharedModels.DTOs.Empleado;
using SharedModels.DTOs.Ingresos;
using SharedModels.DTOs.Nomina;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_nomina
{
    public partial class RegistroNominaForm : Form
    {
        private readonly ApiClient _apiClient;
        private List<NominaDto> _nominas;
        private int _ingresosId;
        private int _deduccionesId;
        private int _nominaId;

        public RegistroNominaForm(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private async void RegistroNominaForm_Load(object sender, EventArgs e)
        {
            await LoadNominasAsync();

            try
            {
                var response = await _apiClient.Empleados.GetAllAsync();

                cboCodigoEmpleado.DataSource = response.Data;
                cboCodigoEmpleado.ValueMember = "Id";
                cboCodigoEmpleado.DisplayMember = "PrimerNombre";
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
                _nominas = response.Data.ToList();

                dgvRegistroNomina.DataSource = await MapNominas(_nominas);

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

        private (IngresosUpdateDto, DeduccionesUpdateDto) GetValues()
        {

            return (

                new IngresosUpdateDto
                {
                    Bonos = Convert.ToDouble(txtBonos.Text.Trim()),
                    Id = _ingresosId,
                    Comision = Convert.ToDouble(txtComisiones.Text.Trim()),
                    Depreciacion = Convert.ToDouble(txtDepreciacion.Text.Trim()),
                    DiasExtras = Convert.ToInt32(txtDiasExtras.Text.Trim()),
                    EmpleadoId = (int)cboCodigoEmpleado.SelectedValue,
                    HorasExtras = Convert.ToInt32(txtHorasExtras.Text.Trim()),
                    Nocturnidad = ckNocturnidad.Checked,
                    RiesgoLaboral = ckRiesgoLaboral.Checked,
                    SalarioOrdinario = Convert.ToDouble(txtSalarioOrdinario.Text.Trim()),
                    Viatico = Convert.ToDouble(txtViaticos.Text.Trim()),
                    FechaCierre = DateTime.Now
                },
                new DeduccionesUpdateDto
                {
                    Anticipos = Convert.ToDouble(txtAnticipos.Text.Trim()),
                    Id = _deduccionesId,
                    EmpleadoId = (int)cboCodigoEmpleado.SelectedValue,
                    Prestamos = Convert.ToDouble(txtPrestamos.Text.Trim()),
                    FechaCierre = DateTime.Now
                }

            );

        }

        private void SetValues(NominaDto dto)
        {
            txtAnticipos.Text = $"{dto.Deducciones.Anticipos}";
            txtPrestamos.Text = $"{dto.Deducciones.Prestamos}";
            txtBonos.Text = $"{dto.Ingresos.Bonos}";
            txtComisiones.Text = $"{dto.Ingresos.Comision}";
            txtDepreciacion.Text = $"{dto.Ingresos.Depreciacion}";
            txtDiasExtras.Text = $"{dto.Ingresos.DiasExtras}";
            txtHorasExtras.Text = $"{dto.Ingresos.HorasExtras}";
            txtSalarioOrdinario.Text = $"{dto.Ingresos.SalarioOrdinario}";
            txtViaticos.Text = $"{dto.Ingresos.Viatico}";
            ckNocturnidad.Checked = dto.Ingresos.Nocturnidad;
            ckRiesgoLaboral.Checked = dto.Ingresos.RiesgoLaboral;

            _nominaId = dto.Id;
            _ingresosId = dto.Ingresos.Id;
            _deduccionesId = dto.Deducciones.Id;

            int index = 0;

            for (int i = 0; i < cboCodigoEmpleado.Items.Count; i++)
            {
                string value = cboCodigoEmpleado.GetItemText(cboCodigoEmpleado.Items[i]);

                if (value == $"{dto.Empleado.PrimerNombre + " " + dto.Empleado.PrimerApellido}")
                {
                    index = i;
                }

            }

            cboCodigoEmpleado.SelectedIndex = index;
        }

        private void cboCodigoEmpleado_Format(object sender, ListControlConvertEventArgs e)
        {
            string firstName = ((EmpleadoDto)e.ListItem).PrimerNombre;
            string lastName = ((EmpleadoDto)e.ListItem).PrimerApellido;

            e.Value = firstName + " " + lastName;
        }

        private async Task<List<NominaInfo>> MapNominas(IEnumerable<NominaDto> nominas)
        {
            NominaCalculator calculator = new NominaCalculator();

            List<NominaInfo> nominaInfos = new List<NominaInfo>();

            foreach (var nomina in nominas)
            {

                var salarioBruto = calculator.GetSalarioBruto(nomina.Ingresos);
                var totalDeducciones = calculator.GetDeducciones(nomina.Deducciones);

                NominaInfo nominaInfo = new NominaInfo
                {
                    Id = nomina.Id,
                    Cedula = nomina.Empleado.Cedula,
                    CodigoEmpleado = nomina.Empleado.CodigoEmpleado,
                    PrimerNombre = nomina.Empleado.PrimerNombre,
                    PrimerApellido = nomina.Empleado.PrimerApellido,
                    NumeroINSS = nomina.Empleado.NumeroINSS,
                    NumeroRUC = nomina.Empleado.NumeroRUC,
                    SalarioBruto = salarioBruto,
                    TotalDeducciones = totalDeducciones,
                    SalarioNeto = salarioBruto - totalDeducciones,
                    FechaRealizacion = nomina.FechaRealizacion
                };

                nominaInfos.Add(nominaInfo);
            }

            return nominaInfos;
        }

        private void dgvRegistroNomina_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedNominaId = (int)dgvRegistroNomina.SelectedRows[0].Cells[0].Value;

                var nomina = _nominas.Where(n => n.Id == selectedNominaId).FirstOrDefault();

                SetValues(nomina);
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            var (updateIngresosDto, updateDeduccionesDto) = GetValues();

            NominaUpdateDto updateNominaDto = new NominaUpdateDto
            {
                DeduccionesId = _deduccionesId,
                IngresosId = _ingresosId,
                Id = _nominaId,
                FechaRealizacion = DateTime.Now,
                EmpleadoId = (int)cboCodigoEmpleado.SelectedValue
            };

            if(updateIngresosDto == null || updateDeduccionesDto == null)
            {
                MessageBox.Show(
                    "Por favor ingrese toda la informacion",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {

                var results = await Task.WhenAll(
                    _apiClient.Nominas.UpdateAsync(_nominaId, updateNominaDto),
                    _apiClient.Ingresos.UpdateAsync(_ingresosId, updateIngresosDto),
                    _apiClient.Deducciones.UpdateAsync(_deduccionesId, updateDeduccionesDto)
                );

                if(results.Any(r => r == false))
                {
                    MessageBox.Show(
                        $"Ocurrio un error al actualizar la nomina, ingresos o deducciones",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                MessageBox.Show(
                    "Nomina actualizada correctamente",
                    "Exito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                await LoadNominasAsync();

            } catch(Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrio un error al actualizar la nomina, ingresos o deducciones {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
