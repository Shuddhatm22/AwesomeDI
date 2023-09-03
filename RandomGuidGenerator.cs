using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace awesomedi
{
    public class RandomGuidGenerator
    {
        public Guid RandomGuid { get; set; } = Guid.NewGuid();
    }
}