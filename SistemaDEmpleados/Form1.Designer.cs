using System.Drawing;

namespace SistemaDEmpleados
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            // Inicialización de controles principales
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnDepartamentosExtras = new System.Windows.Forms.Button();
            this.btnCargosExtras = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.groupEmpleados = new System.Windows.Forms.GroupBox();
            this.btnMostrarEmpleados = new System.Windows.Forms.Button();
            this.btnAgregarEmpleado = new System.Windows.Forms.Button();
            this.btnActualizarEmpleado = new System.Windows.Forms.Button();
            this.btnEliminarEmpleado = new System.Windows.Forms.Button();
            this.btnExportarEmpleados = new System.Windows.Forms.Button();
            this.groupDepartamentos = new System.Windows.Forms.GroupBox();
            this.btnMostrarDepartamentos = new System.Windows.Forms.Button();
            this.btnAgregarDepartamento = new System.Windows.Forms.Button();
            this.btnActualizarDepartamento = new System.Windows.Forms.Button();
            this.btnEliminarDepartamento = new System.Windows.Forms.Button();
            this.btnExportarDepartamentos = new System.Windows.Forms.Button();
            this.groupCargos = new System.Windows.Forms.GroupBox();
            this.btnMostrarCargos = new System.Windows.Forms.Button();
            this.btnAgregarCargo = new System.Windows.Forms.Button();
            this.btnActualizarCargo = new System.Windows.Forms.Button();
            this.btnEliminarCargo = new System.Windows.Forms.Button();
            this.btnExportarCargos = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelSubtitulo = new System.Windows.Forms.Label();
            // Panel lateral moderno
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(235, 230, 255);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Width = 240;
            this.panelMenu.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            // Añadir primero el logo
            this.panelMenu.Controls.Add(this.pictureBoxLogo);
            // GroupBox Departamentos
            this.groupDepartamentos.Location = new System.Drawing.Point(15, 230);
            this.panelMenu.Controls.Add(this.groupDepartamentos);
            // Botón Departamentos Extras (dentro del groupBox de Departamentos)
            this.btnDepartamentosExtras.Text = "Más acciones";
            this.btnDepartamentosExtras.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnDepartamentosExtras.BackColor = System.Drawing.Color.FromArgb(220, 220, 255);
            this.btnDepartamentosExtras.ForeColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnDepartamentosExtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepartamentosExtras.FlatAppearance.BorderSize = 1;
            this.btnDepartamentosExtras.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnDepartamentosExtras.Size = new System.Drawing.Size(170, 28);
            this.btnDepartamentosExtras.Location = new System.Drawing.Point(20, 200); // Debajo del último botón de departamentos
            this.btnDepartamentosExtras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDepartamentosExtras.TabIndex = 20;
            this.groupDepartamentos.Controls.Add(this.btnDepartamentosExtras);
            // GroupBox Cargos
            this.groupCargos.Location = new System.Drawing.Point(15, 370);
            this.panelMenu.Controls.Add(this.groupCargos);
            // Botón Cargos Extras (dentro del groupBox de Cargos)
            this.btnCargosExtras.Text = "Más acciones";
            this.btnCargosExtras.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnCargosExtras.BackColor = System.Drawing.Color.FromArgb(220, 220, 255);
            this.btnCargosExtras.ForeColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnCargosExtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargosExtras.FlatAppearance.BorderSize = 1;
            this.btnCargosExtras.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnCargosExtras.Size = new System.Drawing.Size(170, 28);
            this.btnCargosExtras.Location = new System.Drawing.Point(20, 200); // Debajo del último botón de cargos
            this.btnCargosExtras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargosExtras.TabIndex = 21;
            this.groupCargos.Controls.Add(this.btnCargosExtras);
            // Logo
            this.pictureBoxLogo.Image = null;
            this.pictureBoxLogo.Location = new System.Drawing.Point(40, 18);
            this.pictureBoxLogo.Size = new System.Drawing.Size(160, 60);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // --- Empleados ---
            this.groupEmpleados.Text = "Empleados";
            this.groupEmpleados.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            this.groupEmpleados.ForeColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.groupEmpleados.BackColor = System.Drawing.Color.White;
            this.groupEmpleados.Location = new System.Drawing.Point(15, 90);
            this.groupEmpleados.Size = new System.Drawing.Size(210, 250);
            this.groupEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            // Botón Mostrar Empleados
            this.btnMostrarEmpleados.Text = "Mostrar Empleados";
            this.btnMostrarEmpleados.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnMostrarEmpleados.BackColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnMostrarEmpleados.ForeColor = System.Drawing.Color.White;
            this.btnMostrarEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarEmpleados.FlatAppearance.BorderSize = 0;
            this.btnMostrarEmpleados.Size = new System.Drawing.Size(170, 36);
            this.btnMostrarEmpleados.Location = new System.Drawing.Point(20, 30);
            this.btnMostrarEmpleados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarEmpleados.TabIndex = 1;
            this.btnMostrarEmpleados.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, 170, 36, 12, 12));
            // Botón Agregar Empleado
            this.btnAgregarEmpleado.Text = "Agregar Empleado";
            this.btnAgregarEmpleado.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnAgregarEmpleado.BackColor = System.Drawing.Color.White;
            this.btnAgregarEmpleado.ForeColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnAgregarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarEmpleado.FlatAppearance.BorderSize = 2;
            this.btnAgregarEmpleado.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnAgregarEmpleado.Size = new System.Drawing.Size(170, 36);
            this.btnAgregarEmpleado.Location = new System.Drawing.Point(20, 70);
            this.btnAgregarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarEmpleado.TabIndex = 2;
            this.btnAgregarEmpleado.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, 170, 36, 12, 12));
            // Botón Actualizar Empleado
            this.btnActualizarEmpleado.Text = "Actualizar Empleado";
            this.btnActualizarEmpleado.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnActualizarEmpleado.BackColor = System.Drawing.Color.White;
            this.btnActualizarEmpleado.ForeColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnActualizarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarEmpleado.FlatAppearance.BorderSize = 2;
            this.btnActualizarEmpleado.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnActualizarEmpleado.Size = new System.Drawing.Size(170, 36);
            this.btnActualizarEmpleado.Location = new System.Drawing.Point(20, 110);
            this.btnActualizarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizarEmpleado.TabIndex = 3;
            this.btnActualizarEmpleado.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, 170, 36, 12, 12));
            // Botón Eliminar Empleado
            this.btnEliminarEmpleado.Text = "Eliminar Empleado";
            this.btnEliminarEmpleado.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnEliminarEmpleado.BackColor = System.Drawing.Color.White;
            this.btnEliminarEmpleado.ForeColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnEliminarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarEmpleado.FlatAppearance.BorderSize = 2;
            this.btnEliminarEmpleado.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnEliminarEmpleado.Size = new System.Drawing.Size(170, 36);
            this.btnEliminarEmpleado.Location = new System.Drawing.Point(20, 150);
            this.btnEliminarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarEmpleado.TabIndex = 4;
            this.btnEliminarEmpleado.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, 170, 36, 12, 12));
            // Botón Exportar Empleados
            this.btnExportarEmpleados.Text = "Exportar Empleados";
            this.btnExportarEmpleados.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnExportarEmpleados.BackColor = System.Drawing.Color.White;
            this.btnExportarEmpleados.ForeColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnExportarEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarEmpleados.FlatAppearance.BorderSize = 2;
            this.btnExportarEmpleados.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnExportarEmpleados.Size = new System.Drawing.Size(170, 36);
            this.btnExportarEmpleados.Location = new System.Drawing.Point(20, 190);
            this.btnExportarEmpleados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarEmpleados.TabIndex = 5;
            this.btnExportarEmpleados.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, 170, 36, 12, 12));
            this.groupEmpleados.Controls.Add(this.btnMostrarEmpleados);
            this.groupEmpleados.Controls.Add(this.btnAgregarEmpleado);
            this.groupEmpleados.Controls.Add(this.btnActualizarEmpleado);
            this.groupEmpleados.Controls.Add(this.btnEliminarEmpleado);
            this.groupEmpleados.Controls.Add(this.btnExportarEmpleados);
            this.panelMenu.Controls.Add(this.groupEmpleados);
            // --- Departamentos ---
            this.groupDepartamentos.Text = "Departamentos";
            this.groupDepartamentos.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            this.groupDepartamentos.ForeColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.groupDepartamentos.BackColor = System.Drawing.Color.White;
            this.groupDepartamentos.Location = new System.Drawing.Point(15, 230);
            this.groupDepartamentos.Size = new System.Drawing.Size(210, 120);
            this.groupDepartamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupDepartamentos.Controls.Add(this.btnMostrarDepartamentos);
            this.groupDepartamentos.Controls.Add(this.btnAgregarDepartamento);
            this.groupDepartamentos.Controls.Add(this.btnActualizarDepartamento);
            this.groupDepartamentos.Controls.Add(this.btnEliminarDepartamento);
            this.groupDepartamentos.Controls.Add(this.btnExportarDepartamentos);
            this.panelMenu.Controls.Add(this.groupDepartamentos);
            // Botón Mostrar Departamentos
            this.btnMostrarDepartamentos.Text = "Mostrar Departamentos";
            this.btnMostrarDepartamentos.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnMostrarDepartamentos.BackColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnMostrarDepartamentos.ForeColor = System.Drawing.Color.White;
            this.btnMostrarDepartamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarDepartamentos.FlatAppearance.BorderSize = 0;
            this.btnMostrarDepartamentos.Size = new System.Drawing.Size(170, 36);
            this.btnMostrarDepartamentos.Location = new System.Drawing.Point(20, 30);
            this.btnMostrarDepartamentos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarDepartamentos.TabIndex = 3;
            this.btnMostrarDepartamentos.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, 170, 36, 12, 12));
            // Botón Agregar Departamento
            this.btnAgregarDepartamento.Text = "Agregar Departamento";
            this.btnAgregarDepartamento.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnAgregarDepartamento.BackColor = System.Drawing.Color.White;
            this.btnAgregarDepartamento.ForeColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnAgregarDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarDepartamento.FlatAppearance.BorderSize = 2;
            this.btnAgregarDepartamento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnAgregarDepartamento.Size = new System.Drawing.Size(170, 36);
            this.btnAgregarDepartamento.Location = new System.Drawing.Point(20, 70);
            this.btnAgregarDepartamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarDepartamento.TabIndex = 4;
            this.btnAgregarDepartamento.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, 170, 36, 12, 12));
            // Botón Actualizar Departamento
            this.btnActualizarDepartamento.Text = "Actualizar Departamento";
            this.btnActualizarDepartamento.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnActualizarDepartamento.BackColor = System.Drawing.Color.White;
            this.btnActualizarDepartamento.ForeColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnActualizarDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarDepartamento.FlatAppearance.BorderSize = 2;
            this.btnActualizarDepartamento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnActualizarDepartamento.Size = new System.Drawing.Size(170, 36);
            this.btnActualizarDepartamento.Location = new System.Drawing.Point(20, 110);
            this.btnActualizarDepartamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizarDepartamento.TabIndex = 5;
            this.btnActualizarDepartamento.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, 170, 36, 12, 12));
            // Botón Eliminar Departamento
            this.btnEliminarDepartamento.Text = "Eliminar Departamento";
            this.btnEliminarDepartamento.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnEliminarDepartamento.BackColor = System.Drawing.Color.White;
            this.btnEliminarDepartamento.ForeColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnEliminarDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarDepartamento.FlatAppearance.BorderSize = 2;
            this.btnEliminarDepartamento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnEliminarDepartamento.Size = new System.Drawing.Size(170, 36);
            this.btnEliminarDepartamento.Location = new System.Drawing.Point(20, 150);
            this.btnEliminarDepartamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarDepartamento.TabIndex = 6;
            this.btnEliminarDepartamento.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, 170, 36, 12, 12));
            // Botón Exportar Departamentos
            this.btnExportarDepartamentos.Text = "Exportar Departamentos";
            this.btnExportarDepartamentos.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnExportarDepartamentos.BackColor = System.Drawing.Color.White;
            this.btnExportarDepartamentos.ForeColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnExportarDepartamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarDepartamentos.FlatAppearance.BorderSize = 2;
            this.btnExportarDepartamentos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnExportarDepartamentos.Size = new System.Drawing.Size(170, 36);
            this.btnExportarDepartamentos.Location = new System.Drawing.Point(20, 190);
            this.btnExportarDepartamentos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarDepartamentos.TabIndex = 7;
            this.btnExportarDepartamentos.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, 170, 36, 12, 12));
            this.groupDepartamentos.Controls.Add(this.btnMostrarDepartamentos);
            this.groupDepartamentos.Controls.Add(this.btnAgregarDepartamento);
            this.groupDepartamentos.Controls.Add(this.btnActualizarDepartamento);
            this.groupDepartamentos.Controls.Add(this.btnEliminarDepartamento);
            this.groupDepartamentos.Controls.Add(this.btnExportarDepartamentos);
            this.panelMenu.Controls.Add(this.groupDepartamentos);
            // --- Cargos ---
            this.groupCargos.Text = "Cargos";
            this.groupCargos.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            this.groupCargos.ForeColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.groupCargos.BackColor = System.Drawing.Color.White;
            this.groupCargos.Location = new System.Drawing.Point(15, 370);
            this.groupCargos.Size = new System.Drawing.Size(210, 250);
            this.groupCargos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            // Botón Mostrar Cargos
            this.btnMostrarCargos.Text = "Mostrar Cargos";
            this.btnMostrarCargos.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnMostrarCargos.BackColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnMostrarCargos.ForeColor = System.Drawing.Color.White;
            this.btnMostrarCargos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarCargos.FlatAppearance.BorderSize = 0;
            this.btnMostrarCargos.Size = new System.Drawing.Size(170, 36);
            this.btnMostrarCargos.Location = new System.Drawing.Point(20, 30);
            this.btnMostrarCargos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarCargos.TabIndex = 5;
            this.btnMostrarCargos.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, 170, 36, 12, 12));
            // Botón Agregar Cargo
            this.btnAgregarCargo.Text = "Agregar Cargo";
            this.btnAgregarCargo.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnAgregarCargo.BackColor = System.Drawing.Color.White;
            this.btnAgregarCargo.ForeColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnAgregarCargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCargo.FlatAppearance.BorderSize = 2;
            this.btnAgregarCargo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnAgregarCargo.Size = new System.Drawing.Size(170, 36);
            this.btnAgregarCargo.Location = new System.Drawing.Point(20, 70);
            this.btnAgregarCargo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCargo.TabIndex = 6;
            this.btnAgregarCargo.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, 170, 36, 12, 12));
            // Botón Actualizar Cargo
            this.btnActualizarCargo.Text = "Actualizar Cargo";
            this.btnActualizarCargo.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnActualizarCargo.BackColor = System.Drawing.Color.White;
            this.btnActualizarCargo.ForeColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnActualizarCargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarCargo.FlatAppearance.BorderSize = 2;
            this.btnActualizarCargo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnActualizarCargo.Size = new System.Drawing.Size(170, 36);
            this.btnActualizarCargo.Location = new System.Drawing.Point(20, 110);
            this.btnActualizarCargo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizarCargo.TabIndex = 7;
            this.btnActualizarCargo.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, 170, 36, 12, 12));
            // Botón Eliminar Cargo
            this.btnEliminarCargo.Text = "Eliminar Cargo";
            this.btnEliminarCargo.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnEliminarCargo.BackColor = System.Drawing.Color.White;
            this.btnEliminarCargo.ForeColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnEliminarCargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarCargo.FlatAppearance.BorderSize = 2;
            this.btnEliminarCargo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnEliminarCargo.Size = new System.Drawing.Size(170, 36);
            this.btnEliminarCargo.Location = new System.Drawing.Point(20, 150);
            this.btnEliminarCargo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarCargo.TabIndex = 8;
            this.btnEliminarCargo.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, 170, 36, 12, 12));
            // Botón Exportar Cargos
            this.btnExportarCargos.Text = "Exportar Cargos";
            this.btnExportarCargos.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnExportarCargos.BackColor = System.Drawing.Color.White;
            this.btnExportarCargos.ForeColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnExportarCargos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarCargos.FlatAppearance.BorderSize = 2;
            this.btnExportarCargos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnExportarCargos.Size = new System.Drawing.Size(170, 36);
            this.btnExportarCargos.Location = new System.Drawing.Point(20, 190);
            this.btnExportarCargos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarCargos.TabIndex = 9;
            this.btnExportarCargos.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, 170, 36, 12, 12));
            this.groupCargos.Controls.Add(this.btnMostrarCargos);
            this.groupCargos.Controls.Add(this.btnAgregarCargo);
            this.groupCargos.Controls.Add(this.btnActualizarCargo);
            this.groupCargos.Controls.Add(this.btnEliminarCargo);
            this.groupCargos.Controls.Add(this.btnExportarCargos);
            this.panelMenu.Controls.Add(this.groupCargos);
            // Botón Mostrar Cargos
            this.btnMostrarCargos.Text = "Mostrar Cargos";
            this.btnMostrarCargos.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnMostrarCargos.BackColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnMostrarCargos.ForeColor = System.Drawing.Color.White;
            this.btnMostrarCargos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarCargos.FlatAppearance.BorderSize = 0;
            this.btnMostrarCargos.Size = new System.Drawing.Size(170, 36);
            this.btnMostrarCargos.Location = new System.Drawing.Point(20, 30);
            this.btnMostrarCargos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarCargos.TabIndex = 5;
            this.btnMostrarCargos.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, 170, 36, 12, 12));
            // Botón Agregar Cargo
            this.btnAgregarCargo.Text = "Agregar Cargo";
            this.btnAgregarCargo.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnAgregarCargo.BackColor = System.Drawing.Color.White;
            this.btnAgregarCargo.ForeColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnAgregarCargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCargo.FlatAppearance.BorderSize = 2;
            this.btnAgregarCargo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnAgregarCargo.Size = new System.Drawing.Size(170, 36);
            this.btnAgregarCargo.Location = new System.Drawing.Point(20, 70);
            this.btnAgregarCargo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCargo.TabIndex = 6;
            this.btnAgregarCargo.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, 170, 36, 12, 12));
            // --- Salir ---
            this.btnSalir.Text = "Salir";
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(80)))));
            this.btnSalir.Location = new System.Drawing.Point(20, 680);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(180, 32);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // panelMain
            // 
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(220, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(780, 600);
            this.panelMain.TabIndex = 17;
            this.panelMain.Controls.Add(this.labelTitulo);
            this.panelMain.Controls.Add(this.labelSubtitulo);
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelTitulo.Location = new System.Drawing.Point(250, 60);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(414, 32);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Sistema de Manejo de Empleados";
            // 
            // labelSubtitulo
            // 
            this.labelSubtitulo.AutoSize = true;
            this.labelSubtitulo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelSubtitulo.ForeColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.labelSubtitulo.Location = new System.Drawing.Point(250, 110);
            this.labelSubtitulo.Name = "labelSubtitulo";
            this.labelSubtitulo.Size = new System.Drawing.Size(337, 21);
            this.labelSubtitulo.TabIndex = 1;
            this.labelSubtitulo.Text = "Bienvenido. Gestione empleados, departamentos y cargos.";
            // Panel de bienvenida visualmente atractivo
            this.panelBienvenida = new System.Windows.Forms.Panel();
            this.panelBienvenida.BackColor = System.Drawing.Color.FromArgb(245, 240, 255);
            this.panelBienvenida.Size = new System.Drawing.Size(500, 320);
            this.panelBienvenida.Location = new System.Drawing.Point(320, 120);
            this.panelBienvenida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBienvenida.Padding = new System.Windows.Forms.Padding(24);
            this.panelBienvenida.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, 500, 320, 32, 32));

            // Icono de bienvenida
            this.pictureBoxWelcome = new System.Windows.Forms.PictureBox();
            this.pictureBoxWelcome.Size = new System.Drawing.Size(80, 80);
            this.pictureBoxWelcome.Location = new System.Drawing.Point(210, 20);
            this.pictureBoxWelcome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWelcome.Image = System.Drawing.SystemIcons.Information.ToBitmap();
            this.panelBienvenida.Controls.Add(this.pictureBoxWelcome);

            // Título de bienvenida
            this.lblBienvenidaTitulo = new System.Windows.Forms.Label();
            this.lblBienvenidaTitulo.Text = "Bienvenido al Sistema de Manejo de Empleados";
            this.lblBienvenidaTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblBienvenidaTitulo.ForeColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.lblBienvenidaTitulo.AutoSize = false;
            this.lblBienvenidaTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBienvenidaTitulo.Size = new System.Drawing.Size(480, 40);
            this.lblBienvenidaTitulo.Location = new System.Drawing.Point(10, 110);
            this.panelBienvenida.Controls.Add(this.lblBienvenidaTitulo);

            // Subtítulo
            this.lblBienvenidaSub = new System.Windows.Forms.Label();
            this.lblBienvenidaSub.Text = "Gestione empleados, departamentos y cargos de forma sencilla y moderna.";
            this.lblBienvenidaSub.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.lblBienvenidaSub.ForeColor = System.Drawing.Color.FromArgb(120, 60, 120);
            this.lblBienvenidaSub.AutoSize = false;
            this.lblBienvenidaSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBienvenidaSub.Size = new System.Drawing.Size(480, 30);
            this.lblBienvenidaSub.Location = new System.Drawing.Point(10, 155);
            this.panelBienvenida.Controls.Add(this.lblBienvenidaSub);

            // Botones de acceso rápido
            this.btnAccesoEmpleados = new System.Windows.Forms.Button();
            this.btnAccesoEmpleados.Text = "Empleados";
            this.btnAccesoEmpleados.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAccesoEmpleados.BackColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnAccesoEmpleados.ForeColor = System.Drawing.Color.White;
            this.btnAccesoEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccesoEmpleados.FlatAppearance.BorderSize = 0;
            this.btnAccesoEmpleados.Size = new System.Drawing.Size(140, 40);
            this.btnAccesoEmpleados.Location = new System.Drawing.Point(50, 220);
            this.btnAccesoEmpleados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccesoEmpleados.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, 140, 40, 16, 16));
            this.btnAccesoEmpleados.Click += (s, e) => new FormEmpleados("mostrar").ShowDialog();
            this.panelBienvenida.Controls.Add(this.btnAccesoEmpleados);

            this.btnAccesoDepartamentos = new System.Windows.Forms.Button();
            this.btnAccesoDepartamentos.Text = "Departamentos";
            this.btnAccesoDepartamentos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAccesoDepartamentos.BackColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnAccesoDepartamentos.ForeColor = System.Drawing.Color.White;
            this.btnAccesoDepartamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccesoDepartamentos.FlatAppearance.BorderSize = 0;
            this.btnAccesoDepartamentos.Size = new System.Drawing.Size(140, 40);
            this.btnAccesoDepartamentos.Location = new System.Drawing.Point(180, 220);
            this.btnAccesoDepartamentos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccesoDepartamentos.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, 140, 40, 16, 16));
            this.btnAccesoDepartamentos.Click += (s, e) => new FormDepartamentos("mostrar").ShowDialog();
            this.panelBienvenida.Controls.Add(this.btnAccesoDepartamentos);

            this.btnAccesoCargos = new System.Windows.Forms.Button();
            this.btnAccesoCargos.Text = "Cargos";
            this.btnAccesoCargos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAccesoCargos.BackColor = System.Drawing.Color.FromArgb(80, 0, 80);
            this.btnAccesoCargos.ForeColor = System.Drawing.Color.White;
            this.btnAccesoCargos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccesoCargos.FlatAppearance.BorderSize = 0;
            this.btnAccesoCargos.Size = new System.Drawing.Size(140, 40);
            this.btnAccesoCargos.Location = new System.Drawing.Point(310, 220);
            this.btnAccesoCargos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccesoCargos.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, 140, 40, 16, 16));
            this.btnAccesoCargos.Click += (s, e) => new FormCargos("mostrar").ShowDialog();
            this.panelBienvenida.Controls.Add(this.btnAccesoCargos);

            this.panelMain.Controls.Add(this.panelBienvenida);
            // Tooltips para botones (solo si el botón está inicializado)
            var toolTip = new System.Windows.Forms.ToolTip();
            if (this.btnMostrarEmpleados != null)
                toolTip.SetToolTip(this.btnMostrarEmpleados, "Ver la lista de empleados registrados");
            if (this.btnAgregarEmpleado != null)
                toolTip.SetToolTip(this.btnAgregarEmpleado, "Agregar un nuevo empleado");
            if (this.btnActualizarEmpleado != null)
                toolTip.SetToolTip(this.btnActualizarEmpleado, "Actualizar información de un empleado");
            if (this.btnEliminarEmpleado != null)
                toolTip.SetToolTip(this.btnEliminarEmpleado, "Eliminar un empleado existente");
            if (this.btnExportarEmpleados != null)
                toolTip.SetToolTip(this.btnExportarEmpleados, "Exportar la lista de empleados a CSV");
            if (this.btnMostrarDepartamentos != null)
                toolTip.SetToolTip(this.btnMostrarDepartamentos, "Ver la lista de departamentos");
            if (this.btnAgregarDepartamento != null)
                toolTip.SetToolTip(this.btnAgregarDepartamento, "Agregar un nuevo departamento");
            if (this.btnActualizarDepartamento != null)
                toolTip.SetToolTip(this.btnActualizarDepartamento, "Actualizar información de un departamento");
            if (this.btnEliminarDepartamento != null)
                toolTip.SetToolTip(this.btnEliminarDepartamento, "Eliminar un departamento existente");
            if (this.btnExportarDepartamentos != null)
                toolTip.SetToolTip(this.btnExportarDepartamentos, "Exportar la lista de departamentos a CSV");
            if (this.btnMostrarCargos != null)
                toolTip.SetToolTip(this.btnMostrarCargos, "Ver la lista de cargos disponibles");
            if (this.btnAgregarCargo != null)
                toolTip.SetToolTip(this.btnAgregarCargo, "Agregar un nuevo cargo");
            if (this.btnActualizarCargo != null)
                toolTip.SetToolTip(this.btnActualizarCargo, "Actualizar información de un cargo");
            if (this.btnEliminarCargo != null)
                toolTip.SetToolTip(this.btnEliminarCargo, "Eliminar un cargo existente");
            if (this.btnExportarCargos != null)
                toolTip.SetToolTip(this.btnExportarCargos, "Exportar la lista de cargos a CSV");
            // Accesos rápidos
            this.btnMostrarEmpleados.Text = "&Mostrar Empleados";
            this.btnAgregarEmpleado.Text = "&Agregar Empleado";
            this.btnActualizarEmpleado.Text = "&Actualizar Empleado";
            this.btnEliminarEmpleado.Text = "&Eliminar Empleado";
            this.btnExportarEmpleados.Text = "&Exportar Empleados";
            this.btnMostrarDepartamentos.Text = "&Mostrar Departamentos";
            this.btnAgregarDepartamento.Text = "&Agregar Departamento";
            this.btnActualizarDepartamento.Text = "&Actualizar Departamento";
            this.btnEliminarDepartamento.Text = "&Eliminar Departamento";
            this.btnExportarDepartamentos.Text = "&Exportar Departamentos";
            this.btnMostrarCargos.Text = "&Mostrar Cargos";
            this.btnAgregarCargo.Text = "&Agregar Cargo";
            this.btnActualizarCargo.Text = "&Actualizar Cargo";
            this.btnEliminarCargo.Text = "&Eliminar Cargo";
            this.btnExportarCargos.Text = "&Exportar Cargos";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelMenu);
            this.Name = "Form1";
            this.Text = "Sistema de Manejo de Empleados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            // 
            // Botones de empleados
            // 
            this.btnMostrarEmpleados.Click += (s, e) => new FormEmpleados("mostrar").ShowDialog();
            this.btnAgregarEmpleado.Click += (s, e) => new FormEmpleados("agregar").ShowDialog();
            this.btnActualizarEmpleado.Click += (s, e) => new FormEmpleados("actualizar").ShowDialog();
            this.btnEliminarEmpleado.Click += (s, e) => new FormEmpleados("eliminar").ShowDialog();
            this.btnExportarEmpleados.Click += (s, e) => new FormEmpleados("exportar").ShowDialog();
            // Botones de departamentos
            this.btnMostrarDepartamentos.Click += (s, e) => new FormDepartamentos("mostrar").ShowDialog();
            this.btnAgregarDepartamento.Click += (s, e) => new FormDepartamentos("agregar").ShowDialog();
            this.btnActualizarDepartamento.Click += (s, e) => new FormDepartamentos("actualizar").ShowDialog();
            this.btnEliminarDepartamento.Click += (s, e) => new FormDepartamentos("eliminar").ShowDialog();
            this.btnExportarDepartamentos.Click += (s, e) => new FormDepartamentos("exportar").ShowDialog();
            // Botones de cargos
            this.btnMostrarCargos.Click += (s, e) => new FormCargos("mostrar").ShowDialog();
            this.btnAgregarCargo.Click += (s, e) => new FormCargos("agregar").ShowDialog();
            this.btnActualizarCargo.Click += (s, e) => new FormCargos("actualizar").ShowDialog();
            this.btnEliminarCargo.Click += (s, e) => new FormCargos("eliminar").ShowDialog();
            this.btnExportarCargos.Click += (s, e) => new FormCargos("exportar").ShowDialog();
        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button btnMostrarEmpleados;
        private System.Windows.Forms.Button btnAgregarEmpleado;
        private System.Windows.Forms.Button btnActualizarEmpleado;
        private System.Windows.Forms.Button btnEliminarEmpleado;
        private System.Windows.Forms.Button btnExportarEmpleados;
        private System.Windows.Forms.Button btnDepartamentosExtras;
        private System.Windows.Forms.Button btnCargosExtras;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelSubtitulo;
        private System.Windows.Forms.Button btnMostrarDepartamentos;
        private System.Windows.Forms.Button btnAgregarDepartamento;
        private System.Windows.Forms.Button btnActualizarDepartamento;
        private System.Windows.Forms.Button btnEliminarDepartamento;
        private System.Windows.Forms.Button btnExportarDepartamentos;
        private System.Windows.Forms.Button btnMostrarCargos;
        private System.Windows.Forms.Button btnAgregarCargo;
        private System.Windows.Forms.Button btnActualizarCargo;
        private System.Windows.Forms.Button btnEliminarCargo;
        private System.Windows.Forms.Button btnExportarCargos;
        private System.Windows.Forms.GroupBox groupEmpleados;
        private System.Windows.Forms.GroupBox groupDepartamentos;
        private System.Windows.Forms.GroupBox groupCargos;
        private System.Windows.Forms.Label lblDescEmpleados;
        private System.Windows.Forms.Label lblDescDepartamentos;
        private System.Windows.Forms.Label lblDescCargos;
        private System.Windows.Forms.Panel panelBienvenida;
        private System.Windows.Forms.PictureBox pictureBoxWelcome;
        private System.Windows.Forms.Label lblBienvenidaTitulo;
        private System.Windows.Forms.Label lblBienvenidaSub;
        private System.Windows.Forms.Button btnAccesoEmpleados;
        private System.Windows.Forms.Button btnAccesoDepartamentos;
        private System.Windows.Forms.Button btnAccesoCargos;
    }
}

