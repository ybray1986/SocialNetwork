using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.WorkOfUnit
{
    interface IWorkOfUnit: IDisposable
    {
        Repository<Friends> FriendsWoURepository { get; }
        Repository<Users> UsersWoURepository { get; }
    }
}
