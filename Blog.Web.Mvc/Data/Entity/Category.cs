using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Security.Principal;

namespace Blog.Web.Mvc.Data.Entity
{
    public class Category
    {
        public Category()
        {
            Posts = new List<Post>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(120)")]
        public string? Slug { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? Description { get; set; }

        public List<Post> Posts { get; set; }
    }
}

