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
    public partial class FormCiudad : Form
    {
        Ciudad ciudad;
        bool insert = true;
        public FormCiudad(Ciudad ciudad)
        {
            InitializeComponent();
            this.ciudad = new Ciudad();
            insert = true;
        }
        public FormCiudad()
        {
            InitializeComponent();
            ciudad = new Ciudad();
            insert = false;
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            CiudadesCollection.Insert(ciudad);

            nameText.Text = ciudad.nombre;
            if (!insert)
            {
                CiudadesCollection.Insert(ciudad);

            }
            else
            {
                CiudadesCollection.Update(ciudad);
            }
            this.Close();
        }

        private void FormCiudad_Load(object sender, EventArgs e)
        {
            if (!insert)
            {
                nameText.Text = ciudad.nombre;
            }
        }
    }
}
