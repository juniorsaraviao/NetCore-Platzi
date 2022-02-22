using Microsoft.AspNetCore.Mvc;

namespace NetCore_Platzi.Controllers
{
   public class EscuelaController : Controller
   {
      public IActionResult Index()
      {
         return View();
      }
   }
}
