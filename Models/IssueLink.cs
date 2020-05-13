using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuakeTrack.Models
{
    public class IssueLink
    {
        public int? ObjectId { get; set; }

        [InverseProperty("LinkedAsObject")]
        public virtual Issue Object { get; set; }

        public int? SubjectId { get; set; }

        [InverseProperty("LinkedAsSubject")]
        public virtual Issue Subject { get; set; }

        [Column(TypeName = "int")]
        public IssueRelation Relation { get; set; }
    }
}
