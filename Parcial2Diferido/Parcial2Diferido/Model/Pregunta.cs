namespace Parcial2Diferido.Model
{
    public class Pregunta
    {
        public int id { get; set; }
        public  string pregunta { get; set; }

        public Pregunta()
        {
            
        }

        public Pregunta(string pregunta)
        {
            this.pregunta = pregunta;
        }
    }
}