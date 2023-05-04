using Microsoft.EntityFrameworkCore;
using ProjectManager.Contexts;
using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Repositories.Implementation
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly DatabaseContext Context;
        protected DbSet<T> Entities;

        public Repository(DatabaseContext context)
        {
            Context = context;
            Entities = context.Set<T>();
        }
        public void Delete(Guid id)
        {
            T entity = FindById(id);
            if (entity != null)
            {
                entity.IsActive = false;
                Context.SaveChanges();
            }
        }

        public virtual T Edit(T entity)
        {
            T existing = FindById(entity.Id);
            if(existing != null)
            {
                Context.Entry(existing).CurrentValues.SetValues(entity);
                Context.SaveChanges();
                return entity;
            }
            return null;
        }

        public IEnumerable<T> FindAll()
        {
            return Entities.Where(e => e.IsActive).AsEnumerable();
        }

        public virtual T FindById(Guid id)
        {
            return FindAll().SingleOrDefault(item => item.Id == id);
        }

        public virtual IEnumerable<T> FindPage(int index, int count)
        {
            return Entities
                    .Where(e => e.IsActive)
                    .OrderBy(e => e.CreatedAt)
                    .Skip((index - 1) * count)
                    .Take(count)
                    .AsEnumerable();
        }

        public int GetPageCount(int pageSize)
        {
            int count = Entities.Where(e => e.IsActive).Count();
            int full = count / pageSize;
            if(count % pageSize > 0)
            {
                return full + 1;
            }
            return full;
        }

        public virtual T Save(T entity)
        {
            Entities.Add(entity);
            Context.SaveChanges();
            return entity;
        }
    }
}
