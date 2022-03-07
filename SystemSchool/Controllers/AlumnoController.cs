using Microsoft.AspNetCore.Mvc;
using SystemSchool.Data;
using SystemSchool.Models;

namespace SystemSchool.Controllers
{
    public class AlumnoController : Controller
    {
        readonly SchoolDAL Context = new SchoolDAL();
        public IActionResult Index()
        {
            IEnumerable<Alumno> ListadoAlumnos = Context.MostrarAlumnos();
            return View(ListadoAlumnos);
        }

        //GET
        public IActionResult CrearAlumno()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearAlumno(Alumno Alumno)
        {
            if (ModelState.IsValid)
            {
                Context.CrearAlumno(Alumno);
                return RedirectToAction("Index");
            }
            return View(Alumno);
        }

        //GET
        public IActionResult EditarAlumno(int Matricula_Alumno)
        {
            if(Matricula_Alumno == null) { return NotFound(); }
            Alumno Alumno = Context.MostraralumnoPorId(Matricula_Alumno);
            if(Alumno == null) { return NotFound(); }
            return View(Alumno);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarAlumno(int Matricula_Alumno, Alumno Alumno)
        {
            

            if (ModelState.IsValid)
            {
                Context.EditarAlumno(Alumno);
                return RedirectToAction("Index");
            }

            return View(Alumno);
        }
    }
}
