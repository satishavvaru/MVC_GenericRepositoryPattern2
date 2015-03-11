using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_GenericRepositoryPattern2.Models;

namespace MVC_GenericRepositoryPattern2
{
    public class UnitOfWork : IDisposable
    {
        private ProtoEntities context = new ProtoEntities();
        private GenericRepository<User> userRepository;
        //private GenericRepository<Course> courseRepository;

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        #region Implementation for Dispose Method
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}