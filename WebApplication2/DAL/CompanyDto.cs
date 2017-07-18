using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.DAL
{
    public class CompanyDto
    {
        public string Name { get; set; }
        public virtual List<Employee> Employee { get; set; }
    }
}