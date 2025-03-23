using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Models;

namespace portofilioApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    public DbSet<UserProfileModel> UserProfiles { get; set; }
    public DbSet<ServiceModel> Services { get; set; }
    public DbSet<SkillsModel> Skills { get; set; }
    public DbSet<ExperienceModel> Experiences { get; set; }
    public DbSet<ProjectModel> Projects { get; set; }
    public DbSet<ContactInfoModel> ContactInfo { get; set; }
    public DbSet<SocialLinkModel> SocialLinks { get; set; }
    public DbSet<AboutMeModel> About { get; set; }
    public DbSet<ContactModel> Contacts { get; set; }

}
