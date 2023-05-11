using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Security.Principal;
using Blog.Web.Mvc.Data.Entity.Abstract;

namespace Blog.Web.Mvc.Data.Entity
{
    public class User : AuditEntity
    {
        public int Id { get; set; }

        [Required, Column(TypeName = "varchar(200)")]
        public string? Email { get; set; }

        [Required, Column(TypeName = "nvarchar(100)")]
        public string? Password { get; set; }

        [Required, Column(TypeName = "nvarchar(100)")]
        public string? Name { get; set; }

        [Required, Column(TypeName = "nvarchar(100)")]
        public string? City { get; set; }

        [Required, Column(TypeName = "varchar(20)")]
        public string? Phone { get; set; }
    }
}

