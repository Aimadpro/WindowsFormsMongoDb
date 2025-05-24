using System;
using System.Windows.Forms;
using WindowsFormsMongoDb.Models;
using WindowsFormsMongoDb.Services;

namespace WindowsFormsMongoDb
{
    /// <summary>
    /// Formulario para agregar o editar una ciudad.
    /// </summary>
    public partial class FormCiudad : Form
    {
        private Ciudad ciudad;
        private bool insert;

        /// <summary>
        /// Constructor para agregar una nueva ciudad.
        /// </summary>
        public FormCiudad()
        {
            InitializeComponent();
            ciudad = new Ciudad();
            insert = true;
        }

        /// <summary>
        /// Constructor para editar una ciudad existente.
        /// </summary>
        /// <param name="ciudad">La ciudad a editar. Si es null, se crea una nueva.</param>
        public FormCiudad(Ciudad ciudad)
        {
            InitializeComponent();
            this.ciudad = ciudad ?? new Ciudad();
            insert = false;
        }

        /// <summary>
        /// Evento click del botón "Aceptar". Guarda los cambios en la base de datos (insertar o actualizar).
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void aceptarButton_Click(object sender, EventArgs e)
        {
            // Actualizar el modelo con los datos del formulario
            ciudad.nombre = nameText.Text.Trim();

            try
            {
                if (insert)
                {
                    CiudadesCollection.Insert(ciudad);
                }
                else
                {
                    CiudadesCollection.Update(ciudad);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en la base de datos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento de carga del formulario. Si es edición, muestra el nombre actual de la ciudad.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void FormCiudad_Load(object sender, EventArgs e)
        {
            if (!insert && ciudad != null)
            {
                nameText.Text = ciudad.nombre;
            }
        }
    }
}
