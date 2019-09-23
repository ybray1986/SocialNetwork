using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SocialNetwork.DAL.UnitOfWork;

namespace SocialNetwork.BL
{
    class BusinessObjectBase
    {
        IMapper mapper;
        UnitOfWork unitOfWork;
        BusinessObjectBase(IMapper mapperParam, UnitOfWork unitOfWorkParam)
        {
            mapper = mapperParam;
            unitOfWork = unitOfWorkParam;
        }
        //
    }
}
