using Microsoft.AspNetCore.Identity;

namespace Onlinevotingsystem.Models
{
   
        public class User : IdentityUser
        {
            public string FullName { get; set; }
            public bool HasVoted { get; set; } = false;
        }

    }

