using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappings
{
    public class IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T),GetType());
    }
}
