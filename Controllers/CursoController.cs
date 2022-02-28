using Microsoft.AspNetCore.Mvc;
using NetCore_Platzi.Models;
using System;
using System.Linq;

namespace NetCore_Platzi.Controllers
{
   public class CursoController : Controller
   {
      private readonly EscuelaContext _context;
      public CursoController(EscuelaContext context)
      {
         _context = context;
      }

      public IActionResult Index(string id)
      {
         if (!string.IsNullOrEmpty(id))
         {
            var asignatura = _context.Cursos.FirstOrDefault(x => x.Id == id);
            return View(asignatura);
         }
         else
         {
            return View("MultiCurso", _context.Cursos);
         }
      }

      public IActionResult MultiCurso()
      {
         ViewBag.DynamicThings = "Explorando ASP.NET";
         ViewBag.Date = DateTime.Now;

         return View(_context.Cursos);
      }

      public IActionResult Create()
      {
         
         ViewBag.Date = DateTime.Now;

         return View();
      }

      [HttpPost]
      public IActionResult Create(Curso curso)
      {
         ViewBag.Date = DateTime.Now;

         if (ModelState.IsValid)
         {
            var school = _context.Escuelas.FirstOrDefault();
            curso.EscuelaId = school.Id;
            _context.Cursos.Add(curso);
            _context.SaveChanges();
            ViewBag.ExtraMessage = "Curso creada";
            return View("Index", curso);
         }
         else
         {
            return View(curso);
         }
      }
   }
}
