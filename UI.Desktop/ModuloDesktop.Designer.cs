namespace UI.Desktop
{
    partial class ModuloDesktop
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
            this.tlModuloDesktop = new System.Windows.Forms.TableLayoutPanel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblIDModulo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblEjecuta = new System.Windows.Forms.Label();
            this.txtIDModulo = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtEjecuta = new System.Windows.Forms.TextBox();
            this.tlModuloDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlModuloDesktop
            // 
            this.tlModuloDesktop.ColumnCount = 4;
            this.tlModuloDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlModuloDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlModuloDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlModuloDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlModuloDesktop.Controls.Add(this.btnAceptar, 2, 2);
            this.tlModuloDesktop.Controls.Add(this.btnCancelar, 3, 2);
            this.tlModuloDesktop.Controls.Add(this.lblIDModulo, 0, 0);
            this.tlModuloDesktop.Controls.Add(this.lblDescripcion, 0, 1);
            this.tlModuloDesktop.Controls.Add(this.lblEjecuta, 2, 1);
            this.tlModuloDesktop.Controls.Add(this.txtIDModulo, 1, 0);
            this.tlModuloDesktop.Controls.Add(this.txtDescripcion, 1, 1);
            this.tlModuloDesktop.Controls.Add(this.txtEjecuta, 3, 1);
            this.tlModuloDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlModuloDesktop.Location = new System.Drawing.Point(0, 0);
            this.tlModuloDesktop.Name = "tlModuloDesktop";
            this.tlModuloDesktop.RowCount = 3;
            this.tlModuloDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlModuloDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlModuloDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlModuloDesktop.Size = new System.Drawing.Size(354, 83);
            this.tlModuloDesktop.TabIndex = 0;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(178, 55);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(259, 55);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblIDModulo
            // 
            this.lblIDModulo.AutoSize = true;
            this.lblIDModulo.Location = new System.Drawing.Point(3, 0);
            this.lblIDModulo.Name = "lblIDModulo";
            this.lblIDModulo.Size = new System.Drawing.Size(56, 13);
            this.lblIDModulo.TabIndex = 2;
            this.lblIDModulo.Text = "ID Modulo";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(3, 26);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 3;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblEjecuta
            // 
            this.lblEjecuta.AutoSize = true;
            this.lblEjecuta.Location = new System.Drawing.Point(178, 26);
            this.lblEjecuta.Name = "lblEjecuta";
            this.lblEjecuta.Size = new System.Drawing.Size(43, 13);
            this.lblEjecuta.TabIndex = 4;
            this.lblEjecuta.Text = "Ejecuta";
            // 
            // txtIDModulo
            // 
            this.txtIDModulo.Location = new System.Drawing.Point(72, 3);
            this.txtIDModulo.Name = "txtIDModulo";
            this.txtIDModulo.ReadOnly = true;
            this.txtIDModulo.Size = new System.Drawing.Size(100, 20);
            this.txtIDModulo.TabIndex = 5;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(72, 29);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(100, 20);
            this.txtDescripcion.TabIndex = 6;
            // 
            // txtEjecuta
            // 
            this.txtEjecuta.Location = new System.Drawing.Point(259, 29);
            this.txtEjecuta.Name = "txtEjecuta";
            this.txtEjecuta.Size = new System.Drawing.Size(100, 20);
            this.txtEjecuta.TabIndex = 7;
            // 
            // ModuloDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 83);
            this.Controls.Add(this.tlModuloDesktop);
            this.Name = "ModuloDesktop";
            this.Text = "ModuloDesktop";
            this.tlModuloDesktop.ResumeLayout(false);
            this.tlModuloDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlModuloDesktop;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblIDModulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblEjecuta;
        private System.Windows.Forms.TextBox txtIDModulo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtEjecuta;

    }
}