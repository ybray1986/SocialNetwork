using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SocialNetwork.DAL.Entities;
using SocialNetwork.BL.ModelBO;
using System.Web.Mvc;
using SocialNetwork.WEB.ViewModels;

namespace SocialNetwork.WEB.Profiles
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            this.CreateMap<User, UserBO>().ConstructUsingServiceLocator();
            this.CreateMap<UserBO, UserViewModel>().ConstructUsingServiceLocator();
            this.CreateMap<UserViewModel, UserBO>().ConstructUsingServiceLocator();
            this.CreateMap<UserBO, User>().ConstructUsingServiceLocator();

            this.CreateMap<Relationship, RelationshipBO>().ConstructUsingServiceLocator();
            this.CreateMap<RelationshipBO, FriendsViewModel>().ConstructUsingServiceLocator();
            this.CreateMap<FriendsViewModel, RelationshipBO>().ConstructUsingServiceLocator();
            this.CreateMap<RelationshipBO, Relationship>().ConstructUsingServiceLocator();
        }
    }
}
