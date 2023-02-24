using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
       
        [Required]
        [Display(Name = "ProductName alanı zorunludur")]
        public string ProductName { get; set; }
       
        public int UnitsInStock { get; set; }
       
        public int UnitPrice { get; set; }
    }
}
