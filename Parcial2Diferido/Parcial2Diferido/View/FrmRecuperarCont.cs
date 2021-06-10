using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Parcial2Diferido.Model;

namespace Parcial2Diferido
{
    public partial class FrmRecuperarCont : Form
    {
        public FrmRecuperarCont()
        {
            InitializeComponent();
        }

        private void FrmRecuperarCont_Load(object sender, EventArgs e)
        {
            txtContrasena.Enabled = false;
            txtRespuesta.Enabled = false;
            txtConfirmarCont.Enabled = false;
            btnGuardar.Enabled = false;
            lblPregunta.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            int carnet = Convert.ToInt32(txtCarnet.Text);
            
            var db = new DBAdminContext();
            var contraEditar = db.Usuarios.FirstOrDefault(x => x.id == carnet);
            if (contraEditar==null)
            {
                MessageBox.Show("No existe ese carnet");
            }
            else
            {
                txtContrasena.Enabled = true;
                txtRespuesta.Enabled = true;
                txtConfirmarCont.Enabled = true;
                txtCarnet.Enabled = false;
                btnGuardar.Enabled = true;
                btnverificar.Enabled = false;
                lblPregunta.Visible = true;
               /////Obteniendo pregunta
               var usdr = db.Usuarios.Include(i => i.id_pregunta).ToList();
               var filtroP = usdr.Where(u => u.id == carnet).ToList();
               ////Mostrando en el label
               lblPregunta.Text = filtroP[0].id_pregunta.pregunta;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var db = new DBAdminContext();
            int carnet = Convert.ToInt32(txtCarnet.Text);
            string respuesta = txtRespuesta.Text;
            string ncontrasena = txtContrasena.Text;
            ////Comparando en la base de datos si existe
            var contraEditar = db.Usuarios.FirstOrDefault(x => x.respuesta == respuesta);
            if (contraEditar!=null)
            {
                if (ncontrasena==txtConfirmarCont.Text)
                {
                    var contraEditar2 = db.Usuarios.FirstOrDefault(x => x.id == carnet);
                    contraEditar2.contrasena = ncontrasena;
                    db.SaveChanges();
                    MessageBox.Show("Se a modificado contraseña");   
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Contraseña mal ingresada");
                }
            }
            else
            {
                MessageBox.Show("Respuesta erronea");
            }

            {
                
            }
        }
    }
}