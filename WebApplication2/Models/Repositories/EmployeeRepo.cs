using WebApplication2.Persistence.Repositories;

namespace WebApplication2.Models.Repositories
{
    // Waarom zou ik hier een DTO gebruiken?
    public class EmployeeRepo : Repository<Employee>, IEmployeeRepo
    {
        public EmployeeRepo(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;
    }
}