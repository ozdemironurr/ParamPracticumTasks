using AutoMapper;
using Core.Entities.Abstract;
using Core.Mappings;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Quaries.Model
{
    public class ProductDto : IMapFrom<Product>,IDto
    {
        public string ProductId { get; set; }
        public string UrunAdı { get; set; }
        public string UnitPrice { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDto>()
                .ForMember(c => c.ProductId, opt => opt.MapFrom(d => d.ProductId))
                .ForMember(c => c.UrunAdı, opt => opt.MapFrom(d => d.ProductName))
                .ForMember(c => c.ProductId, opt => opt.MapFrom(d => d.ProductId));

        }
    }
    
}
