using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SocialNetwork.DAL.UnitOfWork;

namespace SocialNetwork.BL
{
    public abstract class BusinessObjectBase
    {
        protected IMapper mapper;
        public BusinessObjectBase() { }
        public BusinessObjectBase(IMapper mapperParam)
        {
            mapper = mapperParam;
        }
    }
}
