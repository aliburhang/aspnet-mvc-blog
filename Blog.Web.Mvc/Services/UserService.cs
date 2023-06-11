using System;
using System.Net.Mail;
using Blog.Web.Mvc.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Mvc.Services
{
    public class UserService
    {
        private readonly EmailService _emailService;

        public UserService(EmailService emailService)
        {
            _emailService = emailService;
        }

        public void SendResetEmail(string email, string EmailAddress)
        {
            var mailLink = "https://localhost:7018/Auth/ResetPassword/?EmailAddress=" + EmailAddress;

            _emailService.Send(email, "BlogWebMvc - Reset Password", @$"
                <style>body {{ font-family: Arial; font-size: 16px; }}</style>
                <h1>BlogWebMvc</h1>
                <p>Please click the link below and reset your password.</p>
                <p><a href='{mailLink}'>Aktive Et</a>
            ");
        }

    }
}

