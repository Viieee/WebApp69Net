using WebAppClient.Models;

namespace WebAppClient.Repositories.Data
{
    public class RegionRepository : GeneralRepository<Region>
    {
        public RegionRepository(string request ="Region/") : base(request)
        {

        }
    }
}
