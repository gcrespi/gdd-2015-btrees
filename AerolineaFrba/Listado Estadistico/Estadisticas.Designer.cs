namespace AerolineaFrba.Listado_Estadistico
{
    partial class Estadisticas
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
            this.groupOpciones = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radio4 = new System.Windows.Forms.RadioButton();
            this.radio3 = new System.Windows.Forms.RadioButton();
            this.radio2 = new System.Windows.Forms.RadioButton();
            this.radio1 = new System.Windows.Forms.RadioButton();
            this.groupSemestre = new System.Windows.Forms.GroupBox();
            this.radioSegundo = new System.Windows.Forms.RadioButton();
            this.radioPrimero = new System.Windows.Forms.RadioButton();
            this.tdpAño = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.gridListado = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupOpciones.SuspendLayout();
            this.groupSemestre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupOpciones
            // 
            this.groupOpciones.Controls.Add(this.radioButton3);
            this.groupOpciones.Controls.Add(this.radio4);
            this.groupOpciones.Controls.Add(this.radio3);
            this.groupOpciones.Controls.Add(this.radio2);
            this.groupOpciones.Controls.Add(this.radio1);
            this.groupOpciones.Location = new System.Drawing.Point(13, 13);
            this.groupOpciones.Name = "groupOpciones";
            this.groupOpciones.Size = new System.Drawing.Size(332, 143);
            this.groupOpciones.TabIndex = 0;
            this.groupOpciones.TabStop = false;
            this.groupOpciones.Text = "Estadisticas";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(17, 112);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(292, 17);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.Tag = "5";
            this.radioButton3.Text = "Aeronaves con mayor cantidad de días fuera de servicio";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radio4
            // 
            this.radio4.AutoSize = true;
            this.radio4.Location = new System.Drawing.Point(17, 89);
            this.radio4.Name = "radio4";
            this.radio4.Size = new System.Drawing.Size(206, 17);
            this.radio4.TabIndex = 3;
            this.radio4.Tag = "4";
            this.radio4.Text = "Destinos con más pasajes cancelados";
            this.radio4.UseVisualStyleBackColor = true;
            // 
            // radio3
            // 
            this.radio3.AutoSize = true;
            this.radio3.Location = new System.Drawing.Point(17, 66);
            this.radio3.Name = "radio3";
            this.radio3.Size = new System.Drawing.Size(250, 17);
            this.radio3.TabIndex = 2;
            this.radio3.Tag = "3";
            this.radio3.Text = "Clientes con más puntos acumulados a la fecha";
            this.radio3.UseVisualStyleBackColor = true;
            // 
            // radio2
            // 
            this.radio2.AutoSize = true;
            this.radio2.Location = new System.Drawing.Point(17, 43);
            this.radio2.Name = "radio2";
            this.radio2.Size = new System.Drawing.Size(202, 17);
            this.radio2.TabIndex = 1;
            this.radio2.Tag = "2";
            this.radio2.Text = "Destinos con más Areronaves vacías";
            this.radio2.UseVisualStyleBackColor = true;
            // 
            // radio1
            // 
            this.radio1.AutoSize = true;
            this.radio1.Checked = true;
            this.radio1.Location = new System.Drawing.Point(17, 20);
            this.radio1.Name = "radio1";
            this.radio1.Size = new System.Drawing.Size(203, 17);
            this.radio1.TabIndex = 0;
            this.radio1.TabStop = true;
            this.radio1.Tag = "1";
            this.radio1.Text = "Destinos con más pasajes comprados";
            this.radio1.UseVisualStyleBackColor = true;
            // 
            // groupSemestre
            // 
            this.groupSemestre.Controls.Add(this.radioSegundo);
            this.groupSemestre.Controls.Add(this.radioPrimero);
            this.groupSemestre.Controls.Add(this.tdpAño);
            this.groupSemestre.Controls.Add(this.label2);
            this.groupSemestre.Location = new System.Drawing.Point(373, 13);
            this.groupSemestre.Name = "groupSemestre";
            this.groupSemestre.Size = new System.Drawing.Size(286, 83);
            this.groupSemestre.TabIndex = 1;
            this.groupSemestre.TabStop = false;
            this.groupSemestre.Text = "Semestre";
            // 
            // radioSegundo
            // 
            this.radioSegundo.AutoSize = true;
            this.radioSegundo.Location = new System.Drawing.Point(121, 19);
            this.radioSegundo.Name = "radioSegundo";
            this.radioSegundo.Size = new System.Drawing.Size(68, 17);
            this.radioSegundo.TabIndex = 6;
            this.radioSegundo.Text = "Segundo";
            this.radioSegundo.UseVisualStyleBackColor = true;
            // 
            // radioPrimero
            // 
            this.radioPrimero.AutoSize = true;
            this.radioPrimero.Checked = true;
            this.radioPrimero.Location = new System.Drawing.Point(24, 19);
            this.radioPrimero.Name = "radioPrimero";
            this.radioPrimero.Size = new System.Drawing.Size(60, 17);
            this.radioPrimero.TabIndex = 5;
            this.radioPrimero.TabStop = true;
            this.radioPrimero.Text = "Primero";
            this.radioPrimero.UseVisualStyleBackColor = true;
            // 
            // tdpAño
            // 
            this.tdpAño.CustomFormat = "yyyy";
            this.tdpAño.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tdpAño.Location = new System.Drawing.Point(107, 52);
            this.tdpAño.Name = "tdpAño";
            this.tdpAño.ShowUpDown = true;
            this.tdpAño.Size = new System.Drawing.Size(55, 20);
            this.tdpAño.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Año:";
            // 
            // gridListado
            // 
            this.gridListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridListado.Location = new System.Drawing.Point(13, 163);
            this.gridListado.Name = "gridListado";
            this.gridListado.Size = new System.Drawing.Size(655, 219);
            this.gridListado.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(440, 119);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // Estadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 394);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.gridListado);
            this.Controls.Add(this.groupSemestre);
            this.Controls.Add(this.groupOpciones);
            this.Name = "Estadisticas";
            this.Text = "Form1";
            this.groupOpciones.ResumeLayout(false);
            this.groupOpciones.PerformLayout();
            this.groupSemestre.ResumeLayout(false);
            this.groupSemestre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupOpciones;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radio4;
        private System.Windows.Forms.RadioButton radio3;
        private System.Windows.Forms.RadioButton radio2;
        private System.Windows.Forms.RadioButton radio1;
        private System.Windows.Forms.GroupBox groupSemestre;
        private System.Windows.Forms.DateTimePicker tdpAño;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridListado;
        private System.Windows.Forms.RadioButton radioSegundo;
        private System.Windows.Forms.RadioButton radioPrimero;
        private System.Windows.Forms.Button btnBuscar;
    }
}