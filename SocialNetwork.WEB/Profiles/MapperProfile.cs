﻿using System;
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
            this.CreateMap<User, UserBO>();
            this.CreateMap<UserBO, UserViewModel>();
            this.CreateMap<UserViewModel, UserBO>();
            this.CreateMap<UserBO, User>();

            this.CreateMap<Relationship, RelationshipBO>();
            this.CreateMap<RelationshipBO, FriendsViewModel>();
            this.CreateMap<FriendsViewModel, RelationshipBO>();
            this.CreateMap<RelationshipBO, Relationship>();
        }
    }
}
