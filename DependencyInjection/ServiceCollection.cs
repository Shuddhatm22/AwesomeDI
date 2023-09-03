using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace awesomedi.DependencyInjection
{
    public class ServiceCollection
    {
        private List<ServiceDescriptior> _serviceDescriptors = new List<ServiceDescriptior>();
        public DiContainer BuildContainer()
        {
            return new DiContainer(_serviceDescriptors);
        }

        public void RegisterSingleton<Tservice>()
        {
            _serviceDescriptors.Add(new ServiceDescriptior(typeof(Tservice), ServiceLifetime.Singleton));
        }

        public void RegisterSingleton<Tservice>(Tservice service)
        {
            _serviceDescriptors.Add(new ServiceDescriptior(service, ServiceLifetime.Singleton));
        }

        public void RegisterTransient<Tservice>()
        {
            _serviceDescriptors.Add(new ServiceDescriptior(typeof(Tservice), ServiceLifetime.Transient));
        }

        internal void RegisterSingleton<Tservice, Timplementation>() where Timplementation : Tservice
        {
            _serviceDescriptors.Add(new ServiceDescriptior(typeof(Tservice), typeof(Timplementation), ServiceLifetime.Singleton));
        }

        internal void RegisterTransient<Tservice, Timplementation>() where Timplementation : Tservice
        {
            _serviceDescriptors.Add(new ServiceDescriptior(typeof(Tservice), typeof(Timplementation), ServiceLifetime.Transient));
        }
    }
}