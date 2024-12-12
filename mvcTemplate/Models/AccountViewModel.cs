using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class AccountViewModel
    {
        [Required(ErrorMessage = "L'email est requis.")]
        [EmailAddress(ErrorMessage = "L'email n'est pas valide.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est requis.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Le mot de passe doit contenir au moins 6 caractères.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "La confirmation du mot de passe est requise.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        public string ConfirmedPassword { get; set; }

        [Required(ErrorMessage = "Le prénom est requis.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Le nom est requis.")]
        public string Lastname { get; set; }

        [Url(ErrorMessage = "L'URL de votre site web n'est pas valide.")]
        public string PersonalWebSite { get; set; }
    }
}
