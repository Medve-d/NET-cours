using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Affiche la page de connexion
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Traitement de la connexion de l'utilisateur
        [HttpPost]
        [ValidateAntiForgeryToken] // Ajout de la validation CSRF pour plus de sécurité
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User not found.");
                }
            }

            return View(model);
        }

        // Affiche la page d'enregistrement
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Traitement de l'enregistrement d'un nouvel utilisateur
        [HttpPost]
        [ValidateAntiForgeryToken] // Ajout de la validation CSRF pour plus de sécurité
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Création d'un nouvel utilisateur
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Firstname = model.Firstname, // Propriétés personnalisées
                    Lastname = model.Lastname,
                    PersonalWebSite = model.PersonalWebSite
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Connecte automatiquement l'utilisateur après l'enregistrement
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                // Gestion des erreurs d'enregistrement
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // Si la validation échoue, retourner à la vue avec les erreurs
            return View(model);
        }

        // Déconnexion de l'utilisateur
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
