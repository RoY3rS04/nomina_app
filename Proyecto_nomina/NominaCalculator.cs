using SharedModels;
using SharedModels.DTOs.Deducciones;
using SharedModels.DTOs.Ingresos;
using SharedModels.DTOs.Nomina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_nomina
{
    public class NominaCalculator
    {

        public double GetSalarioBruto(IngresosDto ingresos)
        {

            double ingresoBruto = ingresos.SalarioOrdinario
                + ingresos.Bonos
                + ingresos.Comision
                + ingresos.Depreciacion
                + (ingresos.Nocturnidad ? ingresos.SalarioOrdinario * 0.2 : 0)
                + (ingresos.RiesgoLaboral ? ingresos.SalarioOrdinario * 0.2 : 0)
                + ObtenerPagoPorDiasExtras(ingresos.SalarioOrdinario, ingresos.DiasExtras)
                + ObtenerPagoPorHorasExtras(ingresos.SalarioOrdinario, ingresos.HorasExtras)
                + ingresos.Viatico
                ;

            double ingresoNeto = ingresoBruto - CalculoINSS(ingresoBruto);
            ingresoNeto = ingresoNeto - CalculoIR(ingresoNeto);

            return ingresoNeto;
        }

        public double GetDeducciones(DeduccionesDto deducciones)
        {
            double deduccionBruta = deducciones.Anticipos
                + deducciones.Prestamos;

            return deduccionBruta;
        }


        private double CalculoINSS(double SalarioBruto)
        {
            return SalarioBruto * 0.07;
        }

        private double CalculoIR(double SalarioBruto)
        {
            double SalarioAnual = SalarioBruto * 12;

            if (SalarioAnual >= 0.01 && SalarioAnual <= 100000.01)
            {
                return 0.00;
            }
            else if (SalarioAnual > 100000.01 && SalarioAnual <= 200000.01)
            {
                return ((SalarioAnual - 100000.00) * 0.15) / 12;

            }
            else if (SalarioAnual > 200000.01 && SalarioAnual <= 350000.01)
            {
                return (((SalarioAnual - 200000.00) + 15000.00) * 0.2) / 12;

            }
            else if (SalarioAnual > 350000.01 && SalarioAnual <= 500000.01)
            {
                return (((SalarioAnual - 350000.00) + 45000.00) * 0.25) / 12;

            }
            else if (SalarioAnual > 500000.01)
            {
                return (((SalarioAnual - 500000) + 82500.00) * 0.3) / 12;

            } else
            {
                return -1;
            }
        }

        private double ObtenerPagoPorDiasExtras(double SalarioOrdinario, int DiasExtras)
        {
            if (DiasExtras != 0)
            {
                double PagoPorDia = SalarioOrdinario / 30;

                return DiasExtras * PagoPorDia;
            }

            return 0.00;
        }

        private double ObtenerPagoPorHorasExtras(double SalarioOrdinario, int HorasExtras)
        {
            if (HorasExtras != 0)
            {
                double PagoPorHora = SalarioOrdinario / 240;

                return HorasExtras * PagoPorHora * 2;
            }

            return 0.00;
        }

    }
}
