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
    public partial class Home : Form
    {
        int imageIndex = 0;

        public Home
()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            picbox.Location = new Point(97,0);
            leyenda.Parent = picbox;
            leyenda.BackColor = Color.Transparent;
        }

        private void slideR_Click(object sender, EventArgs e)
        {
            if (imageIndex < imagelist.Images.Count-1)
            {
                imageIndex++;
            }
            else
            {
                imageIndex = 0;
            }
            picbox.Image = imagelist.Images[imageIndex];
        }

        private void slideL_Click(object sender, EventArgs e)
        {
            if (imageIndex > 0)
            {
                imageIndex--;
            }
            else
            {
                imageIndex = imagelist.Images.Count-1;
            }
            picbox.Image = imagelist.Images[imageIndex];
        }


 



    }
}
