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
using System.Threading.Tasks;

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
        public virtual async Task<IActionResult> GetProjects()
        {
            var projects = await db.Project
                .Include(project => project.UserProjects)
                    .ThenInclude(link => link.User)
                .Select(project => mapper.Map<ProjectViewModel>(project)).ToListAsync();
            return new ObjectResult(projects);
        }

        [HttpPost]
        [Route("/api/projects")]
        public virtual async Task<IActionResult> CreateProject([FromBody] ProjectViewModel project)
        {
            db.Project.Add(mapper.Map<Project>(project));
            await db.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpGet]
        [Route("/api/projects/{projectId}")]
        public virtual async Task<IActionResult> GetProject([FromRoute][Required] int? projectId)
        {
            return new ObjectResult(mapper.Map<ProjectViewModel>(await db.Project.FindAsync(projectId)));
        }

        [HttpDelete]
        [Route("/api/projects/{projectId}")]
        public virtual async Task<IActionResult> DeleteProject([FromRoute][Required] int? projectId)
        {
            var project = db.Project.Find(projectId);
            project.IsDeleted = true;
            await db.SaveChangesAsync();
            return new ObjectResult(mapper.Map<ProjectViewModel>(project));
        }

        [HttpPatch]
        [Route("/api/projects/{projectId}")]
        public virtual async Task<IActionResult> UpdateProject([FromBody] ProjectViewModel patch, [FromRoute][Required] int? projectId)
        {
            var project = await db.Project.FindAsync(projectId);

            project.Name = patch.Name;
            project.Description = patch.Description;

            await db.SaveChangesAsync();
            return new ObjectResult(mapper.Map<ProjectViewModel>(project));
        }

        [HttpGet]
        [Route("/api/projects/{projectId}/users")]
        public virtual async Task<IActionResult> GetUsers([FromRoute][Required] int? projectId)
        {
            var project = await db.Project
                .Include(p => p.UserProjects)
                    .ThenInclude(link => link.User)
                .SingleOrDefaultAsync(p => p.Id == projectId);
            var users = project.UserProjects
                .Select(link => link.User);
            return new ObjectResult(users.Select(user => mapper.Map<UserViewModel>(user)));
        }

        [HttpPatch]
        [Route("/api/projects/{projectId}/users")]
        public virtual async Task<IActionResult> AddUser([FromBody] EmailViewModel email, [FromRoute][Required] int? projectId)
        {
            var project = await db.Project
                .Include(project => project.UserProjects)
                    .ThenInclude(link => link.User)
                .SingleOrDefaultAsync(project => project.Id == projectId);

            var user = await db.Users.Where(u => u.Email == email.Email).SingleOrDefaultAsync();

            if (!project.UserProjects.Any(link => link.User.Email == email.Email))
            {

                if (user != null)
                {
                    var link = new ApplicationUserProject
                    {
                        User = user,
                        Project = project,
                        Role = UserProjectRole.Contributor
                    };
                    project.UserProjects.Add(link);
                    await db.SaveChangesAsync();
                    return new ObjectResult(mapper.Map<UserViewModel>(user));
                }

            }

            return new ObjectResult(mapper.Map<UserViewModel>(new UserViewModel()));
        }

        [HttpDelete]
        [Route("/api/projects/{projectId}/users/{userId}")]
        public virtual async Task<IActionResult> RemoveUser([FromRoute][Required] int? projectId, [FromRoute][Required] string userId)
        {
            var project = await db.Project
                .Include(p => p.UserProjects)
                    .ThenInclude(link => link.User)
                .SingleOrDefaultAsync(p => p.Id == projectId);

            var user = project.UserProjects.SingleOrDefault(link => link.User.Id == userId);
            if (user != null)
            {
                project.UserProjects.Remove(user);
                await db.SaveChangesAsync();
            }

            return Ok("Removed");
        }

        [HttpGet]
        [Route("/api/projects/{projectId}/issues")]
        public virtual async Task<IActionResult> GetIssues([FromRoute][Required] int? projectId)
        {
            var project = await db.Project
                .Include(p => p.Issues)
                .SingleOrDefaultAsync(p => p.Id == projectId);
            var issues = project.Issues.Select(issue => mapper.Map<IssueViewModel>(issue));
            return new ObjectResult(issues);
        }

        [HttpPost]
        [Route("/api/projects/{projectId}/issues")]
        public virtual async Task<IActionResult> CreateIssue([FromBody] IssueViewModel issue, [FromRoute][Required] int? projectId)
        {
            var model = mapper.Map<Issue>(issue);
            var project = await db.Project
                .Include(p => p.Issues)
                .SingleOrDefaultAsync(p => p.Id == projectId);
            project.Issues.Add(model);
            await db.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpGet]
        [Route("/api/projects/{projectId}/issues/{issueId}")]
        public virtual async Task<IActionResult> GetIssue([FromRoute][Required] int? projectId, [FromRoute][Required] int? issueId)
        {
            var project = await db.Project
                .Include(p => p.Issues)
                .SingleOrDefaultAsync(p => p.Id == projectId);
            var issue = project.Issues.SingleOrDefault(i => i.Id == issueId);
            return new ObjectResult(mapper.Map<IssueViewModel>(issue));
        }

        [HttpPatch]
        [Route("/api/projects/{projectId}/issues/{issueId}")]
        public virtual async Task<IActionResult> UpdateIssue([FromBody] IssueViewModel patch, [FromRoute][Required] int? projectId, [FromRoute][Required] int? issueId)
        {
            var model = mapper.Map<Issue>(patch);

            var project = await db.Project
                .Include(p => p.Issues)
                .SingleOrDefaultAsync(p => p.Id == projectId);
            var issue = project.Issues.SingleOrDefault(i => i.Id == issueId);

            issue.Summary = model.Summary;
            issue.Description = model.Description;
            issue.IssueType = model.IssueType;
            issue.Assignee = model.Assignee;
            issue.Storypoints = model.Storypoints;
            issue.Status = model.Status;
            issue.Priority = model.Priority;

            await db.SaveChangesAsync();

            return new ObjectResult(mapper.Map<IssueViewModel>(issue));
        }

        [HttpDelete]
        [Route("/api/projects/{projectId}/issues/{issueId}")]
        public virtual async Task<IActionResult> DeleteIssue([FromRoute][Required] int? projectId, [FromRoute][Required] int? issueId)
        {
            var project = await db.Project
                .Include(p => p.Issues)
                .SingleOrDefaultAsync(p => p.Id == projectId);
            var issue = project.Issues.SingleOrDefault(i => i.Id == issueId);
            if (issue != null)
            {
                project.Issues.Remove(issue);
                issue.IsDeleted = true;
                await db.SaveChangesAsync();
            }

            return Ok("Deleted");
        }
    }
}
