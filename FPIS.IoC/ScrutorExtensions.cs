using Scrutor;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.IoC
{
    public static class ScrutorExtensions
    {
        public static ILifetimeSelector AsFirstInheritedInterface(this IServiceTypeSelector obj)
        {
            return obj.As(type => {
                var firstInterface = type.GetInterfaces()[0];
                return new List<Type> { firstInterface };
            });
        }
    }
}
