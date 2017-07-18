using WebApplication2.Persistence.Repositories;

namespace WebApplication2.Models.Repositories
{
    // Waarom zou ik hier een DTO gebruiken?
    public class CompanyRepo : Repository<Company>, ICompanyRepo
    {
        public CompanyRepo(ApplicationDbContext context) : base(context)
        {
        }

        public bool WordConsistsOfMinFourLetters(string text)
        {
            return text.Length >= 4;
        }

        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;
    }
}