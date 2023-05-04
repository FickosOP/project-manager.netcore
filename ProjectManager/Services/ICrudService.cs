using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Services
{
    public interface ICrudService<T> where T : IEntity
    {
        public T FindById(Guid id);
        public IEnumerable<T> FindAll();
        public IEnumerable<T> FindPage(int index, int count);
        public T Save(T entity);
        public T Edit(T entity);
        public void Delete(Guid id);
        public int GetPageCount(int pageSize);
    }
}
