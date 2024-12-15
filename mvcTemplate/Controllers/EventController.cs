using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.Data;
using System.Linq;
using System.Threading.Tasks;
public class EventController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public EventController(AppDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        var events = _context.Events.ToList();
        return View(events);
    }


    public IActionResult Details(int id)
    {
        var eventDetails = _context.Events.Find(id);
        return View(eventDetails);
    }


    [Authorize]
    public IActionResult Add()
    {
        var currentUser = _userManager.GetUserAsync(User).Result;
        
        if (currentUser != null && currentUser is Teacher)
        {
            return View(); 
        }
        else
        {
            return RedirectToAction("AccessDenied", "Account"); 
        }
    }

    [Authorize]
    public IActionResult Edit(int id)
    {
        var currentUser = _userManager.GetUserAsync(User).Result;
        
        if (currentUser != null && currentUser is Teacher)
        {
            var eventToEdit = _context.Events.Find(id);
            return View(eventToEdit);
        }
        else
        {
            return RedirectToAction("AccessDenied", "Account");
        }
    }

    [Authorize]
    public IActionResult Delete(int id)
    {
        var currentUser = _userManager.GetUserAsync(User).Result;
        
        if (currentUser != null && currentUser is Teacher)
        {
            var eventToDelete = _context.Events.Find(id);
            _context.Events.Remove(eventToDelete);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return RedirectToAction("AccessDenied", "Account");
        }
    }
}
