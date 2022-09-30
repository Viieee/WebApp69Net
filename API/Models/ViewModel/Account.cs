using System.Collections.Generic;

namespace API.Models.ViewModel
{
    public class Account // whats inside the token
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Role> Roles { get; set; }
    }
}
