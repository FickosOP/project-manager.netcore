using ProjectManager.Exceptions;
using ProjectManager.Models;
using ProjectManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Services.Implementation
{
    public class CrudService<T> : ICrudService<T> where T : EntityBase
    {
        protected readonly IRepository<T> Repository;

        public CrudService(IRepository<T> repository)
        {
            Repository = repository;
        }
        public void Delete(Guid id)
        {
            Repository.Delete(id);
        }

        public T Edit(T entity)
        {
            if(entity is null || FindById(entity.Id) is null)
            {
                throw new IdNotExistingException<T>();
            }
            else
            {
                return Repository.Edit(entity);
            }
        }

        public virtual IEnumerable<T> FindAll()
        {
            return Repository.FindAll();
        }

        public T FindById(Guid id)
        {
            return Repository.FindById(id);
        }

        public IEnumerable<T> FindPage(int index, int count)
        {
            int validIndex = index < 1 ? 1 : index;
            int validCount = count < 1 ? 1 : count;
            return Repository.FindPage(validIndex, validCount);
        }

        public virtual T Save(T entity)
        {
            if(entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
            if(entity is null)
            {
                return null;
            }
            if(FindById(entity.Id) == null)
            {
                return Repository.Save(entity);
            }
            else
            {
                throw new IdExistingException<T>();
            }
        }
        public int GetPageCount(int pageSize)
        {
            return Repository.GetPageCount(pageSize);
        }
    }
}
