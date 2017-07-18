namespace WebApplication2.Models
{
    public class Employee : Entity
    {
        public string Name { get; set; }

        public Company Company { get; set; }
    }
}