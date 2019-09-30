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
        Repository<Relationship> FriendWoURepository { get; }
        Repository<User> UserWoURepository { get; }
    }
}
