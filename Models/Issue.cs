using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuakeTrack.Models
{
    public class Issue
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Column(TypeName = "nvarchar(60)")]
        public string Summary { get; set; }

        [StringLength(300)]
        [Column(TypeName = "nvarchar(300)")]
        public string Description { get; set; }

        [Column(TypeName = "int")]
        public IssueType IssueType { get; set; }

        public string AssigneeId { get; set; }
        public virtual ApplicationUser Assignee { get; set; }

        public int Storypoints { get; set; }

        [Column(TypeName = "int")]
        public IssueStatus Status { get; set; }

        [Column(TypeName = "int")]
        public Priority Priority { get; set; }

        public virtual ICollection<IssueLink> LinkedAsObject { get; set; }
        public virtual ICollection<IssueLink> LinkedAsSubject { get; set; }
    }
}
