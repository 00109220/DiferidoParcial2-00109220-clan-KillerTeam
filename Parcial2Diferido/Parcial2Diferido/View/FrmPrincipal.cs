using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Parcial2Diferido.Model;

namespace Parcial2Diferido
{
    public partial class FrmPrincipal : Form
    {
        public int Cartuser;
        public string id_Eliminar;
        public int poc;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            var db = new DBAdminContext();
            List<Facultad> facultades = db.Facultades.ToList();
            cmbFacultad.DataSource = facultades;
            cmbFacultad .DisplayMember = "facultad";
            cmbFacultad.ValueMember = "id";
            /////Combobox 2
            cmbver.DataSource = facultades;
            cmbver .DisplayMember = "facultad";
            cmbver.ValueMember = "id";
            ////Data grip
            Actualizardgv();
        }

        private void Actualizardgv()
        {
            /*
            var db = new DBAdminContext();
            dgvFacultad.DataSource = db.Solicitudes.ToList();
            */
            
            var db = new DBAdminContext();
            var ListaSolicitud = db.Solicitudes
                .Include(i => i.id_usuario)
                .Include(i => i.id_facultad)
                .OrderBy(i=>i.id)
                .ToList();
       
            List<Facultad> listsolicitud = new List<Facultad>();
            foreach (Solicitud i in ListaSolicitud)
            {
                listsolicitud.Add(i.id_facultad);   
            }
            
            dgvFacultad.DataSource = null;
            dgvFacultad.DataSource = ListaSolicitud;
            

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime fecha = dateInscripcion.Value;
            ////Obteniendo valores del combobox
            Facultad mref = (Facultad)cmbFacultad.SelectedItem;
            ///////abriendo conexion
            var db = new DBAdminContext();
            //////Buscando en la base de datos el id del combobox sea igual al de la base de datos
            Facultad mbdd = db.Set<Facultad>()
                .SingleOrDefault(m => m.id == mref.id);
            ////////Buscando el usuario y haciendo el tipo usuario 
            Usuario ubdd = db.Set<Usuario>()
                .SingleOrDefault(m => m.id == Cartuser);
            //////llamando al constructor 
            Solicitud u = new Solicitud(ubdd, mbdd,fecha,true);
            ///////Almacenando en la base de datos
            db.Add(u);
            db.SaveChanges();
            MessageBox.Show("Agregado exitosamente");
            Actualizardgv();
        }
        private void dgvFacultad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            poc = dgvFacultad.CurrentRow.Index;////obteniendo el valor de la final para despues ubicar la columna
            id_Eliminar = dgvFacultad[0,poc].Value.ToString();///ubicando valor de columna e igualando a una variable tipo string
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro que desea eliminar la solicitud?", "Registro UCA", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                int id_Delete = Convert.ToInt32(id_Eliminar);
                var db = new DBAdminContext();
                ///Buscando el id en la tabla solicitud
                Solicitud Deleteregistro = db.Solicitudes.Find(id_Delete);
                ///Eliminando datos
                db.Solicitudes.Remove(Deleteregistro);
                ///actualizando cambios
                db.SaveChanges();
                Actualizardgv();
            }
            else if (dialogResult == DialogResult.No)
            {
               
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro que desea modificar la facultad?", "Registro UCA", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                var db = new DBAdminContext();
                int id_Delete = Convert.ToInt32(id_Eliminar);
                var contraEditar2 = db.Solicitudes.FirstOrDefault(x => x.id == id_Delete);
                ///Llamando valores del combobox
                Facultad mref = (Facultad)cmbver.SelectedItem;
                Facultad mbdd = db.Set<Facultad>()
                    .SingleOrDefault(m => m.id == mref.id);
                ////guardando en el registro para editar
                contraEditar2.id_facultad = mbdd;
                db.SaveChanges();
                MessageBox.Show("Se a modificado contraseña");
                Actualizardgv();
            }
            else if (dialogResult == DialogResult.No)
            {
               
            }
        }
    }
}