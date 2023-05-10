using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Security.Principal;

namespace Blog.Web.Mvc.Data.Entity
{
    public class Page
    {
        public int Id { get; set; }

        [Required, Column(TypeName = "nvarchar(100)")]
        public string? Title { get; set; }

        [Required]
        public string? Content { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}

