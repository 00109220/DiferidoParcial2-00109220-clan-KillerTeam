namespace Parcial2Diferido.Model
{
    public class Facultad
    {
        public int id { get; set; }
        public string facultad { get; set; }

        public Facultad()
        {
            
        }

        public Facultad(string facultad)
        {
            this.facultad = facultad;
        }
    }
}