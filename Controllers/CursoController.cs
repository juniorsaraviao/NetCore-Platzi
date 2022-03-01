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

      [Route("Curso/Index")]
      [Route("Curso/Index/{id}")]
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

      [Route("Curso/Update")]
      public IActionResult Update(string id)
      {
         var curso = _context.Cursos.FirstOrDefault(x => x.Id == id);
         return View(curso);
      }

      [Route("Curso/Update")]
      [HttpPost]
      public IActionResult Update(Curso curso)
      {
         ViewBag.Fecha = DateTime.Now;

         if (ModelState.IsValid)
         {
            Curso cursoDb = _context.Cursos.Where(c => c.Id == curso.Id).SingleOrDefault();
            if (cursoDb == null || string.IsNullOrWhiteSpace(cursoDb.Id))
            {
               ViewBag.MensajeExtra = "El curso no existe. Compruebe el ID.";

               return View(curso);
            }
            var escuela = _context.Escuelas.FirstOrDefault();
            if (curso.EscuelaId != cursoDb.EscuelaId) cursoDb.EscuelaId = curso.EscuelaId;
            if (curso.Nombre != cursoDb.Nombre) cursoDb.Nombre = curso.Nombre;
            if (curso.Dirección != cursoDb.Dirección) cursoDb.Dirección = curso.Dirección;
            if (curso.Jornada != cursoDb.Jornada) cursoDb.Jornada = curso.Jornada;

            _context.Cursos.Update(cursoDb);
            _context.SaveChanges();
            ViewBag.MensajeExtra = "Curso actualizado";

            return RedirectToAction("Index", "Curso",curso.Id);
         }
         else
         {
            return View(curso);
         }
      }

      [Route("Curso/Delete/{id}")]
      public IActionResult Delete(string id)
      {
         var curso = _context.Cursos.FirstOrDefault(x => x.Id == id);
         _context.Cursos.Remove(curso);
         _context.SaveChanges();
         return RedirectToAction("Index");
      }
   }
}
