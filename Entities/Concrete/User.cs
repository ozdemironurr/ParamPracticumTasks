using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User:IEntity
    {
        public int UserId { get; set; }
        // Daha sonra kendimizin ValidationAttribute ile kontrolleri sağlanacaktır.
        [Required]
        [Display(Name = "UserName alanı zorunludur")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "FirstName alanı zorunludur")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "LastName alanı zorunludur")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email alanı zorunludur")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password alanı zorunludur")]
        public string Password { get; set; }
    }
}
