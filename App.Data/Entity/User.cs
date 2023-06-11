using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Security.Principal;
using App.Data.Entity.Abstract;

namespace App.Data.Entity
{
    public class User : AuditEntity
    {
        public int Id { get; set; }

        [Required, Column(TypeName = "varchar(200)")]
        public string Email { get; set; }

        [Required, Column(TypeName = "nvarchar(100)")]
        public string? Password { get; set; }

        [Required, Column(TypeName = "nvarchar(100)")]
        public string? Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Surname { get; set; }

        [Required, Column(TypeName = "nvarchar(100)")]
        public string? City { get; set; }

        [Required, Column(TypeName = "varchar(20)")]
        public string? Phone { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string? Definition { get; set; }

        //public List<Post>? Post { get; set; }

        public List<PostComment>? PostComment { get; set; }

        [MaxLength(100)]
        public string? ActivationCode { get; set; }

        public bool IsActive { get; set; } = false;

        public string? Roles { get; set; }
    }
}

