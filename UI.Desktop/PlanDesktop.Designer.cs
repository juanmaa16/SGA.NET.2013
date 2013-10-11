namespace UI.Desktop
{
    partial class PlanDesktop
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
            this.tlPlanDesktop = new System.Windows.Forms.TableLayoutPanel();
            this.lblIDPlan = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblIDEspecialidad = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtIDPlan = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtIDEspecialidad = new System.Windows.Forms.TextBox();
            this.tlPlanDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlPlanDesktop
            // 
            this.tlPlanDesktop.ColumnCount = 4;
            this.tlPlanDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlPlanDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlPlanDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlPlanDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlPlanDesktop.Controls.Add(this.lblIDPlan, 0, 0);
            this.tlPlanDesktop.Controls.Add(this.lblDescripcion, 0, 1);
            this.tlPlanDesktop.Controls.Add(this.lblIDEspecialidad, 2, 1);
            this.tlPlanDesktop.Controls.Add(this.btnAceptar, 2, 2);
            this.tlPlanDesktop.Controls.Add(this.btnCancelar, 3, 2);
            this.tlPlanDesktop.Controls.Add(this.txtIDPlan, 1, 0);
            this.tlPlanDesktop.Controls.Add(this.txtDescripcion, 1, 1);
            this.tlPlanDesktop.Controls.Add(this.txtIDEspecialidad, 3, 1);
            this.tlPlanDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlPlanDesktop.Location = new System.Drawing.Point(0, 0);
            this.tlPlanDesktop.Name = "tlPlanDesktop";
            this.tlPlanDesktop.RowCount = 3;
            this.tlPlanDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlPlanDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlPlanDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlPlanDesktop.Size = new System.Drawing.Size(371, 88);
            this.tlPlanDesktop.TabIndex = 0;
            this.tlPlanDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.tlPlanDesktop_Paint);
            // 
            // lblIDPlan
            // 
            this.lblIDPlan.AutoSize = true;
            this.lblIDPlan.Location = new System.Drawing.Point(3, 0);
            this.lblIDPlan.Name = "lblIDPlan";
            this.lblIDPlan.Size = new System.Drawing.Size(42, 13);
            this.lblIDPlan.TabIndex = 0;
            this.lblIDPlan.Text = "ID Plan";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(3, 26);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblIDEspecialidad
            // 
            this.lblIDEspecialidad.AutoSize = true;
            this.lblIDEspecialidad.Location = new System.Drawing.Point(178, 26);
            this.lblIDEspecialidad.Name = "lblIDEspecialidad";
            this.lblIDEspecialidad.Size = new System.Drawing.Size(81, 13);
            this.lblIDEspecialidad.TabIndex = 2;
            this.lblIDEspecialidad.Text = "ID Especialidad";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(178, 55);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(265, 55);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtIDPlan
            // 
            this.txtIDPlan.Location = new System.Drawing.Point(72, 3);
            this.txtIDPlan.Name = "txtIDPlan";
            this.txtIDPlan.ReadOnly = true;
            this.txtIDPlan.Size = new System.Drawing.Size(100, 20);
            this.txtIDPlan.TabIndex = 5;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(72, 29);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(100, 20);
            this.txtDescripcion.TabIndex = 6;
            // 
            // txtIDEspecialidad
            // 
            this.txtIDEspecialidad.Location = new System.Drawing.Point(265, 29);
            this.txtIDEspecialidad.Name = "txtIDEspecialidad";
            this.txtIDEspecialidad.Size = new System.Drawing.Size(100, 20);
            this.txtIDEspecialidad.TabIndex = 7;
            // 
            // PlanDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 88);
            this.Controls.Add(this.tlPlanDesktop);
            this.Name = "PlanDesktop";
            this.Text = "PlanDesktop";
            this.Load += new System.EventHandler(this.PlanDesktop_Load);
            this.tlPlanDesktop.ResumeLayout(false);
            this.tlPlanDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlPlanDesktop;
        private System.Windows.Forms.Label lblIDPlan;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblIDEspecialidad;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtIDPlan;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtIDEspecialidad;
    }
}