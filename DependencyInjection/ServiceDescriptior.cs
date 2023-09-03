using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace awesomedi.DependencyInjection
{
    public class ServiceDescriptior
    {
        public Type ServiceType { get; }
        public Type? ImplementationType { get; }
        public object? Implementation { get; internal set; }

        public ServiceLifetime Lifetime { get; }

        public ServiceDescriptior(object serviceImplementation, ServiceLifetime lifetime)
        {
            Implementation = serviceImplementation;
            ServiceType = serviceImplementation.GetType();
            Lifetime = lifetime;
        }

        public ServiceDescriptior(Type serviceType, ServiceLifetime lifetime)
        {
            ServiceType = serviceType;
            Lifetime = lifetime;
        }

        public ServiceDescriptior(Type serviceType, Type implementationType, ServiceLifetime lifetime)
        {
            ServiceType = serviceType;
            Lifetime = lifetime;
            ImplementationType = implementationType;
        }

    }
}