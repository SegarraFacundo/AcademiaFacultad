namespace UI.Desktop
{
    partial class PersonaDesktop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblId = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.lblLegajo = new System.Windows.Forms.Label();
            this.lblTipoPersona = new System.Windows.Forms.Label();
            this.lblIdPlan = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.cbTipoPersona = new System.Windows.Forms.ComboBox();
            this.cbIdPlan = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.lblId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblApellido, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNombre, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDireccion, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblEmail, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblTelefono, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaNacimiento, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLegajo, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTipoPersona, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblIdPlan, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtApellido, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNombre, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDireccion, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtEmail, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.dtpFechaNacimiento, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTelefono, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtLegajo, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbTipoPersona, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbIdPlan, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(682, 265);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblId
            // 
            this.lblId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(3, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(164, 40);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApellido.Location = new System.Drawing.Point(3, 40);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(164, 40);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido";
            this.lblApellido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(3, 80);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(164, 40);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDireccion
            // 
            this.lblDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(3, 120);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(164, 40);
            this.lblDireccion.TabIndex = 3;
            this.lblDireccion.Text = "Dirección";
            this.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(3, 160);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(164, 40);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTelefono.Location = new System.Drawing.Point(343, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(164, 40);
            this.lblTelefono.TabIndex = 5;
            this.lblTelefono.Text = "Teléfono";
            this.lblTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(343, 40);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(164, 40);
            this.lblFechaNacimiento.TabIndex = 6;
            this.lblFechaNacimiento.Text = "Fecha de nacimiento";
            this.lblFechaNacimiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLegajo
            // 
            this.lblLegajo.AutoSize = true;
            this.lblLegajo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLegajo.Location = new System.Drawing.Point(343, 80);
            this.lblLegajo.Name = "lblLegajo";
            this.lblLegajo.Size = new System.Drawing.Size(164, 40);
            this.lblLegajo.TabIndex = 7;
            this.lblLegajo.Text = "Legajo";
            this.lblLegajo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTipoPersona
            // 
            this.lblTipoPersona.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTipoPersona.AutoSize = true;
            this.lblTipoPersona.Location = new System.Drawing.Point(343, 120);
            this.lblTipoPersona.Name = "lblTipoPersona";
            this.lblTipoPersona.Size = new System.Drawing.Size(164, 40);
            this.lblTipoPersona.TabIndex = 8;
            this.lblTipoPersona.Text = "Rol";
            this.lblTipoPersona.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIdPlan
            // 
            this.lblIdPlan.AutoSize = true;
            this.lblIdPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIdPlan.Location = new System.Drawing.Point(343, 160);
            this.lblIdPlan.Name = "lblIdPlan";
            this.lblIdPlan.Size = new System.Drawing.Size(164, 40);
            this.lblIdPlan.TabIndex = 9;
            this.lblIdPlan.Text = "Plan de estudio";
            this.lblIdPlan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(173, 3);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(164, 20);
            this.txtId.TabIndex = 10;
            // 
            // txtApellido
            // 
            this.txtApellido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtApellido.Location = new System.Drawing.Point(173, 43);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(164, 20);
            this.txtApellido.TabIndex = 11;
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(173, 83);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(164, 20);
            this.txtNombre.TabIndex = 12;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDireccion.Location = new System.Drawing.Point(173, 123);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(164, 20);
            this.txtDireccion.TabIndex = 13;
            this.txtDireccion.TextChanged += new System.EventHandler(this.txtDireccion_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Location = new System.Drawing.Point(173, 163);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(164, 20);
            this.txtEmail.TabIndex = 14;
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(513, 43);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(166, 20);
            this.dtpFechaNacimiento.TabIndex = 15;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTelefono.Location = new System.Drawing.Point(513, 3);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(166, 20);
            this.txtTelefono.TabIndex = 16;
            // 
            // txtLegajo
            // 
            this.txtLegajo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLegajo.Location = new System.Drawing.Point(513, 83);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(166, 20);
            this.txtLegajo.TabIndex = 20;
            // 
            // cbTipoPersona
            // 
            this.cbTipoPersona.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTipoPersona.FormattingEnabled = true;
            this.cbTipoPersona.Location = new System.Drawing.Point(513, 123);
            this.cbTipoPersona.Name = "cbTipoPersona";
            this.cbTipoPersona.Size = new System.Drawing.Size(166, 21);
            this.cbTipoPersona.TabIndex = 21;
            // 
            // cbIdPlan
            // 
            this.cbIdPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIdPlan.FormattingEnabled = true;
            this.cbIdPlan.Location = new System.Drawing.Point(513, 163);
            this.cbIdPlan.Name = "cbIdPlan";
            this.cbIdPlan.Size = new System.Drawing.Size(166, 21);
            this.cbIdPlan.TabIndex = 22;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(343, 223);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(164, 30);
            this.btnAceptar.TabIndex = 23;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(513, 223);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(166, 30);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // PersonaDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 265);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PersonaDesktop";
            this.Text = "PersonaDesktop";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.Label lblLegajo;
        private System.Windows.Forms.Label lblTipoPersona;
        private System.Windows.Forms.Label lblIdPlan;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.ComboBox cbTipoPersona;
        private System.Windows.Forms.ComboBox cbIdPlan;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}