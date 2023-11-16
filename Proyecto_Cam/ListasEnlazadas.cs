using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Cam
{
    public partial class ListasEnlazadas : Form
    {
        public ListasEnlazadas()
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\TeslaImagen1.jpg");
            this.BackgroundImage = img;

            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form1 ventana = new Form1();
            ventana.Show();

            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
