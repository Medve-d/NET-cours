namespace mvc.Models;

public class Student
{

    // ecrire des variables d'instance

    [Required]
    public int Id { get; set; }

    [StringLength(20, MinimumLength(5))]
    public string Nom { get; set; }
    public int Age { get; set; }
    public string Specialite { get; set; }
    [Required]
    [EmailAddress]

    public string Email { get; set; }

    [Required]
    [Url]

    public string PersonalWebSite { get; set; }

}