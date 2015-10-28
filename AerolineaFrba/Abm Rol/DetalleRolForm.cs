﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Plantillas;

namespace AerolineaFrba.Abm_Rol
{
    public partial class DetalleRolForm : DetalleForm
    {
        public DetalleRolForm()
        {
            InitializeComponent();
        }

        public DetalleRolForm(int rolID) : this()
        {
            uctrlRolDetalle.retrieveInfoFrom(rolID);
            uctrlRolDetalle.blockAttrs();
        }
    }
}
