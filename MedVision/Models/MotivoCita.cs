namespace MedVision.Models
{
    public class MotivoCita
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Cita> Citas { get; set; }
    }
}
