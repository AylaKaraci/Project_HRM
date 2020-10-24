using Microsoft.EntityFrameworkCore;
using Project_HRM.DATA.Contracts;
using Project_HRM.DATA.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Project_HRM.DATA.Implementation
{
    public class Repository<T> : IRepositoryBase<T> where T : class, new()
    {
        private readonly ProjectContext _ctx;
        internal DbSet<T> dbSet;

        #region Constructor
        public Repository(ProjectContext ctx)
        {
            _ctx = ctx;
            this.dbSet = _ctx.Set<T>(); //burada set edildi.
        }
        #endregion

        #region Methods
        //Add to T type entity (gelen tipte veriyi kayıt etmek için)
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
                query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) //arada boş karakter varsa sil
                {
                    query = query.Include(item);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
                query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) //arada boş karakter varsa sil
                {
                    query = query.Include(item);
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        } 
        #endregion
    }
}
