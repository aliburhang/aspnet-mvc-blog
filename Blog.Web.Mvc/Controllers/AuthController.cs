using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Blog.Web.Mvc.Data;
using Blog.Web.Mvc.Data.Entity;
using Blog.Web.Mvc.Models;
using Blog.Web.Mvc.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Web.Mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserService _userService;

        public AuthController(AppDbContext context, UserService userService)
        {
            _context = context;
            _userService = userService;
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
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(e => e.Email == model.EmailAddress);

                if (user == null)
                {
                    ModelState.AddModelError("EmailAddress", "Email could not be found!");
                    return View(model);
                }

                //if (user.IsActive == false)
                //{
                //    ModelState.AddModelError("EmailAddress", "User is not active!");
                //    return View(model);
                //}

                if (user.Password != model.Password)
                {
                    ModelState.AddModelError("Password", "Password is wrong!");
                    return View(model);
                }

                // Kimlik Bilgileri
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Name ?? ""),
                        new Claim(ClaimTypes.GivenName, user.Name ?? ""),
                        new Claim(ClaimTypes.Surname, user.Surname ?? ""),
                        new Claim(ClaimTypes.Email, model.EmailAddress)
                    };

                if (!string.IsNullOrEmpty(user.Roles))
                {
                    string[] roles = user.Roles.Split(',');
                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }
                }

                // Kimlik
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Cüzdan
                var principal = new ClaimsPrincipal(identity);

                var props = new AuthenticationProperties()
                {
                    IsPersistent = model.RememberMe,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(15),
                };

                await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        principal,
                        props
                    );

                return Redirect(returnUrl != "" ? returnUrl : "/");
            }

            return View(model);
        }

        public IActionResult RegisterSuccess() => View();

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(e => e.Email == model.EmailAddress);

                if (user == null)
                {
                    ModelState.AddModelError("EmailAddress", "Email could not be found!");
                    return View(model);
                }

                _userService.SendResetEmail(model.EmailAddress);

                return RedirectToAction("ForgotPasswordSuccess");
            }
            else
            {
                return View(model);
            }    
        }

        public IActionResult ForgotPasswordSuccess() => View();

        public IActionResult ResetPassword() => View();

        [HttpPost]
        public IActionResult ResetPassword(ForgotPasswordViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(e => e.Email == model.EmailAddress);

                if (user == null)
                {
                    ModelState.AddModelError("EmailAddress", "Email could not be found!");
                    return View(model);
                }

                if (model.Password != model.Password2)
                {
                    ModelState.AddModelError("Password", "Passwords does not match!");
                    return View(model);
                }

                if (user.Password == model.Password)
                {
                    ModelState.AddModelError("Password", "New password should be different than the old one!");
                    return View(model);
                }

                user.Password = model.Password;
                _context.SaveChanges();

                return RedirectToAction("ResetPasswordSuccess");

            }

            return View(model);
    }

        public IActionResult ResetPasswordSuccess() => View();

    }
}

