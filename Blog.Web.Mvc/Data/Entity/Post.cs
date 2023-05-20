using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Security.Principal;
using Blog.Web.Mvc.Data.Entity.Abstract;

namespace Blog.Web.Mvc.Data.Entity
{
    public class Post : AuditEntity
{
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required, Column(TypeName = "nvarchar(200)")]
        public string? Title { get; set; }

        [Required]
        public string? Content { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        //public User? User { get; set; }

        public List<PostImage>? PostImage { get; set; }

        public List<PostComment>? PostComment { get; set; }


    }
}

