﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class DecisionBajaAeronaveForm : Form
    {
        public DecisionBajaAeronaveForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnReasignar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
    }
}
