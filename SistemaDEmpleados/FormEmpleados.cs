using SistemaDEmpleados.Data;
using SistemaDEmpleados.Models;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace SistemaDEmpleados
{
    public class FormEmpleados : Form
    {
        private DataGridView dgvEmpleados;
        private TextBox txtNombre;
        private ComboBox cbDepartamento;
        private ComboBox cbCargo;
        private DateTimePicker dtpFechaInicio;
        private TextBox txtSalario;
        private ComboBox cbEstado;
        private Button btnGuardar;
        private EmpleadoRepository empleadoRepo = new EmpleadoRepository();
        private DepartamentoRepository departamentoRepo = new DepartamentoRepository();
        private CargoRepository cargoRepo = new CargoRepository();
        private int? empleadoSeleccionadoId = null;
        private string modo;
        private Panel panelEdicion;
        private MenuStrip menuSuperior;
        private ToolStripMenuItem menuMostrar;
        private ToolStripMenuItem menuAgregar;
        private ToolStripMenuItem menuActualizar;
        private ToolStripMenuItem menuEliminar;
        private ToolStripMenuItem menuExportar;
        private TextBox txtEmpleadoID;
        private Label lblTitulo;
        private Label lblDescripcion;
        // Nuevos labels para errores
        private Label lblErrorNombre;
        private Label lblErrorDepartamento;
        private Label lblErrorCargo;
        private Label lblErrorSalario;
        private Label lblErrorEstado;

        public FormEmpleados(string modo = "mostrar")
        {
            this.modo = modo;
            this.Text = "Gestión de Empleados";
            this.WindowState = FormWindowState.Maximized;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            InicializarControles();
            AgregarCargosYDepartamentosPorDefecto();
            CargarEmpleados();
            this.Resize += (s, e) => CentrarTituloYDescripcion();
        }

        private void InicializarControles()
        {
            // Título y descripción centrados
            lblTitulo = new Label
            {
                Text = "Gestión de Empleados",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = Color.FromArgb(80, 0, 80),
                AutoSize = true,
                Top = 40,
            };
            lblDescripcion = new Label
            {
                Text = "Administre empleados, departamentos y cargos de forma sencilla.",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.FromArgb(120, 60, 120),
                AutoSize = true,
                Top = 90,
            };
            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblDescripcion);
            CentrarTituloYDescripcion();

            // Menú superior visualmente mejorado
            menuSuperior = new MenuStrip
            {
                BackColor = Color.FromArgb(80, 0, 80),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 48,
                Padding = new Padding(20, 8, 20, 8),
                GripStyle = ToolStripGripStyle.Hidden
            };
            menuMostrar = new ToolStripMenuItem("Mostrar") { ForeColor = Color.White, Margin = new Padding(10, 0, 10, 0) };
            menuAgregar = new ToolStripMenuItem("Agregar") { ForeColor = Color.White, Margin = new Padding(10, 0, 10, 0) };
            menuActualizar = new ToolStripMenuItem("Actualizar") { ForeColor = Color.White, Margin = new Padding(10, 0, 10, 0) };
            menuEliminar = new ToolStripMenuItem("Eliminar") { ForeColor = Color.White, Margin = new Padding(10, 0, 10, 0) };
            menuExportar = new ToolStripMenuItem("Exportar") { ForeColor = Color.White, Margin = new Padding(10, 0, 10, 0) };
            menuSuperior.Items.AddRange(new ToolStripItem[] { menuMostrar, menuAgregar, menuActualizar, menuEliminar, menuExportar });
            this.MainMenuStrip = menuSuperior;
            this.Controls.Add(menuSuperior);
            menuSuperior.Renderer = new ToolStripProfessionalRenderer(new CustomMenuColorTable());

            // Eventos del menú
            menuMostrar.Click += (s, e) => CambiarModo("mostrar");
            menuAgregar.Click += (s, e) => CambiarModo("agregar");
            menuActualizar.Click += (s, e) => CambiarModo("actualizar");
            menuEliminar.Click += (s, e) => CambiarModo("eliminar");
            menuExportar.Click += (s, e) => ExportarEmpleados();

            // DataGridView principal
            dgvEmpleados = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 350,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Font = new Font("Segoe UI", 11),
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle { Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.White, BackColor = Color.FromArgb(80, 0, 80), Alignment = DataGridViewContentAlignment.MiddleCenter, Padding = new Padding(0, 8, 0, 8) },
                DefaultCellStyle = new DataGridViewCellStyle { Font = new Font("Segoe UI", 11), ForeColor = Color.Black, BackColor = Color.White },
                RowTemplate = { Height = 32 },
                EnableHeadersVisualStyles = false,
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(240, 235, 255) },
                GridColor = Color.FromArgb(180, 180, 220),
                ScrollBars = ScrollBars.Both,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            };
            dgvEmpleados.Columns.Clear();
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "EmpleadoID", Width = 60 });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre", Width = 120 });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Departamento", DataPropertyName = "DepartamentoID", Width = 120 });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cargo", DataPropertyName = "CargoID", Width = 120 });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fecha Inicio", DataPropertyName = "FechaInicio", Width = 90 });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Salario", DataPropertyName = "Salario", Width = 100 });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Estado", DataPropertyName = "Estado", Width = 70 });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tiempo Empresa", DataPropertyName = "TiempoEnEmpresa", Width = 110 });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "AFP", DataPropertyName = "AFP", Width = 80 });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ARS", DataPropertyName = "ARS", Width = 80 });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ISR", DataPropertyName = "ISR", Width = 80 });
            this.Controls.Add(dgvEmpleados);
            dgvEmpleados.BringToFront();
            dgvEmpleados.SelectionChanged += DgvEmpleados_SelectionChanged;

            // Panel de edición (solo visible en agregar/actualizar/eliminar)
            panelEdicion = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 260,
                BackColor = Color.FromArgb(245, 240, 255),
                Visible = false,
                Padding = new Padding(30),
                BorderStyle = BorderStyle.FixedSingle
            };
            int editLeft = 80, editTop = 20, editSpacing = 38;
            // Campo ID solo para actualizar/eliminar
            var lblId = new Label { Text = "ID:", Left = editLeft, Top = editTop, Width = 40, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.FromArgb(80, 0, 80) };
            panelEdicion.Controls.Add(lblId);
            txtEmpleadoID = new TextBox { Left = editLeft + 50, Top = editTop, Width = 80, Font = new Font("Segoe UI", 10), BorderStyle = BorderStyle.FixedSingle };
            txtEmpleadoID.KeyDown += TxtEmpleadoID_KeyDown;
            panelEdicion.Controls.Add(txtEmpleadoID);
            // Botón guardar/eliminar
            btnGuardar = new Button
            {
                Text = "Guardar",
                Left = editLeft + 150,
                Top = editTop - 2,
                Width = 140,
                Height = 38,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                BackColor = Color.FromArgb(80, 0, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatAppearance.MouseOverBackColor = Color.FromArgb(120, 60, 120);
            btnGuardar.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 60);
            btnGuardar.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, btnGuardar.Width, btnGuardar.Height, 12, 12));
            panelEdicion.Controls.Add(btnGuardar);
            btnGuardar.Click += (s, e) => GuardarEmpleado();
            // Nombre
            panelEdicion.Controls.Add(new Label { Text = "Nombre:", Left = editLeft, Top = editTop + editSpacing, Width = 80, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.FromArgb(80, 0, 80) });
            txtNombre = new TextBox { Left = editLeft + 90, Top = editTop + editSpacing, Width = 220, Font = new Font("Segoe UI", 10), BorderStyle = BorderStyle.FixedSingle };
            panelEdicion.Controls.Add(txtNombre);
            lblErrorNombre = new Label { Left = editLeft + 90, Top = editTop + editSpacing + 25, Width = 220, ForeColor = Color.Red, Font = new Font("Segoe UI", 8), Visible = false };
            panelEdicion.Controls.Add(lblErrorNombre);
            // Departamento
            panelEdicion.Controls.Add(new Label { Text = "Departamento:", Left = editLeft, Top = editTop + editSpacing * 2, Width = 100, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.FromArgb(80, 0, 80) });
            cbDepartamento = new ComboBox { Left = editLeft + 110, Top = editTop + editSpacing * 2, Width = 200, Font = new Font("Segoe UI", 10), DropDownStyle = ComboBoxStyle.DropDownList, DisplayMember = "Nombre", ValueMember = "DepartamentoID" };
            panelEdicion.Controls.Add(cbDepartamento);
            lblErrorDepartamento = new Label { Left = editLeft + 110, Top = editTop + editSpacing * 2 + 25, Width = 200, ForeColor = Color.Red, Font = new Font("Segoe UI", 8), Visible = false };
            panelEdicion.Controls.Add(lblErrorDepartamento);
            // Cargo
            panelEdicion.Controls.Add(new Label { Text = "Cargo:", Left = editLeft, Top = editTop + editSpacing * 3, Width = 80, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.FromArgb(80, 0, 80) });
            cbCargo = new ComboBox { Left = editLeft + 90, Top = editTop + editSpacing * 3, Width = 220, Font = new Font("Segoe UI", 10), DropDownStyle = ComboBoxStyle.DropDownList, DisplayMember = "Nombre", ValueMember = "CargoID" };
            panelEdicion.Controls.Add(cbCargo);
            lblErrorCargo = new Label { Left = editLeft + 90, Top = editTop + editSpacing * 3 + 25, Width = 220, ForeColor = Color.Red, Font = new Font("Segoe UI", 8), Visible = false };
            panelEdicion.Controls.Add(lblErrorCargo);
            // Fecha Inicio
            panelEdicion.Controls.Add(new Label { Text = "Fecha Inicio:", Left = editLeft, Top = editTop + editSpacing * 4, Width = 100, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.FromArgb(80, 0, 80) });
            dtpFechaInicio = new DateTimePicker { Left = editLeft + 110, Top = editTop + editSpacing * 4, Width = 200, Font = new Font("Segoe UI", 10) };
            panelEdicion.Controls.Add(dtpFechaInicio);
            // Salario
            panelEdicion.Controls.Add(new Label { Text = "Salario:", Left = editLeft, Top = editTop + editSpacing * 5, Width = 80, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.FromArgb(80, 0, 80) });
            txtSalario = new TextBox { Left = editLeft + 90, Top = editTop + editSpacing * 5, Width = 220, Font = new Font("Segoe UI", 10), BorderStyle = BorderStyle.FixedSingle };
            panelEdicion.Controls.Add(txtSalario);
            lblErrorSalario = new Label { Left = editLeft + 90, Top = editTop + editSpacing * 5 + 25, Width = 220, ForeColor = Color.Red, Font = new Font("Segoe UI", 8), Visible = false };
            panelEdicion.Controls.Add(lblErrorSalario);
            // Estado
            panelEdicion.Controls.Add(new Label { Text = "Estado:", Left = editLeft, Top = editTop + editSpacing * 6, Width = 80, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.FromArgb(80, 0, 80) });
            cbEstado = new ComboBox {
                Left = editLeft + 90,
                Top = editTop + editSpacing * 6,
                Width = 220,
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList,
                DropDownWidth = 220
            };
            // Opciones de estado, con opción por defecto
            cbEstado.Items.Clear();
            cbEstado.Items.Add("Seleccione...");
            cbEstado.Items.Add("Activo");
            cbEstado.Items.Add("Inactivo");
            cbEstado.SelectedIndex = 0;
            panelEdicion.Controls.Add(cbEstado);
            lblErrorEstado = new Label { Left = editLeft + 90, Top = editTop + editSpacing * 6 + 25, Width = 220, ForeColor = Color.Red, Font = new Font("Segoe UI", 8), Visible = false };
            panelEdicion.Controls.Add(lblErrorEstado);
            this.Controls.Add(panelEdicion);
            CargarCombos();
        }

        private void CentrarTituloYDescripcion()
        {
            if (lblTitulo != null)
                lblTitulo.Left = (this.ClientSize.Width - lblTitulo.Width) / 2;
            if (lblDescripcion != null)
                lblDescripcion.Left = (this.ClientSize.Width - lblDescripcion.Width) / 2;
        }

        private void CambiarModo(string modo)
        {
            this.modo = modo;
            dgvEmpleados.Visible = (modo == "mostrar" || modo == "actualizar" || modo == "eliminar");
            panelEdicion.Visible = (modo == "agregar" || modo == "actualizar" || modo == "eliminar");
            txtEmpleadoID.Visible = (modo == "actualizar" || modo == "eliminar");
            foreach (Control c in panelEdicion.Controls)
            {
                if (c is Label lbl && lbl.Text == "ID:")
                    lbl.Visible = txtEmpleadoID.Visible;
            }
            // Mostrar/ocultar campos según el modo
            bool mostrarCampos = (modo == "agregar" || modo == "actualizar");
            foreach (Control c in panelEdicion.Controls)
            {
                if (c is Label lbl && lbl.Text != "ID:")
                    lbl.Visible = mostrarCampos;
                if (c == txtNombre || c == cbDepartamento || c == cbCargo || c == dtpFechaInicio || c == txtSalario || c == cbEstado)
                    c.Visible = mostrarCampos;
            }
            // Siempre cargar combos al entrar en modo actualizar o agregar
            if (modo == "actualizar" || modo == "agregar")
            {
                CargarCombos();
            }
            // Botón guardar/eliminar visual
            if (modo == "eliminar")
            {
                btnGuardar.Text = "Eliminar";
                btnGuardar.BackColor = Color.FromArgb(180, 0, 40);
                btnGuardar.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 0, 60);
                btnGuardar.FlatAppearance.MouseDownBackColor = Color.FromArgb(120, 0, 20);
                btnGuardar.Enabled = false;
                panelEdicion.Height = 100;
            }
            else if (modo == "agregar")
            {
                LimpiarCampos();
                btnGuardar.Text = "Agregar";
                btnGuardar.BackColor = Color.FromArgb(80, 0, 80);
                btnGuardar.FlatAppearance.MouseOverBackColor = Color.FromArgb(120, 60, 120);
                btnGuardar.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 60);
                btnGuardar.Enabled = true;
                panelEdicion.Height = 340; // Aumenta la altura para mostrar todos los campos
            }
            else if (modo == "actualizar")
            {
                LimpiarCampos();
                btnGuardar.Text = "Actualizar";
                btnGuardar.BackColor = Color.FromArgb(80, 0, 80);
                btnGuardar.FlatAppearance.MouseOverBackColor = Color.FromArgb(120, 60, 120);
                btnGuardar.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 0, 60);
                btnGuardar.Enabled = false;
                panelEdicion.Height = 340; // Aumenta la altura para mostrar todos los campos
            }
            else
            {
                panelEdicion.Visible = false;
            }
        }

        // Buscar empleado por ID en actualizar/eliminar
        private void TxtEmpleadoID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && (modo == "eliminar"))
            {
                int id;
                if (int.TryParse(txtEmpleadoID.Text, out id))
                {
                    var emp = empleadoRepo.GetAll().Find(x => x.EmpleadoID == id);
                    if (emp != null)
                    {
                        var confirm = MessageBox.Show($"¿Está seguro que desea eliminar al empleado '{emp.Nombre}' (ID: {emp.EmpleadoID})?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (confirm == DialogResult.Yes)
                        {
                            empleadoRepo.Delete(emp.EmpleadoID);
                            MessageBox.Show("Empleado eliminado correctamente.");
                            CargarEmpleados();
                            LimpiarCampos();
                            CambiarModo("mostrar");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe un empleado con ese ID.");
                        LimpiarCampos();
                        btnGuardar.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un ID válido.");
                    LimpiarCampos();
                    btnGuardar.Enabled = false;
                }
            }
            else if (e.KeyCode == Keys.Enter && modo == "actualizar")
            {
                int id;
                if (int.TryParse(txtEmpleadoID.Text, out id))
                {
                    var emp = empleadoRepo.GetAll().Find(x => x.EmpleadoID == id);
                    if (emp != null)
                    {
                        empleadoSeleccionadoId = emp.EmpleadoID;
                        txtNombre.Text = emp.Nombre;
                        cbDepartamento.SelectedValue = emp.DepartamentoID;
                        cbCargo.SelectedValue = emp.CargoID;
                        dtpFechaInicio.Value = emp.FechaInicio;
                        txtSalario.Text = emp.Salario.ToString();
                        cbEstado.SelectedItem = emp.Estado;
                        btnGuardar.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("No existe un empleado con ese ID.");
                        LimpiarCampos();
                        btnGuardar.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un ID válido.");
                    LimpiarCampos();
                    btnGuardar.Enabled = false;
                }
            }
        }

        private void DgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            if ((modo == "actualizar" || modo == "eliminar") && dgvEmpleados.CurrentRow != null && dgvEmpleados.CurrentRow.DataBoundItem != null)
            {
                // Asegura que los combos estén cargados antes de asignar valores
                CargarCombos();
                dynamic emp = dgvEmpleados.CurrentRow.DataBoundItem;
                empleadoSeleccionadoId = emp.EmpleadoID;
                txtNombre.Text = emp.Nombre;
                cbDepartamento.SelectedValue = emp.DepartamentoID;
                cbCargo.SelectedValue = emp.CargoID;
                dtpFechaInicio.Value = emp.FechaInicio;
                txtSalario.Text = emp.Salario.ToString();
                // Estado: busca el índice correcto (por si el texto no coincide exactamente)
                int idxEstado = 0;
                for (int i = 0; i < cbEstado.Items.Count; i++)
                {
                    if (cbEstado.Items[i].ToString().Equals(emp.Estado.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        idxEstado = i;
                        break;
                    }
                }
                cbEstado.SelectedIndex = idxEstado;
                btnGuardar.Enabled = true;
            }
        }

        private void GuardarEmpleado()
        {
            try
            {
                if (modo == "agregar")
                {
                    if (!ValidarCampos()) return;
                    var empleado = new Empleado
                    {
                        Nombre = txtNombre.Text.Trim(),
                        DepartamentoID = (int)cbDepartamento.SelectedValue,
                        CargoID = (int)cbCargo.SelectedValue,
                        FechaInicio = dtpFechaInicio.Value.Date,
                        Salario = decimal.Parse(txtSalario.Text),
                        Estado = cbEstado.SelectedItem.ToString()
                    };
                    empleadoRepo.Add(empleado);
                    MessageBox.Show("Empleado agregado correctamente.");
                }
                else if (modo == "actualizar")
                {
                    if (empleadoSeleccionadoId == null) { MessageBox.Show("Seleccione un empleado para actualizar."); return; }
                    if (!ValidarCampos()) return;
                    var empleado = empleadoRepo.GetAll().Find(emp => emp.EmpleadoID == empleadoSeleccionadoId);
                    if (empleado == null) { MessageBox.Show("Empleado no encontrado."); return; }
                    empleado.Nombre = txtNombre.Text.Trim();
                    empleado.DepartamentoID = (int)cbDepartamento.SelectedValue;
                    empleado.CargoID = (int)cbCargo.SelectedValue;
                    empleado.FechaInicio = dtpFechaInicio.Value.Date;
                    empleado.Salario = decimal.Parse(txtSalario.Text);
                    empleado.Estado = cbEstado.SelectedItem.ToString();
                    empleadoRepo.Update(empleado);
                    MessageBox.Show("Empleado actualizado correctamente.");
                }
                else if (modo == "eliminar")
                {
                    if (empleadoSeleccionadoId == null) { MessageBox.Show("Seleccione un empleado para eliminar."); return; }
                    empleadoRepo.Delete(empleadoSeleccionadoId.Value);
                    MessageBox.Show("Empleado eliminado correctamente.");
                }
                CargarEmpleados();
                LimpiarCampos();
                CambiarModo("mostrar");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CargarCombos()
        {
            // Solo asignar si los controles existen y están visibles
            if (cbDepartamento != null)
            {
                cbDepartamento.DataSource = departamentoRepo.GetAll();
                cbDepartamento.DisplayMember = "Nombre";
                cbDepartamento.ValueMember = "DepartamentoID";
            }
            if (cbCargo != null)
            {
                cbCargo.DataSource = cargoRepo.GetAll();
                cbCargo.DisplayMember = "Nombre";
                cbCargo.ValueMember = "CargoID";
            }
        }

        private void CargarEmpleados()
        {
            try
            {
                // Asignar directamente la lista de empleados al DataGridView
                dgvEmpleados.DataSource = null;
                dgvEmpleados.DataSource = empleadoRepo.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarEmpleados()
        {
            try
            {
                var empleados = empleadoRepo.GetAll();
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", FileName = "Empleados_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                        {
                            sw.WriteLine("EmpleadoID,Nombre,DepartamentoID,CargoID,FechaInicio,Salario,Estado,TiempoEnEmpresa,AFP,ARS,ISR");
                            foreach (var emp in empleados)
                            {
                                sw.WriteLine($"{emp.EmpleadoID},{emp.Nombre},{emp.DepartamentoID},{emp.CargoID},{emp.FechaInicio:yyyy-MM-dd},{emp.Salario},{emp.Estado},{emp.TiempoEnEmpresa},{emp.AFP},{emp.ARS},{emp.ISR}");
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

        private void AgregarCargosYDepartamentosPorDefecto()
        {
            var cargosDefecto = new[] { "Gerente", "Analista", "Desarrollador", "Soporte", "Recursos Humanos" };
            foreach (var nombre in cargosDefecto)
            {
                if (!cargoRepo.GetAll().Exists(c => c.Nombre == nombre))
                {
                    cargoRepo.Add(new Cargo { Nombre = nombre });
                }
            }
            var departamentosDefecto = new[] { "Administración", "Finanzas", "TI", "Recursos Humanos", "Operaciones" };
            foreach (var nombre in departamentosDefecto)
            {
                if (!departamentoRepo.GetAll().Exists(d => d.Nombre == nombre))
                {
                    departamentoRepo.Add(new Departamento { Nombre = nombre });
                }
            }
        }

        private void LimpiarCampos()
        {
            if (txtNombre != null) txtNombre.Clear();
            if (cbDepartamento != null) cbDepartamento.SelectedIndex = -1;
            if (cbCargo != null) cbCargo.SelectedIndex = -1;
            if (dtpFechaInicio != null) dtpFechaInicio.Value = DateTime.Now;
            if (txtSalario != null) txtSalario.Clear();
            // No limpiar los ítems, solo la selección
            if (cbEstado != null && cbEstado.Items.Count > 0) cbEstado.SelectedIndex = 0;
            empleadoSeleccionadoId = null;
        }

        private bool ValidarCampos()
        {
            bool valido = true;
            string errores = "";
            // Limpiar errores
            lblErrorNombre.Visible = lblErrorDepartamento.Visible = lblErrorCargo.Visible = lblErrorSalario.Visible = lblErrorEstado.Visible = false;
            // Nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                lblErrorNombre.Text = "El nombre es obligatorio.";
                lblErrorNombre.Visible = true;
                errores += "- El nombre es obligatorio.\n";
                valido = false;
            }
            else if (!Regex.IsMatch(txtNombre.Text, "^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ ]+$"))
            {
                lblErrorNombre.Text = "Solo letras y espacios.";
                lblErrorNombre.Visible = true;
                errores += "- El nombre solo puede contener letras y espacios.\n";
                valido = false;
            }
            else
            {
                // Validar nombre duplicado
                var nombreNormalizado = txtNombre.Text.Trim().ToLowerInvariant();
                var empleados = empleadoRepo.GetAll();
                bool existeNombre = false;
                if (modo == "agregar")
                    existeNombre = empleados.Exists(e => e.Nombre.Trim().ToLowerInvariant() == nombreNormalizado);
                else if (modo == "actualizar")
                    existeNombre = empleados.Exists(e => e.Nombre.Trim().ToLowerInvariant() == nombreNormalizado && e.EmpleadoID != empleadoSeleccionadoId);
                if (existeNombre)
                {
                    lblErrorNombre.Text = "Ya existe un empleado con ese nombre.";
                    lblErrorNombre.Visible = true;
                    errores += "- Ya existe un empleado con ese nombre.\n";
                    valido = false;
                }
            }
            // Departamento
            if (cbDepartamento.SelectedValue == null)
            {
                lblErrorDepartamento.Text = "Seleccione un departamento.";
                lblErrorDepartamento.Visible = true;
                errores += "- Seleccione un departamento.\n";
                valido = false;
            }
            // Cargo
            if (cbCargo.SelectedValue == null)
            {
                lblErrorCargo.Text = "Seleccione un cargo.";
                lblErrorCargo.Visible = true;
                errores += "- Seleccione un cargo.\n";
                valido = false;
            }
            // Salario
            if (string.IsNullOrWhiteSpace(txtSalario.Text))
            {
                lblErrorSalario.Text = "El salario es obligatorio.";
                lblErrorSalario.Visible = true;
                errores += "- El salario es obligatorio.\n";
                valido = false;
            }
            else if (!decimal.TryParse(txtSalario.Text, out decimal salario) || salario <= 0)
            {
                lblErrorSalario.Text = "Ingrese un número válido (>0).";
                lblErrorSalario.Visible = true;
                errores += "- Ingrese un salario válido mayor a 0.\n";
                valido = false;
            }
            // Estado
            if (cbEstado.SelectedIndex <= 0)
            {
                lblErrorEstado.Text = "Seleccione un estado.";
                lblErrorEstado.Visible = true;
                errores += "- Seleccione un estado.\n";
                valido = false;
            }
            if (!valido && !string.IsNullOrEmpty(errores))
            {
                MessageBox.Show("Corrija los siguientes errores:\n\n" + errores, "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return valido;
        }

        // Helper para bordes redondeados en botones
        private static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
            public static extern IntPtr CreateRoundRectRgn(
                int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        }

        // Custom renderer para menú visual
        private class CustomMenuColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.FromArgb(120, 60, 120);
            public override Color MenuItemBorder => Color.Transparent;
            public override Color MenuItemSelectedGradientBegin => Color.FromArgb(120, 60, 120);
            public override Color MenuItemSelectedGradientEnd => Color.FromArgb(120, 60, 120);
            public override Color MenuBorder => Color.FromArgb(80, 0, 80);
            public override Color ToolStripDropDownBackground => Color.FromArgb(80, 0, 80);
            public override Color ImageMarginGradientBegin => Color.FromArgb(80, 0, 80);
            public override Color ImageMarginGradientMiddle => Color.FromArgb(80, 0, 80);
            public override Color ImageMarginGradientEnd => Color.FromArgb(80, 0, 80);
        }
    }
}