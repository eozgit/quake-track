using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using IdentityServer4.EntityFramework.Options;
using QuakeTrack.Models;

namespace QuakeTrack.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Project> Project { get; set; }

        public DbSet<Issue> Issue { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUserProject>()
                .HasKey(c => new { c.UserId, c.ProjectId });

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(user => user.Issues)
                .WithOne(issue => issue.Assignee)
                .HasForeignKey(issue => issue.AssigneeId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Project>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<Issue>().HasQueryFilter(i => !i.IsDeleted);
        }
    }
}
