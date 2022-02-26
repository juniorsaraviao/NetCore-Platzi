using Microsoft.AspNetCore.Mvc;
using NetCore_Platzi.Models;
using System;
using System.Collections.Generic;

namespace NetCore_Platzi.Controllers
{
   public class AsignaturaController : Controller
   {
      public IActionResult Index()
      {
         var asignatura = new Asignatura
         {
            Nombre = "Programación",
            Id = Guid.NewGuid().ToString()
         };
         return View(asignatura);
      }

      public IActionResult MultiAsignatura()
      {
         var listaAsignaturas = new List<Asignatura>() {
            new Asignatura {
            Nombre = "Matemáticas",
            Id = Guid.NewGuid ().ToString ()
            },
            new Asignatura {
            Nombre = "Educación Física",
            Id = Guid.NewGuid ().ToString ()
            },
            new Asignatura {
            Nombre = "Castellano",
            Id = Guid.NewGuid ().ToString ()
            },
            new Asignatura {
            Nombre = "Ciencias Naturales",
            Id = Guid.NewGuid ().ToString ()
            },
            new Asignatura {
            Nombre = "Programación",
            Id = Guid.NewGuid ().ToString ()
            }
         };

         ViewBag.DynamicThings = "Explorando ASP.NET";
         ViewBag.Date = DateTime.Now;

         return View(listaAsignaturas);
      }
   }
}
