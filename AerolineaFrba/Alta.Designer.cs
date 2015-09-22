namespace AerolineaFrba
{
    partial class Alta
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
            System.Windows.Forms.ListBox listBox1;
            this.bGuardar = new System.Windows.Forms.Button();
            this.bLimpiar = new System.Windows.Forms.Button();
            this.lCampo1 = new System.Windows.Forms.Label();
            this.lCampo2 = new System.Windows.Forms.Label();
            this.lCampo3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 24;
            listBox1.Items.AddRange(new object[] {
            "Blah",
            "Bleh",
            "Blih"});
            listBox1.Location = new System.Drawing.Point(334, 121);
            listBox1.Name = "listBox1";
            listBox1.Size = new System.Drawing.Size(312, 28);
            listBox1.TabIndex = 6;
            listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // bGuardar
            // 
            this.bGuardar.BackColor = System.Drawing.Color.Silver;
            this.bGuardar.FlatAppearance.BorderSize = 0;
            this.bGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bGuardar.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGuardar.Location = new System.Drawing.Point(740, 404);
            this.bGuardar.Name = "bGuardar";
            this.bGuardar.Size = new System.Drawing.Size(107, 56);
            this.bGuardar.TabIndex = 3;
            this.bGuardar.Text = "Guardar";
            this.bGuardar.UseVisualStyleBackColor = false;
            // 
            // bLimpiar
            // 
            this.bLimpiar.BackColor = System.Drawing.Color.Silver;
            this.bLimpiar.FlatAppearance.BorderSize = 0;
            this.bLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLimpiar.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLimpiar.Location = new System.Drawing.Point(155, 404);
            this.bLimpiar.Name = "bLimpiar";
            this.bLimpiar.Size = new System.Drawing.Size(107, 56);
            this.bLimpiar.TabIndex = 3;
            this.bLimpiar.Text = "Limpiar";
            this.bLimpiar.UseVisualStyleBackColor = false;
            // 
            // lCampo1
            // 
            this.lCampo1.AutoSize = true;
            this.lCampo1.Font = new System.Drawing.Font("Calibri Light", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCampo1.Location = new System.Drawing.Point(186, 53);
            this.lCampo1.Name = "lCampo1";
            this.lCampo1.Size = new System.Drawing.Size(140, 41);
            this.lCampo1.TabIndex = 4;
            this.lCampo1.Text = "Campo 1";
            // 
            // lCampo2
            // 
            this.lCampo2.AutoSize = true;
            this.lCampo2.Font = new System.Drawing.Font("Calibri Light", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCampo2.Location = new System.Drawing.Point(186, 112);
            this.lCampo2.Name = "lCampo2";
            this.lCampo2.Size = new System.Drawing.Size(140, 41);
            this.lCampo2.TabIndex = 4;
            this.lCampo2.Text = "Campo 2";
            this.lCampo2.Click += new System.EventHandler(this.label1_Click);
            // 
            // lCampo3
            // 
            this.lCampo3.AutoSize = true;
            this.lCampo3.Font = new System.Drawing.Font("Calibri Light", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCampo3.Location = new System.Drawing.Point(186, 166);
            this.lCampo3.Name = "lCampo3";
            this.lCampo3.Size = new System.Drawing.Size(140, 41);
            this.lCampo3.TabIndex = 4;
            this.lCampo3.Text = "Campo 3";
            this.lCampo3.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(211, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 41);
            this.label1.TabIndex = 4;
            this.label1.Text = "Campo 4";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri Light", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(186, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 41);
            this.label2.TabIndex = 4;
            this.label2.Text = "Campo 5";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(334, 58);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(312, 32);
            this.textBox1.TabIndex = 5;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(193, 231);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(334, 272);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(312, 32);
            this.numericUpDown1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(334, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(312, 28);
            this.label3.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(664, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "Seleccionar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 486);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lCampo3);
            this.Controls.Add(this.lCampo2);
            this.Controls.Add(this.lCampo1);
            this.Controls.Add(this.bLimpiar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bGuardar);
            this.Name = "Alta";
            this.Text = "Alta";
            this.Controls.SetChildIndex(this.bGuardar, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.bLimpiar, 0);
            this.Controls.SetChildIndex(this.lCampo1, 0);
            this.Controls.SetChildIndex(this.lCampo2, 0);
            this.Controls.SetChildIndex(this.lCampo3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(listBox1, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.numericUpDown1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bGuardar;
        private System.Windows.Forms.Button bLimpiar;
        private System.Windows.Forms.Label lCampo1;
        private System.Windows.Forms.Label lCampo2;
        private System.Windows.Forms.Label lCampo3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}