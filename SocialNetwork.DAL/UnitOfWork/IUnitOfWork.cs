using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        Repository<Category> CategoryUOWRepository { get; }
        Repository<Comment> CommentUOWRepository { get; }
        Repository<Country> CountryUOWRepository { get; }
        Repository<Post> PostUOWRepository { get; }
        Repository<PostLike> PostLikeUOWRepository { get; }
        Repository<Role> RoleUOWRepository { get; }
        Repository<User> UserUOWRepository { get; }
        Repository<UserFollower> UserFollowerUOWRepository { get; }
        void Save();
    }
}
