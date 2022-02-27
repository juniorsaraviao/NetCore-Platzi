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
      public IActionResult Index()
      {         
         return View(_context.Asignaturas.FirstOrDefault());
      }

      public IActionResult MultiAsignatura()
      {         

         ViewBag.DynamicThings = "Explorando ASP.NET";
         ViewBag.Date = DateTime.Now;

         return View(_context.Asignaturas);
      }
   }
}
