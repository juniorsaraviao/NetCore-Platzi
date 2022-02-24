using System.Collections.Generic;

namespace NetCore_Platzi.Models
{
   public class Alumno: ObjetoEscuelaBase
    {
        public List<Evaluación> Evaluaciones { get; set; } = new List<Evaluación>();
    }
}