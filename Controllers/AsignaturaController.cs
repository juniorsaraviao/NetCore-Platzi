using Microsoft.AspNetCore.Mvc;
using NetCore_Platzi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCore_Platzi.Controllers
{
   public class AsignaturaController : Controller
   {
      private readonly EscuelaContext _context;
      public AsignaturaController(EscuelaContext context)
      {
         _context = context;
      }

      [Route("Asignatura/Index")]
      [Route("Asignatura/Index/{asignaturaId}")]
      public IActionResult Index(string asignaturaId)
      {
         if (!string.IsNullOrEmpty(asignaturaId))
         {
            var asignatura = _context.Asignaturas.FirstOrDefault(x => x.Id == asignaturaId);
            return View(asignatura);
         }
         else
         {
            return View("MultiAsignatura", _context.Asignaturas);
         }         
      }

      public IActionResult MultiAsignatura()
      {         

         ViewBag.DynamicThings = "Explorando ASP.NET";
         ViewBag.Date = DateTime.Now;

         return View(_context.Asignaturas);
      }
   }
}
