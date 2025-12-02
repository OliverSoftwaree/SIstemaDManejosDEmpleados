using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace SistemaDEmpleados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Ocultar botones de acciones al inicio
            this.MostrarGrupoDepartamentos(false);
            this.MostrarGrupoCargos(false);

            // Solo mostrar un grupo de acciones a la vez
            btnDepartamentosExtras.Click += (s, e) => {
                bool visible = !btnMostrarDepartamentos.Visible;
                this.MostrarGrupoDepartamentos(visible);
                if (visible) this.MostrarGrupoCargos(false);
            };
            btnCargosExtras.Click += (s, e) => {
                bool visible = !btnMostrarCargos.Visible;
                this.MostrarGrupoCargos(visible);
                if (visible) this.MostrarGrupoDepartamentos(false);
            };

            // Abrir formularios con lógica de modo
            btnMostrarEmpleados.Click += (s, e) => this.AbrirSeguro(() => new FormEmpleados("mostrar").ShowDialog());
            btnAgregarEmpleado.Click += (s, e) => this.AbrirSeguro(() => new FormEmpleados("agregar").ShowDialog());
            btnActualizarEmpleado.Click += (s, e) => this.AbrirSeguro(() => new FormEmpleados("editar").ShowDialog());
            btnEliminarEmpleado.Click += (s, e) => this.AbrirSeguro(() => new FormEmpleados("editar").ShowDialog());
            btnExportarEmpleados.Click += (s, e) => this.AbrirSeguro(() => new FormEmpleados("mostrar").ShowDialog());
            btnMostrarDepartamentos.Click += (s, e) => this.AbrirSeguro(() => new FormDepartamentos("mostrar").ShowDialog());
            btnAgregarDepartamento.Click += (s, e) => this.AbrirSeguro(() => new FormDepartamentos("agregar").ShowDialog());
            btnActualizarDepartamento.Click += (s, e) => this.AbrirSeguro(() => new FormDepartamentos("actualizar").ShowDialog());
            btnEliminarDepartamento.Click += (s, e) => this.AbrirSeguro(() => new FormDepartamentos("eliminar").ShowDialog());
            btnExportarDepartamentos.Click += (s, e) => this.AbrirSeguro(() => new FormDepartamentos("mostrar").ShowDialog());
            btnMostrarCargos.Click += (s, e) => this.AbrirSeguro(() => new FormCargos("mostrar").ShowDialog());
            btnAgregarCargo.Click += (s, e) => this.AbrirSeguro(() => new FormCargos("agregar").ShowDialog());
            btnActualizarCargo.Click += (s, e) => this.AbrirSeguro(() => new FormCargos("actualizar").ShowDialog());
            btnEliminarCargo.Click += (s, e) => this.AbrirSeguro(() => new FormCargos("eliminar").ShowDialog());
            btnExportarCargos.Click += (s, e) => this.AbrirSeguro(() => new FormCargos("mostrar").ShowDialog());
        }

        // Helper para bordes redondeados en botones
        private static class NativeMethods
        {
            [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
            public static extern IntPtr CreateRoundRectRgn(
                int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        }

        // Métodos auxiliares para mostrar/ocultar grupos de acciones
        private void MostrarGrupoDepartamentos(bool visible)
        {
            btnMostrarDepartamentos.Visible = visible;
            btnAgregarDepartamento.Visible = visible;
            btnActualizarDepartamento.Visible = visible;
            btnEliminarDepartamento.Visible = visible;
            btnExportarDepartamentos.Visible = visible;
        }

        private void MostrarGrupoCargos(bool visible)
        {
            btnMostrarCargos.Visible = visible;
            btnAgregarCargo.Visible = visible;
            btnActualizarCargo.Visible = visible;
            btnEliminarCargo.Visible = visible;
            btnExportarCargos.Visible = visible;
        }

        // Manejo global de errores al abrir formularios
        private void AbrirSeguro(Action accion)
        {
            try
            {
                accion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
