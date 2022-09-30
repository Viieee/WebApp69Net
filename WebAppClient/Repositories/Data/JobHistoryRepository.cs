using WebAppClient.Models;

namespace WebAppClient.Repositories.Data
{
    public class JobHistoryRepository : GeneralRepository<JobHistory>
    {
        public JobHistoryRepository(string request = "JobHistory/") : base(request)
        {

        }
    }
}
