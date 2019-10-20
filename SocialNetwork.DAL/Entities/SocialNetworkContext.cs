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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFollower> UserFollowers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public class DbContextInitializer : DropCreateDatabaseAlways<SocialNetworkContext>
        {
            protected override void Seed(SocialNetworkContext context)
            {
                context.Users.Add(new User() { UserName = "user1", UserPassword = "1234", DateBirth = new DateTime(1980, 12, 01), NotificationEmails = true, NotificationPostComments = true, NotificationPostLikers = true, FirstLogin = 1 });
                base.Seed(context);
            }
        }
    }
}
