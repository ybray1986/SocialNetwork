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
            this.CreateMap<User, UserBO>().ConstructUsing(m => DependencyResolver.Current.GetService<UserBO>());
            this.CreateMap<UserBO, UserViewModel>().ConstructUsing(m => DependencyResolver.Current.GetService<UserViewModel>());
            this.CreateMap<UserViewModel, UserBO>().ConstructUsing(m => DependencyResolver.Current.GetService<UserBO>());
            this.CreateMap<UserBO, User>().ConstructUsing(m => DependencyResolver.Current.GetService<User>());

            this.CreateMap<Relationship, RelationshipBO>().ConstructUsing(m=> DependencyResolver.Current.GetService<RelationshipBO>());
            this.CreateMap<RelationshipBO, FriendsViewModel>().ConstructUsing(m => DependencyResolver.Current.GetService<FriendsViewModel>());
            this.CreateMap<FriendsViewModel, RelationshipBO>().ConstructUsing(m => DependencyResolver.Current.GetService<RelationshipBO>());
            this.CreateMap<RelationshipBO, Relationship>().ConstructUsing(m => DependencyResolver.Current.GetService<Relationship>());
        }
    }
}
