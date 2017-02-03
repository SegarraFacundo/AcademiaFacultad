namespace UI.Desktop
{
    partial class MainMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permisosDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDocentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAlumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instituciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.especialidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comisionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inscripcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.docentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.instituciónToolStripMenuItem,
            this.inscripcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(289, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsuariosToolStripMenuItem,
            this.menuDocentesToolStripMenuItem,
            this.menuAlumnosToolStripMenuItem});
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // menuUsuariosToolStripMenuItem
            // 
            this.menuUsuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.permisosDeUsuariosToolStripMenuItem});
            this.menuUsuariosToolStripMenuItem.Name = "menuUsuariosToolStripMenuItem";
            this.menuUsuariosToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.menuUsuariosToolStripMenuItem.Text = "Menu Usuarios";
            this.menuUsuariosToolStripMenuItem.Click += new System.EventHandler(this.menuUsuariosToolStripMenuItem_Click);
            // 
            // permisosDeUsuariosToolStripMenuItem
            // 
            this.permisosDeUsuariosToolStripMenuItem.Name = "permisosDeUsuariosToolStripMenuItem";
            this.permisosDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.permisosDeUsuariosToolStripMenuItem.Text = "Permisos de Usuarios";
            // 
            // menuDocentesToolStripMenuItem
            // 
            this.menuDocentesToolStripMenuItem.Name = "menuDocentesToolStripMenuItem";
            this.menuDocentesToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.menuDocentesToolStripMenuItem.Text = "Menu Docentes";
            this.menuDocentesToolStripMenuItem.Click += new System.EventHandler(this.menuDocentesToolStripMenuItem_Click);
            // 
            // menuAlumnosToolStripMenuItem
            // 
            this.menuAlumnosToolStripMenuItem.Name = "menuAlumnosToolStripMenuItem";
            this.menuAlumnosToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.menuAlumnosToolStripMenuItem.Text = "Menu Alumnos";
            this.menuAlumnosToolStripMenuItem.Click += new System.EventHandler(this.menuAlumnosToolStripMenuItem_Click_1);
            // 
            // instituciónToolStripMenuItem
            // 
            this.instituciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planesToolStripMenuItem,
            this.especialidadesToolStripMenuItem,
            this.comisionesToolStripMenuItem,
            this.cursosToolStripMenuItem,
            this.materiasToolStripMenuItem});
            this.instituciónToolStripMenuItem.Name = "instituciónToolStripMenuItem";
            this.instituciónToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.instituciónToolStripMenuItem.Text = "Institución";
            // 
            // planesToolStripMenuItem
            // 
            this.planesToolStripMenuItem.Name = "planesToolStripMenuItem";
            this.planesToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.planesToolStripMenuItem.Text = "Planes";
            // 
            // especialidadesToolStripMenuItem
            // 
            this.especialidadesToolStripMenuItem.Name = "especialidadesToolStripMenuItem";
            this.especialidadesToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.especialidadesToolStripMenuItem.Text = "Especialidades";
            // 
            // comisionesToolStripMenuItem
            // 
            this.comisionesToolStripMenuItem.Name = "comisionesToolStripMenuItem";
            this.comisionesToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.comisionesToolStripMenuItem.Text = "Comisiones";
            // 
            // cursosToolStripMenuItem
            // 
            this.cursosToolStripMenuItem.Name = "cursosToolStripMenuItem";
            this.cursosToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.cursosToolStripMenuItem.Text = "Cursos";
            // 
            // materiasToolStripMenuItem
            // 
            this.materiasToolStripMenuItem.Name = "materiasToolStripMenuItem";
            this.materiasToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.materiasToolStripMenuItem.Text = "Materias";
            // 
            // inscripcionesToolStripMenuItem
            // 
            this.inscripcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.docentesToolStripMenuItem,
            this.alumnosToolStripMenuItem});
            this.inscripcionesToolStripMenuItem.Name = "inscripcionesToolStripMenuItem";
            this.inscripcionesToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.inscripcionesToolStripMenuItem.Text = "Inscripciones";
            // 
            // docentesToolStripMenuItem
            // 
            this.docentesToolStripMenuItem.Name = "docentesToolStripMenuItem";
            this.docentesToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.docentesToolStripMenuItem.Text = "Docentes";
            // 
            // alumnosToolStripMenuItem
            // 
            this.alumnosToolStripMenuItem.Name = "alumnosToolStripMenuItem";
            this.alumnosToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.alumnosToolStripMenuItem.Text = "Alumnos";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 219);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Menu Principal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permisosDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuDocentesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAlumnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instituciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem especialidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comisionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materiasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inscripcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem docentesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alumnosToolStripMenuItem;

    }
}