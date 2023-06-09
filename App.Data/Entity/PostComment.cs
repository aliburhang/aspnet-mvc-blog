﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Security.Principal;
using App.Data.Entity.Abstract;

namespace App.Data.Entity
{
    public class PostComment : AuditEntity
    {
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string? Comment { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public User? User { get; set; }

    }
}

