using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Security.Principal;

namespace Blog.Web.Mvc.Data.Entity
{
    public class Setting
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required, Column(TypeName = "nvarchar(200)")]
        public string? Name { get; set; }

        [Required, Column(TypeName = "nvarchar(400)")]
        public string? Value { get; set; }
    }
}

