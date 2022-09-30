using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class JobHistory
    {
        public virtual Employee Employee { get; set; }
        [Key]
        [ForeignKey("Employee")]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Job Job { get; set; }
        [ForeignKey("Job")]
        public int? Job_Id { get; set; } // foreign key
        public virtual Department Department { get; set; }
        [ForeignKey("Department")]
        public int? Department_Id { get; set; } // foreign key 
    }
}
