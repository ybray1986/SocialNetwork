using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SocialNetwork.BL.ModelBO;
using System.Web.Mvc;
using SocialNetwork.WEB.ViewModels;
using SocialNetwork.DAL.Entities;

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

            this.CreateMap<Country, CountryBO>().ConstructUsingServiceLocator();
            this.CreateMap<CountryBO, CountryViewModel>().ConstructUsingServiceLocator();
            this.CreateMap<CountryViewModel, CountryBO>().ConstructUsingServiceLocator();
            this.CreateMap<CountryBO, Country>().ConstructUsingServiceLocator();

            this.CreateMap<Role, RoleBO>().ConstructUsingServiceLocator();
            this.CreateMap<RoleBO, RoleViewModel>().ConstructUsingServiceLocator();
            this.CreateMap<RoleViewModel, RoleBO>().ConstructUsingServiceLocator();
            this.CreateMap<RoleBO, Role>().ConstructUsingServiceLocator();

            this.CreateMap<Post, PostBO>().ConstructUsingServiceLocator();
            this.CreateMap<PostBO, PostViewModel>().ConstructUsingServiceLocator();
            this.CreateMap<PostViewModel, PostBO>().ConstructUsingServiceLocator();
            this.CreateMap<PostBO, Post>().ConstructUsingServiceLocator();

            this.CreateMap<Comment, CommentBO>().ConstructUsingServiceLocator();
            this.CreateMap<CommentBO, CommentViewModel>().ConstructUsingServiceLocator();
            this.CreateMap<CommentViewModel, CommentBO>().ConstructUsingServiceLocator();
            this.CreateMap<CommentBO, Comment>().ConstructUsingServiceLocator();

            this.CreateMap<Category, CategoryBO>().ConstructUsingServiceLocator();
            this.CreateMap<CategoryBO, CategoryViewModel>().ConstructUsingServiceLocator();
            this.CreateMap<CategoryViewModel, CategoryBO>().ConstructUsingServiceLocator();
            this.CreateMap<CategoryBO, Category>().ConstructUsingServiceLocator();
        }
    }
}
