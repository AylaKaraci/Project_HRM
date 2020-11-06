using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Project_HRM.DATA.Contracts
{
    public interface IRepositoryBase<T> where T : class, new()  //new'lenebilir classlar
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null);

        T Get(int id);
        T Get(string id);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null);
        void Add(T entity);
        void Remove(T entity);
      
        void Remove(string id);
        void Update(T entity);

    }
}
