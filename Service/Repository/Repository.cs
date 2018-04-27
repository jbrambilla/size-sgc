using Domain.Context;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Repository
{
    public class Repository<T> : BaseRepository, IRepository<T> where T : class
    {
        private DbSet<T> _entities;

        public Repository(BackendContext context) : base(context) { }

        private DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = Context.Set<T>();
                }
                return _entities;
            }
        }

        public T GetById(object id)
        {
            var entity = Entities.Find(id);

            return entity;
        }

        public virtual void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Entities.Add(entity);
        }

        public virtual void Insert(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entity");

            Context.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Context.Entry(entity).State = EntityState.Deleted;
        }

        public IQueryable<T> List
        {
            get { return this.Entities; }
        }

        public void Attach(object entity)
        {
            if (entity != null)
                Context.Entry(entity).State = EntityState.Unchanged;
        }

        public void SetObjectState(object entity, EntityState state)
        {
            if (entity != null)
                Context.Entry(entity).State = state;
        }

        public void SaveChanges()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception dbEx)
            {
                throw dbEx;
            }
        }
    }
}
