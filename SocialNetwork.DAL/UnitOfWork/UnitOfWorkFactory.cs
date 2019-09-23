using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.UnitOfWork
{
    class UnitOfWorkFactory
    {
        void Create()
        {
            new UnitOfWork(new DbContext());
        }
    }
}
