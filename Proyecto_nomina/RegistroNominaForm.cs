using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
                dgvRegistroNomina.DefaultCellStyle.ForeColor = Color.Black;
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

        private (IngresosDto, DeduccionesDto) GetValues()
        {

            return (

                new IngresosDto
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
                new DeduccionesDto
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
                var diasExtras = nomina.Ingresos;
                var horasExtras = nomina.Ingresos;
                var riesgoLaboral = nomina.Ingresos;
                var nocturnidad = nomina.Ingresos;
                var viatico = nomina.Ingresos;
                var depreciacion = nomina.Ingresos;
                var comision = nomina.Ingresos;
                var bonos = nomina.Ingresos;
                var prestamo = nomina.Deducciones;
                var anticipos = nomina.Deducciones;
                var INSS = calculator.CalculoINSS(salarioBruto);
                var IR = calculator.CalculoIR(salarioBruto);
                NominaInfo nominaInfo = new NominaInfo
                {
                    Id = nomina.Id,
                    Cedula = nomina.Empleado.Cedula,
                    CodigoEmpleado = nomina.Empleado.CodigoEmpleado,
                    PrimerNombre = nomina.Empleado.PrimerNombre,
                    PrimerApellido = nomina.Empleado.PrimerApellido,
                    NumeroINSS = nomina.Empleado.NumeroINSS,
                    NumeroRUC = nomina.Empleado.NumeroRUC,
                    DiasExtras = diasExtras.DiasExtras,
                    HorasExtras = horasExtras.HorasExtras,
                    RiesgoLaboral = riesgoLaboral.RiesgoLaboral,
                    Nocturnidad = nocturnidad.Nocturnidad,
                    Viatico = viatico.Viatico,
                    Depreciacion = depreciacion.Depreciacion,
                    Comision = comision.Comision,
                    Bonos = bonos.Bonos,
                    SalarioBruto = salarioBruto,
                    Prestamos = prestamo.Prestamos,
                    Anticipos = anticipos.Anticipos,
                    INSS = INSS,
                    IR = IR,
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

            if (updateIngresosDto == null || updateDeduccionesDto == null)
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

                if (results.Any(r => r == false))
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrio un error al actualizar la nomina, ingresos o deducciones {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            var (createIngresosDto, createDeduccionesDto) = GetValues();

            try
            {

                var createIngresosResponse = await _apiClient.Ingresos.CreateAsync(createIngresosDto);
                var createDeduccionesResponse = await _apiClient.Deducciones.CreateAsync(createDeduccionesDto);

                var createNominaResponse = await _apiClient.Nominas.CreateAsync(
                    new NominaCreateDto
                    {
                        IngresosId = createIngresosResponse.Data.Id,
                        DeduccionesId = createDeduccionesResponse.Data.Id,
                        EmpleadoId = (int)cboCodigoEmpleado.SelectedValue,
                        FechaRealizacion = DateTime.Now
                    }
                );

                MessageBox.Show(
                    "Nomina creada correctamente",
                    "Exito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                await LoadNominasAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrio un error al crear la nomina, ingresos o deducciones {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {

            if (_nominaId <= 0)
            {
                MessageBox.Show(
                    "Seleccione una nomina para eliminar",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {

                var response = await _apiClient.Nominas.GetByIdAsync(_nominaId);

                var result = MessageBox.Show(
                    $"Esta seguro que quiere eliminar la nomina del empleado {cboCodigoEmpleado.SelectedText} y fecha de realizacion: {response.Data.FechaRealizacion}",
                    "Confirmacion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    await _apiClient.Nominas.DeleteAsync(_nominaId);

                    MessageBox.Show(
                        "Nomina eliminada correctamente",
                        "Exito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    await LoadNominasAsync();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrio un error al eliminar la nomina, ingresos o deducciones {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnNvo_Click(object sender, EventArgs e)
        {
            cboCodigoEmpleado.SelectedIndex = -1;
            txtSalarioOrdinario.Text = "";
            txtViaticos.Text = "";
            txtDepreciacion.Text = "";
            txtComisiones.Text = "";
            txtBonos.Text = "";
            txtHorasExtras.Text = "";
            txtDiasExtras.Text = "";
            ckNocturnidad.Checked = false;
            ckRiesgoLaboral.Checked = false;
            txtPrestamos.Text = "";
            txtAnticipos.Text = "";
            foreach (DataGridViewRow row in dgvRegistroNomina.Rows)
            {
                row.Selected = false;
            }
        }
    }
}
