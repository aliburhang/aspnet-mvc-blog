using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Web.Mvc.Data;
using Blog.Web.Mvc.Data.Entity;
using Blog.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Web.Mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDb = _context.Users.FirstOrDefault(e => e.Email == model.EmailAddress);
                if (userDb != null)
                {
                    ModelState.AddModelError("EmailAddress", "Email exists!");
                    return View(model);
                }

                if (model.Password != model.Password2)
                {
                    ModelState.AddModelError("Password", "Passwords does not match!");
                    return View(model);
                }

                var newUser = new User()
                {
                    Email = model.EmailAddress,
                    Password = model.Password,                   
                    Name = model.Name,
                    Surname = model.Surname,
                    City = model.City,
                    Phone = model.Phone,
                };
                _context.Users.Add(newUser);
                _context.SaveChanges();

                return RedirectToAction("RegisterSuccess");
            }
            else
            {
                return View(model);
            }
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

        public IActionResult RegisterSuccess() => View();

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

