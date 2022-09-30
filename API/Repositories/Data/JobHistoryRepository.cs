using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class JobHistoryRepository : GeneralRepository<JobHistory, int>
    {
        public JobHistoryRepository(MyContext context) : base(context)
        {

        }
    }
}
