using System;

namespace QuakeTrack.ViewModels
{
    public class IssueViewModel
    {
        public int? Id { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public string IssueType { get; set; }

        public virtual string AssigneeId { get; set; }

        public int? Storypoints { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public int? Index { get; set; }
    }
}
