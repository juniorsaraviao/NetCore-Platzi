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
         escuela.AñoDeCreación = 2005;
         escuela.UniqueId = Guid.NewGuid().ToString();
         escuela.Nombre = "Platzi School";
         escuela.Ciudad = "Lima";
         escuela.Pais = "Peru";
         escuela.TipoEscuela = TiposEscuela.Secundaria;
         escuela.Dirección = "Av. Perú s/n";

         ViewBag.DynamicThings = "Explorando ASP.NET";

         return View(escuela);
      }
   }
}
