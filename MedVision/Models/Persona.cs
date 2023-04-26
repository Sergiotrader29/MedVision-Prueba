using System.ComponentModel.DataAnnotations;

namespace MedVision.Models
{
    public class Persona
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }

        [MaxLength(50, ErrorMessage = "El campo Apellido no puede tener más de 50 caracteres")]
        public string Apellido { get; set; }

        [Range(1, 120, ErrorMessage = "La Edad debe estar entre 1 y 120 años")]
        public int Edad { get; set; }

        public virtual ICollection<Cita> Citas { get; set; }
    }
}