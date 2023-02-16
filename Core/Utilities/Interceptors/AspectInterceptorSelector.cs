﻿
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();// class'ın attribute'larını oku
                
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);//Methotların attribute'larını oku
               
            classAttributes.AddRange(methodAttributes);// onları listeye koy
           // classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));  (Loglama altyapısını yaptıktan sonra default eklemek için kullanılır.

            return classAttributes.OrderBy(x => x.Priority).ToArray();// öncelik değerine göre sırala
        }
    }
}
