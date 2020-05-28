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
            if (result.Succeeded) // Add user to sample projects for demo purposes
            {
                var sampleNames = new List<string> { "Make a Cat Ramp", "Face Mask", "Pan Fry the Perfect Steak" };
                var samples = db.Project
                    .Include(project => project.UserProjects)
                .Where(project => sampleNames.Contains(project.Name))
                .ToList();

                samples.ForEach(project =>
                {
                    var role = project.UserProjects.Count() == 0 ? UserProjectRole.Owner : UserProjectRole.Contributor;
                    project.UserProjects.Add(new ApplicationUserProject { User = user, Project = project, Role = role });
                });
                await db.SaveChangesAsync();
            }
            return Page();
        }
    }
}
