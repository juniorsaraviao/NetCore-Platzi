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
            UniqueId = Guid.NewGuid().ToString()
         };
         return View(asignatura);
      }

      public IActionResult MultiAsignatura()
      {
         var listaAsignaturas = new List<Asignatura>() {
            new Asignatura {
            Nombre = "Matemáticas",
            UniqueId = Guid.NewGuid ().ToString ()
            },
            new Asignatura {
            Nombre = "Educación Física",
            UniqueId = Guid.NewGuid ().ToString ()
            },
            new Asignatura {
            Nombre = "Castellano",
            UniqueId = Guid.NewGuid ().ToString ()
            },
            new Asignatura {
            Nombre = "Ciencias Naturales",
            UniqueId = Guid.NewGuid ().ToString ()
            },
            new Asignatura {
            Nombre = "Programación",
            UniqueId = Guid.NewGuid ().ToString ()
            }
         };

         ViewBag.DynamicThings = "Explorando ASP.NET";
         ViewBag.Date = DateTime.Now;

         return View(listaAsignaturas);
      }
   }
}
