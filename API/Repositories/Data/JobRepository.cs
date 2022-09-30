using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class JobRepository : GeneralRepository<Job, int>
    {
        public JobRepository(MyContext context) : base(context)
        {

        }
    }
}
