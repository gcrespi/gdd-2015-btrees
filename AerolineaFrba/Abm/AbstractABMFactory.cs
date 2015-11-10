using AerolineaFrba.Abm_Aeronave;
using AerolineaFrba.Plantillas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm
{
    public abstract class AbstractBMDFactory
    {
        protected OpcionesABMForm opcionesForm;

        public AbstractBMDFactory(OpcionesABMForm opcionesForm)
        { 
            this.opcionesForm = opcionesForm;
        }

        public abstract Form create(DataGridViewRow selectedRow);

        public abstract String nameButtonAccess();
    }

    public class BajaFactory : AbstractBMDFactory
    {
        public BajaFactory(OpcionesABMForm opcionesForm)
            : base(opcionesForm)
        { }

        public override Form create(DataGridViewRow selectedRow)
        {
            return new BajaForm(opcionesForm.abmControl(), selectedRow);
        }

        public override String nameButtonAccess()
        {
            return "Eliminar";
        }
    }

    public class ModifFactory : AbstractBMDFactory
    {
        public ModifFactory(OpcionesABMForm opcionesForm)
            : base(opcionesForm)
        { }

        public override Form create(DataGridViewRow selectedRow)
        {
            return new ModifForm(opcionesForm.abmControl(), selectedRow);
        }

        public override String nameButtonAccess()
        {
            return "Modificar";
        }

    }

    public class DetalleFactory : AbstractBMDFactory
    {
        public DetalleFactory(OpcionesABMForm opcionesForm)
            : base(opcionesForm)
        { }


        public override Form create(DataGridViewRow selectedRow)
        {
            return new DetalleForm(opcionesForm.abmControl(), selectedRow);
        }
        
        public override String nameButtonAccess()
        {
            return "Detalles";
        }

    }

    public class FueraServicioFactory : AbstractBMDFactory
    {
        public FueraServicioFactory(OpcionesABMForm opcionesForm)
            : base(opcionesForm)
        { }

        public override Form create(DataGridViewRow selectedRow)
        {
            return new BajaServicioAeronaveForm((UctrlAeronave)opcionesForm.abmControl(), selectedRow);
        }

        public override String nameButtonAccess()
        {
            return "Fuera de Servicio";
        }

    }
}
