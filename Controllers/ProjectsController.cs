using System;
using System.Collections.Generic;
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
    }
}
