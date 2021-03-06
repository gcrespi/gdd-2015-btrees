﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm
{
    public interface IAbmControl
    {
        bool activo();

        void retrieveInfoFrom(DataGridViewRow selectedRow);
        
        void fillAttrsDefault();

        void limpiar_campos();

        void blockAttrs();

        void blockKeyAttrs();

        bool validateAttrs();

        bool validateAttrsModif();

        void darModif();

        void darBaja();

        string accionConcretadaMessage();

        string accionRechazadaMessage();

        void drawIn(Form aForm);

        bool validateBaja();

        void darAlta();
    }
}
