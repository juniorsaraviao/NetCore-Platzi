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

      [Route("Alumno/Index")]
      [Route("Alumno/Index/{id}")]
      public IActionResult Index(string id)
      {
         if (!string.IsNullOrEmpty(id))
         {
            var asignatura = _context.Alumnos.FirstOrDefault(x => x.Id == id);
            return View(asignatura);
         }
         else
         {
            return View("MultiAlumno", _context.Alumnos);
         }
      }

      public IActionResult MultiAlumno()
      {
         ViewBag.DynamicThings = "Explorando ASP.NET";
         ViewBag.Date = DateTime.Now;

         return View(_context.Alumnos);
      }

      [Route("Alumno/Update")]
      public IActionResult Update(string id)
      {
         var curso = _context.Alumnos.FirstOrDefault(x => x.Id == id);
         return View(curso);
      }

      [Route("Alumno/Update")]
      [HttpPost]
      public IActionResult Update(Alumno alumno)
      {
         ViewBag.Fecha = DateTime.Now;

         if (ModelState.IsValid)
         {
            var alumnoDb = _context.Alumnos.Where(c => c.Id == alumno.Id).SingleOrDefault();
            if (alumnoDb == null || string.IsNullOrWhiteSpace(alumnoDb.Id))
            {
               ViewBag.MensajeExtra = "El alumno no existe. Compruebe el ID.";

               return View(alumno);
            }
            var escuela = _context.Escuelas.FirstOrDefault();
            if (alumno.Nombre != alumnoDb.Nombre) alumnoDb.Nombre = alumno.Nombre;
            if (alumno.CursoId != alumnoDb.CursoId) alumnoDb.CursoId = alumno.CursoId;

            _context.Alumnos.Update(alumnoDb);
            _context.SaveChanges();
            ViewBag.MensajeExtra = "Alumno actualizado";

            return RedirectToAction("Index", "Alumno", alumno.Id);
         }
         else
         {
            return View(alumno);
         }
      }

      [Route("Alumno/Delete/{id}")]
      public IActionResult Delete(string id)
      {
         var alumno = _context.Alumnos.FirstOrDefault(x => x.Id == id);
         _context.Alumnos.Remove(alumno);
         _context.SaveChanges();
         return RedirectToAction("Index");
      }
   }
}
