using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsMongoDb.Models;
using WindowsFormsMongoDb.Services;

namespace WindowsFormsMongoDb
{
    public partial class FormCiudades : Form
    {
        public FormCiudades()
        {
            InitializeComponent();
        }
        private void RefrescarGrid()
        {

            List<Ciudad> ciudades = CiudadesCollection.GetAll();
            dataGridViewCiudades.DataSource = ciudades;

        }
        private void FormCiudades_Load(object sender, EventArgs e)
        {
            RefrescarGrid();
            

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            FormCiudad f = new FormCiudad();
            f.ShowDialog();

        }

        private void dataGridViewCiudades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Ciudad ciudad = dataGridViewCiudades.CurrentRow.DataBoundItem as Ciudad;
            FormCiudad f = new FormCiudad(ciudad);
            f.ShowDialog();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Ciudad ciudad = dataGridViewCiudades.SelectedRows[0].DataBoundItem as Ciudad;
            CiudadesCollection.Delete(ciudad);
            RefrescarGrid();

        }
    }
}
