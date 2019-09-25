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
        public SocialNetworkContext(string connectionString): base(connectionString)
        {
        }

        public virtual DbSet<Friends> Friends { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public class DbContextInitializer : DropCreateDatabaseAlways<SocialNetworkContext>
        {
            protected override void Seed(SocialNetworkContext context)
            {
                context.Friends.Add(new Entities.Friends { Id = 1, FriendId = 2, UserId = 1 });
                context.Users.Add(new Entities.Users { Id = 1, FirstName = "John", LastName = "Doe", MiddleName = "", BirthDate = new DateTime(1999, 05, 10), Photo = @"~\SocialNetwork\SocialNetwork.DAL\Content\Photo\Users\default\default-user-icon.jpg", RegisteredDate = new DateTime(2019, 09, 20) });
                context.Users.Add(new Entities.Users { Id = 2, FirstName = "Max", LastName = "Payne", MiddleName = "", BirthDate = new DateTime(1998, 01, 20), Photo = @"~\SocialNetwork\SocialNetwork.DAL\Content\Photo\Users\default\default-user-icon.jpg", RegisteredDate = new DateTime(2019, 09, 20) });
                base.Seed(context);
            }
        }
    }
}
