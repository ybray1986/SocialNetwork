using AutoMapper;
using SocialNetwork.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BL.ModelBO
{
    public class UsersBO: BusinessObjectBase
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Photo { get; set; }
        public DateTime RegisteredDate { get; set; }

        public UsersBO(IMapper mapperParam, UnitOfWorkFactory unitOfWorkFactoryParam) : base(mapperParam, unitOfWorkFactoryParam) { }

        public List<UsersBO> GetListUsers()
        {
            List<UsersBO> users = new List<UsersBO>();
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                users = unitOfWork.UsersWoURepository.GetAll().Select(model => mapper.Map<UsersBO>(model)).ToList();
            }
            return users;
        }
    }
}
