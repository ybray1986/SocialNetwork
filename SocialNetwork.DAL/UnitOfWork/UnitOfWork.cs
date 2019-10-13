using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext db;
        public  UnitOfWork(DbContext dbParam)
        {
            db = dbParam;
        }
        Repository<Relationship> _relationshipWoURepository;
        public Repository<Relationship> FriendWoURepository
        {
            get
            {
                return (_relationshipWoURepository == null) ? new Repository<Relationship>(db) : _relationshipWoURepository;
            }
        }

        Repository<AppUser> _userWoURepository;
        public Repository<AppUser> UserWoURepository
        {
            get
            {
                return (_userWoURepository == null) ? new Repository<AppUser>(db) : _userWoURepository;
            }
        }

        Repository<AppRole> _roleWoURepository;
        public Repository<AppRole> RoleWoURepository => _roleWoURepository ?? new Repository<AppRole>(db);

        Repository<Message> _messageWoURepository;
        public Repository<Message> MessageWoURepository => _messageWoURepository ?? new Repository<Message>(db);

        public void Save()
        {
            db.SaveChanges();
        }
        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).
                    if (db != null)
                    {
                        db.Dispose();
                    }
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~WorkOfUnit() {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            GC.SuppressFinalize(this);
        }

        
        #endregion
    }
}
