using System.ComponentModel.DataAnnotations;
using Blog.Web.Mvc.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Mvc.Models;

public class ResetPasswordViewModel
{
    [EmailAddress]
    public string? EmailAddress { get; set; }

    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password",ErrorMessage = "Password and Confirm Password must match")]
    public string? Password2 { get; set; }

}