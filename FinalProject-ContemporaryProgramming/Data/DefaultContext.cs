using FinalProject_ContemporaryProgramming.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject_ContemporaryProgramming.Data
{
    public class DefaultContext : DbContext
    {
        public DefaultContext() { }
        public DefaultContext(DbContextOptions<DefaultContext> options)
            : base(options)
        {

        }

        public DbSet<Hobbies> Hobbies { get; set; }

        public DbSet<TeamMember> TeamMember { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hobbies>().HasData(
                new Hobbies { Id = 1, Name = "Reading", Description = "Engaging with written content for pleasure and knowledge.", HobbiesId = 1 },
                new Hobbies { Id = 2, Name = "Cooking", Description = "Preparing food for enjoyment and sustenance.", HobbiesId = 2 },
                new Hobbies { Id = 3, Name = "Traveling", Description = "Exploring new places and cultures for leisure.", HobbiesId = 3 }
            );
            modelBuilder.Entity<TeamMember>().HasData(
                new TeamMember { TeamMemberId = 1, TeamMemberBirthdate = "2005-1-1", TeamMemberName = "Aneesh Palande", TeamMemberProgram = "Information Technology", TeamMemberYear = "Pre-Junior"},
                new TeamMember { TeamMemberId = 2, TeamMemberBirthdate = "2005-1-1", TeamMemberName = "Alex Lauffenberger", TeamMemberProgram = "CyberSecurity", TeamMemberYear="Pre-Junior" }
            );
        }
    }

}
