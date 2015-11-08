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
            this.label3 = new System.Windows.Forms.Label();
            this.lbPrecio = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(562, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gracias por elegirnos";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(117, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(464, 46);
            this.label2.TabIndex = 1;
            this.label2.Text = "Su código de compra es:";
            // 
            // lbCompraRef
            // 
            this.lbCompraRef.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCompraRef.AutoSize = true;
            this.lbCompraRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCompraRef.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbCompraRef.Location = new System.Drawing.Point(225, 332);
            this.lbCompraRef.Name = "lbCompraRef";
            this.lbCompraRef.Size = new System.Drawing.Size(236, 46);
            this.lbCompraRef.TabIndex = 2;
            this.lbCompraRef.Text = "XXXXXXXX";
            this.lbCompraRef.Click += new System.EventHandler(this.lbCompraRef_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(195, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 46);
            this.label3.TabIndex = 1;
            this.label3.Text = "Total a abonar:";
            // 
            // lbPrecio
            // 
            this.lbPrecio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbPrecio.AutoSize = true;
            this.lbPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrecio.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbPrecio.Location = new System.Drawing.Point(224, 182);
            this.lbPrecio.Name = "lbPrecio";
            this.lbPrecio.Size = new System.Drawing.Size(236, 46);
            this.lbPrecio.TabIndex = 2;
            this.lbPrecio.Text = "XXXXXXXX";
            this.lbPrecio.Click += new System.EventHandler(this.lbCompraRef_Click);
            // 
            // CompraFormFinal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 460);
            this.Controls.Add(this.lbPrecio);
            this.Controls.Add(this.lbCompraRef);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CompraFormFinal";
            this.Text = "CompraFormFinal";
            this.Load += new System.EventHandler(this.CompraFormFinal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbCompraRef;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbPrecio;
    }
}