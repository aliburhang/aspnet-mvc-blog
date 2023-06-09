﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Security.Principal;

namespace App.Data.Entity
{
    public class CategoryPost
    {
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int PostId { get; set; }

        public Category? Category { get; set; }
    }
}

