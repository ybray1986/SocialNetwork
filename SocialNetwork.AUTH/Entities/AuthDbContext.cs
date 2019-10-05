namespace SocialNetwork.AUTH.Entities
{
    using System;
    using System.Data.Entity;

    public partial class AuthDbContext : DbContext
    {
        public AuthDbContext()
            : base("name=AuthDbContext")
        {
        }
        public AuthDbContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(m =>
                {
                    m.ToTable("UserRoles");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                });
        }
        public class DbContextInitializer : DropCreateDatabaseAlways<AuthDbContext>
        {
            protected override void Seed(AuthDbContext context)
            {
                base.Seed(context);
            }
        }
    }
}
