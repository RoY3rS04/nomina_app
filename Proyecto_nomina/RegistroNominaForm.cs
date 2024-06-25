using AutoMapper;
using NominaAPI.Http.Responses;
using SharedModels;
using SharedModels.DTOs.Empleado;
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

            int index = 0;

            for(int i = 0; i< cboCodigoEmpleado.Items.Count; i++)
            {
                string value = cboCodigoEmpleado.GetItemText(cboCodigoEmpleado.Items[i]);

                if(value == $"{dto.Empleado.PrimerNombre + " " + dto.Empleado.PrimerApellido}")
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

                /*var ingresos = (
                    await _apiClient.Ingresos.GetByIdAsync(nomina.IngresosId)
                ).Data;

                var deducciones = (
                    await _apiClient.Deducciones.GetByIdAsync(nomina.DeduccionesId)
                ).Data;

                var empleado = (
                    await _apiClient.Empleados.GetByIdAsync(nomina.EmpleadoId)
                ).Data;*/

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
    }
}
