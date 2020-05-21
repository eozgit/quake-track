using System;
using System.Collections.Generic;

namespace QuakeTrack.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<UserViewModel> Users { get; set; }
        public virtual ICollection<IssueViewModel> Issues { get; set; }
    }
}
