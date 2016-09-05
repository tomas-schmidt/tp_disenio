namespace tp_disenio_1.Comandos
{
    partial class PruebaComandos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_actualizarLocales = new System.Windows.Forms.Button();
            this.txt_actualizarLocales = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btn_bajaPoi = new System.Windows.Forms.Button();
            this.txt_bajaPoi = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_actualizarLocales);
            this.groupBox1.Controls.Add(this.txt_actualizarLocales);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actualizar Locales";
            // 
            // btn_actualizarLocales
            // 
            this.btn_actualizarLocales.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_actualizarLocales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_actualizarLocales.Location = new System.Drawing.Point(327, 21);
            this.btn_actualizarLocales.Name = "btn_actualizarLocales";
            this.btn_actualizarLocales.Size = new System.Drawing.Size(92, 55);
            this.btn_actualizarLocales.TabIndex = 1;
            this.btn_actualizarLocales.Text = "Actualizar Locales";
            this.btn_actualizarLocales.UseVisualStyleBackColor = false;
            this.btn_actualizarLocales.Click += new System.EventHandler(this.btn_actualizarLocales_Click);
            // 
            // txt_actualizarLocales
            // 
            this.txt_actualizarLocales.Location = new System.Drawing.Point(12, 39);
            this.txt_actualizarLocales.Name = "txt_actualizarLocales";
            this.txt_actualizarLocales.Size = new System.Drawing.Size(178, 26);
            this.txt_actualizarLocales.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.btn_bajaPoi);
            this.groupBox2.Controls.Add(this.txt_bajaPoi);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Baja de POI";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 68);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(304, 26);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // btn_bajaPoi
            // 
            this.btn_bajaPoi.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_bajaPoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_bajaPoi.Location = new System.Drawing.Point(327, 25);
            this.btn_bajaPoi.Name = "btn_bajaPoi";
            this.btn_bajaPoi.Size = new System.Drawing.Size(92, 55);
            this.btn_bajaPoi.TabIndex = 3;
            this.btn_bajaPoi.Text = "Baja POI";
            this.btn_bajaPoi.UseVisualStyleBackColor = false;
            this.btn_bajaPoi.Click += new System.EventHandler(this.btn_bajaPoi_Click);
            // 
            // txt_bajaPoi
            // 
            this.txt_bajaPoi.Location = new System.Drawing.Point(12, 32);
            this.txt_bajaPoi.Name = "txt_bajaPoi";
            this.txt_bajaPoi.Size = new System.Drawing.Size(233, 26);
            this.txt_bajaPoi.TabIndex = 2;
            // 
            // PruebaComandos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 260);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PruebaComandos";
            this.Text = "Comandos";
            this.Load += new System.EventHandler(this.Comandos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_actualizarLocales;
        private System.Windows.Forms.TextBox txt_actualizarLocales;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_bajaPoi;
        private System.Windows.Forms.TextBox txt_bajaPoi;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}