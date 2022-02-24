using Microsoft.AspNetCore.Mvc;
using NetCore_Platzi.Models;
using System;

namespace NetCore_Platzi.Controllers
{
   public class AsignaturaController : Controller
   {
      public IActionResult Index()
      {
         var asignatura = new Asignatura 
         {
            UniqueId = Guid.NewGuid().ToString(),
            Nombre = "Programación"
         };

         ViewBag.DynamicThings = "Explorando ASP.NET";
         ViewBag.Date = DateTime.Now;

         return View(asignatura);
      }
   }
}
