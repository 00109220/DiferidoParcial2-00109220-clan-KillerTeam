namespace Parcial2Diferido.Model
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public string residencia { get; set; }
        public string contrasena { get; set; }
        public virtual Pregunta id_pregunta { get; set; }
        public string respuesta { get; set; }

        public Usuario()
        {
            
        }
        public Usuario(string nombre, int edad, string residencia, string contrasena, Pregunta idPregunta, string respuesta)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.residencia = residencia;
            this.contrasena = contrasena;
            id_pregunta = idPregunta;
            this.respuesta = respuesta;
        }
    }
}