using System.Collections.Generic;

namespace NetCore_Platzi.Models
{
   public class Alumno: ObjetoEscuelaBase
   {
      public List<Evaluacion> Evaluaciones { get; set; }
      public string CursoId { get; set; }
      public Curso Curso { get; set; }
   }
}