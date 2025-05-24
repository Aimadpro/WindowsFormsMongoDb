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
    /// <summary>
    /// Formulario principal para la gestión de ciudades.
    /// Permite listar, añadir, editar y eliminar ciudades almacenadas en MongoDB.
    /// </summary>
    public partial class FormCiudades : Form
    {
        /// <summary>
        /// Constructor. Inicializa el formulario y configura el DataGridView para mostrar solo el nombre de la ciudad.
        /// </summary>
        public FormCiudades()
        {
            InitializeComponent();
            dataGridViewCiudades.AutoGenerateColumns = false;
            dataGridViewCiudades.Columns.Clear();
            dataGridViewCiudades.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "nombre",
                HeaderText = "Nombre",
                Name = "nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        /// <summary>
        /// Refresca el DataGridView con la lista actual de ciudades desde la base de datos.
        /// </summary>
        private void RefrescarGrid()
        {
            List<Ciudad> ciudades = CiudadesCollection.GetAll();
            dataGridViewCiudades.DataSource = ciudades;
        }

        /// <summary>
        /// Evento de carga del formulario. Refresca la grid al iniciar.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void FormCiudades_Load(object sender, EventArgs e)
        {
            RefrescarGrid();
        }

        /// <summary>
        /// Evento click del botón "Añadir". Abre el formulario para agregar una nueva ciudad.
        /// Al cerrar el formulario, refresca la grid.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void addButton_Click(object sender, EventArgs e)
        {
            FormCiudad f = new FormCiudad();
            f.ShowDialog();
            RefrescarGrid(); // Refresca la grid después de añadir
        }

        /// <summary>
        /// Evento doble click en una celda del DataGridView. Abre el formulario para editar la ciudad seleccionada.
        /// Al cerrar el formulario, refresca la grid.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void dataGridViewCiudades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Ciudad ciudad = dataGridViewCiudades.CurrentRow.DataBoundItem as Ciudad;
            FormCiudad f = new FormCiudad(ciudad);
            f.ShowDialog();
            RefrescarGrid(); // Refresca la grid después de editar
        }

        /// <summary>
        /// Evento click del botón "Eliminar". Elimina la ciudad seleccionada y refresca la grid.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            Ciudad ciudad = dataGridViewCiudades.SelectedRows[0].DataBoundItem as Ciudad;
            CiudadesCollection.Delete(ciudad);
            RefrescarGrid();
        }

        /// <summary>
        /// Evento click del botón "Salir". Cierra el formulario principal.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void outButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
