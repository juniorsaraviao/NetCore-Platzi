using Microsoft.AspNetCore.Mvc;
using NetCore_Platzi.Models;
using System;
using System.Linq;

namespace NetCore_Platzi.Controllers
{
   public class EscuelaController : Controller
   {
      private readonly EscuelaContext _context;
      public EscuelaController(EscuelaContext context)
      {
         _context = context;
      }
      public IActionResult Index()
      {        

         ViewBag.DynamicThings = "Explorando ASP.NET";
         var escuela = _context.Escuelas.FirstOrDefault();

         return View(escuela);
      }
   }
}
