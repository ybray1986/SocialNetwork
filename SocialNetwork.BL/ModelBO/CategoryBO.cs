using AutoMapper;
using SocialNetwork.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BL.ModelBO
{
    public class CategoryBO:BusinessObjectBase
    {
        public int IdCategory { get; set; }
        public string CategoryName { get; set; }

        public CategoryBO(IMapper mapperParam, UnitOfWorkFactory unitOfWorkFactoryParam) : base(mapperParam, unitOfWorkFactoryParam)
        {
        }

        public void SaveBO()
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                AddEditBO(unitOfWork);
            }
        }

        private void AddEditBO(IUnitOfWork unitOfWork)
        {
            var category = mapper.Map<DAL.Entities.Category>(this);
            unitOfWork.CategoryUOWRepository.Add(category);
            unitOfWork.Save();
        }

        public void DeleteBO(int id)
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                unitOfWork.CategoryUOWRepository.Delete(id);
            }
        }
        public List<CategoryBO> CategoryBOList()
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.CategoryUOWRepository.GetAll().Select(item=>mapper.Map<CategoryBO>(item)).ToList();
            }
        }
    }
}
