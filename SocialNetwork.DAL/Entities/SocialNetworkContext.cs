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

        public virtual DbSet<Relationship> Relationship { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Message> Message { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public class DbContextInitializer : DropCreateDatabaseAlways<SocialNetworkContext>
        {
            protected override void Seed(SocialNetworkContext context)
            {
                context.Relationship.Add(new Entities.Relationship { Id = 1, FriendId = 2, UserId = 1 });
                context.User.Add(new Entities.User { Id = 1, FirstName = "John", LastName = "Doe", MiddleName = "", BirthDate = new DateTime(1999, 05, 10), Photo = @"~\SocialNetwork\SocialNetwork.DAL\Content\Photo\Users\default\default-user-icon.jpg", RegisteredDate = new DateTime(2019, 09, 20) });
                context.User.Add(new Entities.User { Id = 2, FirstName = "Max", LastName = "Payne", MiddleName = "", BirthDate = new DateTime(1998, 01, 20), Photo = @"~\SocialNetwork\SocialNetwork.DAL\Content\Photo\Users\default\default-user-icon.jpg", RegisteredDate = new DateTime(2019, 09, 20) });
                context.Message.Add(new Entities.Message { Id = 1, RelationshipId = 1, From = "John Doe", To = "Max Payne", SendTime = new DateTime(2019, 09, 21) });
                base.Seed(context);
            }
        }
    }
}
