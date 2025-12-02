using System;

namespace SistemaDEmpleados.Models
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public int DepartamentoID { get; set; }
        public int CargoID { get; set; }
        public DateTime FechaInicio { get; set; }
        public decimal Salario { get; set; }
        public string Estado { get; set; }

        // Propiedades calculadas
        public string TiempoEnEmpresa
        {
            get
            {
                var ahora = DateTime.Now;
                int anios = ahora.Year - FechaInicio.Year;
                int meses = ahora.Month - FechaInicio.Month;
                if (meses < 0) { anios--; meses += 12; }
                return $"{anios} años, {meses} meses";
            }
        }
        public decimal AFP => Salario * 0.0287m;
        public decimal ARS => Salario * 0.0304m;
        public decimal ISR
        {
            get
            {
                // Ejemplo simple de ISR
                if (Salario < 34685) return 0;
                if (Salario < 52027) return (Salario - 34685) * 0.15m;
                if (Salario < 72260) return (Salario - 52027) * 0.20m + 2601.18m;
                return (Salario - 72260) * 0.25m + 6648.00m;
            }
        }
    }
}