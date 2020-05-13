using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuakeTrack.Models
{
    public class ApplicationUserProject
    {
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }

        [Column(TypeName = "int")]
        public UserProjectRole Role { get; set; }
    }
}
