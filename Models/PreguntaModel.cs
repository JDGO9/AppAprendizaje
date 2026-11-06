namespace Proyect.Models
{
    public class PreguntaModel
    {
        public string Enunciado { get; set; }
        public List<string> Opciones { get; set; }
        public int respuestaCorrecta { get; set; }
        public int IndiceSeleccionado { get; set; } = -1;
    }
}