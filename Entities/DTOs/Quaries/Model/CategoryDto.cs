using AutoMapper;
using Core.Mappings;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Quaries.Model
{
    public class CategoryDto:IMapFrom<Category>
    {
        public string CategoryName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryDto>()
                .ForMember(c => c.CategoryName, opt => opt.MapFrom(d => d.CategoryName));
              //.ForMember(c => c.CategoryId, opt => opt.MapFrom(d => d.CategoryId)) şeklinde ekleme yapılabilir.
        }
    }
   
}
