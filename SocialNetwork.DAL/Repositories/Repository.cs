using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        SocialNetwork.DAL.Entities.DbContext db;
        DbSet<T> table;
        Repository()
        {
            db = new SocialNetwork.DAL.Entities.DbContext();
            table = db.Set<T>();
        }
        Repository(SocialNetwork.DAL.Entities.DbContext model)
        {
            this.db = model;
            table = db.Set<T>();
        }
        public void Add(T model)
        {
            table.Add(model);
        }

        public void Delete(int id)
        {
            T result = table.Find(id);
            table.Remove(result);
        }

        public void Update(T model)
        {
            db.Entry(model).State = EntityState.Modified;
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
