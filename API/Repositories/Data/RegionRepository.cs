using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class RegionRepository : GeneralRepository<Region, int>
    {
        public RegionRepository(MyContext context) : base(context)
        {

        }
    }
}
