using MedVision.Models;
using Microsoft.EntityFrameworkCore;

namespace MedVision
{
    public class ApplicationDbContest: DbContext
    {
        public ApplicationDbContest(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<MotivoCita> MotivosCita { get; set; }
    }
}
