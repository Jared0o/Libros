using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Core.Entities.Identity
{
    public class User : IdentityUser
    {
        public ICollection<UserRole> UserRoles { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
