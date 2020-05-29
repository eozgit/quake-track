using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using QuakeTrack.Data;
using QuakeTrack.Models;

namespace QuakeTrack.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext db;

        public ConfirmEmailModel(UserManager<ApplicationUser> userManager, ApplicationDbContext _db)
        {
            _userManager = userManager;
            db = _db;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            StatusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";
            if (result.Succeeded) // Add sample projects for demo purposes
            {
                var id = 0;
                if (db.Project.Any()) id = db.Project.Max(project => project.Id);

                CreateProject(user, ++id, SeedData.CreateProjectCatRamp());
                CreateProject(user, ++id, SeedData.CreateProjectFaceMask());
                CreateProject(user, ++id, SeedData.CreateProjectPerfectSteak());

                await db.SaveChangesAsync();
            }
            return Page();
        }

        private void CreateProject(ApplicationUser user, int id, Project project)
        {
            project.Name = $"{id}. {project.Name}";
            project.UserProjects = new List<ApplicationUserProject> {
                new ApplicationUserProject { User = user, Project = project, Role = UserProjectRole.Owner }
            };
            db.Project.Add(project);
        }
    }
}
