using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);

         var escuela = new Escuela();
         escuela.AñoDeCreación = 2005;
         escuela.Id = Guid.NewGuid().ToString();
         escuela.Nombre = "Platzi School";
         escuela.Ciudad = "Lima";
         escuela.Pais = "Peru";
         escuela.TipoEscuela = TiposEscuela.Secundaria;
         escuela.Dirección = "Av. Perú s/n";

         var cursos = LoadCursos(escuela);
         var asignaturas = LoadAsignaturas(cursos);
         var alumnos = LoadAlumnos(cursos);

         modelBuilder.Entity<Escuela>().HasData(escuela);
         modelBuilder.Entity<Curso>().HasData(cursos.ToArray()); // avoid errors in runtime
         modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
         modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());
      }

      private static List<Curso> LoadCursos(Escuela escuela)
      {
         return new List<Curso>(){
            new Curso { EscuelaId = escuela.Id, Nombre = "101", Jornada = TiposJornada.Mañana, Dirección = "Av. Lima 152" },
            new Curso { EscuelaId = escuela.Id, Nombre = "201", Jornada = TiposJornada.Mañana, Dirección = "Av. Lima 152" },
            new Curso { EscuelaId = escuela.Id, Nombre = "301", Jornada = TiposJornada.Mañana, Dirección = "Av. Lima 152" },
            new Curso { EscuelaId = escuela.Id, Nombre = "401", Jornada = TiposJornada.Tarde, Dirección = "Av. Lima 152" },
            new Curso { EscuelaId = escuela.Id, Nombre = "501", Jornada = TiposJornada.Tarde, Dirección = "Av. Lima 152" }
         };
      }

      private static List<Asignatura> LoadAsignaturas(List<Curso> cursos)
      {
         var fullList = new List<Asignatura>();
         foreach (var curso in cursos)
         {
            var tmpList = new List<Asignatura> {
               new Asignatura{ Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre = "Matemáticas"} ,
               new Asignatura{ Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre = "Educación Física"},
               new Asignatura{ Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre = "Castellano"},
               new Asignatura{ Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre = "Ciencias Naturales"},
               new Asignatura{ Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre = "Programación"}
            };
            fullList.AddRange(tmpList);
         }

         return fullList;
      }

      private List<Alumno> LoadAlumnos(List<Curso> cursos)
      {
         var alumnoList = new List<Alumno>();

         var rnd = new Random();
         foreach (var curso in cursos)
         {
            int cantRandom = rnd.Next(5, 20);
            var tmplist = GenerateRandomAlumno(curso, cantRandom);
            alumnoList.AddRange(tmplist);
         }
         return alumnoList;
      }

      private List<Alumno> GenerateRandomAlumno(Curso curso, int cantidad)
      {
         string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
         string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
         string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

         var listaAlumnos = from n1 in nombre1
                            from n2 in nombre2
                            from a1 in apellido1
                            select new Alumno { CursoId = curso.Id, Nombre = $"{n1} {n2} {a1}", Id = Guid.NewGuid().ToString() };

         return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
      }
   }
}
