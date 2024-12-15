using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;
using System.Linq;

public class TeacherController : Controller
{
    private readonly AppDbContext _context;

    public TeacherController(AppDbContext context)
    {
        _context = context;
    }


    public IActionResult Index()
    {

        var teachers = _context.Teachers.ToList();
        return View(teachers);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Teacher teacher)
    {
        if (ModelState.IsValid)
        {

            _context.Teachers.Add(teacher);


            _context.SaveChanges();


            return RedirectToAction("Index");
        }


        return View(teacher);
    }


    [HttpGet]
    public IActionResult ShowDetails(string id) 
    {
        var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
        if (teacher == null)
        {
            return NotFound(); 
        }

        return View(teacher);
    }

    [HttpPost]
    public IActionResult Delete(string id) 
    {

        var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
        if (teacher == null)
        {
            return NotFound(); 
        }

        _context.Teachers.Remove(teacher);


        _context.SaveChanges();


        return RedirectToAction("Index");
    }
}
