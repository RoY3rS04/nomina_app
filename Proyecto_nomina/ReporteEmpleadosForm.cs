using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronXL;

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

            if (
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Hubo un error al obtener el empleado: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
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
            WorkSheet workSheet = workBook.CreateWorkSheet("empleados");

            try
            {
                for(int i = 0; i< dgvReporteEmpleados.Columns.Count; i++)
                {
                    string cellAddress = ConvertToCellAddress(0, i);

                    workSheet[cellAddress].Value = dgvReporteEmpleados.Columns[i].HeaderText;
                }


                for (int i = 0; i < dgvReporteEmpleados.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvReporteEmpleados.Columns.Count; j++)
                    {
                        // Convert row and column index to Excel cell address format
                        string cellAddress = ConvertToCellAddress(i+1, j);

                        workSheet[cellAddress].Value = dgvReporteEmpleados.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                workBook.SaveAs($"{dirPath}/empleados.xlsx");

                MessageBox.Show(
                    "Empleados exportados correctamente!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

            } catch(Exception ex)
            {
                MessageBox.Show(
                    $"Hubo un error al exportar los empleados {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
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
    }
}
