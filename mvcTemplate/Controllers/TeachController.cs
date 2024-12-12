using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;
using System.Linq;

public class TeacherController : Controller
{
    // Champ privé pour stocker le DbContext
    private readonly AppDbContext _context;

    // Constructeur
    public TeacherController(AppDbContext context)
    {
        _context = context;
    }

    // Afficher la liste des enseignants
    public IActionResult Index()
    {
        // Récupérer les enseignants depuis la base de données
        var teachers = _context.Teachers.ToList();
        return View(teachers);
    }

    // Ajouter un enseignant
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    // Ajouter un enseignant en POST
    [HttpPost]
    public IActionResult Add(Teacher teacher)
    {
        if (ModelState.IsValid)
        {
            // Ajouter l'enseignant dans la base de données
            _context.Teachers.Add(teacher);

            // Sauvegarder les changements dans la base de données
            _context.SaveChanges();

            // Rediriger vers la liste des enseignants
            return RedirectToAction("Index");
        }

        // Si le modèle est invalide, retourner la vue de formulaire
        return View(teacher);
    }

    // Afficher les détails d'un enseignant
    [HttpGet]
    public IActionResult ShowDetails(string id) // Utilisation de 'string' pour l'ID
    {
        // Chercher l'enseignant par son ID (id est de type string)
        var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
        if (teacher == null)
        {
            return NotFound(); // Si l'enseignant n'existe pas, afficher une erreur 404
        }

        // Passer l'enseignant à la vue de détail
        return View(teacher);
    }

    // Supprimer un enseignant
    [HttpPost]
    public IActionResult Delete(string id) // Utilisation de 'string' pour l'ID
    {
        // Chercher l'enseignant à supprimer
        var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
        if (teacher == null)
        {
            return NotFound(); // Si l'enseignant n'existe pas, afficher une erreur 404
        }

        // Supprimer l'enseignant
        _context.Teachers.Remove(teacher);

        // Sauvegarder les changements
        _context.SaveChanges();

        // Rediriger vers la liste des enseignants
        return RedirectToAction("Index");
    }
}
