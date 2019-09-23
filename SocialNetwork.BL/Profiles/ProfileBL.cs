using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SocialNetwork.DAL.Entities;
using SocialNetwork.BL.ModelBO;

namespace SocialNetwork.BL.Profiles
{
    class ProfileBL: Profile
    {
        ProfileBL()
        {
            this.CreateMap<Friends, FriendsBO>().ReverseMap();
            this.CreateMap<Users, UsersBO>().ReverseMap();
        }
    }
}
