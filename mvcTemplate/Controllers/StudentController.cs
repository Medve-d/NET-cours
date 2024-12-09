using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    public class StudentController : Controller
    {
        // Creation d'une liste statique de Student
        private static List<Student> _students = new List<Student>
        {
            new Student { Id = 1, Nom = "Alice", Age = 20, Specialite = "Informatique" },
            new Student { Id = 2, Nom = "Bob", Age = 22, Specialite = "Mathématiques" },
            new Student { Id = 3, Nom = "Charlie", Age = 21, Specialite = "Physique" }
        };

        // GET: StudentController/Index
        public ActionResult Index()
        {
            return View(_students);
        }

        // GET: StudentController/Edit/id
        public ActionResult Edit(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound(); // Handle student not found
            }

            return View(student);
        }

        // POST: StudentController/Edit/id
        [HttpPost]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest(); // Handle ID mismatch
            }

            if (ModelState.IsValid)
            {
                var index = _students.FindIndex(s => s.Id == id);
                if (index != -1)
                {
                    _students[index] = student; // Update student in the list
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(student); // Re-render view with validation errors
        }

        public IActionResult Add(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = _students.Max(e => e.Id) + 1;
                _students.Add(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
        
    }
}
    