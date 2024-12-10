using Microsoft.AspNetCore.Mvc;

using mvcTemplate.Models;
using mvcTemplate.Data;

public class TeachController : Controller
{
    // Champ privé pour stocker DbContext (not used in this example)
    private readonly AppDbContext _context;

    public TeachController(AppDbContext context) // Injecting AppDbContext (optional)
    {
        _context = context;
    }

    // Liste d'enseignants (static for this example)
    private static List<Teacher> _teachers = new List<Teacher>
    {
    };

    public IActionResult Index()
    {
        return View(_teachers);
    }
    [HttpPost]
    public IActionResult Add(Teacher teacher)
    {
        // Declencher le mecanisme de validation
        if (!ModelState.IsValid)
        {
            return View();
        }
        // Ajouter le teacher
        _context.Teachers.Add(teacher);

        // Sauvegarder les changements
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}