using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Core.Entities.Identity
{
    public class Role : IdentityRole
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
