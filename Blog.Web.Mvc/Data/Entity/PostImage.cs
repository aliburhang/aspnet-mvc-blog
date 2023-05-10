using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Security.Principal;

namespace Blog.Web.Mvc.Data.Entity
{
    public class PostImage
    {
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? ImagePath { get; set; }
    }
}

