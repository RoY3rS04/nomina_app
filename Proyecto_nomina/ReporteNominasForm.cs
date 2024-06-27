using IronXL;
using NominaAPI.Http.Responses;
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

                dgvReporteNominas.DataSource = await MapNominas(response.Data);
                
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

                dgvReporteNominas.DataSource = await MapNominas(response.Data);
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


        private string ConvertToCellAddress(int row, int column)
        {
            // Columns in Excel are labeled as A, B, C, ..., Z, AA, AB, ..., etc.
            // The following code converts a column index to this format.
            string columnLabel = "";
            while (column >= 0)
            {
                columnLabel = (char)('A' + column % 26) + columnLabel;
                column = column / 26 - 1;
            }
            // Rows in Excel are labeled as 1, 2, 3, ..., n
            // Adding 1 because Excel is 1-based and our loop is 0-based.
            string rowLabel = (row + 1).ToString();
            return columnLabel + rowLabel;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string dirPath;

            using (var dirChooser = new FolderBrowserDialog())
            {
                result = dirChooser.ShowDialog();

                dirPath = dirChooser.SelectedPath;
            }

            if (result != DialogResult.OK)
            {
                return;
            }

            if (string.IsNullOrEmpty(dirPath))
            {
                MessageBox.Show(
                    "Carpeta Invalida",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }


            WorkBook workBook = new WorkBook();
            WorkSheet workSheet = workBook.CreateWorkSheet("nominas");

            try
            {
                for (int i = 0; i < dgvReporteNominas.Columns.Count; i++)
                {
                    string cellAddress = ConvertToCellAddress(0, i);

                    workSheet[cellAddress].Value = dgvReporteNominas.Columns[i].HeaderText;
                }


                for (int i = 0; i < dgvReporteNominas.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvReporteNominas.Columns.Count; j++)
                    {
                        // Convert row and column index to Excel cell address format
                        string cellAddress = ConvertToCellAddress(i + 1, j);

                        workSheet[cellAddress].Value = dgvReporteNominas.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                workBook.SaveAs($"{dirPath}/nominas.xlsx");

                MessageBox.Show(
                    "Nominas exportadas correctamente!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Hubo un error al exportar las nominas {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
