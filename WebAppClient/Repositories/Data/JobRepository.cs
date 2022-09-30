using WebAppClient.Models;

namespace WebAppClient.Repositories.Data
{
    public class JobRepository : GeneralRepository<Job>
    {
        public JobRepository(string request = "Job/") : base(request)
        {

        }
    }
}
