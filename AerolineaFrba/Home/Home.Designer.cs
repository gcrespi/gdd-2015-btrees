namespace AerolineaFrba
{
    partial class Home
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.picbox = new System.Windows.Forms.PictureBox();
            this.imagelist = new System.Windows.Forms.ImageList(this.components);
            this.slideR = new System.Windows.Forms.Button();
            this.slideL = new System.Windows.Forms.Button();
            this.leyenda = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).BeginInit();
            this.SuspendLayout();
            // 
            // picbox
            // 
            this.picbox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picbox.Image = ((System.Drawing.Image)(resources.GetObject("picbox.Image")));
            this.picbox.Location = new System.Drawing.Point(100, 0);
            this.picbox.Margin = new System.Windows.Forms.Padding(0);
            this.picbox.Name = "picbox";
            this.picbox.Padding = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.picbox.Size = new System.Drawing.Size(784, 486);
            this.picbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbox.TabIndex = 1;
            this.picbox.TabStop = false;
            // 
            // imagelist
            // 
            this.imagelist.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagelist.ImageStream")));
            this.imagelist.TransparentColor = System.Drawing.Color.Transparent;
            this.imagelist.Images.SetKeyName(0, "alMundo1.jpg");
            this.imagelist.Images.SetKeyName(1, "almundo2.jpg");
            this.imagelist.Images.SetKeyName(2, "alMundo3.jpg");
            // 
            // slideR
            // 
            this.slideR.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.slideR.BackColor = System.Drawing.Color.Silver;
            this.slideR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.slideR.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.slideR.FlatAppearance.BorderSize = 0;
            this.slideR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.slideR.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.slideR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slideR.Font = new System.Drawing.Font("NSimSun", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slideR.ForeColor = System.Drawing.SystemColors.ControlText;
            this.slideR.Location = new System.Drawing.Point(858, 185);
            this.slideR.Margin = new System.Windows.Forms.Padding(0);
            this.slideR.Name = "slideR";
            this.slideR.Size = new System.Drawing.Size(25, 95);
            this.slideR.TabIndex = 2;
            this.slideR.Text = ">";
            this.slideR.UseVisualStyleBackColor = false;
            this.slideR.Click += new System.EventHandler(this.slideR_Click);
            // 
            // slideL
            // 
            this.slideL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.slideL.BackColor = System.Drawing.Color.Silver;
            this.slideL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.slideL.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.slideL.FlatAppearance.BorderSize = 0;
            this.slideL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.slideL.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.slideL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slideL.Font = new System.Drawing.Font("NSimSun", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slideL.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.slideL.Location = new System.Drawing.Point(100, 185);
            this.slideL.Margin = new System.Windows.Forms.Padding(0);
            this.slideL.Name = "slideL";
            this.slideL.Size = new System.Drawing.Size(25, 95);
            this.slideL.TabIndex = 3;
            this.slideL.Text = "<";
            this.slideL.UseVisualStyleBackColor = false;
            this.slideL.Click += new System.EventHandler(this.slideL_Click);
            // 
            // leyenda
            // 
            this.leyenda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.leyenda.AutoSize = true;
            this.leyenda.BackColor = System.Drawing.Color.Gray;
            this.leyenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leyenda.Font = new System.Drawing.Font("Calibri Light", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leyenda.ForeColor = System.Drawing.Color.White;
            this.leyenda.Location = new System.Drawing.Point(141, 69);
            this.leyenda.Margin = new System.Windows.Forms.Padding(0);
            this.leyenda.Name = "leyenda";
            this.leyenda.Size = new System.Drawing.Size(499, 58);
            this.leyenda.TabIndex = 4;
            this.leyenda.Text = "¿A dónde quieres irte tú?";
            // 
            // login
            // 
            this.login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.login.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.login.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login.Font = new System.Drawing.Font("Calibri Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.login.Location = new System.Drawing.Point(707, 405);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(127, 38);
            this.login.TabIndex = 5;
            this.login.Text = "Login >>";
            this.login.UseVisualStyleBackColor = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(884, 486);
            this.Controls.Add(this.leyenda);
            this.Controls.Add(this.login);
            this.Controls.Add(this.slideL);
            this.Controls.Add(this.slideR);
            this.Controls.Add(this.picbox);
            this.Name = "Home";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.picbox, 0);
            this.Controls.SetChildIndex(this.slideR, 0);
            this.Controls.SetChildIndex(this.slideL, 0);
            this.Controls.SetChildIndex(this.login, 0);
            this.Controls.SetChildIndex(this.leyenda, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imagelist;
        private System.Windows.Forms.Button slideR;
        private System.Windows.Forms.Button slideL;
        private System.Windows.Forms.Label leyenda;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.PictureBox picbox;

    }
}

