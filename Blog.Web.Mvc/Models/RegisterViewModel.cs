using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Mvc.Models;

public class RegisterViewModel
{
    public string? Name { get; set; }
    public string? Surname { get; set; }

    [EmailAddress]
    public string? EmailAddress { get; set; }

    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "Password and Confirm Password must match")]
    public string? Password2 { get; set; }
    public string? City { get; set; }
    public string? Phone { get; set; }

}