using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class LocationRepository : GeneralRepository<Location, int>
    {
        public LocationRepository(MyContext context) : base(context)
        {

        }
    }
}
