using Proyecto_Cam.Dato;
using Proyecto_Cam.Modelo;
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
    public partial class Matrices : Form
    {
        private int Id;
        private DataTable tabla;
        VehiculoAdmin admin = new VehiculoAdmin();
        vehiculo vehiculo = new vehiculo();

        private void Inicicializar()
        {
            tabla = new DataTable();
            tabla.Columns.Add("Id");
            tabla.Columns.Add("Modelo");
            tabla.Columns.Add("Marca");
            tabla.Columns.Add("Año");
            tabla.Columns.Add("Combustible");
            dgVehiculo.DataSource = tabla;
        }
        public Matrices()
        {
            InitializeComponent();

            Inicicializar();
            
            Consultar();
        }

        private void Consultar()
        {
            Inicicializar();
            List<vehiculo> lista = admin.Mostrar();
            foreach (var item in lista)
            {
                DataRow row = tabla.NewRow();
                row["Id"] = item.Id;
                row["Modelo"] = item.modelo;
                row["Marca"] = item.marca;
                row["Año"] = item.yeart;
                row["Combustible"] = item.combustible;
                tabla.Rows.Add(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 ventana = new Form1();
            ventana.Show();

            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Matrices_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

       

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void limpiar()
        {
            Id = 0;
            txtModelo.Focus();
            txtModelo.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtyear.Text = string.Empty;
            txtCombustible.Text = string.Empty;
            Consultar();

        }

        private void Agregar()
        {
            vehiculo.Id = Id;
            vehiculo.modelo = txtModelo.Text;
            vehiculo.marca = txtMarca.Text;
            vehiculo.yeart = txtyear.Text;
            vehiculo.combustible = txtCombustible.Text;
        }
        private void clickAgregar(object sender, EventArgs e)
        {
            Agregar();
            admin.Agregar(vehiculo);
            limpiar();
            
        }

        private void dgVehiculo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //error
        }

        //boton eliminar
        private void clickEditar(object sender, EventArgs e)
        {
            if(Id > 0)
            {
                Agregar();//vincula los textboxs con su respectivo dato en el objeto vehiculo
                admin.Editar(vehiculo);
                limpiar();
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        private void seleccionar(object sender, EventArgs e)
        {
            Id = Convert.ToInt32(dgVehiculo.CurrentRow.Cells["Id"].Value.ToString());
            txtModelo.Text = dgVehiculo.CurrentRow.Cells["Modelo"].Value.ToString();
            txtMarca.Text = dgVehiculo.CurrentRow.Cells["Marca"].Value.ToString();
            txtyear.Text = dgVehiculo.CurrentRow.Cells["Año"].Value.ToString();
            txtCombustible.Text = dgVehiculo.CurrentRow.Cells["Combustible"].Value.ToString();
        }//para seleccionar la fila correspondinte para despues poder modificar o eliminar

        private void EliminarVehiculo(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                Agregar();//vincula los textboxs con su respectivo dato en el objeto vehiculo
                admin.Eliminar(Id);
                limpiar();
            }
        }

        private void btnmostrarVehiculo(object sender, EventArgs e)
        {
            if(buscarPorID.Text!= string.Empty)
            {
                var lst = admin.buscarId(Convert.ToInt32(buscarPorID.Text));
                dgVehiculo.DataSource = lst;
            }
        }

        private void buscarPorNombre_TextChanged(object sender, EventArgs e)
        {
            if (buscarPorNombre.Text != string.Empty)
            {
                var lst = admin.buscarNombre(buscarPorNombre.Text);
                dgVehiculo.DataSource = lst;
            }
            else
            {
                Agregar();
            }
        }
    }
}
