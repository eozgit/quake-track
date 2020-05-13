using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuakeTrack.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<ApplicationUserProject> UserProjects { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
    }
}
