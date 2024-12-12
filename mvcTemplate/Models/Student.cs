using System.ComponentModel.DataAnnotations;

public class Student
{
    [Key]
    public int Id { get; set; }
    public string Nom { get; set; }
    public int Age { get; set; }
    public string Specialite { get; set; }
}
