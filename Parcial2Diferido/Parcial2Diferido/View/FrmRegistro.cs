using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Parcial2Diferido.Model;


namespace Parcial2Diferido
{
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
        {
            InitializeComponent();
        }

        private void FrmRegistro_Load(object sender, EventArgs e)
        {
            var db = new DBAdminContext();
            List<Pregunta> pregunta = db.Preguntas.ToList();
            cmbPregunta.DataSource = pregunta;
            cmbPregunta.DisplayMember = "pregunta";
            cmbPregunta.ValueMember = "id";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string UserCompare=txtUsuario.Text;
            string PassCompare=txtUsuario.Text;
            ////Obteniendo valores del combobox
            Pregunta mref = (Pregunta)cmbPregunta.SelectedItem;
            ///////abriendo conexion
            var db = new DBAdminContext();
            //////Buscando en la base de datos el id del combobox sea igual al de la base de datos
            Pregunta mbdd = db.Set<Pregunta>()
                .SingleOrDefault(m => m.id == mref.id);
            //////llamando al constructor
            int Edadbd = Convert.ToInt32(nudEdad.Value);
            Usuario u = new Usuario(txtUsuario.Text,Edadbd,txtRecidencia.Text,txtContrasena.Text,mbdd,txtRespuestaP.Text);
            ///////Almacenando en la base de datos
            db.Add(u);
            db.SaveChanges();
            //////Mostrando el carnet
            var UltimoId = db.Set<Usuario>().OrderByDescending(t => t.id).ToList().FirstOrDefault();
            /////Mostrando carnet
            MessageBox.Show("Agregado exitosamente y su carnet es: "+UltimoId.id);
            this.Hide();
        }
    }
}