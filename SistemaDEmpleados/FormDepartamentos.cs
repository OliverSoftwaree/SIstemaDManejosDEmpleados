using SistemaDEmpleados.Data;
using SistemaDEmpleados.Models;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace SistemaDEmpleados
{
    public class FormDepartamentos : Form
    {
        private Panel panelMenu;
        private Button btnMostrar;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnExportar;
        private Button btnSalir;
        private Panel panelAccion;
        private DataGridView dgvDepartamentos;
        private TextBox txtNombre;
        private Button btnGuardar;
        private DepartamentoRepository departamentoRepo = new DepartamentoRepository();
        private int? departamentoSeleccionadoId = null;
        private string modo;
        private Label lblTitulo;
        private Label lblDescripcion;
        private ToolTip toolTip;
        private Panel panelHeader;

        public FormDepartamentos(string modo = "mostrar")
        {
            this.modo = modo;
            this.Text = "Gestión de Departamentos";
            this.WindowState = FormWindowState.Maximized;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            InicializarControles();
            CargarDepartamentos();
            MostrarPanel(modo);
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
            btnMostrar = new Button { Text = "Mostrar Departamentos", Left = 20, Top = btnTop, Width = 180, Height = 40, Font = new Font("Segoe UI", 11, FontStyle.Bold), BackColor = Color.White, ForeColor = Color.FromArgb(80, 0, 80), FlatStyle = FlatStyle.Flat };
            btnAgregar = new Button { Text = "Agregar Departamento", Left = 20, Top = btnTop + btnSpacing, Width = 180, Height = 40, Font = new Font("Segoe UI", 11, FontStyle.Bold), BackColor = Color.White, ForeColor = Color.FromArgb(80, 0, 80), FlatStyle = FlatStyle.Flat };
            btnActualizar = new Button { Text = "Actualizar Departamento", Left = 20, Top = btnTop + btnSpacing * 2, Width = 180, Height = 40, Font = new Font("Segoe UI", 11, FontStyle.Bold), BackColor = Color.White, ForeColor = Color.FromArgb(80, 0, 80), FlatStyle = FlatStyle.Flat };
            btnEliminar = new Button { Text = "Eliminar Departamento", Left = 20, Top = btnTop + btnSpacing * 3, Width = 180, Height = 40, Font = new Font("Segoe UI", 11, FontStyle.Bold), BackColor = Color.White, ForeColor = Color.FromArgb(80, 0, 80), FlatStyle = FlatStyle.Flat };
            btnExportar = new Button { Text = "Exportar a CSV", Left = 20, Top = btnTop + btnSpacing * 4, Width = 180, Height = 40, Font = new Font("Segoe UI", 11, FontStyle.Bold), BackColor = Color.White, ForeColor = Color.FromArgb(80, 0, 80), FlatStyle = FlatStyle.Flat };
            btnSalir = new Button { Text = "Salir", Left = 20, Top = btnTop + btnSpacing * 5, Width = 180, Height = 40, Font = new Font("Segoe UI", 11, FontStyle.Bold), BackColor = Color.White, ForeColor = Color.FromArgb(80, 0, 80), FlatStyle = FlatStyle.Flat };
            btnMostrar.Click += (s, e) => MostrarPanel("mostrar");
            btnAgregar.Click += (s, e) => MostrarPanel("agregar");
            btnActualizar.Click += (s, e) => MostrarPanel("actualizar");
            btnEliminar.Click += (s, e) => MostrarPanel("eliminar");
            btnExportar.Click += BtnExportar_Click;
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

            dgvDepartamentos = new DataGridView {
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
            dgvDepartamentos.Columns.Clear();
            dgvDepartamentos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "DepartamentoID", DataPropertyName = "DepartamentoID" });
            dgvDepartamentos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre" });
            panelAccion.Controls.Add(dgvDepartamentos);

            int editLeft = 250, editTop = 290, editSpacing = 40;
            panelAccion.Controls.Add(new Label { Text = "Nombre del Departamento:", Left = editLeft, Top = editTop, Width = 180, Font = new Font("Segoe UI", 11) });
            txtNombre = new TextBox { Left = editLeft + 190, Top = editTop, Width = 250, Font = new Font("Segoe UI", 11) };
            panelAccion.Controls.Add(txtNombre);
            btnGuardar = new Button { Text = "Guardar", Left = editLeft + 190, Top = editTop + editSpacing, Width = 250, Height = 40, Font = new Font("Segoe UI", 11, FontStyle.Bold), BackColor = Color.FromArgb(220, 220, 255), ForeColor = Color.FromArgb(80, 0, 80), FlatStyle = FlatStyle.Flat };
            panelAccion.Controls.Add(btnGuardar);
            dgvDepartamentos.SelectionChanged += DgvDepartamentos_SelectionChanged;
        }

        private void MostrarPanel(string modoPanel)
        {
            modo = modoPanel;
            dgvDepartamentos.Visible = true;
            bool edicion = (modo == "agregar" || modo == "actualizar" || modo == "eliminar");
            foreach (Control c in panelAccion.Controls)
            {
                if (c == dgvDepartamentos)
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
            btnExportar.Visible = (modo == "mostrar" || modo == "exportar");
            btnMostrar.Visible = true;
            btnAgregar.Visible = btnActualizar.Visible = btnEliminar.Visible = btnSalir.Visible = (modo == "mostrar");
            btnGuardar.Text = modo == "agregar" ? "Agregar" : (modo == "actualizar" ? "Actualizar" : (modo == "eliminar" ? "Eliminar" : "Guardar"));
            if (modo == "agregar")
            {
                LimpiarCampos();
            }
        }

        private void CargarDepartamentos()
        {
            try
            {
                dgvDepartamentos.DataSource = null;
                dgvDepartamentos.DataSource = departamentoRepo.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar departamentos: " + ex.Message);
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
                    foreach (var dep in departamentoRepo.GetAll())
                    {
                        if (dep.Nombre.Trim().ToLower() == txtNombre.Text.Trim().ToLower())
                        {
                            MessageBox.Show("Ya existe un departamento con ese nombre.");
                            txtNombre.Focus();
                            return;
                        }
                    }
                    var departamento = new Departamento { Nombre = txtNombre.Text.Trim() };
                    departamentoRepo.Add(departamento);
                    MessageBox.Show("Departamento agregado correctamente.");
                    CargarDepartamentos();
                    LimpiarCampos();
                    MostrarPanel("mostrar");
                }
                else if (modo == "actualizar")
                {
                    if (departamentoSeleccionadoId == null)
                    {
                        MessageBox.Show("Seleccione un departamento para actualizar.");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    {
                        MessageBox.Show("El nombre es obligatorio.");
                        txtNombre.Focus();
                        return;
                    }
                    var existente = departamentoRepo.GetAll().Find(dep => dep.DepartamentoID == departamentoSeleccionadoId);
                    if (existente == null)
                    {
                        MessageBox.Show("El departamento seleccionado ya no existe.");
                        CargarDepartamentos();
                        LimpiarCampos();
                        return;
                    }
                    foreach (var dep in departamentoRepo.GetAll())
                    {
                        if (dep.DepartamentoID != departamentoSeleccionadoId && dep.Nombre.Trim().ToLower() == txtNombre.Text.Trim().ToLower())
                        {
                            MessageBox.Show("Ya existe un departamento con ese nombre.");
                            txtNombre.Focus();
                            return;
                        }
                    }
                    existente.Nombre = txtNombre.Text.Trim();
                    departamentoRepo.Update(existente);
                    MessageBox.Show("Departamento actualizado correctamente.");
                    CargarDepartamentos();
                    LimpiarCampos();
                    MostrarPanel("mostrar");
                }
                else if (modo == "eliminar")
                {
                    if (departamentoSeleccionadoId == null)
                    {
                        MessageBox.Show("Seleccione un departamento para eliminar.");
                        return;
                    }
                    var existente = departamentoRepo.GetAll().Find(dep => dep.DepartamentoID == departamentoSeleccionadoId);
                    if (existente == null)
                    {
                        MessageBox.Show("El departamento seleccionado ya no existe.");
                        CargarDepartamentos();
                        LimpiarCampos();
                        return;
                    }
                    if (MessageBox.Show("¿Está seguro de eliminar este departamento?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        departamentoRepo.Delete(departamentoSeleccionadoId.Value);
                        MessageBox.Show("Departamento eliminado correctamente.");
                        CargarDepartamentos();
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
                var departamentos = departamentoRepo.GetAll();
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                        {
                            sw.WriteLine("DepartamentoID,Nombre");
                            foreach (var dep in departamentos)
                            {
                                // Escribir los datos tal cual, sin comillas ni signos extra
                                sw.WriteLine(dep.DepartamentoID + "," + dep.Nombre);
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

        private void DgvDepartamentos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDepartamentos.CurrentRow != null && dgvDepartamentos.CurrentRow.DataBoundItem is Departamento dep)
            {
                departamentoSeleccionadoId = dep.DepartamentoID;
                txtNombre.Text = dep.Nombre;
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            departamentoSeleccionadoId = null;
        }
    }
}