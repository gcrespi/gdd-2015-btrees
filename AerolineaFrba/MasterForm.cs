using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba
{
    public partial class MasterForm : Form
    {
        public MasterForm()
        {
            InitializeComponent();
            menu.Renderer = new MyRenderer();
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }

        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.DeepSkyBlue; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.DeepSkyBlue; }
            }
            public override Color MenuItemPressedGradientBegin
            {
                get { return Color.SkyBlue; }
            }
            public override Color MenuItemPressedGradientEnd
            {
                get { return Color.SkyBlue; }
            }

        }


     


    }
}
