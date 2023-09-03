using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace awesomedi.DependencyInjection
{
    public class SomeService1 : ISomeService
    {
        private readonly IRandomGuidProvider _randomGuidProvider;

        // private readonly Guid RandomGuid = Guid.NewGuid();

        public SomeService1(IRandomGuidProvider randomGuidProvider)
        {
            _randomGuidProvider = randomGuidProvider;
        }

        public void PrintSomething()
        {
            Console.WriteLine($"from some service {_randomGuidProvider.RandomGuid}");
        }
    }
}