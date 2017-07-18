using System.Collections.Generic;

namespace WebApplication2.Models
{
    public class Company : Entity
    {
            public string Name { get; set; }

            public virtual List<Employee> Employee { get; set; }
        
    }
}
