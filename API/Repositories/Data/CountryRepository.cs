using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class CountryRepository : GeneralRepository<Country, int>
    {
        public CountryRepository(MyContext context) : base(context)
        {

        }
    }
}
