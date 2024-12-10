using System.ComponentModel.DataAnnotations;

namespace mvcTemplate.Models;

public class Student
{

    // ecrire des variables d'instance

    public int Id { get; set; }
    [Required(ErrorMessage = "Le nom de l'étudiant est obligatoire")]
    [Display(Name = "Nom de l'étudiant")]
    public string Nom { get; set; }
    [Required(ErrorMessage = "L'âge' de l'étudiant est obligatoire")]
    [Display(Name = "L'âge de l'étudiant")]
    public int Age { get; set; }
    [Required(ErrorMessage = "La spéialité de l'étudiant est obligatoire")]
    [Display(Name = "Spécialité de l'étudiant")]
    public string Specialite { get; set; }


}