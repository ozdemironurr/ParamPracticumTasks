﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            ApplyMappingFromAssembly(Assembly.GetExecutingAssembly());

        }
        private void ApplyMappingFromAssembly(Assembly assembly)
        { 
            var types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i => i.IsGenericType&& i.GetGenericTypeDefinition()==typeof(IMapFrom<>))).ToList();
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methotInfo = type.GetMethod("Mapping");
                methotInfo?.Invoke(instance, new object[] { this });
            }



        }
    }
}
