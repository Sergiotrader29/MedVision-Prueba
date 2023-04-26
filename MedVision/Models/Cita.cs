namespace MedVision.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public DateTime FechaCita { get; set; }
        public string HoraCita { get; set; }
        public string Lugar { get; set; }
        public int IdPersona { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual ICollection<MotivoCita> MotivosCita { get; set; }
    }
}
