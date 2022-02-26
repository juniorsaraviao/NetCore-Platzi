using System.Collections.Generic;

namespace NetCore_Platzi.Models
{
   public class Alumno: ObjetoEscuelaBase
    {
        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
    }
}