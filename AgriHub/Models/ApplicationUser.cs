using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriHub.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserAccount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
