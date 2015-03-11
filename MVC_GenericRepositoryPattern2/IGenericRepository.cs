using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_GenericRepositoryPattern2.Models;

namespace MVC_GenericRepositoryPattern2
{
    public interface IGenericRepository<TEntity> where TEntity : class, IDisposable
    {
        IEnumerable<TEntity> Get();

        TEntity GetByID(object Id);

        void Insert(TEntity entity);

        void Update(TEntity entityToUpdate);

        void Delete(object id);

        void Delete(TEntity entityToDelete);



    }
}
