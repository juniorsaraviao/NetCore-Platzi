using Microsoft.AspNetCore.Mvc;
using NetCore_Platzi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCore_Platzi.Controllers
{
   public class AlumnoController : Controller
   {
      private readonly EscuelaContext _context;
      public AlumnoController(EscuelaContext context)
      {
         _context = context;
      }
      public IActionResult Index()
      {
         return View(_context.Alumnos.FirstOrDefault());
      }

      public IActionResult MultiAlumno()
      {
         ViewBag.DynamicThings = "Explorando ASP.NET";
         ViewBag.Date = DateTime.Now;

         return View(_context.Alumnos);
      }
   }
}
