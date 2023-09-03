using System.Reflection;

namespace awesomedi.DependencyInjection
{
    public class DiContainer
    {
        private readonly IList<ServiceDescriptior> _registeredServices;

        public DiContainer(IList<ServiceDescriptior> services)
        {
            _registeredServices = services;
        }


        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        public object? GetService(Type type)
        {
            var requiredService = _registeredServices.SingleOrDefault(s => s.ServiceType == type);
            if (requiredService == null)
            {
                throw new Exception($"service of type {type.Name} is not registered.");
            }

            if (requiredService.Implementation != null)
            {
                return requiredService.Implementation;
            }

            var actualType = requiredService.ImplementationType ?? requiredService.ServiceType;

            if (actualType.IsAbstract || actualType.IsInterface)
            {
                throw new Exception("Cannot instantiate abstract classes or interface");
            }

            var parameters = GetConstructorParameterTypes(actualType);

            // create implementation of concrete type
            var implementation = Activator.CreateInstance(actualType, parameters);
            if (requiredService.Lifetime == ServiceLifetime.Singleton)
            {
                // store it in list if its a singleton
                requiredService.Implementation = implementation;
            }

            return implementation;
        }

        public object?[] GetConstructorParameterTypes(Type targetType)
        {
            ConstructorInfo[] constructorInfos = targetType.GetConstructors();

            if (constructorInfos.Length == 0)
            {
                return null;
            }

            var constructor = constructorInfos.FirstOrDefault();

            if (constructor == null)
            {
                return null;
            }

            return constructor.GetParameters().Select(param => GetService(param.ParameterType)).ToArray();
        }
    }
}