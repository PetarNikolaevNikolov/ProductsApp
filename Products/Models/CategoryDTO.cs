﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PNN.ProductsApp.Web.Models
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(1024, ErrorMessage = "Name must be 1024 characters or less")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}