using Blog.Web.Mvc.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Mvc.Models;

public class ForgotPasswordViewModel
{
    public string? EmailAddress { get; set; }
    public string? Password { get; set; }
    public string? Password2 { get; set; }

}