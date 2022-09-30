using System.ComponentModel.DataAnnotations;

namespace WebAppClient.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
    }
}
