namespace SocialNetwork.DAL.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SocialNetworkContext : DbContext
    {
        public SocialNetworkContext()
            : base("name=DbContext")
        {
        }
        public SocialNetworkContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Message> Messages { get; set; }

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
        public class DbContextInitializer : DropCreateDatabaseAlways<SocialNetworkContext>
        {
            protected override void Seed(SocialNetworkContext context)
            {
                context.AppRoles.Add(new AppRole { RoleId = 1, RoleName = "admin" });
                context.AppRoles.Add(new AppRole { RoleId = 2, RoleName = "user" });
                context.Relationships.Add(new Entities.Relationship { Id = 1, FriendId = 2, UserId = 1 });
                context.AppUsers.Add(new Entities.AppUser { UserId = 1, FirstName = "John", LastName = "Doe", MiddleName = "", BirthDate = new DateTime(1999, 05, 10), Photo = @"~\SocialNetwork\SocialNetwork.DAL\Content\Photo\Users\default\default-user-icon.jpg", RegisteredDate = new DateTime(2019, 09, 20) });
                context.AppUsers.Add(new Entities.AppUser { UserId = 2, FirstName = "Max", LastName = "Payne", MiddleName = "", BirthDate = new DateTime(1998, 01, 20), Photo = @"~\SocialNetwork\SocialNetwork.DAL\Content\Photo\Users\default\default-user-icon.jpg", RegisteredDate = new DateTime(2019, 09, 20) });
                context.Messages.Add(new Entities.Message { Id = 1, RelationshipId = 1, From = "John Doe", To = "Max Payne", SendTime = new DateTime(2019, 09, 21) });
                base.Seed(context);
            }
        }
    }
}
