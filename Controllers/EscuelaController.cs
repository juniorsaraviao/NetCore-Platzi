using Microsoft.AspNetCore.Mvc;
using NetCore_Platzi.Models;
using System;

namespace NetCore_Platzi.Controllers
{
   public class EscuelaController : Controller
   {
      public IActionResult Index()
      {
         var escuela = new Escuela();
         escuela.FoundationYear = 2005;
         escuela.SchoolId = Guid.NewGuid().ToString();
         escuela.Name = "Platzi School";
         return View(escuela);
      }
   }
}
