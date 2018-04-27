using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> List { get; }
        void Attach(object entity);
        void SetObjectState(object entity, EntityState state);
        void SaveChanges();
    }
}
