using SistemaDEmpleados.Data;
using SistemaDEmpleados.Models;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace SistemaDEmpleados
{
    public class FormCargos : Form
    {
        private Panel panelMenu;
        private Button btnMostrar;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnExportar;
        private Panel panelAccion;
        private DataGridView dgvCargos;
        private TextBox txtNombre;
        private Button btnGuardar;
        private CargoRepository cargoRepo = new CargoRepository();
        private DepartamentoRepository departamentoRepo = new DepartamentoRepository();
        private int? cargoSeleccionadoId = null;
        private string modo;
        private Label lblTitulo;
        private Label lblDescripcion;
        private ToolTip toolTip;
        private Panel panelHeader;

        private void AgregarCargosPorDefecto()
        {
            var cargosDefecto = new[] { "Gerente", "Analista", "Desarrollador", "Soporte", "Recursos Humanos" };
            foreach (var nombre in cargosDefecto)
            {
                if (!cargoRepo.GetAll().Exists(c => c.Nombre == nombre))
                {
                    cargoRepo.Add(new Cargo { Nombre = nombre });
                }
            }
        }

        public FormCargos(string modo = "mostrar")
        {
            this.modo = modo;
            this.Text = "Gestión de Cargos";
            this.WindowState = FormWindowState.Maximized;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            InicializarControles();
            AgregarCargosPorDefecto();
            CargarCargos();
            MostrarPanel(modo);
            panelMenu.Enabled = true;
            panelAccion.Enabled = true;
        }

        private void InicializarControles()
        {
            panelMenu = new Panel {
                Dock = DockStyle.Left,
                Width = 220,
                BackColor = Color.FromArgb(210, 220, 240)
            };
            int btnTop = 40;
            int btnSpacing = 60;
            btnMostrar = new Button { Text = "Mostrar Cargos", Left = 20, Top = btnTop, Width = 180, Height = 40, Font = new Font("Segoe UI", 11, FontStyle.Bold), BackColor = Color.White, ForeColor = Color.FromArgb(80, 0, 80), FlatStyle = FlatStyle.Flat };
            btnAgregar = new Button { Text = "Agregar Cargo", Left = 20, Top = btnTop + btnSpacing, Width = 180, Height = 40, Font = new Font("Segoe UI", 11, FontStyle.Bold), BackColor = Color.White, ForeColor = Color.FromArgb(80, 0, 80), FlatStyle = FlatStyle.Flat };
            btnActualizar = new Button { Text = "Actualizar Cargo", Left = 20, Top = btnTop + btnSpacing * 2, Width = 180, Height = 40, Font = new Font("Segoe UI", 11, FontStyle.Bold), BackColor = Color.White, ForeColor = Color.FromArgb(80, 0, 80), FlatStyle = FlatStyle.Flat };
            btnEliminar = new Button { Text = "Eliminar Cargo", Left = 20, Top = btnTop + btnSpacing * 3, Width = 180, Height = 40, Font = new Font("Segoe UI", 11, FontStyle.Bold), BackColor = Color.White, ForeColor = Color.FromArgb(80, 0, 80), FlatStyle = FlatStyle.Flat };
            btnExportar = new Button { Text = "Exportar a CSV", Left = 20, Top = btnTop + btnSpacing * 4, Width = 180, Height = 40, Font = new Font("Segoe UI", 11, FontStyle.Bold), BackColor = Color.White, ForeColor = Color.FromArgb(80, 0, 80), FlatStyle = FlatStyle.Flat };
            Button btnSalir = new Button { Text = "Salir", Left = 20, Top = btnTop + btnSpacing * 5, Width = 180, Height = 40, Font = new Font("Segoe UI", 11, FontStyle.Bold), BackColor = Color.White, ForeColor = Color.FromArgb(80, 0, 80), FlatStyle = FlatStyle.Flat };
            btnSalir.Click += (s, e) => this.Close();
            panelMenu.Controls.AddRange(new Control[] { btnMostrar, btnAgregar, btnActualizar, btnEliminar, btnExportar, btnSalir });
            this.Controls.Add(panelMenu);
            this.Controls.SetChildIndex(panelMenu, 0);

            panelAccion = new Panel {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            this.Controls.Add(panelAccion);
            this.Controls.SetChildIndex(panelAccion, 1);

            dgvCargos = new DataGridView {
                Location = new Point(230, 20),
                Size = new Size(900, 250),
                ReadOnly = true, AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.LightGray,
                BorderStyle = BorderStyle.FixedSingle,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Font = new Font("Segoe UI", 11),
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle { Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.FromArgb(80, 0, 80), BackColor = Color.FromArgb(210, 220, 240) },
                DefaultCellStyle = new DataGridViewCellStyle { Font = new Font("Segoe UI", 11), ForeColor = Color.Black, BackColor = Color.White }
            };
            dgvCargos.Columns.Clear();
            dgvCargos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "CargoID", DataPropertyName = "CargoID" });
            dgvCargos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre" });
            panelAccion.Controls.Add(dgvCargos);

            int editLeft = 250, editTop = 290, editSpacing = 40;
            panelAccion.Controls.Add(new Label { Text = "Nombre del Cargo:", Left = editLeft, Top = editTop, Width = 160, Font = new Font("Segoe UI", 11) });
            txtNombre = new TextBox { Left = editLeft + 170, Top = editTop, Width = 250, Font = new Font("Segoe UI", 11) };
            panelAccion.Controls.Add(txtNombre);
            btnGuardar = new Button { Text = "Guardar", Left = editLeft + 170, Top = editTop + editSpacing, Width = 250, Height = 40, Font = new Font("Segoe UI", 11, FontStyle.Bold), BackColor = Color.FromArgb(220, 220, 255), ForeColor = Color.FromArgb(80, 0, 80), FlatStyle = FlatStyle.Flat };
            panelAccion.Controls.Add(btnGuardar);
            btnGuardar.Click += BtnGuardar_Click;
            dgvCargos.SelectionChanged += DgvCargos_SelectionChanged;
        }

        private void MostrarPanel(string modoPanel)
        {
            modo = modoPanel;
            dgvCargos.Visible = true;
            bool edicion = (modo == "agregar" || modo == "actualizar" || modo == "eliminar");
            foreach (Control c in panelAccion.Controls)
            {
                if (c == dgvCargos)
                {
                    c.Visible = true;
                }
                else if (c == btnGuardar)
                {
                    c.Visible = edicion;
                    btnGuardar.Enabled = edicion;
                }
                else if (c == txtNombre)
                {
                    c.Visible = edicion;
                    c.Enabled = edicion;
                }
                else if (c is Label && c.Top == 430)
                {
                    c.Visible = edicion;
                }
            }
            // Ocultar/mostrar botones del menú según el modo
            btnMostrar.Visible = (modo == "mostrar");
            btnAgregar.Visible = (modo == "agregar");
            btnActualizar.Visible = (modo == "actualizar");
            btnEliminar.Visible = (modo == "eliminar");
            btnExportar.Visible = (modo == "mostrar" || modo == "exportar");
            // El botón salir siempre visible
            foreach (Control c in panelMenu.Controls)
            {
                if (c is Button b && b.Text == "Salir")
                    b.Visible = true;
            }
            btnGuardar.Text = modo == "agregar" ? "Agregar" : (modo == "actualizar" ? "Actualizar" : (modo == "eliminar" ? "Eliminar" : "Guardar"));
            if (modo == "agregar")
            {
                LimpiarCampos();
            }
        }

        private void CargarCargos()
        {
            try
            {
                var cargos = cargoRepo.GetAll();
                var departamentos = departamentoRepo.GetAll();
                // Agregar nombre de departamento si existe relación
                foreach (var cargo in cargos)
                {
                    var dep = departamentos.Find(d => d.DepartamentoID == cargo.CargoID); // Suponiendo relación por ID
                    cargo.GetType().GetProperty("DepartamentoNombre")?.SetValue(cargo, dep?.Nombre ?? "");
                }
                dgvCargos.DataSource = null;
                dgvCargos.DataSource = cargos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cargos: " + ex.Message);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (modo == "agregar")
                {
                    if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    {
                        MessageBox.Show("El nombre es obligatorio.");
                        txtNombre.Focus();
                        return;
                    }
                    foreach (var cargo in cargoRepo.GetAll())
                    {
                        if (cargo.Nombre.Trim().ToLower() == txtNombre.Text.Trim().ToLower())
                        {
                            MessageBox.Show("Ya existe un cargo con ese nombre.");
                            txtNombre.Focus();
                            return;
                        }
                    }
                    var cargoNuevo = new Cargo { Nombre = txtNombre.Text.Trim() };
                    cargoRepo.Add(cargoNuevo);
                    MessageBox.Show("Cargo agregado correctamente.");
                    CargarCargos();
                    LimpiarCampos();
                    MostrarPanel("mostrar");
                }
                else if (modo == "actualizar")
                {
                    if (cargoSeleccionadoId == null)
                    {
                        MessageBox.Show("Seleccione un cargo para actualizar.");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    {
                        MessageBox.Show("El nombre es obligado.");
                        txtNombre.Focus();
                        return;
                    }
                    var existente = cargoRepo.GetAll().Find(c => c.CargoID == cargoSeleccionadoId);
                    if (existente == null)
                    {
                        MessageBox.Show("El cargo seleccionado ya no existe.");
                        CargarCargos();
                        LimpiarCampos();
                        return;
                    }
                    foreach (var cargo in cargoRepo.GetAll())
                    {
                        if (cargo.CargoID != cargoSeleccionadoId && cargo.Nombre.Trim().ToLower() == txtNombre.Text.Trim().ToLower())
                        {
                            MessageBox.Show("Ya existe un cargo con ese nombre.");
                            txtNombre.Focus();
                            return;
                        }
                    }
                    existente.Nombre = txtNombre.Text.Trim();
                    cargoRepo.Update(existente);
                    MessageBox.Show("Cargo actualizado correctamente.");
                    CargarCargos();
                    LimpiarCampos();
                    MostrarPanel("mostrar");
                }
                else if (modo == "eliminar")
                {
                    if (cargoSeleccionadoId == null)
                    {
                        MessageBox.Show("Seleccione un cargo para eliminar.");
                        return;
                    }
                    var existente = cargoRepo.GetAll().Find(c => c.CargoID == cargoSeleccionadoId);
                    if (existente == null)
                    {
                        MessageBox.Show("El cargo seleccionado ya no existe.");
                        CargarCargos();
                        LimpiarCampos();
                        return;
                    }
                    if (MessageBox.Show("¿Está seguro de eliminar este cargo?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        cargoRepo.Delete(cargoSeleccionadoId.Value);
                        MessageBox.Show("Cargo eliminado correctamente.");
                        CargarCargos();
                        LimpiarCampos();
                        MostrarPanel("mostrar");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                var cargos = cargoRepo.GetAll();
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                        {
                            sw.WriteLine("CargoID,Nombre");
                            foreach (var cargo in cargos)
                            {
                                sw.WriteLine($"{cargo.CargoID},{cargo.Nombre}");
                            }
                        }
                        MessageBox.Show("Exportación exitosa.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message);
            }
        }

        private void DgvCargos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCargos.CurrentRow != null && dgvCargos.CurrentRow.DataBoundItem is Cargo cargo)
            {
                cargoSeleccionadoId = cargo.CargoID;
                txtNombre.Text = cargo.Nombre;
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            cargoSeleccionadoId = null;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                txtNombre.BackColor = Color.LightPink;
                txtNombre.Focus();
                return false;
            }
            txtNombre.BackColor = Color.White;
            return true;
        }
    }
}