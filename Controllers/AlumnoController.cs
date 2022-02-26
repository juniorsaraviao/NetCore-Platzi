using Microsoft.AspNetCore.Mvc;
using NetCore_Platzi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCore_Platzi.Controllers
{
   public class AlumnoController : Controller
   {
      public IActionResult Index()
      {
         var asignatura = new Alumno
         {
            Nombre = "Pepe Pérez",
            Id = Guid.NewGuid().ToString()
         };
         return View(asignatura);
      }

      public IActionResult MultiAlumno()
      {
         var alumnoList = GenerateRandomAlumno();

         ViewBag.DynamicThings = "Explorando ASP.NET";
         ViewBag.Date = DateTime.Now;

         return View(alumnoList);
      }

      private List<Alumno> GenerateRandomAlumno()
      {
         string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
         string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
         string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

         var listaAlumnos = from n1 in nombre1
                            from n2 in nombre2
                            from a1 in apellido1
                            select new Alumno { Nombre = $"{n1} {n2} {a1}", Id = Guid.NewGuid().ToString() };

         return listaAlumnos.OrderBy((al) => al.Id).ToList();
      }
   }
}
