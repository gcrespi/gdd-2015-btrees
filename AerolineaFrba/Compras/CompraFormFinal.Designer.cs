namespace AerolineaFrba.Compras
{
    partial class CompraFormFinal
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCompraRef = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(166, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "Felicidades";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(98, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(464, 46);
            this.label2.TabIndex = 1;
            this.label2.Text = "Su código de compra es:";
            // 
            // lbCompraRef
            // 
            this.lbCompraRef.AutoSize = true;
            this.lbCompraRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCompraRef.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbCompraRef.Location = new System.Drawing.Point(264, 239);
            this.lbCompraRef.Name = "lbCompraRef";
            this.lbCompraRef.Size = new System.Drawing.Size(128, 46);
            this.lbCompraRef.TabIndex = 2;
            this.lbCompraRef.Text = "XXXX";
            // 
            // CompraFormFinal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 460);
            this.Controls.Add(this.lbCompraRef);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CompraFormFinal";
            this.Text = "CompraFormFinal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbCompraRef;
    }
}