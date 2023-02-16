﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        // Daha sonra kendimizin ValidationAttribute ile kontrolleri sağlanacaktır.
        [Required]
        [Display(Name = "CategoryName alanı zorunludur")]
        public string CategoryName { get; set; }
    }
}
