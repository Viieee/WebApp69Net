using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppClient.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Region Region { get; set; }
        [ForeignKey("Region")]
        public int? Region_Id { get; set; } // foreign key
    }
}
