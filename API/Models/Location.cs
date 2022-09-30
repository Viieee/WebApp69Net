using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public virtual Country Country { get; set; }
        [ForeignKey("Country")]
        public int? Country_Id { get; set; } // foreign key
    }
}
