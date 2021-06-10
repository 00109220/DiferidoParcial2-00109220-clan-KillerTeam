using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal;
using Microsoft.VisualBasic.ApplicationServices;
using Parcial2Diferido.Model;

namespace Parcial2Diferido
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var db = new DBAdminContext();
            int carnet = Convert.ToInt32(txtUsuario.Text);
            String pass = txtcontrasena.Text;
            string respuesta = txtcontrasena.Text;
            var Usercart = db.Usuarios.FirstOrDefault(x => x.id == carnet && x.contrasena== pass);
            if (Usercart!=null)
            { 
                MessageBox.Show("Bienbenido al sistema UCA");
                    ///abriendo formulari principal
                FrmPrincipal ventana = new FrmPrincipal();
                    ///Mandando el el carnet (id)
                ventana.Cartuser =carnet;
                    ///Mostrando ventana
                ventana.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error al ingresar datos!", "Admicion UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmRegistro ventana = new FrmRegistro();
            ventana.ShowDialog();
            
        }

        private void btnOlvidarCont_Click(object sender, EventArgs e)
        {
            FrmRecuperarCont ventana = new FrmRecuperarCont();
            ventana.ShowDialog();
            
        }
    }
}