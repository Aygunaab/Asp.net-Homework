using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classwork.Models
{
    public class User:IdentityUser
    {
        public string FulName { get; set; }
        public int Age{ get; set; }
        public string Position { get; set; }
    }
}
