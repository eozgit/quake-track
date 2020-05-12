using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuakeTrack.Models
{
    public class Project
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Column(TypeName = "nvarchar(60)")]
        public string Name { get; set; }

        [StringLength(300)]
        [Column(TypeName = "nvarchar(300)")]
        public string Description { get; set; }

        public ICollection<ApplicationUserProject> UserProjects { get; set; }
    }
}
