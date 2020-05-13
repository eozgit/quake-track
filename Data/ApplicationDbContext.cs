using QuakeTrack.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuakeTrack.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUserProject>()
                .HasKey(c => new { c.UserId, c.ProjectId });

            modelBuilder.Entity<IssueLink>()
                .HasKey(c => new { c.ObjectId, c.SubjectId });

            modelBuilder.Entity<Project>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<Issue>().HasQueryFilter(i => !i.IsDeleted);

            modelBuilder.Entity<IssueLink>()
                .HasOne(l => l.Subject)
                .WithMany(s => s.LinkedAsSubject)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
