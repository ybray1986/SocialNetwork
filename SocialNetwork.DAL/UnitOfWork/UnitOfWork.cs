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
        
        public void Save()
        {
            db.SaveChanges();
        }

        private Repository<Category> _categoryUOWRepository = null;
        public Repository<Category> CategoryUOWRepository => _categoryUOWRepository ?? new Repository<Category>(db);


        private Repository<Comment> _commentUOWRepository = null;
        public Repository<Comment> CommentUOWRepository => _commentUOWRepository ?? new Repository<Comment>(db);

        private Repository<Country> _countryUOWRepository = null;
        public Repository<Country> CountryUOWRepository => _countryUOWRepository ?? new Repository<Country>(db);

        private Repository<Post> _postUOWRepository = null;
        public Repository<Post> PostUOWRepository => _postUOWRepository ?? new Repository<Post>(db);

        private Repository<PostLike> _postLikeUOWRepository = null;
        public Repository<PostLike> PostLikeUOWRepository => _postLikeUOWRepository ?? new Repository<PostLike>(db);

        private Repository<Role> _roleUOWRepository = null;
        public Repository<Role> RoleUOWRepository => _roleUOWRepository ?? new Repository<Role>(db);

        private Repository<User> _userUOWRepository = null;
        public Repository<User> UserUOWRepository => _userUOWRepository ?? new Repository<User>(db);

        private Repository<UserFollower> _userFollowerUOWRepository = null;
        public Repository<UserFollower> UserFollowerUOWRepository => _userFollowerUOWRepository ?? new Repository<UserFollower>(db);

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
