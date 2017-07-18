namespace WebApplication2.Models.Services
{
    public class CompanyService : IService
    {
        public bool WordConsistsOfMinFourLetters(string text)
        {
            return text.Length >= 4;
        }
    }
}