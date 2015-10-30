using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm
{
    public interface IAbmControl
    {
        void retrieveInfoFrom(DataGridViewRow selectedRow);
        
        void fillAttrsDefault();

        void limpiar_campos();

        void blockAttrs();

        void blockKeyAttrs();

        bool validateAttrs();

        void darModif();

        void darBaja();

        string accionConcretadaMessage();

        string accionRechazadaMessage();

        void drawIn(Form aForm);

        bool validateBaja();

        void darAlta();
    }
}
