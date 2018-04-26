using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class User : IdentityUser
    {
        public User()
        {
            CreatedAt = UpdatedAt = DateTime.Now;
        }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
