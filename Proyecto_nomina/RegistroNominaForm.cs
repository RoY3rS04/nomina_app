using AutoMapper;
using SharedModels;
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
    public partial class RegistroNominaForm : Form
    {
        private readonly ApiClient _apiClient;
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

                dgvRegistroNomina.DataSource = await MapNominas(response.Data);

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
                var ingresos = (
                    await _apiClient.Ingresos.GetByIdAsync(nomina.IngresosId)
                ).Data;

                var deducciones = (
                    await _apiClient.Deducciones.GetByIdAsync(nomina.DeduccionesId)
                ).Data;

                var empleado = (
                    await _apiClient.Empleados.GetByIdAsync(nomina.EmpleadoId)
                ).Data;

                var salarioBruto = calculator.GetSalarioBruto(ingresos);
                var totalDeducciones = calculator.GetDeducciones(deducciones);

                NominaInfo nominaInfo = new NominaInfo
                {
                    Id = nomina.Id,
                    Cedula = empleado.Cedula,
                    CodigoEmpleado = empleado.CodigoEmpleado,
                    PrimerNombre = empleado.PrimerNombre,
                    PrimerApellido = empleado.PrimerApellido,
                    NumeroINSS = empleado.NumeroINSS,
                    NumeroRUC = empleado.NumeroRUC,
                    SalarioBruto = salarioBruto,
                    TotalDeducciones = totalDeducciones,
                    SalarioNeto = salarioBruto - totalDeducciones,
                    FechaRealizacion = nomina.FechaRealizacion
                };

                nominaInfos.Add(nominaInfo);
            }

            return nominaInfos;
        }
    }
}
