using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using QuakeTrack.Data;
using QuakeTrack.Models;
using QuakeTrack.ViewModels;

namespace QuakeTrack.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private ApplicationDbContext db;
        private IMapper mapper;

        public ProjectsController(ApplicationDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }

        [HttpGet]
        [Route("/api/projects")]
        public virtual IActionResult GetProjects([FromQuery] int limit = 10, [FromQuery] int skip = 0)
        {
            var query = db.Project.AsQueryable();
            query = query.Skip(skip * limit);
            query = query.Take(limit);
            var projects = query.Select(p => mapper.Map<ProjectViewModel>(p));
            return new ObjectResult(projects);
        }

        [HttpPost]
        [Route("/api/projects")]
        public virtual IActionResult CreateProject([FromBody] ProjectViewModel project)
        {
            db.Project.Add(mapper.Map<Project>(project));
            db.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpGet]
        [Route("/api/projects/{projectId}")]
        public virtual IActionResult GetProject([FromRoute][Required] int? projectId)
        {
            return new ObjectResult(mapper.Map<ProjectViewModel>(db.Project.Find(projectId)));
        }

        [HttpDelete]
        [Route("/api/projects/{projectId}")]
        public virtual IActionResult DeleteProject([FromRoute][Required] int? projectId)
        {
            var project = db.Project.Find(projectId);
            project.IsDeleted = true;
            db.SaveChangesAsync();
            return new ObjectResult(mapper.Map<ProjectViewModel>(project));
        }

        [HttpPatch]
        [Route("/api/projects/{projectId}")]
        public virtual IActionResult UpdateProject([FromBody] ProjectViewModel patch, [FromRoute][Required] int? projectId)
        {
            var project = db.Project.Find(projectId);

            project.Name = patch.Name;
            project.Description = patch.Description;

            db.SaveChangesAsync();
            return new ObjectResult(mapper.Map<ProjectViewModel>(project));
        }

        [HttpGet]
        [Route("/api/projects/{projectId}/users")]
        public virtual IActionResult GetUsers([FromRoute][Required] int? projectId)
        {
            var project = db.Project
                .Include(p => p.UserProjects)
                    .ThenInclude(link => link.User)
                .FirstOrDefault(p => p.Id == projectId);
            var users = project.UserProjects
                .Select(link => link.User);
            return new ObjectResult(users.Select(user => mapper.Map<UserViewModel>(user)));
        }

        [HttpPatch]
        [Route("/api/projects/{projectId}/users")]
        public virtual IActionResult AddUser([FromBody] ApplicationUser userInfo, [FromRoute][Required] int? projectId)
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

            return new ObjectResult(mapper.Map<UserViewModel>(user));
        }

        [HttpDelete]
        [Route("/api/projects/{projectId}/users/{userId}")]
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
        [Route("/api/projects/{projectId}/issues")]
        public virtual IActionResult GetIssues([FromRoute][Required] int? projectId)
        {
            var project = db.Project
                .Include(p => p.Issues)
                .SingleOrDefault(p => p.Id == projectId);
            var issues = project.Issues.Select(issue => mapper.Map<IssueViewModel>(issue));
            return new ObjectResult(issues);
        }

        [HttpPost]
        [Route("/api/projects/{projectId}/issues")]
        public virtual IActionResult CreateIssue([FromBody] IssueViewModel issue, [FromRoute][Required] int? projectId)
        {
            var model = mapper.Map<Issue>(issue);
            var project = db.Project
                .Include(p => p.Issues)
                .SingleOrDefault(p => p.Id == projectId);
            project.Issues.Add(model);
            db.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpGet]
        [Route("/api/projects/{projectId}/issues/{issueId}")]
        public virtual IActionResult GetIssue([FromRoute][Required] int? projectId, [FromRoute][Required] int? issueId)
        {
            var project = db.Project
                .Include(p => p.Issues)
                .SingleOrDefault(p => p.Id == projectId);
            var issue = project.Issues.SingleOrDefault(i => i.Id == issueId);
            return new ObjectResult(mapper.Map<IssueViewModel>(issue));
        }

        [HttpPatch]
        [Route("/api/projects/{projectId}/issues/{issueId}")]
        public virtual IActionResult UpdateIssue([FromBody] IssueViewModel patch, [FromRoute][Required] int? projectId, [FromRoute][Required] int? issueId)
        {
            var model = mapper.Map<Issue>(patch);

            var project = db.Project
                .Include(p => p.Issues)
                .SingleOrDefault(p => p.Id == projectId);
            var issue = project.Issues.SingleOrDefault(i => i.Id == issueId);

            issue.Summary = model.Summary;
            issue.Description = model.Description;
            issue.IssueType = model.IssueType;
            issue.Assignee = model.Assignee;
            issue.Storypoints = model.Storypoints;
            issue.Status = model.Status;
            issue.Priority = model.Priority;

            db.SaveChangesAsync();

            return new ObjectResult(mapper.Map<IssueViewModel>(issue));
        }

        [HttpDelete]
        [Route("/api/projects/{projectId}/issues/{issueId}")]
        public virtual IActionResult DeleteIssue([FromRoute][Required] int? projectId, [FromRoute][Required] int? issueId)
        {
            var project = db.Project
                .Include(p => p.Issues)
                .SingleOrDefault(p => p.Id == projectId);
            var issue = project.Issues.SingleOrDefault(i => i.Id == issueId);
            if (issue != null)
            {
                project.Issues.Remove(issue);
                issue.IsDeleted = true;
                db.SaveChangesAsync();
            }

            return Ok("Deleted");
        }
    }
}
