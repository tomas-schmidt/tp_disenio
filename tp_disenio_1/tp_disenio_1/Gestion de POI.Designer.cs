namespace tp_disenio_1
{
    partial class frm_gestion_poi
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
            this.tex_direccion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tex_longitud = new System.Windows.Forms.TextBox();
            this.tex_latitud = new System.Windows.Forms.TextBox();
            this.tex_nombre = new System.Windows.Forms.TextBox();
            this.but_Eliminar = new System.Windows.Forms.Button();
            this.but_Modificar = new System.Windows.Forms.Button();
            this.but_Agregar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.but_Buscar = new System.Windows.Forms.Button();
            this.rb_banco = new System.Windows.Forms.RadioButton();
            this.rb_cgp = new System.Windows.Forms.RadioButton();
            this.rb_local = new System.Windows.Forms.RadioButton();
            this.rb_parada = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // tex_direccion
            // 
            this.tex_direccion.Location = new System.Drawing.Point(77, 198);
            this.tex_direccion.Name = "tex_direccion";
            this.tex_direccion.Size = new System.Drawing.Size(209, 20);
            this.tex_direccion.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Direccion";
            // 
            // tex_longitud
            // 
            this.tex_longitud.Location = new System.Drawing.Point(77, 161);
            this.tex_longitud.Name = "tex_longitud";
            this.tex_longitud.Size = new System.Drawing.Size(107, 20);
            this.tex_longitud.TabIndex = 29;
            // 
            // tex_latitud
            // 
            this.tex_latitud.Location = new System.Drawing.Point(79, 126);
            this.tex_latitud.Name = "tex_latitud";
            this.tex_latitud.Size = new System.Drawing.Size(105, 20);
            this.tex_latitud.TabIndex = 28;
            // 
            // tex_nombre
            // 
            this.tex_nombre.Location = new System.Drawing.Point(79, 88);
            this.tex_nombre.Name = "tex_nombre";
            this.tex_nombre.Size = new System.Drawing.Size(158, 20);
            this.tex_nombre.TabIndex = 27;
            // 
            // but_Eliminar
            // 
            this.but_Eliminar.Location = new System.Drawing.Point(243, 306);
            this.but_Eliminar.Name = "but_Eliminar";
            this.but_Eliminar.Size = new System.Drawing.Size(75, 23);
            this.but_Eliminar.TabIndex = 26;
            this.but_Eliminar.Text = "Eliminar";
            this.but_Eliminar.UseVisualStyleBackColor = true;
            this.but_Eliminar.Click += new System.EventHandler(this.but_Eliminar_Click);
            // 
            // but_Modificar
            // 
            this.but_Modificar.Location = new System.Drawing.Point(123, 306);
            this.but_Modificar.Name = "but_Modificar";
            this.but_Modificar.Size = new System.Drawing.Size(75, 23);
            this.but_Modificar.TabIndex = 25;
            this.but_Modificar.Text = "Modificar";
            this.but_Modificar.UseVisualStyleBackColor = true;
            this.but_Modificar.Click += new System.EventHandler(this.but_Modificar_Click);
            // 
            // but_Agregar
            // 
            this.but_Agregar.Location = new System.Drawing.Point(4, 306);
            this.but_Agregar.Name = "but_Agregar";
            this.but_Agregar.Size = new System.Drawing.Size(75, 23);
            this.but_Agregar.TabIndex = 24;
            this.but_Agregar.Text = "Agregar";
            this.but_Agregar.UseVisualStyleBackColor = true;
            this.but_Agregar.Click += new System.EventHandler(this.but_Agregar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Longitud";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Latitud";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Nombre";
            // 
            // but_Buscar
            // 
            this.but_Buscar.Location = new System.Drawing.Point(243, 88);
            this.but_Buscar.Name = "but_Buscar";
            this.but_Buscar.Size = new System.Drawing.Size(75, 29);
            this.but_Buscar.TabIndex = 20;
            this.but_Buscar.Text = "Buscar";
            this.but_Buscar.UseVisualStyleBackColor = true;
            this.but_Buscar.Click += new System.EventHandler(this.but_Buscar_Click);
            // 
            // rb_banco
            // 
            this.rb_banco.AutoSize = true;
            this.rb_banco.Location = new System.Drawing.Point(14, 22);
            this.rb_banco.Name = "rb_banco";
            this.rb_banco.Size = new System.Drawing.Size(56, 17);
            this.rb_banco.TabIndex = 34;
            this.rb_banco.TabStop = true;
            this.rb_banco.Text = "Banco";
            this.rb_banco.UseVisualStyleBackColor = true;
            // 
            // rb_cgp
            // 
            this.rb_cgp.AutoSize = true;
            this.rb_cgp.Location = new System.Drawing.Point(106, 22);
            this.rb_cgp.Name = "rb_cgp";
            this.rb_cgp.Size = new System.Drawing.Size(47, 17);
            this.rb_cgp.TabIndex = 35;
            this.rb_cgp.TabStop = true;
            this.rb_cgp.Text = "CGP";
            this.rb_cgp.UseVisualStyleBackColor = true;
            // 
            // rb_local
            // 
            this.rb_local.AutoSize = true;
            this.rb_local.Location = new System.Drawing.Point(197, 22);
            this.rb_local.Name = "rb_local";
            this.rb_local.Size = new System.Drawing.Size(51, 17);
            this.rb_local.TabIndex = 36;
            this.rb_local.TabStop = true;
            this.rb_local.Text = "Local";
            this.rb_local.UseVisualStyleBackColor = true;
            // 
            // rb_parada
            // 
            this.rb_parada.AutoSize = true;
            this.rb_parada.Location = new System.Drawing.Point(288, 22);
            this.rb_parada.Name = "rb_parada";
            this.rb_parada.Size = new System.Drawing.Size(59, 17);
            this.rb_parada.TabIndex = 37;
            this.rb_parada.TabStop = true;
            this.rb_parada.Text = "Parada";
            this.rb_parada.UseVisualStyleBackColor = true;
            // 
            // frm_gestion_poi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 398);
            this.Controls.Add(this.rb_parada);
            this.Controls.Add(this.rb_local);
            this.Controls.Add(this.rb_cgp);
            this.Controls.Add(this.rb_banco);
            this.Controls.Add(this.tex_direccion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tex_longitud);
            this.Controls.Add(this.tex_latitud);
            this.Controls.Add(this.tex_nombre);
            this.Controls.Add(this.but_Eliminar);
            this.Controls.Add(this.but_Modificar);
            this.Controls.Add(this.but_Agregar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.but_Buscar);
            this.Name = "frm_gestion_poi";
            this.Text = "POI";
            this.Load += new System.EventHandler(this.frm_gestion_poi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tex_direccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tex_longitud;
        private System.Windows.Forms.TextBox tex_latitud;
        private System.Windows.Forms.TextBox tex_nombre;
        private System.Windows.Forms.Button but_Eliminar;
        private System.Windows.Forms.Button but_Modificar;
        private System.Windows.Forms.Button but_Agregar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button but_Buscar;
        private System.Windows.Forms.RadioButton rb_banco;
        private System.Windows.Forms.RadioButton rb_cgp;
        private System.Windows.Forms.RadioButton rb_local;
        private System.Windows.Forms.RadioButton rb_parada;
    }
}