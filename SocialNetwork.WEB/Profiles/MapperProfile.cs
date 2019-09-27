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
            this.CreateMap<Users, UsersBO>().ConstructUsing(m => DependencyResolver.Current.GetService<UsersBO>());
            this.CreateMap<UsersBO, UserViewModel>().ConstructUsing(m => DependencyResolver.Current.GetService<UserViewModel>());
            this.CreateMap<UserViewModel, UsersBO>().ConstructUsing(m => DependencyResolver.Current.GetService<UsersBO>());
            this.CreateMap<UsersBO, Users>().ConstructUsing(m => DependencyResolver.Current.GetService<Users>());

            this.CreateMap<Relationship, FriendsBO>().ConstructUsing(m=> DependencyResolver.Current.GetService<FriendsBO>());
            this.CreateMap<FriendsBO, FriendsViewModel>().ConstructUsing(m => DependencyResolver.Current.GetService<FriendsViewModel>());
            this.CreateMap<FriendsViewModel, FriendsBO>().ConstructUsing(m => DependencyResolver.Current.GetService<FriendsBO>());
            this.CreateMap<FriendsBO, Relationship>().ConstructUsing(m => DependencyResolver.Current.GetService<Relationship>());
        }
    }
}
