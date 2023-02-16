using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        // Daha sonra kendimizin ValidationAttribute ile kontrolleri sağlanacaktır.
        [Required]
        [Display(Name = "ProductName alanı zorunludur")]
        public string ProductName { get; set; }
       
        public int UnitsInstock { get; set; }
       
        public int UnitPrice { get; set; }
    }
}
