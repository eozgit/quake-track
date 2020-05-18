using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using QuakeTrack.Data;
using QuakeTrack.Models;

namespace QuakeTrack.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private ApplicationDbContext db;

        public ProjectsController(ApplicationDbContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public virtual ActionResult<IEnumerable<Project>> GetProjects([FromQuery] int? limit = 10, [FromQuery] int? skip = 0)
        {
            var query = db.Project.AsQueryable();
            query = query.Skip((int)skip * (int)limit);
            query = query.Take((int)limit);
            return new ObjectResult(query.ToList());
        }

        [HttpPost]
        public virtual IActionResult CreateProject([FromBody] Project project)
        {
            db.Project.Add(project);
            db.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpGet]
        [Route("/projects/{projectId}")]
        public virtual ActionResult<Project> GetProject([FromRoute][Required] int? projectId)
        {
            return new ObjectResult(db.Project.Find(projectId));
        }

        [HttpDelete]
        [Route("/projects/{projectId}")]
        public virtual ActionResult<Project> DeleteProject([FromRoute][Required] int? projectId)
        {
            var project = db.Project.Find(projectId);
            project.IsDeleted = true;
            db.SaveChangesAsync();
            return new ObjectResult(project);
        }

        [HttpPatch]
        [Route("/projects/{projectId}")]
        public virtual ActionResult<Project> UpdateProject([FromBody] Project patch, [FromRoute][Required] int? projectId)
        {
            var project = db.Project.Find(projectId);

            project.Name = patch.Name;
            project.Description = patch.Description;

            db.SaveChangesAsync();
            return new ObjectResult(project);
        }

        [HttpGet]
        [Route("/projects/{projectId}/users")]
        public virtual ActionResult<IEnumerable<ApplicationUser>> GetUsers([FromRoute][Required] int? projectId)
        {
            var project = db.Project
                .Include(p => p.UserProjects)
                    .ThenInclude(link => link.User)
                .FirstOrDefault(p => p.Id == projectId);
            var users = project.UserProjects
                .Select(link => link.User).ToList();
            var safe = users.Select(user => new
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            });
            return new ObjectResult(safe);
        }

        [HttpPatch]
        [Route("/projects/{projectId}/users")]
        public virtual ActionResult AddUser([FromBody] ApplicationUser userInfo, [FromRoute][Required] int? projectId)
        {
            var project = db.Project
                .Include(project => project.UserProjects)
                .FirstOrDefault(project => project.Id == projectId);

            var user = db.Users.Where(u => u.Email == userInfo.Email).FirstOrDefault();
            if (user != null)
            {
                var link = new ApplicationUserProject
                {
                    User = user,
                    Project = project,
                    Role = UserProjectRole.Contributor
                };
                project.UserProjects.Add(link);
                db.SaveChangesAsync();
            }

            return new ObjectResult(new
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            });
        }

        [HttpDelete]
        [Route("/projects/{projectId}/users/{userId}")]
        public virtual IActionResult RemoveUser([FromRoute][Required] int? projectId, [FromRoute][Required] string userId)
        {
            var project = db.Project
                .Include(p => p.UserProjects)
                    .ThenInclude(link => link.User)
                .FirstOrDefault(p => p.Id == projectId);

            var user = project.UserProjects.SingleOrDefault(link => link.User.Id == userId);
            if (user != null)
            {
                project.UserProjects.Remove(user);
                db.SaveChangesAsync();
            }

            return Ok("Removed");
        }

        [HttpGet]
        [Route("/projects/{projectId}/issues")]
        public virtual IActionResult GetIssues([FromRoute][Required] int? projectId)
        {
            var project = db.Project
                .Include(p => p.Issues)
                .SingleOrDefault(p => p.Id == projectId);
            return new ObjectResult(project.Issues);
        }

        [HttpPost]
        [Route("/projects/{projectId}/issues")]
        public virtual IActionResult CreateIssue([FromBody] Issue issue, [FromRoute][Required] int? projectId)
        {
            var project = db.Project
                .Include(p => p.Issues)
                .SingleOrDefault(p => p.Id == projectId);
            project.Issues.Add(issue);
            db.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpGet]
        [Route("/projects/{projectId}/issues/{issueId}")]
        public virtual IActionResult GetIssue([FromRoute][Required] int? projectId, [FromRoute][Required] int? issueId)
        {
            var project = db.Project
                .Include(p => p.Issues)
                .SingleOrDefault(p => p.Id == projectId);
            var issue = project.Issues.SingleOrDefault(i => i.Id == issueId);
            return new ObjectResult(issue);
        }

        [HttpPatch]
        [Route("/projects/{projectId}/issues/{issueId}")]
        public virtual IActionResult UpdateIssue([FromBody] Issue patch, [FromRoute][Required] int? projectId, [FromRoute][Required] int? issueId)
        {
            var project = db.Project
                .Include(p => p.Issues)
                .SingleOrDefault(p => p.Id == projectId);
            var issue = project.Issues.SingleOrDefault(i => i.Id == issueId);

            issue.Summary = patch.Summary;
            issue.Description = patch.Description;
            issue.IssueType = patch.IssueType;
            issue.Assignee = patch.Assignee;
            issue.Storypoints = patch.Storypoints;
            issue.Status = patch.Status;
            issue.Priority = patch.Priority;

            db.SaveChangesAsync();

            return new ObjectResult(issue);
        }
    }
}
