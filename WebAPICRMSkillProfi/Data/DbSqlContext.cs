using Microsoft.EntityFrameworkCore;

namespace WebAPICRMSkillProfi.Models
{
    public class DbSqlContext : DbContext
    {
        public DbSqlContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Messange> Messanges { get; set; }
        public DbSet<ProjectItem> Projects { get; set; }
        public DbSet<ServiceItem> Service { get; set; }
        public DbSet<BlogItem> Blogs { get; set; }
        public DbSet<MainItem> Mains { get; set; }
        public DbSet<ContactItem> Contacts { get; set; }
        public DbSet<LinkItem> Links { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder _optionBuild)
        {
            _optionBuild.UseSqlServer(@$"{Option.DBPATH}");
        }
    }
}
