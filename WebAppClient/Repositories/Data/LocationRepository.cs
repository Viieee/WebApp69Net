using WebAppClient.Models;

namespace WebAppClient.Repositories.Data
{
    public class LocationRepository : GeneralRepository<Location>
    {
        public LocationRepository(string request = "Location/") : base(request)
        {

        }
    }
}
