using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Mvc.Models;

public class LoginViewModel
{
    [EmailAddress]
    public string? EmailAddress { get; set; }

    [DataType(DataType.Password)]
    public string? Password { get; set; }
    public bool RememberMe { get; set; }
}