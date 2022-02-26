using Microsoft.EntityFrameworkCore;

namespace NetCore_Platzi.Models
{
   public class EscuelaContext : DbContext
   {
      public DbSet<Escuela> Escuelas { get; set; }
      public DbSet<Asignatura> Asignaturas { get; set; }
      public DbSet<Alumno> Alumnos { get; set; }
      public DbSet<Curso> Cursos { get; set; }
      public DbSet<Evaluacion> Evaluaciones { get; set; }

      public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
      {

      }
   }
}
