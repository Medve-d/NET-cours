using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using mvcTemplate.Data;
namespace mvcTemplate.Models;

public class Teacher
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Lastname { get; set; }
    [Required]
    public string Firstname { get; set; }
}