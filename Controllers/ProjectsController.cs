using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    }
}
