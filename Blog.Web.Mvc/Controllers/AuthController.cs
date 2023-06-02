using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Web.Mvc.Controllers
{
    public class AuthController : Controller
    {
        // GET: /<controller>/
        public IActionResult Register()
        {
            return View();
        }

        // /auth/login
        public IActionResult Login(string? redirectUrl)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (model.EmailAddress == "abg@gmail.com" &&
                model.Password == "123")
            {
                var cookieOptions = new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(7)
                };
                Response.Cookies.Append("Username", AuthHelper.Base64Encode(model.EmailAddress), cookieOptions);
                Response.Cookies.Append("IsLoggedIn", AuthHelper.Base64Encode("1"), cookieOptions);

                return Redirect("/");
            }
            else
            {
                ViewBag.Message = "Username or Password is wrong!";
                return View(model);
            }
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("Username");
            Response.Cookies.Delete("IsLoggedIn");

            return Redirect("/");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}

