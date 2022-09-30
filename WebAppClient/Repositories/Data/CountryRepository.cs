using WebAppClient.Models;

namespace WebAppClient.Repositories.Data
{
    public class CountryRepository : GeneralRepository<Country>
    {
        public CountryRepository(string request = "Country/") : base(request)
        {

        }
    }
}
