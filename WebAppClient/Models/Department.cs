using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebAppClient.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Location Location { get; set; }
        [ForeignKey("Location")]
        public int? Location_Id { get; set; } // foreign key
    }
}
