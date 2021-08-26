using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HelloWorldWeb.Models
{
    public class IdentityUserWithRole : IdentityUser
    {
        public string Role { get; set; }
    }
}
