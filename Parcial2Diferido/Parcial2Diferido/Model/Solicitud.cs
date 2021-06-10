using System;

namespace Parcial2Diferido.Model
{
    public class Solicitud
    {
        public int id { get; set; }
        public virtual Usuario id_usuario { get; set; }
        public virtual Facultad id_facultad { get; set; }
       
        public DateTime fecha { get; set; }
        public bool vigente { get; set; }

        public Solicitud()
        {
            
        }

        public Solicitud(Usuario idUsuario, Facultad idFacultad, DateTime fecha, bool vigente)
        {
            id_usuario = idUsuario;
            id_facultad = idFacultad;
            this.fecha = fecha;
            this.vigente = vigente;
        }
    }
}